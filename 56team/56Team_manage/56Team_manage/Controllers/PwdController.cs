using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class PwdController : Controller
    {
        //
        // GET: /Pwd/

        public ActionResult Index()
        {
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            ViewBag.level = Others.CheckPwdLevel.CheckLevel(user);
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());            
            return View(userModel);
        }
        [HttpGet]
        public ActionResult ModifPwd()
        {
            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userS);
        }
        [HttpPost]
        public ActionResult ModifPwd(FormCollection form)
        {
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                string oldPwd = form["LastPwd"];
                string newPwd = form["NewPwd"];
                string newPwdSec = form["NewPwdSec"];
                if (newPwd == newPwdSec)
                {
                    Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                    if (user.password == oldPwd)
                    {
                        user.password = newPwd;
                        if (BLL.SetDataBaseModel.SetData(user))
                        {
                            Response.Write("<script>alert('修改成功！');</script>");
                            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                            Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                            ViewBag.level = Others.CheckPwdLevel.CheckLevel(userModel);
                            return View("Index", userS);
                        }
                        else
                        {
                            Response.Write("<script>alert('修改失败！');</script>");
                            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                            Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                            ViewBag.level = Others.CheckPwdLevel.CheckLevel(userModel);
                            return View("Index", userS);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('原密码错误！');</script>");
                        dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                        return View(userS);
                    }
                }
                else
                {
                    Response.Write("<script>alert('两次输入的密码不一致！');</script>");
                    dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                    return View(userS);
                }
               
            }
            else
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View(userS);
            }
            
        }
        [HttpGet]
        public ActionResult SettingPwdQuest()
        {
            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userS);
        }
        [HttpPost]
        public ActionResult SettingPwdQuest(FormCollection form)
        {
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                string selectQuest = form["select"].ToString();
                string answer = form["Pwdanswer"].ToString();
                if (answer != null && answer != "")
                {
                    Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                    user.user_psw_quest = selectQuest;
                    user.user_psw_answ = answer;
                    if (BLL.SetDataBaseModel.SetData(user))
                    {
                        Response.Write("<script>alert('设置成功！');</script>");
                        dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());                       
                        Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                        ViewBag.level = Others.CheckPwdLevel.CheckLevel(userModel);                  
                        return View("Index",userS);
                    }
                    else
                    {
                        Response.Write("<script>alert('设置失败！');</script>");
                        dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                        Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
                        ViewBag.level = Others.CheckPwdLevel.CheckLevel(userModel);    
                        return View("Index",userS);
                    }
                }
                else
                {
                    Response.Write("<script>alert('密码找回问题答案未填写！');</script>");
                    dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                    return View(userS);
                }
                
            }
            else
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View(userS);
            }
            
            
            
        }
    }
}
