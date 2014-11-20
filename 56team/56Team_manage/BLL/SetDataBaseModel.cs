using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SetDataBaseModel
    {
        public static bool SetData(Model.C56rms_user user)
        {
            return DAL.User.SetUserMessage(user);

        }
        public static bool DeleteData(Model.C56rms_user user)
        {
            user.user_major = null;
            user.user_qq = null;
            user.user_realname = null;
            user.user_tel = null;
            user.user_grade = null;
            user.user_gender = null;
            user.user_email = null;
            user.user_department = null;
            return DAL.User.SetUserMessage(user);

        }
    }
}
