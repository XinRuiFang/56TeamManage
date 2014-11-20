using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace _56Team_manage.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {                     
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string userName = form["userName"];
            string userPassword = form["userPwd"];
            string vcode = form["vcode"];
            if (Session["vCode"].ToString () == vcode)
            {
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = userName;
                user.password = userPassword;
                if (BLL.GetDataBaseModel.GetModel(user) != null)
                {
                    if (BLL.LoginBLL.GetUserInformtion(user))
                    {
                        Session["Name"] = userName;
                        dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                        return View("~/views/Home/Index.cshtml", userModel);

                    }
                    else
                    {
                        Response.Write("<script>alert('用户名密码错误！');</script>");
                        return View();
                    }
                }
                else
                {
                    Response.Write("<script>alert('网络连接错误！');</script>");
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
