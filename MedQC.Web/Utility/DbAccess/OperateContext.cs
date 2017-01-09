// ***********************************************************
// ���ݿ���ʻ���������֮���ݿ���������Ķ���
// ��ҪΪ֧�ֶ��̷߳���ͬһ��DataAccess��ʵ��������
// Creator:YangMingkun  Date:2011-12-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace MedQC.Web.Utility.DbAccess
{
    /// <summary>
    /// ���ݿ���������Ķ���
    /// </summary>
    internal class OperateContext : IDisposable
    {
        private DatabaseType m_dbType = DatabaseType.ORACLE;
        private DataProvider m_provider = DataProvider.OleDb;
        private string m_connString = null;

        private string m_identifier = null;

        private IDbTransaction m_transaction = null;
        private IDbConnection m_connection = null;
        private IDataReader m_dataReader = null;
        private bool m_needCommit = false;
        private short m_timeOut = 120;

        public string Identifier
        {
            get { return this.m_identifier; }
        }

        public short TimeOut
        {
            get { return this.m_timeOut; }
            set { this.m_timeOut = value; }
        }

        private bool m_clearPoolEnabled = true;
        /// <summary>
        /// ��ȡ�����õ�����ORA-12571����ʱ,
        /// �Ƿ�����ִ����ջ������Ӳ���
        /// </summary>
        public bool ClearPoolEnabled
        {
            get { return this.m_clearPoolEnabled; }
            set { this.m_clearPoolEnabled = value; }
        }

        public event EventHandler ConnectionClosed;
        protected virtual void OnConnectionClosed(EventArgs e)
        {
            if (this.ConnectionClosed != null)
                this.ConnectionClosed(this, e);
        }

        public OperateContext(string identifier
            , DatabaseType dbType, DataProvider provider, string connString)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException("identifier");
            this.m_identifier = identifier;
            this.m_dbType = dbType;
            this.m_provider = provider;
            this.m_connString = connString;
        }

        public override string ToString()
        {
            return this.m_identifier;
        }

        public void Dispose()
        {
            this.CloseConnnection(false);
            this.DisposeTransaction(true);
        }

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        public void OpenConnnection()
        {
            if (this.m_connection == null)
                this.m_connection = ProviderFactory.GetConnection(this.m_connString, this.m_provider);
            if (this.m_connection.State == ConnectionState.Open)
                return;
            try
            {
                this.m_needCommit = false;
                this.m_connection.Open();
            }
            catch (Exception ex)
            {
                this.CleanConnnectionPool();
                throw ex;
            }
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        /// <param name="bCheckTransaction">�Ƿ�����������ִ��</param>
        public void CloseConnnection(bool checkTransaction)
        {
            // �����������������У���ȡ���ر�
            if (checkTransaction && this.IsInTransaction())
                return;

            // �ر�DataReader
            if (this.m_dataReader != null)
            {
                if (!this.m_dataReader.IsClosed)
                    this.m_dataReader.Close();
                this.m_dataReader.Dispose();
                this.m_dataReader = null;
            }

            // �ر�Connection
            if (this.m_connection == null)
                return;
            if (this.m_connection.State != ConnectionState.Closed)
                this.m_connection.Close();
            this.m_connection.Dispose();
            this.m_connection = null;

            // δ���¹����ݿ�
            this.m_needCommit = false;
            this.OnConnectionClosed(EventArgs.Empty);
        }

        /// <summary>
        /// �������ӳ��еĸ��ֶ���
        /// </summary>
        public void CleanConnnectionPool()
        {
            if (this.m_connection == null)
                return;
            if (this.m_connection is OleDbConnection)
            {
                OleDbConnection.ReleaseObjectPool();
            }
            else if (this.m_connection is OdbcConnection)
            {
                OdbcConnection.ReleaseObjectPool();
            }
            else if (this.m_connection is SqlConnection)
            {
                SqlConnection.ClearPool((SqlConnection)this.m_connection);
            }
            if (this.m_connection is Oracle.DataAccess.Client.OracleConnection)
            {
                Oracle.DataAccess.Client.OracleConnection.ClearPool(
                    (Oracle.DataAccess.Client.OracleConnection)this.m_connection);
            }
            if (this.m_connection is System.Data.OracleClient.OracleConnection)
            {
                System.Data.OracleClient.OracleConnection.ClearPool(
                    (System.Data.OracleClient.OracleConnection)this.m_connection);
            }
        }

        /// <summary>
        /// ��ǰ�����ݿ�����Ƿ���һ��������
        /// </summary>
        /// <returns>bool</returns>
        private bool IsInTransaction()
        {
            return this.m_transaction == null ? false : true;
        }

        /// <summary>
        /// ��ʼ���ݿ�����
        /// </summary>
        /// <param name="isolationLevel">������뼶��</param>
        /// <returns>bool</returns>
        public bool BeginTransaction(IsolationLevel isolationLevel)
        {
            try
            {
                this.OpenConnnection();
                this.m_transaction = ProviderFactory.GetTransaction(ref this.m_connection, isolationLevel);
                this.m_needCommit = false;
                return true;
            }
            catch (Exception ex)
            {
                this.DisposeTransaction(true);
                LogManager.Instance.WriteLog("OperateContext.BeginTransaction", ex);
                return false;
            }
        }

        /// <summary>
        /// �ύ���ݿ�����
        /// </summary>
        /// <returns>bool</returns>
        public bool CommitTransaction()
        {
            return this.CommitTransaction(true);
        }

        /// <summary>
        /// �ύ���ݿ�����
        /// </summary>
        /// <param name="bCloseConnection">�Ƿ�ر�����</param>
        /// <returns>bool</returns>
        public bool CommitTransaction(bool closeConnection)
        {
            try
            {
                if (this.m_needCommit)
                    this.m_transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("OperateContext.CommitTransaction", ex);
                return false;
            }
            finally
            {
                this.DisposeTransaction(closeConnection);
            }
        }

        /// <summary>
        /// ��ֹ���ݿ�����
        /// </summary>
        public void AbortTransaction()
        {
            if (this.IsInTransaction())
            {
                try
                {
                    if (this.m_needCommit)//������¹�����
                        this.m_transaction.Rollback();
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("OperateContext.AbortTransaction", ex);
                }
                this.DisposeTransaction(true);
            }
        }

        /// <summary>
        /// �ͷ����ݿ������йض���
        /// </summary>
        /// <param name="bCloseConnection">�Ƿ�ر�����</param>
        private void DisposeTransaction(bool closeConnection)
        {
            if (this.m_transaction != null)
                this.m_transaction.Dispose();
            this.m_transaction = null;
            if (closeConnection)
                this.CloseConnnection(false);
            this.m_needCommit = false;
        }

        /// <summary>
        /// ׼�����ݿ����Ӻ�����
        /// </summary>
        /// <param name="sql">SQL�ַ���</param>
        /// <param name="cmdType">��������</param>
        /// <param name="parameterArray">�������</param>
        /// <param name="command">���ص����ݿ�����</param>
        public IDbCommand PrepareAll(string sql, CommandType type, DbParameter[] parameters)
        {
            IDbCommand command = ProviderFactory.GetCommand(sql
                , type, this.m_timeOut, parameters, this.m_provider);
            if (this.IsInTransaction())
            {
                command.Connection = this.m_connection;
                command.Transaction = this.m_transaction;
            }
            else
            {
                this.OpenConnnection();
                command.Connection = this.m_connection;
            }
            return command;
        }

        public int ExecuteNonQuery(string sql, CommandType cmdType)
        {
            DbParameter[] parameters = null;
            return this.ExecuteNonQuery(sql, cmdType, ref parameters);
        }

        public int ExecuteNonQuery(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepareAll(sql, cmdType, parameters);
                int nResult = cmd.ExecuteNonQuery();
                int nCount = cmd.Parameters.Count;
                for (int index = 0; index < nCount; index++)
                {
                    IDbDataParameter param = (IDbDataParameter)cmd.Parameters[index];
                    if (param.Direction == ParameterDirection.Output
                        || param.Direction == ParameterDirection.InputOutput)
                    {
                        parameters[index].Value = param.Value;
                    }
                }
                this.m_needCommit = true;
                return nResult;
            }
            catch (Exception ex)
            {
                this.GenericExceptionHandler(ex);
                return -1;
            }
            finally
            {
                this.CloseConnnection(true);
                if (cmd != null) cmd.Dispose();
            }
        }

        public IDataReader ExecuteReader(string sql, CommandType cmdType)
        {
            DbParameter[] parameters = null;
            return this.ExecuteReader(sql, cmdType, ref parameters);
        }

        public IDataReader ExecuteReader(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepareAll(sql, cmdType, parameters);
                this.m_dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return this.m_dataReader;
            }
            catch (Exception ex)
            {
                this.GenericExceptionHandler(ex);
                return null;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        public object ExecuteScalar(string sql, CommandType cmdType)
        {
            DbParameter[] parameters = null;
            return this.ExecuteScalar(sql, cmdType, ref parameters);
        }

        public object ExecuteScalar(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepareAll(sql, cmdType, parameters);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                this.GenericExceptionHandler(ex);
                return null;
            }
            finally
            {
                this.CloseConnnection(true);
                if (cmd != null) cmd.Dispose();
            }
        }

        public DataSet ExecuteDataSet(string sql, CommandType cmdType)
        {
            DbParameter[] parameters = null;
            return this.ExecuteDataSet(sql, cmdType, ref parameters);
        }

        public DataSet ExecuteDataSet(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            IDbDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            try
            {
                adapter = ProviderFactory.GetAdapter(this.m_provider);
                adapter.SelectCommand = this.PrepareAll(sql, cmdType, parameters);
                dataSet.Clear();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                this.GenericExceptionHandler(ex);
                return null;
            }
            finally
            {
                this.CloseConnnection(true);
                if (adapter != null)
                {
                    if (adapter.SelectCommand != null) adapter.SelectCommand.Dispose();
                    ((IDisposable)adapter).Dispose();
                }
            }
        }

        private void GenericExceptionHandler(Exception ex)
        {
            if (this.m_provider != DataProvider.ODPNET)
                throw ex;
            Oracle.DataAccess.Client.OracleException oracleException = ex as Oracle.DataAccess.Client.OracleException;
            if (oracleException == null)
                throw ex;

            int CONNECTION_INVALID = 12571;

            //��׽���������Ӷϵ��������ӳ��е�����ʧЧ�쳣��,������ջ������Ӳ���
            if (oracleException.Number == CONNECTION_INVALID && this.m_clearPoolEnabled)
                this.CleanConnnectionPool();
            throw oracleException;
        }
    }
}
