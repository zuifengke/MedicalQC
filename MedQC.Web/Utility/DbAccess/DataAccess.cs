// ***********************************************************
// 数据库访问基础方法类，主要对ADO.NET对象进行一次封装,
// 以及提供多数据库访问方法
// Creator:YangMingkun  Date:2009-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using System.Data;
using System.Threading;
using System.Collections.Generic;

namespace MedQC.Web.Utility.DbAccess
{
    public class DataAccess
    {
        private DatabaseType m_dbType = DatabaseType.ORACLE;
        private DataProvider m_provider = DataProvider.OleDb;
        private string m_connString = null;

        private Dictionary<string, OperateContext> m_contexts = null;
        private object m_objectLocker = null;

        /// <summary>
        /// 获取或设置连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return this.m_connString; }
            set { this.m_connString = value; }
        }

        /// <summary>
        /// 获取或设置数据提供者类型
        /// </summary>
        public DataProvider DataProvider
        {
            get { return this.m_provider; }
            set { this.m_provider = value; }
        }

        /// <summary>
        /// 获取或设置数据库类型
        /// </summary>
        public DatabaseType DatabaseType
        {
            get { return this.m_dbType; }
            set { this.m_dbType = value; }
        }

        private bool m_bClearPoolEnabled = true;
        /// <summary>
        /// 获取或设置当出现ORA-12571错误时,
        /// 是否允许执行清空缓存连接操作
        /// </summary>
        public bool ClearPoolEnabled
        {
            get { return this.m_bClearPoolEnabled; }
            set { this.m_bClearPoolEnabled = value; }
        }

        /// <summary>
        /// 获取当前数据库操作上下文
        /// </summary>
        private OperateContext CurrentContext
        {
            get
            {
                lock (this.m_objectLocker)
                { return this.GetCurrentContext(); }
            }
        }

        public DataAccess()
        {
            this.m_contexts = new Dictionary<string, OperateContext>();
            this.m_objectLocker = new object();
        }

        public override string ToString()
        {
            return string.Format("TYPE={0};PROVIDER={1};CONNECTION={2};"
                , this.m_dbType, this.m_provider, this.m_connString);
        }

        /// <summary>
        /// 获取当前数据库操作上下文
        /// </summary>
        /// <returns>OperateContext</returns>
        private OperateContext GetCurrentContext()
        {
            string szThreadID =
                Thread.CurrentThread.ManagedThreadId.ToString();
            OperateContext context = null;
            if (this.m_contexts.ContainsKey(szThreadID))
                context = this.m_contexts[szThreadID];
            if (context != null)
                return context;
            context = new OperateContext(szThreadID
                , this.m_dbType, this.m_provider, this.m_connString);
            context.ClearPoolEnabled = this.m_bClearPoolEnabled;
            this.m_contexts.Add(szThreadID, context);
            return context;
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenConnnection()
        {
            this.CurrentContext.OpenConnnection();
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="bCheckTransaction">是否检查事务正在执行</param>
        public void CloseConnnection(bool bCheckTransaction)
        {
            this.CurrentContext.CloseConnnection(bCheckTransaction);
        }

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        /// <returns>bool</returns>
        public bool BeginTransaction(IsolationLevel isolationLevel)
        {
            return this.CurrentContext.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// 提交数据库事务
        /// </summary>
        /// <returns>bool</returns>
        public bool CommitTransaction()
        {
            return this.CurrentContext.CommitTransaction(true);
        }

        /// <summary>
        /// 提交数据库事务
        /// </summary>
        /// <param name="bCloseConnection">是否关闭连接</param>
        /// <returns>bool</returns>
        public bool CommitTransaction(bool bCloseConnection)
        {
            return this.CurrentContext.CommitTransaction(bCloseConnection);
        }

        /// <summary>
        /// 中止数据库事务
        /// </summary>
        public void AbortTransaction()
        {
            this.CurrentContext.AbortTransaction();
        }

        #region"多数据库兼容性处理函数"
        /// <summary>
        /// 判断指定异常是否是唯一性索引约束异常
        /// </summary>
        /// <returns>是否</returns>
        public bool IsConstraintConflictExpception(Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.Message))
                return false;
            if (this.m_dbType == DatabaseType.ORACLE)
            {
                if (ex.Message.ToLower().Contains("ora-00001"))
                    return true;
            }
            else if (this.m_dbType == DatabaseType.SQLSERVER)
            {
                if (ex.Message.ToLower().Contains("2627"))
                    return true;
            }
            else if (this.m_dbType == DatabaseType.ACCESS)
            {
                if (ex.Message.ToLower().Contains("3022"))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取当前数据库系统时间SQL表达式
        /// </summary>
        /// <returns>系统时间SQL表达式</returns>
        public string GetSystemTimeSql()
        {
            if (this.m_dbType == DatabaseType.ORACLE)
                return string.Format("{0}", "SYSDATE");
            else if (this.m_dbType == DatabaseType.ACCESS)
                return string.Format("{0}", "NOW");
            else
                return string.Format("{0}", "CONVERT(VARCHAR(20), GETDATE(), 20)");
        }

        /// <summary>
        /// 获取SQL语句中时间字段格式
        /// </summary>
        /// <param name="time">日期时间对象</param>
        /// <returns>返回的SQL时间格式串</returns>
        public string GetSqlTimeFormat(DateTime time)
        {
            string value = time.ToString("yyyy-MM-dd HH:mm:ss");
            if (this.m_dbType == DatabaseType.ORACLE)
                return string.Format("TO_DATE('{0}' ,'YYYY-MM-DD HH24:MI:SS')", value);
            else
                return string.Format("'{0}'", value);
        }

        /// <summary>
        /// 获取SQL语句中时间字段格式
        /// </summary>
        /// <param name="time">可空的日期时间对象</param>
        /// <returns>返回的SQL时间格式串</returns>
        public string GetSqlTimeFormat(DateTime? time)
        {
            if (time == null)
                return "NULL";
            string value = time.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (this.m_dbType == DatabaseType.ORACLE)
                return string.Format("TO_DATE('{0}' ,'YYYY-MM-DD HH24:MI:SS')", value);
            else
                return string.Format("'{0}'", value);
        }

        /// <summary>
        /// 获取SQL语句动态参数名称
        /// </summary>
        /// <param name="szParamName">参数名</param>
        /// <returns>动态参数名称</returns>
        public string GetSqlParamName(string szParamName)
        {
            if (this.m_provider == DataProvider.OleDb || this.m_provider == DataProvider.Odbc)
                return "?";
            if (this.m_dbType == DatabaseType.ORACLE)
                return string.Format(":{0}", szParamName);
            else
                return string.Format("@{0}", szParamName);
        }
        #endregion

        public int ExecuteNonQuery(string sql)
        {
            return this.CurrentContext.ExecuteNonQuery(sql, CommandType.Text);
        }

        public int ExecuteNonQuery(string sql, CommandType cmdType)
        {
            return this.CurrentContext.ExecuteNonQuery(sql, cmdType);
        }

        public int ExecuteNonQuery(string sql, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteNonQuery(sql, CommandType.Text, ref parameters);
        }

        public int ExecuteNonQuery(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteNonQuery(sql, cmdType, ref parameters);
        }

        public IDataReader ExecuteReader(string sql)
        {
            return this.CurrentContext.ExecuteReader(sql, CommandType.Text);
        }

        public IDataReader ExecuteReader(string sql, CommandType cmdType)
        {
            return this.CurrentContext.ExecuteReader(sql, cmdType);
        }

        public IDataReader ExecuteReader(string sql, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteReader(sql, CommandType.Text, ref parameters);
        }

        public IDataReader ExecuteReader(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteReader(sql, cmdType, ref parameters);
        }

        public object ExecuteScalar(string sql)
        {
            return this.CurrentContext.ExecuteScalar(sql, CommandType.Text);
        }

        public object ExecuteScalar(string sql, CommandType cmdType)
        {
            return this.CurrentContext.ExecuteScalar(sql, cmdType);
        }

        public object ExecuteScalar(string sql, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteScalar(sql, CommandType.Text, ref parameters);
        }

        public object ExecuteScalar(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteScalar(sql, cmdType, ref parameters);
        }

        public DataSet ExecuteDataSet(string sql)
        {
            return this.CurrentContext.ExecuteDataSet(sql, CommandType.Text);
        }

        public DataSet ExecuteDataSet(string sql, CommandType cmdType)
        {
            return this.CurrentContext.ExecuteDataSet(sql, cmdType);
        }

        public DataSet ExecuteDataSet(string sql, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteDataSet(sql, CommandType.Text, ref parameters);
        }

        public DataSet ExecuteDataSet(string sql, CommandType cmdType, ref DbParameter[] parameters)
        {
            return this.CurrentContext.ExecuteDataSet(sql, cmdType, ref parameters);
        }
    }
}
