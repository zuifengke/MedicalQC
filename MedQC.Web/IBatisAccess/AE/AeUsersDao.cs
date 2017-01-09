
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class AeUsersDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.AESqlMapConfig;

        private static AeUsersDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static AeUsersDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new AeUsersDao();
                return AeUsersDao.m_Instance;
            }
        }
        /// <summary>
        /// 获取手术代码
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<AeUsers> GetAeUsers(AeUsers AeUsers)
        {
            var reValue =base.GetSqlMapper(databaseName).QueryForList<AeUsers>("GetAeUsers", AeUsers);
            logger.Debug("GetAeUsers:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
    }
}
