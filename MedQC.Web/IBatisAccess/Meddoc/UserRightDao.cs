
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;
using MedQC.Web.Models.Meddoc;

namespace MedQC.Web.IBatisAccess.Meddoc
{
    public class UserRightDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.MeddocSqlMapConfig;

        private static UserRightDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static UserRightDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new UserRightDao();
                return UserRightDao.m_Instance;
            }
        }
        /// <summary>
        /// 获取手术代码
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IList<UserRight> GetUserRight(UserRight userRight)
        {
            var reValue =base.GetSqlMapper(databaseName).QueryForList<UserRight>("GetUserRight", userRight);
            logger.Debug("GetUserRight:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
    }
}
