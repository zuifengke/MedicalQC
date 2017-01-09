
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class SysUserDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.SysSqlMapConfig;

        private static SysUserDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SysUserDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SysUserDao();
                return SysUserDao.m_Instance;
            }
        }

        public IList<SysUser> LoadPageList(int pageIndex, int pageSize, SysUser SysUser)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize+1;
            int end = pageIndex * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("end", end);
            hashTable.Add("sysUser", SysUser);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.LoadPageList", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysUser>("SysConfig.SysUser.LoadPageList", hashTable);
            logger.Debug("LoadPageList:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(SysUser SysUser)
        {
            int totalCount = 0;
            Hashtable hashTable = new Hashtable();
            hashTable.Add("sysUser", SysUser);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.GetTotalCount", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForObject("SysConfig.SysUser.GetTotalCount", hashTable);
            totalCount = int.Parse(reValue.ToString());
            return totalCount;
        }
        public IList<SysUser> GetSysUsers(SysUser SysUser)
        {
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.GetSysUsers", SysUser);
            var reValue =base.GetSqlMapper(databaseName).QueryForList<SysUser>("SysConfig.SysUser.GetSysUsers", SysUser);
            logger.Debug("GetSysUsers:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        
        public SysUser QueryOne(int ID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ID", ID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.QueryOne", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysUser>("SysConfig.SysUser.QueryOne", hashTable);
            
            return (SysUser)reValue.FirstOrDefault();
        }
        public List<SysUser> GetChildNodes(int ParentID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ParentID", ParentID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.GetChildNodes", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysUser>("SysConfig.SysUser.GetChildNodes", hashTable);

            return reValue.ToList();
        }

        public bool Insert(SysUser SysUser)
        {
            try
            {
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysUser.Insert", SysUser);
                SysUser.ID = int.Parse(result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Update(SysUser SysUser)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.Update", SysUser);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysUser.Update", SysUser);
                
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }

        public bool ChangePassword(SysUser SysUser)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.ChangePassword", SysUser);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysUser.ChangePassword", SysUser);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool ResetPassword(SysUser SysUser)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.ResetPassword", SysUser);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysUser.ResetPassword", SysUser);

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
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.Delete", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysUser.Delete", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }

        public bool InsertUserRole(int userid,int roleid)
        {
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("userid", userid);
                hashTable.Add("roleid", roleid);
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysUser.InsertUserRole", hashTable);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool DeleteUserRole(int userid)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("userid", userid);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysUser.DeleteUserRole", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysUser.DeleteUserRole", hashTable);

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
