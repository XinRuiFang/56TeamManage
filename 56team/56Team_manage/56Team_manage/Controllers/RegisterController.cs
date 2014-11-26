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
            if (userName.Length < 6 || userName.Length > 13)
            {
                Response.Write("<script>alert('用户名格式不符合标准，请输入6-13个字符！');</script>");
                return View();
            }
            string password = form["userPwd"];
            if (password.Length < 6 || password.Length > 20) 
            {
                Response.Write("<script>alert('密码格式不符合标准，请输入6-20个字符！');</script>");
                return View();
            }
            string passwordSconed = form["userPedSconed"];
            if (password != passwordSconed)
            {
                Response.Write("<script>alert('两次输入的密码不一致！');</script>");
                return View();
            }
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                if (!BLL.RegisterBLL.CheckUserName(userName))
                {
                    Response.Write("<script>alert('用户名已存在！');</script>");
                    return View();
                }
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = userName;
                user.password = password;
                user.user_limit = 0;
                if (BLL.RegisterBLL.NewRegister(user))
                {
                    Response.Write("<script>alert('注册成功！确认后进入主界面！');</script>");
                    Session["Name"] = userName;
                    dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                    return View("~/views/Home/Index.cshtml",userModel);
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
        public ActionResult TestUserName(FormCollection form)
        {
            string userName = form["userName"];
            if(userName != null && userName != "")
            {
                if (userName.Length >= 6 && userName.Length <= 13)
                {
                    if (BLL.GetDataBaseModel.GetModelBySession(userName) != null)
                    {
                        Response.Write("<script>alert('该用户名已被使用！');</script>");
                        return View("Index");
                    }
                    else
                    {
                        Response.Write("<script>alert('恭喜！该用户名可以使用！');</script>");
                        return View("Index");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请输入正确格式的用户名！');</script>");
                    return View("Index");
                }
            }
            else
            {
                Response.Write("<script>alert('请输入用户名！');</script>");
                return View("Index");
            }
            
        }
    }
}
