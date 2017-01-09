// ***********************************************************
// 数据库访问层数据访问基类,本基类负责提供一些共享变量与方法.
// 用于防止重复实例化,提高效率
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using MedQC.Web.Utility.DbAccess;
using System;


namespace MedQC.Web.OleDbAccess
{
    public abstract class DBAccessBase
    {
        private MedQC.Web.Utility.DbAccess.DataAccess m_DbAccess = null;
        public DBAccessBase()
        {

        }
        /// <summary>
        /// 获取数据库访问对象实例
        /// </summary>
        protected MedQC.Web.Utility.DbAccess.DataAccess DataAccess
        {
            get
            {
                if (this.m_DbAccess == null)
                {
                    this.m_DbAccess = new MedQC.Web.Utility.DbAccess.DataAccess();
                    this.m_DbAccess.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["meddoc"].ToString();
                    this.m_DbAccess.ClearPoolEnabled = true;
                    this.m_DbAccess.DatabaseType = DatabaseType.ORACLE;
                    this.m_DbAccess.DataProvider = DataProvider.OleDb;
                }
                return this.m_DbAccess;
            }
        }

        
    }
}
