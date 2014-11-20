using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56Team_manage.Others
{
    public static class GetRModelBySession
    {
        public static DynamicModel GetModelForView(string SessionName)
        {
            return CreateDynamic(BLL.LoginBLL.GetModel(SessionName));
        }
        private static DynamicModel CreateDynamic(Model.C56rms_user user)
        {
            DynamicModel RModel = new DynamicModel();
            RModel.Grade = Others.AnalysisModel.GetGrade(user);
            RModel.Major = Others.AnalysisModel.GetMajor(user);
            RModel.Limit = Others.AnalysisModel.GetLimit(user);
            RModel.Department = Others.AnalysisModel.GetDepartment(user);
            RModel.Realname = Others.AnalysisModel.GetRealname(user);
            RModel.Name = Others.AnalysisModel.GetName(user);
            RModel.Tel = Others.AnalysisModel.GetTel(user);
            RModel.Qq = Others.AnalysisModel.GetQq(user);
            RModel.Mail = Others.AnalysisModel.GetMail(user);
            return RModel;
        }
    }
    public class DynamicModel
    {
        public string Grade = null;
        public string Major = null;
        public string Limit = null;
        public string Department = null;
        public string Realname = null;
        public string Name = null;
        public string Tel = null;
        public string Qq = null;
        public string Mail = null;
    }
}