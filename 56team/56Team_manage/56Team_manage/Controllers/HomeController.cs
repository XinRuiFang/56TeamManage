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

            if (Session["id"] == null)
            {
                Response.Write("<script>alert('登陆超时！将返回主界面！');</script>");
                return View("~/views/Login/Index.cshtml");
            }

            return View();       
            
                     
        }

        [HttpGet]
        public ActionResult MessageChange()
        {
            return View();
        }
    }
}
