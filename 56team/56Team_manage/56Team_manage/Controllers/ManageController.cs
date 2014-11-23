using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/

        public ActionResult Index()
        {
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            if (user.user_limit != 3)
            {
                Response.Write("<script>alert('你不是管理员！');</script>");
                dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("~/views/Home/Index.cshtml", userModel);
            }
            return View();
        }
        public ActionResult InfoGroupPermit()
        {
            List<Model.C56rms_user> ulist = BLL.MkTableForView.GetPermitList();
            return View(ulist);
        }
        public ActionResult PassPermit(FormCollection form)
        {
            string userName = form["userName"].ToString();
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(userName);
            BLL.SetDataBaseModel.SetUserLimit(user);           
            List<Model.C56rms_user> ulist = BLL.MkTableForView.GetPermitList();
            return View("InfoGroupPermit", ulist);
        }

    }
}
