﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace DAL
{
    public class User
    {
        /// <summary>
        /// 创建EF上下文对象
        /// </summary>
        static Model.Entities db = new Entities();
        public static Model.C56rms_user Getuser(System.Linq.Expressions.Expression<Func<Model.C56rms_user,bool>> user)
        {
            
            Model.C56rms_user auser=null;
            List<Model.C56rms_user> ulist = db.C56rms_user.Where(user).ToList();
            foreach (Model.C56rms_user aUser in ulist)
            {
                auser= aUser;
            }
            return auser;
        }
        public static bool InsertNewUser(Model.C56rms_user userModel)
        {
            db.C56rms_user.Add(userModel);
            return db.SaveChanges() == 1 ? true : false;
        }
    }
}
