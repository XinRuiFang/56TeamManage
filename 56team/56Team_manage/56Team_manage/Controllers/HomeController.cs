using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace _56Team_manage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {                     
            return View();
        }
        [HttpPost]
        public string Index(FormCollection form)
        {
            string userName = form["userName"];
            string userPassword = form["userPwd"];
            string vcode = form["vcode"];
            if (Session["vCode"].ToString () == vcode)
            {
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = userName;
                user.password = userPassword;
                if (BLL.LoginBLL.GetUserInformtion(user))
                {
                    return "登陆成功！";
                }
                else
                {
                    return "登陆失败！";
                }
            }
            else
            {
                return "验证码错误";
            }
        }
       
       
    }
}
