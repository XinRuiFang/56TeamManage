using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {

            if (Session["Name"] == null)
            {
                Response.Write("<script>alert('登陆超时！将返回主界面！');</script>");
                return View("~/views/Login/Index.cshtml");
            }
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userModel);       
            
                     
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Session["Name"] == null)
            {
                Response.Write("<script>alert('登陆超时！将返回主界面！');</script>");
                return View("~/views/Login/Index.cshtml");
            }
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userModel);
        }
        public ActionResult Back()
        {
            Session["Name"] = null;
            return View("~/views/Login/Index.cshtml");
        }
       
    }
}
