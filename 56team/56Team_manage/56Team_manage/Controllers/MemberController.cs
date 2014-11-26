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
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.MkMemsTable();          
            return View(uList);       
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (form["userName"] != null && form["userName"].ToString() != "") 
            {
                string user = form["userName"];
                List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetUserByRealName(user);
                return View(uList);
            }           
            List<Model.C56rms_user> aList = BLL.GetMsgTableBLL.MkMemsTable();
            return View(aList);
        }
        public ActionResult SelectAllMems()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.MkMemsTable();   
            return View("Index",uList);
        }
        public ActionResult SelectGroup()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(0);
            return View(uList);
        }
        #region 人员分组控制器 + ActionResult Get*()
        public ActionResult GetCSharp()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(0);
            return View("SelectGroup", uList);
        }
        public ActionResult GetJava()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(1);
            return View("SelectGroup", uList);
        }
        public ActionResult GetUI()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(2);
            return View("SelectGroup", uList);
        }
        public ActionResult GetIO()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(3);
            return View("SelectGroup", uList);
        }
        public ActionResult GetDb()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGroupList(4);
            return View("SelectGroup", uList);
        } 
        #endregion
        public ActionResult SelectGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(1);
            return View(uList);
        }
        #region 人员年级控制器 + ActionResult Get*Grade()
        public ActionResult GetOneGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(1);
            return View("SelectGrade", uList);
        }
        public ActionResult GetTwoGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(2);
            return View("SelectGrade", uList);
        }
        public ActionResult GetThreeGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(3);
            return View("SelectGrade", uList);
        }
        public ActionResult GetFourGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(4);
            return View("SelectGrade", uList);
        }
        public ActionResult GetFiveGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(5);
            return View("SelectGrade", uList);
        }
        public ActionResult GetOtherGrade()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetGradeList(6);
            return View("SelectGrade", uList);
        } 
        #endregion
        public ActionResult SelectMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(1);
            return View(uList);
        }
        #region 人员院系控制器 + ActionResult Get*Major()
        public ActionResult GetOneMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(1);
            return View("SelectMajor", uList);
        }
        public ActionResult GetTwoMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(2);
            return View("SelectMajor", uList);
        }
        public ActionResult GetThreeMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(3);
            return View("SelectMajor", uList);
        }
        public ActionResult GetFourMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(4);
            return View("SelectMajor", uList);
        }
        public ActionResult GetFiveMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(5);
            return View("SelectMajor", uList);
        }
        public ActionResult GetOtherMajor()
        {
            List<Model.C56rms_user> uList = BLL.GetMsgTableBLL.GetMajorList(6);
            return View("SelectMajor", uList);
        } 
        #endregion
       
    }
}
