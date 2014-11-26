using System;
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
            try
            {
                List<Model.C56rms_user> ulist = db.C56rms_user.Where(user).ToList();
                foreach (Model.C56rms_user aUser in ulist)
                {
                    auser = aUser;
                }
                return auser;
            }
            catch 
            {
                return null;
            }
            
        }
        public static bool InsertNewUser(Model.C56rms_user userModel)
        {
            db.C56rms_user.Add(userModel);
            try
            {
                return db.SaveChanges() == 1 ? true : false;
            }
            catch {
                return false;
            }
        }
        public static bool SetUserMessage(Model.C56rms_user user)
        {
            Model.C56rms_user userModel = db.C56rms_user.Where(u => u.user_name == user.user_name).FirstOrDefault();
            
                userModel.user_major = user.user_major;
                        
                userModel.user_qq = user.user_qq;
                       
                userModel.user_realname = user.user_realname;           
           
                userModel.user_tel = user.user_tel;
           
                userModel.user_grade = user.user_grade;
            
                userModel.user_gender = user.user_gender;
           
                userModel.user_email = user.user_email;
           
                userModel.user_department = user.user_department;
                                
            db.SaveChanges();
            return true;
        }
        public static bool SetUserLimit(Model.C56rms_user user)
        {
            Model.C56rms_user auser = db.C56rms_user.Where(u => u.user_name == user.user_name).FirstOrDefault();
            auser.grouppsIsTrue = 1;
            auser.user_limit = 1;
            return db.SaveChanges() == 1 ? true : false;
        }
        public static bool CheckUserName(string userName)
        {
            if (db.C56rms_user.Where(u => u.user_name == userName) != null)
            {
                return false;
            }
            return true;         
        }
    }
}
