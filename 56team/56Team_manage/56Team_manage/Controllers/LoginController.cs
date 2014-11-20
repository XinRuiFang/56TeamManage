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
        [HttpGet]
        public ActionResult PwdFind()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PwdFind(FormCollection form)
        {
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                string userName = form["userName"];
                if (userName != null && userName != "")
                {
                    if (BLL.GetDataBaseModel.GetModelBySession(userName) != null)
                    {
                        Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(userName);
                        if (user.user_psw_quest != "" && user.user_psw_quest != null)
                        {
                            Session["Name"] = userName;
                            ViewBag.Quest = user.user_psw_quest;
                            return View("PwdGet");
                        }
                        else
                        {
                            Response.Write("<script>alert('对不起，您没有设置密码提示问题，请联系管理员！');</script>");
                            return View();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('用户不存在！');</script>");
                        return View();
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('请输入用户名！');</script>");
                    return View();
                }
                
            }
            else
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                return View();
            }
        }
        [HttpGet]
        public ActionResult PwdGet()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult PwdGet(FormCollection form)
        {
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                string answer = form["answer"];
                if (answer != null && answer != "")
                {
                    Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                    if (user.user_psw_answ == answer)
                    {
                        return View("ModifPwd");
                    }
                    else
                    {
                        Response.Write("<script>alert('答案错误！');</script>");
                        return View("PwdFind");
                    }
                }
                else
                {
                    Response.Write("<script>alert('未填写答案！');</script>");
                    return View("PwdFind");
                }
                
            }
            else
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                return View("PwdFind");
            }
        }
        [HttpGet]
        public ActionResult ModifPwd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModifPwd(FormCollection form)
        {
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                string newPwd = form["NewPwd"];
                string newPwdSec = form["NewPwdSec"];
                if (newPwd == newPwdSec)
                {
                    Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                    user.password = newPwd;
                    if (BLL.SetDataBaseModel.SetData(user))
                    {
                        Response.Write("<script>alert('修改成功！');</script>");
                        return View("Index");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败！');</script>");
                        return View("Index");
                    }
                }
                else
                {
                    Response.Write("<script>alert('两次输入的密码不一致！');</script>");
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
