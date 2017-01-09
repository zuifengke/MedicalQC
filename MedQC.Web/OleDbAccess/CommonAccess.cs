// ***********************************************************
// ���ݿ���ʲ�ͨ�ò����йص����ݷ��ʽӿ�.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MedQC.Web.Utility.DbAccess;
using MedQC.Web.Utility;

namespace MedQC.Web.OleDbAccess
{
    public class CommonAccess : DBAccessBase
    {
        private static CommonAccess m_Instance = null;

        /// <summary>
        /// ��ȡϵͳ����������ʵ��
        /// </summary>
        public static CommonAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new CommonAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// ��ȡ���ݿ������ʱ��
        /// </summary>
        /// <param name="dtSysDate">���ݿ������ʱ��</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetServerTime(ref DateTime dtSysDate)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = null;
            if (base.DataAccess.DatabaseType == DatabaseType.SQLSERVER)
            {
                szSQL = string.Format(SystemData.SQL.SELECT, "CONVERT(VARCHAR(20), GETDATE(), 20)");
            }
            else if (base.DataAccess.DatabaseType == DatabaseType.ORACLE)
            {
                szSQL = string.Format(SystemData.SQL.SELECT_FROM, "SYSDATE", "DUAL");
            }
            else
            {
                dtSysDate = DateTime.Now;
                return SystemData.ReturnValue.OK;
            }
            object oRet = null;
            try
            {
                oRet = base.DataAccess.ExecuteScalar(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            try
            {
                dtSysDate = DateTime.Parse(oRet.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }
                    , string.Format("�޷�����{0}��ת��ΪDateTime!", oRet), ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// ִ��ָ����SQL����ѯ
        /// </summary>
        /// <param name="sql">��ѯ��SQL���</param>
        /// <param name="result">��ѯ���صĽ����</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short ExecuteQuery(string sql, out DataSet result)
        {
            result = null;
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            try
            {
                result = base.DataAccess.ExecuteDataSet(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.ExecuteQuery", new string[] { "sql" }, new object[] { sql }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// ִ��ָ����һϵ�е�SQL������
        /// </summary>
        /// <param name="isProc">�����SQL�Ƿ��Ǵ洢����</param>
        /// <param name="sqlArray">��ѯ��SQL��伯��</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short ExecuteUpdate(bool isProc, params string[] sqlarray)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.DataAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            if (sqlarray == null)
                sqlarray = new string[0];
            foreach (string sql in sqlarray)
            {
                try
                {
                    if (!isProc)
                        base.DataAccess.ExecuteNonQuery(sql, CommandType.Text);
                    else
                        base.DataAccess.ExecuteNonQuery(sql, CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    base.DataAccess.AbortTransaction();
                    LogManager.Instance.WriteLog("CommonAccess.ExecuteUpdate", new string[] { "sql" }, new object[] { sql }, ex);
                    return SystemData.ReturnValue.EXCEPTION;
                }
            }
            base.DataAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }
    }
}
