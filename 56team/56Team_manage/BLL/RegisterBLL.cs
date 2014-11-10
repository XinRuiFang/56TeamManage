using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RegisterBLL
    {
        public static bool NewRegister(Model.C56rms_user user)
        {
            if (DAL.User.InsertNewUser(user))
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
