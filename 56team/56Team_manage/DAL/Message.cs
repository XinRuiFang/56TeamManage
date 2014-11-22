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
    }
}
