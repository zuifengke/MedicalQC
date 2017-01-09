using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;

namespace MedQC.Web.Services
{
    public class SysUserServices
    {
        /// <summary>
        /// 获取用户的角色名称
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static string GetRoleNames(int userid)
        {

            //获取用户及角色已授权的权限
            var roles = IBatisAccess.SysRoleDao.Instance.GetRolesByUserID(userid).ToList();
            string roleNames = string.Empty;
            foreach (var item in roles)
            {
                if (roleNames == string.Empty)
                    roleNames = item.Name;
                else
                    roleNames += "," + item.Name;
            }
            return roleNames;
        }
        /// <summary>
        /// 获取用户的角色ID
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static string GetRoleIDs(int userid)
        {

            //获取用户及角色已授权的权限
            var roles = IBatisAccess.SysRoleDao.Instance.GetRolesByUserID(userid).ToList();
            string roleIDs = string.Empty;
            foreach (var item in roles)
            {
                if (roleIDs == string.Empty)
                    roleIDs = item.ID.ToString();
                else
                    roleIDs += "," + item.ID.ToString();
            }
            return roleIDs;
        }
    }
}