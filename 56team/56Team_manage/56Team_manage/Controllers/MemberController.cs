using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace _56Team_manage.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        [HttpGet]
        public ActionResult Index()
        {                      
            List<Model.C56rms_user> uList = BLL.MkTableForView.MkMemsTable();          
            return View(uList);       
        }
        public ActionResult SelectAllMems()
        {         
            return View("Index");
        }
        

    }
}
