
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class SysLogDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.SysSqlMapConfig;

        private static SysLogDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SysLogDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SysLogDao();
                return SysLogDao.m_Instance;
            }
        }

        public IList<SysLog> LoadPageList(int pageIndex, int pageSize, SysLog SysLog)
        {
            Hashtable hashTable = new Hashtable();
            int start = (pageIndex - 1) * pageSize+1;
            int end = pageIndex * pageSize;
            hashTable.Add("start", start);
            hashTable.Add("end", end);
            hashTable.Add("SysLog", SysLog);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysLog.LoadPageList", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysLog>("SysConfig.SysLog.LoadPageList", hashTable);
            logger.Debug("LoadPageList:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        public int GetTotalCount(SysLog SysLog)
        {
            int totalCount = 0;
            Hashtable hashTable = new Hashtable();
            hashTable.Add("SysLog", SysLog);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysLog.GetTotalCount", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForObject("SysConfig.SysLog.GetTotalCount", hashTable);
            totalCount = int.Parse(reValue.ToString());
            return totalCount;
        }
        public bool Delete(int id)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("ID", id);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysLog.Delete", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysLog.Delete", hashTable);

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
