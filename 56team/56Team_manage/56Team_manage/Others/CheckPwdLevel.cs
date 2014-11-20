using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _56Team_manage.Others
{
    public static class CheckPwdLevel
    {
        public static string CheckLevel(Model.C56rms_user user)
        {
            if (CheckString(user.password))
            {
                //纯数字串
                if (user.user_psw_quest != null)
                {
                    return "中上";
                }
                else
                {
                    return "低";
                }
            }
            else
            {
                if (user.user_psw_quest != null)
                {
                    return "高";
                }
                else
                {
                    return "中";
                }
            }
        }
        private static bool CheckString(string password)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (rex.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }                
        }
    }
}