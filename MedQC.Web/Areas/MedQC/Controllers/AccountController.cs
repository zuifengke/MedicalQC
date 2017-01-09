using MedQC.Web.Models;
using MedQC.Web.IBatisAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedQC.Web.IBatisAccess.Meddoc;
using MedQC.Web.Models.Meddoc;

namespace MedQC.Web.Areas.MedQC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /MedQC/Account/

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
            AeUsers user = new AeUsers();
            user.UserName = form["account"].ToString();
            var result= AeUsersDao.Instance.GetAeUsers(user);
            UserRight userRight = new UserRight();
            var result2 = UserRightDao.Instance.GetUserRight(userRight);
            return Json(new
            {
                status = "1",
                message = "登录成功！"
            });
        }
    }
}
