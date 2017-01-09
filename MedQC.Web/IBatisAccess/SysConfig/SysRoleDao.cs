
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class SysRoleDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.SysSqlMapConfig;

        private static SysRoleDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SysRoleDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SysRoleDao();
                return SysRoleDao.m_Instance;
            }
        }

        public IList<SysRole> LoadPageList(int pageIndex, int pageSize, SysRole SysRole)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize+1;
            int end = pageIndex * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("end", end);
            hashTable.Add("sysRole", SysRole);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.LoadPageList", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysRole>("SysConfig.SysRole.LoadPageList", hashTable);
            logger.Debug("LoadPageList:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(SysRole SysRole)
        {
            int totalCount = 0;
            Hashtable hashTable = new Hashtable();
            hashTable.Add("sysRole", SysRole);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.GetTotalCount", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForObject("SysConfig.SysRole.GetTotalCount", hashTable);
            totalCount = int.Parse(reValue.ToString());
            return totalCount;
        }
        public IList<SysRole> GetSysRoles(SysRole SysRole)
        {
            var reValue =base.GetSqlMapper(databaseName).QueryForList<SysRole>("SysConfig.SysRole.GetSysRoles", SysRole);
            logger.Debug("GetSysRoles:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }

        public IList<SysRole> GetRolesByUserID(int UserID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("UserID", UserID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.GetRolesByUserID", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysRole>("SysConfig.SysRole.GetRolesByUserID", hashTable);

            return reValue;
        }
        public SysRole QueryOne(int ID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ID", ID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.QueryOne", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysRole>("SysConfig.SysRole.QueryOne", hashTable);
            
            return (SysRole)reValue.FirstOrDefault();
        }
        public List<SysRole> GetChildNodes(int ParentID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ParentID", ParentID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.GetChildNodes", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysRole>("SysConfig.SysRole.GetChildNodes", hashTable);

            return reValue.ToList();
        }

        public bool Insert(SysRole SysRole)
        {
            try
            {
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysRole.Insert", SysRole);
                SysRole.ID = int.Parse(result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Update(SysRole SysRole)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.Update", SysRole);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysRole.Update", SysRole);
                
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }

        public bool ResetPassword(SysRole SysRole)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.ResetPassword", SysRole);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysRole.ResetPassword", SysRole);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("ID", id);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysRole.Delete", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysRole.Delete", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }

    }
}
