using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;


namespace _56Team_manage.Others
{
    public static class AnalysisModel
    {
        public static string GetGender(Model.C56rms_user user)
        {
            switch (user.user_gender)
            {
                case "0": return "女"; 
                case "1": return "男"; 
                default:
                    return "暂无信息";                   
            }          
        }
        public static string GetGrade(Model.C56rms_user user)
        {
            switch (user.user_grade)
            {
                case 1: return "一年级";
                case 2: return "二年级";
                case 3: return "三年级";
                case 4: return "四年级";
                case 5: return "五年级";
                case 6: return "其他";
                default:
                    return "暂无信息";
            }
        }
        public static string GetMajor(Model.C56rms_user user)
        {
            switch (user.user_major)
            {
                case 1: return "经济管理学院";
                case 2: return "外国语学院";
                case 3: return "理学院";
                case 4: return "软件学院";
                case 5: return "艺术学院";
                case 6: return "其他";
                default:
                    return "暂无信息";
            }
        }
        public static string GetLimit(Model.C56rms_user user)
        {
            switch (user.user_limit)
            {
                case 0: return "一般用户";
                case 1: return "组员";
                case 2: return "组长";
                case 3: return "管理员";
                default:
                    return "暂无信息";
            }
        }
        public static string GetDepartment(Model.C56rms_user user)
        {
            if (user.user_department != null && user.user_department.ToString() != "")
            {
                return user.user_department.ToString();
            }
            else
            {
                return "暂无信息";
            }
        }
        public static string GetRealname(Model.C56rms_user user)
        {
            if (user.user_realname != null && user.user_realname != "")
            {
                return user.user_realname;
            }
            else
            {
                return "暂无信息";
            }
        }
        public static string GetName(Model.C56rms_user user)
        {
            if (user.user_name != null && user.user_name != "")
            {
                return user.user_name;
            }
            else
            {
                return "用户名无效！";
            }
        }
        public static string GetTel(Model.C56rms_user user)
        {
            if (user.user_tel != null && user.user_tel.ToString() != "")
            {
                return user.user_tel.ToString();
            }
            else
            {
                return "暂无信息";
            }
        }
        public static string GetQq(Model.C56rms_user user)
        {
            if (user.user_qq != null && user.user_qq.ToString() != "")
            {
                return user.user_qq.ToString();
            }
            else
            {
                return "暂无信息";
            }
        }
        public static string GetMail(Model.C56rms_user user)
        {
            if (user.user_email != null && user.user_email != "")
            {
                return user.user_email;
            }
            else
            {
                return "暂无信息";
            }
        }
    }
}