using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        public static bool GetUserInformtion(Model.C56rms_user user)
        {
            Model.C56rms_user getUser= DAL.User.Getuser(u=>u.user_name==user.user_name);
            if (getUser != null)
            {
                if (getUser.password == user.password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
