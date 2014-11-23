using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _56Team_manage.Others
{
    public static class CheckModel
    {
        public static bool CheckModelIsNull(Model.C56rms_user user)
        {
            if (user.user_department != null && user.user_department.ToString() != "" && user.user_email != null && user.user_email != "" &&
                user.user_gender != null && user.user_gender != "" && user.user_grade != null && user.user_grade.ToString() != "" &&
                user.user_major != null && user.user_major.ToString() != "" && user.user_qq != null && user.user_qq.ToString() != "" &&
                user.user_realname != null && user.user_realname != "" && user.user_tel != null && user.user_tel.ToString() != "") 
            {
                return true;
            }
            return false;
        }
    }
}