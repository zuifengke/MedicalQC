
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class SysParameterDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.SysSqlMapConfig;

        private static SysParameterDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SysParameterDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SysParameterDao();
                return SysParameterDao.m_Instance;
            }
        }
        public IList<SysParameter> GetSysParameters(SysParameter SysParameter)
        {
            var reValue =base.GetSqlMapper(databaseName).QueryForList<SysParameter>("SysConfig.SysParameter.GetSysParameters", SysParameter);
            logger.Debug("GetSysParameters:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        
        public SysParameter QueryOne(int ID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ID", ID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.QueryOne", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysParameter>("SysConfig.SysParameter.QueryOne", hashTable);
            
            return (SysParameter)reValue.FirstOrDefault();
        }

        public SysParameter QueryOneByCode(string code)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("code", code);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.QueryOneByCode", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysParameter>("SysConfig.SysParameter.QueryOneByCode", hashTable);

            return (SysParameter)reValue.FirstOrDefault();
        }
        public List<SysParameter> GetChildNodesByCode(string Code)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("Code", Code);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.GetChildNodesByCode", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysParameter>("SysConfig.SysParameter.GetChildNodesByCode", hashTable);

            return reValue.ToList();
        }

        public bool Insert(SysParameter SysParameter)
        {
            try
            {
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysParameter.Insert", SysParameter);
                SysParameter.ID = int.Parse(result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return false;
            }
        }
        public bool Update(SysParameter SysParameter)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.Update", SysParameter);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysParameter.Update", SysParameter);
                
                return true;
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return false;
            }
        }

        public bool ModifyValue(string code,string value)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("code", code);
                hashTable.Add("value",value);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.ModifyValue", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysParameter.ModifyValue", hashTable);
                return true;
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("ID", id);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysParameter.Delete", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysParameter.Delete", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                GlobalMethod.log.Error(ex);
                return false;
            }
        }
        
    }
}
