using Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAL
{
    public class Message
    {
        
        static Model.Entities db = new Entities();

        public static List<C56rms_user> GetMsgTable()
        {
            List<C56rms_user> uList = db.C56rms_user.Where(u => u.user_limit != 0).ToList();
            return uList;
        }
        public static bool SetUserPermit(C56rms_user user)
        {
            Model.C56rms_user auser = db.C56rms_user.Where(u => u.user_name == user.user_name).FirstOrDefault();          
            auser.user_group = user.user_group;
            auser.grouppsIsTrue = 0;
            return db.SaveChanges() == 1 ? true : false;
        }
        public static List<Model.C56rms_user> GetPermitList()
        {
            return db.C56rms_user.Where(u => u.user_group != null && u.grouppsIsTrue == 0).ToList();

        }
    }
}
