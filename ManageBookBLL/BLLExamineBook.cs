using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using ManageBook.Modle;
using ManageBook.DAL;

namespace ManageBook.BLL
{
    public class BLLExamineBook
    {
        private DALExamineBook dob = new DALExamineBook();
        public DataSet GetOrderBook( int Examine, int NoExamine)    //获取预定的结果
        {
           return  dob.GetOrderBook(Examine,NoExamine);
        }
        public DataSet GetSelectCollege(int CollegeID, string txtBookName) //根据学院编号和文本框的值查询
        {
            return dob.GetSelectCollege(CollegeID,txtBookName);
        }

        public void UpdateExamine(string isbn,int a)  //修改审核是否通过的方法
        {
            dob.UpdateExamine(isbn, a);
        }

        public void UpdateOrderBookRemark(string Remark, string isbn) //修改备注的方法
        {
            dob.UpdateOrderBookRemark(Remark, isbn);
        }
    }
}
