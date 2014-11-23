using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class UserInGroupController : Controller
    {
        //
        // GET: /UserInGroup/
        [HttpGet]
        public ActionResult Index()
        {
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            if (user.user_limit != 0)
            {
                Response.Write("<script>alert('你已经是成员了！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/Home/Index.cshtml",userModel);
            }
            if (Others.CheckModel.CheckModelIsNull(user))
            {
                ViewBag.Test = Others.TestForIntroduce.GetIntroduce(0);
                Session["Group"] = 0;
                return View();
            }
            else
            {
                Response.Write("<script>alert('请先完善你的个人信息！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/PMessage/MessageChange.cshtml", userModel);
            }
            
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            if (user.user_limit != 0)
            {
                Response.Write("<script>alert('你已经是成员了！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/Home/Index.cshtml", userModel);
            }
            if (Others.CheckModel.CheckModelIsNull(user))
            {
                ViewBag.Test = Others.TestForIntroduce.GetIntroduce(0);
                Session["Group"] = 0;
                return View();
            }
            else
            {
                Response.Write("<script>alert('请先完善你的个人信息！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/PMessage/MessageChange.cshtml", userModel);
            }
        }
        public ActionResult GetJava()
        {
            ViewBag.Test = Others.TestForIntroduce.GetIntroduce(1);
            Session["Group"] = 1;
            return View("Index");
        }
        public ActionResult GetUI()
        {
            ViewBag.Test = Others.TestForIntroduce.GetIntroduce(2);
            Session["Group"] = 2;
            return View("Index");
        }
        public ActionResult GetIO()
        {
            ViewBag.Test = Others.TestForIntroduce.GetIntroduce(3);
            Session["Group"] = 3;
            return View("Index");
        }
        public ActionResult GetDb()
        {
            ViewBag.Test = Others.TestForIntroduce.GetIntroduce(4);
            Session["Group"] = 4;
            return View("Index");
        }
        public ActionResult GetSubmit()
        {
            int group = int.Parse(Session["Group"].ToString());
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            user.user_group = group;
            if (BLL.SetDataBaseModel.SetPermit(user))
            {
                Response.Write("<script>alert('进组申请已经成功提交给管理员，请等待审核！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/Home/Index.cshtml", userModel);
            }
            else
            {
                Response.Write("<script>alert('进组申请提交失败，请重试！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/Home/Index.cshtml", userModel);
            }
        }
    }
}
