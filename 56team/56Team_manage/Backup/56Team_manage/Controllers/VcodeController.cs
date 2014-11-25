using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class VcodeController : Controller
    {
        //
        // GET: /Vcode/

        public ActionResult getVcode()
        {
            byte[] vcode = CAPTCHA.GetCAPTCHA();
            return File(vcode, "image/jpeg");
        }

    }
}
