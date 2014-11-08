using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;


namespace _56Team_manage
{        
    /// <summary>
    /// 生成验证码类
    /// </summary>
    public static class CAPTCHA
    {
        static char[] captcha = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static Random ran = new Random();

        #region 生成验证码字符串 - string MakeRanStr()
        /// <summary>
        /// 生成验证码字符串
        /// </summary>
        /// <returns>返回验证码字符串</returns>
        static string MakeRanStr()
        {
            System.Text.StringBuilder sbCode = new System.Text.StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                sbCode.Append(captcha[ran.Next(captcha.Length)]);
            }
            return sbCode.ToString();
        }
        #endregion
         
        #region 生成验证码图片 - GDI - void MakeNewCaptcha(string code)
        /// <summary>
        /// 生成验证码图片 - GDI
        /// </summary>
        /// <param name="code">验证码字符串</param>
        static Image MakeNewCaptcha(string code)
        {
            Image img = new Bitmap(100, 35);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, img.Width - 1, img.Height - 1));
            g.DrawString(code, new Font("微软雅黑", 16), Brushes.Red, 0, 2);
            return img;
        }
        #endregion       

        #region 为验证码图片添加干扰点 - Image DrawGanRaoDian(Image img)
        /// <summary>
        /// 为验证码图片添加干扰点
        /// </summary>
        /// <param name="count"></param>
        /// <param name="g"></param>
        /// <param name="img"></param>
        static Image DrawGanRaoDian(Image img)
        {
            int count = 50;
            Graphics g = Graphics.FromImage(img);
            for (int i = 0; i < count; i++)
            {
                Point p1 = new Point(ran.Next(img.Width - 5), ran.Next(img.Height - 5));
                Point p2 = new Point(p1.X - ran.Next(10), p1.Y - ran.Next(10));
                g.DrawLine(Pens.Black, p1, p2);
            }
            return img;
        }
        #endregion

        #region 获取验证码图片方法 + byte[] GetCAPTCHA()
        /// <summary>
        /// 获取验证码图片方法
        /// </summary>
        /// <returns></returns>
        public static byte[] GetCAPTCHA()
        {
            string str = MakeRanStr();
            HttpContext.Current.Session["vCode"] = str; // 将字符串存入session
            Image img= DrawGanRaoDian(MakeNewCaptcha(str));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        #endregion
    }
}
    