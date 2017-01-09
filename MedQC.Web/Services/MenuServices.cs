using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;

namespace MedQC.Web
{
    public class MenuServices
    {
        /// <summary>
        /// 获取用户的权限
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static List<Models.Menu> GetMenuByEmpID(int empid)
        {
            //获取用户及角色已授权的权限
            var menus = EnterRepository.GetRepositoryEnter().MenuRepository.GetMenuByEmpID(empid).ToList();
            return menus;
        }
    }
}