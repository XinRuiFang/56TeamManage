using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Model;
using System.Web.UI.HtmlControls;

namespace BLL
{
    public static class GetMsgTableBLL
    {
        public static List<C56rms_user> MkMemsTable()
        {
            return DAL.Message.GetMsgTable();
            //HtmlTable hTb = new HtmlTable();
            //HtmlTableRow rowHTML = new HtmlTableRow();
            //HtmlTableCell cellHTML = new HtmlTableCell();
            //cellHTML.InnerText="编号";
            //rowHTML.Cells.Add(cellHTML);
            //cellHTML.InnerText="姓名";
            //rowHTML.Cells.Add(cellHTML);
            //cellHTML.InnerText="性别";
            //rowHTML.Cells.Add(cellHTML);
            //cellHTML.InnerText="院系";
            //rowHTML.Cells.Add(cellHTML);
            //cellHTML.InnerText="年级";
            //rowHTML.Cells.Add(cellHTML);
            //hTb.Controls.Add(rowHTML);
            ////foreach (C56rms_user user in uList)
            ////{
            ////    rowHTML = new HtmlTableRow();
            ////    rowHTML.Cells
            ////}
            //return hTb;
        }
        public static List<C56rms_user> GetPermitList()
        {
            return DAL.Message.GetPermitList();
        }
        public static List<C56rms_user> GetGroupList(int group)
        {
            return DAL.Message.GetGroupList(group);
        }
        public static List<C56rms_user> GetGradeList(int grade)
        {
            return DAL.Message.GetGradeList(grade);
        }
        public static List<C56rms_user> GetMajorList(int major)
        {
            return DAL.Message.GetMajorList(major);
        }
    }
}
