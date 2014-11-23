using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _56Team_manage.Others
{
    public static class TestForIntroduce
    {
        public static string GetIntroduce(int i)
        {
            switch (i)
            {
                case 0:
                    return "C#组介绍：主要学习C#语言与面向对象知识。学习.net FrameWork框架的使用以及Ado.net，Asp.net的使用";
                case 1:
                    return "Java组介绍:跟刘哥学Java，没什么好说的。";
                case 2:
                    return "UI组介绍:就那么回事。";
                case 3:
                    return "运维组介绍：和强哥混，没毛病。";
                case 4:
                    return "数据库组介绍：就是用来卖萌的。";
                default:
                    return "";
                    
            }
        }
    }
}