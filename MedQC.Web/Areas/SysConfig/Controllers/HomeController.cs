﻿using MedQC.Web.Filters;
using MedQC.Web.IBatisAccess;
using MedQC.Web.Models;
using MedQC.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedQC.Web.Areas.SysConfig.Controllers
{
    [MyException]
    public class HomeController : Controller
    {
        //
        // GET: /SysConfig/Home/

        public ActionResult Index()
        {
            int id = WebCookieHelper.GetSysUserId();
            if (id == 0)
                return Redirect("/login.html");
            string url = Request.Url.AbsolutePath.ToString();
            var systems = SysMenuDao.Instance.GetSysMenus(null).Where(m => m.MenuType == "系统").ToList();
            ViewBag.sysmenu= systems.Where(m => m.Url == url).FirstOrDefault();
            ViewBag.systems = systems;
            ViewBag.name = WebCookieHelper.GetSysUserInfo(1);
            return View();
        }
        [HttpPost]
        public ActionResult GetMenus()
        {
            int parentid = int.Parse(Request.Form["parentid"].ToString());
            int userid = WebCookieHelper.GetSysUserId() ;
            string strJson = string.Empty;

            var menus = new List<SysMenu>();
            if (parentid != 0)
                menus = SysMenuDao.Instance.GetChildNodes(parentid, userid);
            else
                menus = SysMenuDao.Instance.GetSysMenus(null).ToList();
            if (menus.ToList().Count > 0)
            {
                strJson = JsonHelper.GetMenuJson(menus, parentid);
                strJson = "{" + strJson + "}";
            }
            else
                strJson = "\"menus\":[]";
            //string strJson = "[{\"id\":\"1\",\"text\":\"hello1\",\"checked\":\"true\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]},{\"id\":\"1\",\"text\":\"hello1\",\"state\":\"open\",\"children\":[{\"id\":\"2\",\"text\":\"hello2\",\"state\":\"open\"}]}]";

            return Content(strJson);

        }
    }
}
