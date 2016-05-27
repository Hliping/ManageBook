using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using ManageBook.Modle;
using System.Data;

namespace ManageBook.DAL
{
    public class DALPlanBook
    {
        public void InsertPlanBook(PlanBook plan) //添加教材预定
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {

                conn.Open();
                string sql1 = "insert into PlanBook values(@CourseID,@MajorInfoID,@CollegeID,@StudentClassID,@SchoolTermID,@CourseName,@BookName,@ISBN,@Author,@Publish,@Price,@YearMonth,@TeacherBookNum,@StudentBookNum,@BookTotalNum,'false',null)";
                SqlCommand scm = new SqlCommand(sql1, conn);
                scm.Parameters.AddWithValue("@CourseID", plan.CourseID);
                scm.Parameters.AddWithValue("@MajorInfoID", plan.MajorInfoID);
                scm.Parameters.AddWithValue("@CollegeID", plan.CollegeID);
                scm.Parameters.AddWithValue("@StudentClassID", plan.StudentClassID);
                scm.Parameters.AddWithValue("@SchoolTermID", plan.SchoolTermID);
                scm.Parameters.AddWithValue("@CourseName", plan.CourseName);
                scm.Parameters.AddWithValue("@BookName", plan.BookName);
                scm.Parameters.AddWithValue("@ISBN", plan.ISBN);
                scm.Parameters.AddWithValue("@Author", plan.Author);
                scm.Parameters.AddWithValue("@Publish", plan.Publish);
                scm.Parameters.AddWithValue("@Price", plan.Price);
                scm.Parameters.AddWithValue("@YearMonth", plan.YearMonth);
                scm.Parameters.AddWithValue("@TeacherBookNum", plan.TeacherBookNum);
                scm.Parameters.AddWithValue("@StudentBookNum", plan.StudentBookNum);
                scm.Parameters.AddWithValue("@BookTotalNum", plan.BookTotalNum);
                scm.ExecuteNonQuery();

                conn.Close();
            }
        }
        public DataSet ds;
        public DataSet PlanBookinfo()  //多表联合查询返回结果
        {
            SqlConnection conn = new SqlConnection(DBHelpers.Connection);
            conn.Open();
            string sql = "SELECT SchoolTerm.TermSimple as '学年学期', CollegeInfo.CollegeName as '学院名称',MajorInfo.MajorSimple as '专业简称',StudentClass.ClassName as '班级', Course.CourseType as '课程类型',PlanBook.CourseName as '课程名称',PlanBook.BookName as '教材名称', PlanBook.ISBN as 'ISBN码', PlanBook.Author as '作者', PlanBook.Publish as '出版社', PlanBook.Price as '价格', PlanBook.TeacherBookNum as '教师用书数', PlanBook.StudentBookNum as '学生用书数',PlanBook.BookTotalNum as '总共用书数' FROM PlanBook INNER JOIN Course ON PlanBook.CourseID = Course.CourseID INNER JOIN CollegeInfo ON PlanBook.CollegeID = CollegeInfo.CollegeID INNER JOIN MajorInfo ON PlanBook.MajorInfoID = MajorInfo.MajorInfoID INNER JOIN SchoolTerm ON PlanBook.SchoolTermID = SchoolTerm.SchoolTermID INNER JOIN StudentClass ON PlanBook.StudentClassID = StudentClass.StudentClassID";
            SqlCommand scm = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = scm;
            ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public void DeletePlanBook(string isbn)   //删除预定教材
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                conn.Open();
                string sql = "delete from PlanBook where ISBN=@ISBN";
                SqlCommand scm = new SqlCommand(sql, conn);
                scm.Parameters.AddWithValue("@ISBN", isbn);
                scm.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdatePlanBook(PlanBook plan, string isbn)   //删除预定教材
        {
            using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
            {
                conn.Open();
                string sql = "update PlanBook set CourseID=@CourseID,MajorInfoID=@MajorInfoID,CollegeID=@CollegeID,StudentClassID=@StudentClassID,SchoolTermID=@SchoolTermID,CourseName=@CourseName,BookName=@BookName,ISBN=@ISBN,Author=@Author,Publish=@Publish,Price=@Price,YearMonth=@YearMonth,TeacherBookNum=@TeacherBookNum,StudentBookNum=@StudentBookNum,BookTotalNum=@BookTotalNum where ISBN=@isb";
                SqlCommand scm = new SqlCommand(sql, conn);
                scm.Parameters.AddWithValue("@CourseID", plan.CourseID);
                scm.Parameters.AddWithValue("@MajorInfoID", plan.MajorInfoID);
                scm.Parameters.AddWithValue("@CollegeID", plan.CollegeID);
                scm.Parameters.AddWithValue("@StudentClassID", plan.StudentClassID);
                scm.Parameters.AddWithValue("@SchoolTermID", plan.SchoolTermID);
                scm.Parameters.AddWithValue("@CourseName", plan.CourseName);
                scm.Parameters.AddWithValue("@BookName", plan.BookName);
                scm.Parameters.AddWithValue("@ISBN", plan.ISBN);
                scm.Parameters.AddWithValue("@Author", plan.Author);
                scm.Parameters.AddWithValue("@Publish", plan.Publish);
                scm.Parameters.AddWithValue("@Price", plan.Price);
                scm.Parameters.AddWithValue("@YearMonth", plan.YearMonth);
                scm.Parameters.AddWithValue("@TeacherBookNum", plan.TeacherBookNum);
                scm.Parameters.AddWithValue("@StudentBookNum", plan.StudentBookNum);
                scm.Parameters.AddWithValue("@BookTotalNum", plan.BookTotalNum);
                scm.Parameters.AddWithValue("@isb", isbn);
                scm.ExecuteNonQuery();

            }
        }

        /*  public List<PlanBook> DelectPlanBook() 
          {  
              PlanBook plan;
              List<PlanBook> list = new List<PlanBook>();
              using (SqlConnection conn = new SqlConnection(DBHelpers.Connection))
              {
                  conn.Open();
                  string sql = "select * from PlanBook";//"SELECT SchoolTerm.TermSimple, StudentClass.ClassName, MajorInfo.MajorSimple, CollegeInfo.CollegeName,Course.CourseType,PlanBook.CourseName,PlanBook.BookName, PlanBook.ISBN, PlanBook.Author, PlanBook.Publish, PlanBook.Price, PlanBook.TeacherBookNum, PlanBook.StudentBookNum,PlanBook.BookTotalNum FROM PlanBook INNER JOIN Course ON PlanBook.CourseID = Course.CourseID INNER JOIN CollegeInfo ON PlanBook.CollegeID = CollegeInfo.CollegeID INNER JOIN MajorInfo ON PlanBook.MajorInfoID = MajorInfo.MajorInfoID INNER JOIN SchoolTerm ON PlanBook.SchoolTermID = SchoolTerm.SchoolTermID INNER JOIN StudentClass ON PlanBook.StudentClassID = StudentClass.StudentClassID";
                  SqlCommand scm=new SqlCommand(sql,conn);
                  using (SqlDataReader sdr = scm.ExecuteReader()) 
                  {
                      while (sdr.Read()) 
                      {
                          plan = new PlanBook();
                          plan.BookName = sdr["BookName"].ToString();
                          plan.Author = sdr["Author"].ToString();
                          plan.BookTotalNum = int.Parse(sdr["BookTotalNum"].ToString());
                          plan.CollegeID = int.Parse(sdr["CollegeID"].ToString());
                          plan.CourseID = int.Parse(sdr["CourseID"].ToString());
                          plan.CourseName = sdr["CourseName"].ToString();
                          plan.ISBN = sdr["ISBN"].ToString();
                          plan.MajorInfoID = int.Parse(sdr["MajorInfoID"].ToString());
                          plan.Price = float.Parse(sdr["Price"].ToString());
                          plan.Publish = sdr["Publish"].ToString();
                          plan.SchoolTermID = int.Parse(sdr["SchoolTermID"].ToString());
                          plan.StudentBookNum = int.Parse(sdr["StudentBookNum"].ToString());
                          plan.StudentClassID = int.Parse(sdr["StudentClassID"].ToString());
                          plan.TeacherBookNum = int.Parse(sdr["TeacherBookNum"].ToString());
                          list.Add(plan);
                      }
                  }
              }
              return list;
          }
         * */
    }
}
