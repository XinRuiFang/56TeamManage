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
                if (BLL.LoginBLL.GetUserInformtion(user))
                {
                    Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModel(user);
                    Session["id"] = userModel.user_id;
                    Session["Name"] = userModel.user_name;                                                                                 
                    
                    if (userModel.user_major != null)
                    {
                        Session["Major"] = userModel.user_major.ToString();
                    }
                    else
                    {
                        Session["Major"] = "无";
                    }
                    if (userModel.user_department != null)
                    {
                        Session["Department"] = userModel.user_department.ToString();
                    }
                    else
                    {
                        Session["Department"] = "无";
                    }
                    if (userModel.user_grade != null)
                    {
                        Session["Grade"] = userModel.user_grade;
                    }
                    else
                    {
                        Session["Grade"] = "无";
                    }
                    switch (userModel.user_limit)
                    {
                        case 0: Session["Limit"] = "一般用户"; return View("~/views/Home/Index.cshtml");
                        case 1: Session["Limit"] = "组员"; return View("~/views/Home/Index.cshtml");
                        case 2: Session["Limit"] = "组长"; return View("~/views/Home/Index.cshtml");
                        case 3: Session["Limit"] = "管理员"; return View("~/views/Home/Index.cshtml");
                        default: Session["Limit"] = "未知"; return View("~/views/Home/Index.cshtml");
                    }
                   
                }
                else
                {
                    Response.Write("<script>alert('登陆失败！');</script>");
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
