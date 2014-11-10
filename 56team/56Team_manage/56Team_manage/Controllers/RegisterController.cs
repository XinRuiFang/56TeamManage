using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string userName = form["userName"];
            string password = form["userPwd"];
            string passwordSconed = form["userPedSconed"];
            if (password != passwordSconed)
            {
                Response.Write("<script>alert('两次输入的密码不一致！');</script>");
                return View();
            }
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = userName;
                user.password = password;
                user.user_limit = 0;
                if (BLL.RegisterBLL.NewRegister(user))
                {
                    Response.Write("<script>alert('注册成功！确认后进入主界面！');</script>");
                    Session["Name"] = user.user_name;                
                    return View("~/views/Home/Index.cshtml");
                }
                else
                {
                    Response.Write("<script>alert('注册失败！');</script>");
                    return View();
                }

            }
            else 
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                return View();
            }
            
        }

    }
}
