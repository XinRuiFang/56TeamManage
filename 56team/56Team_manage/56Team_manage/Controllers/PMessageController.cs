using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Controllers
{
    public class PMessageController : Controller
    {
        //
        // GET: /PMessage/
        [HttpGet]
        public ActionResult PersonalMessage()
        {
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userModel);
        }
        [HttpPost]
        public ActionResult PersonalMessage(FormCollection form)
        {
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userModel);
        }
        [HttpGet]
        public ActionResult MessageChange()
        {
            dynamic userModel = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View(userModel);
        }

        [HttpPost]
        public ActionResult MessageChange(FormCollection form)
        {
            if (Session["Name"] == null)
            {
                Response.Write("<script>alert('登陆超时！将返回主界面！');</script>");
                return View("~/views/Login/Index.cshtml");
            }
            string vcode = form["vcode"];
            if (Session["vCode"].ToString() == vcode)
            {
                
                Model.C56rms_user user = new Model.C56rms_user();
                user.user_name = Session["Name"].ToString();
                Model.C56rms_user userModel = BLL.GetDataBaseModel.GetModel(user);
                //此处判断表单元素是否为null，是为了防御性编程，而实际中，这些表单元素是不大可能为null的
                //当用户在某一元素中没有输入数据时，默认保存的是""。
                if (form["userDepartment"] != null && form["userDepartment"] != "")
                {
                    userModel.user_department = int.Parse(form["userDepartment"]);
                }
                if (form["userMail"] != null && form["userMail"] != "")
                {
                    userModel.user_email = form["userMail"];
                }
                if (form["Gender"] != null && form["Gender"] != "")
                {
                    userModel.user_gender = form["Gender"];
                }
                if (form["Grade"] != null && form["Grade"] != "")
                {
                    userModel.user_grade = int.Parse(form["Grade"]);
                }
                if (form["Major"] != null && form["Major"] != "")
                {
                    userModel.user_major = int.Parse(form["Major"]);
                }
                if (form["userQq"] != null && form["userQq"] != "")
                {
                    userModel.user_qq = Convert.ToInt64(form["userQq"]);
                }
                if (form["userRealName"] != null && form["userRealName"] != "")
                {
                    userModel.user_realname = form["userRealName"];
                }
                if (form["userTel"] != null && form["userTel"] != "")
                {
                    userModel.user_tel = Convert.ToInt64(form["userTel"]);
                }
                if (BLL.SetDataBaseModel.SetData(userModel))
                {
                    Response.Write("<script>alert('修改成功！');</script>");
                    dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                    return View("PersonalMessage",userS);
                }
                else
                {
                    Response.Write("<script>alert('修改失败！');</script>");
                    dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                    return View("PersonalMessage", userS);
                }
            }
            else
            {
                Response.Write("<script>alert('验证码错误！');</script>");
                dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
                return View("MessageChange",userS);
            }

        }
        public ActionResult DeletePMessage()
        {
            Response.Write("<script>if(confirm('确定要删除你的全部信息？')){   window.location.href='Delete';  }</script>");
            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View("PersonalMessage", userS);
        }
        public ActionResult Delete()
        {
            Model.C56rms_user user = BLL.GetDataBaseModel.GetModelBySession(Session["Name"].ToString());
            if (BLL.SetDataBaseModel.DeleteData(user))
            {
                Response.Write("<script>alert('删除成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败！');</script>");
            }
            dynamic userS = Others.GetRModelBySession.GetModelForView(Session["Name"].ToString());
            return View("PersonalMessage", userS);
        }
    }
}
