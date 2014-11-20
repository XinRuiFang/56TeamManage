using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class GetDataBaseModel
    {
        public static Model.C56rms_user GetModel(Model.C56rms_user user)
        {
            return  DAL.User.Getuser(u => u.user_name == user.user_name);
        }
        public static Model.C56rms_user GetModelBySession(string userName)
        {
            return DAL.User.Getuser(u => u.user_name == userName);
        }
    }
}
