using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(FormCollection form)
        {
            string userName = form["userName"];
            string password = form["userPwd"];
            string passwordSconed = form["userPedSconed"];
            if (password != passwordSconed)
            {
                return "两次输入的密码不一致！";
            }
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = userName;
                user.password = password;
                if (BLL.RegisterBLL.NewRegister(user))
                {
                    return "注册成功！";
                }
                else
                {
                    return "注册失败！";
                }

            }
            else 
            {
                return "验证码输入错误！";
            }
            
        }

    }
}
