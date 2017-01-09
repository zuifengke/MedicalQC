using MedQC.Web.Models;
using MedQC.Web.IBatisAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedQC.Web.IBatisAccess.Meddoc;
using MedQC.Web.Models.Meddoc;

namespace MedQC.Web.Areas.SysConfig.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /SysConfig/Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(FormCollection form)
        {
            string account = form["account"].ToString();
            string password = form["password"].ToString();
            SysUser user = new SysUser();
            user.LoginName = form["account"].ToString();
            var result = SysUserDao.Instance.GetSysUsers(user).FirstOrDefault();
            if (result == null)
            {
                return Json(new { status = "0", message = "用户名不存在" });
            }
            if (result.Password != Utility.MD5Helper.MD5(password))
            {
                return Json(new { status = "0", message = "密码不对" });
            }
            //写入cookies
            WebCookieHelper.SetSysUserCookie(result.ID, result.Name, result.LoginName, result.Tel, 15);
            GlobalMethod.log.Info(string.Format("{1}:{0}登录系统",result.Name,DateTime.Now.ToString()));
            return Json(new
            {
                status = "1",
                message = "登录成功！"
            });
        }
        public ActionResult ChangePwd()
        {
            string szPwdOld = Request.Form["pwdold"] != "" ? Request.Form["pwdold"] : "";
            string szPwdNew = Request.Form["pwdnew"] != "" ? Request.Form["pwdnew"] : "";
            string szPwdConfirm = Request.Form["pwdconfirm"] != "" ? Request.Form["pwdconfirm"] : "";
            int id = WebCookieHelper.GetSysUserId();
            var curUser = SysUserDao.Instance.QueryOne(id);
            string writeMsg = "更改失败！";
            if (curUser == null)
            {
                 writeMsg = "用户登录状态过期，请重新登录!";
                return Content(writeMsg);
            }
            if (curUser.Password != Utility.MD5Helper.MD5(szPwdOld))
            {
                writeMsg = "原始密码错误，无法更改密码！";
            }
            else
            {
                curUser.Password = Utility.MD5Helper.MD5(szPwdNew);
                bool result = SysUserDao.Instance.ChangePassword(curUser);
                if (result)
                {
                    writeMsg = "更改成功!";
                }
                else
                {
                    writeMsg = "更改失败!";
                }
            }
            return Content(writeMsg);
        }
    }
}
