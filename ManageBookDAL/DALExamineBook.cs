using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using ManageBook.Modle;

namespace ManageBook.DAL
{
    public class DALExamineBook
    {
        private DataSet date;
        public DataSet GetOrderBook(int Examine,int NoExamine)
        {
            SqlConnection conn = new SqlConnection(DBHelpers.Connection);
            conn.Open();
            SqlDataAdapter sda;
            StringBuilder sql = new StringBuilder("SELECT PlanBook.Examine as '审核通过', SchoolTerm.TermSimple as '学年学期', MajorInfo.MajorSimple as '专业',StudentClass.ClassName as '班级',PlanBook.CourseName as '课程名称', Course.CourseType as '课程类型',  PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '标价', PlanBook.TeacherBookNum as '教师用书数量', PlanBook.StudentBookNum as '学生用书数量', PlanBook.BookTotalNum as '总共教材数量', PlanBook.OrderBookRemark as '备注' FROM PlanBook INNER JOIN MajorInfo ON PlanBook.MajorInfoID = MajorInfo.MajorInfoID INNER JOIN SchoolTerm ON PlanBook.SchoolTermID = SchoolTerm.SchoolTermID INNER JOIN StudentClass ON PlanBook.StudentClassID = StudentClass.StudentClassID INNER JOIN Course ON PlanBook.CourseID = Course.CourseID where 1=1");
            if ( Examine == 1 && NoExamine == 0) 
            {
                sda = new SqlDataAdapter(sql.ToString(), conn);
            }
            else if (Examine == 1 && NoExamine == 1)
            {
                sql.Append(" and PlanBook.Examine='true'");
                sda = new SqlDataAdapter(sql.ToString(), conn);
            }
            else
            {
                sql.Append(" and PlanBook.Examine='false'");
                sda = new SqlDataAdapter(sql.ToString(), conn);
            }
            
            date = new DataSet();
            sda.Fill(date);
            conn.Close();
            return date;
        }
        public DataSet GetSelectCollege(int CollegeID,string txtBookName)  //根据学院编号获得数据和教材名称
        {
            SqlConnection conn = new SqlConnection(DBHelpers.Connection);
            conn.Open();
            StringBuilder sql = new StringBuilder("SELECT SchoolTerm.TermSimple as '学年学期', MajorInfo.MajorSimple as '专业',StudentClass.ClassName as '班级',PlanBook.CourseName as '课程名称', Course.CourseType as '课程类型',  PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '标价', PlanBook.TeacherBookNum as '教师用书数量', PlanBook.StudentBookNum as '学生用书数量', PlanBook.BookTotalNum as '总共教材数量', PlanBook.Examine as '审核通过', PlanBook.OrderBookRemark as '备注' FROM PlanBook INNER JOIN MajorInfo ON PlanBook.MajorInfoID = MajorInfo.MajorInfoID INNER JOIN SchoolTerm ON PlanBook.SchoolTermID = SchoolTerm.SchoolTermID INNER JOIN StudentClass ON PlanBook.StudentClassID = StudentClass.StudentClassID INNER JOIN Course ON PlanBook.CourseID = Course.CourseID where 1=1");
            SqlCommand scm = new SqlCommand();
            scm.Connection = conn;
            if (txtBookName == null && CollegeID!=-1)
            {
                sql.Append(" and PlanBook.CollegeID=@CollegeID");
                scm.Parameters.AddWithValue("@CollegeID", CollegeID);
            }
            else if (CollegeID == -1) 
            {
                sql.Append("  and PlanBook.BookName like @txtBookName");
                scm.Parameters.AddWithValue("@txtBookName",txtBookName);
            }
            else
            {
                sql.Append(" and PlanBook.CollegeID=@CollegeID and PlanBook.BookName like @txtBookName");
                scm.Parameters.AddWithValue("@CollegeID", CollegeID);
                scm.Parameters.AddWithValue("@txtBookName", txtBookName);
            }
            scm.CommandText = sql.ToString();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = scm;
            date = new DataSet();
            sda.Fill(date);
            conn.Close();
            return date;
        }

        public void UpdateExamine(string isbn, int a) 
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection)) 
            {
                conn.Open();
                SqlCommand scm = new SqlCommand();
                string sql="";
                scm.Connection = conn;
                if (a == 1)
                {
                    sql = "Update PlanBook set Examine='true' where ISBN=@ISBN";
                    scm.Parameters.AddWithValue("@ISBN", isbn);
                }else if(a == -1)
                {
                    sql = "Update PlanBook set Examine='false' where ISBN=@ISBN";
                    scm.Parameters.AddWithValue("@ISBN", isbn);
                }
                scm.CommandText = sql;
                scm.ExecuteNonQuery();
            }
            
        }
        public void UpdateOrderBookRemark(string Remark,string isbn)
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                conn.Open();
                string sql = "Update PlanBook set OrderBookRemark=@OrderBookRemark where ISBN=@ISBN";
                SqlCommand scm = new SqlCommand();
                
                scm.Connection = conn;
                scm.CommandText = sql;

                scm.Parameters.AddWithValue("@OrderBookRemark",Remark);
                scm.Parameters.AddWithValue("@ISBN",isbn);

                scm.ExecuteNonQuery();
            }
        }
    }
}
