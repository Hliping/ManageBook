using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using ManageBook.Modle;
using System.Data;

namespace ManageBook.DAL
{
    /// <summary>
    /// 类名：DALCommon
    /// 功能：提供各种公共使用的表的操作
    /// 详细：包括对公共使用的表的增、删、修、改、查表等操作
    /// 内容：包括CollegeInfo学院表、MajorInfo专业表、Course教材类型表、SchoolTerm学年学期表、StudentClass学生信息表
    /// </summary>
    public class DALCommon
    {
        public List<CollegeInfo> GetAllCollegeInfo() //获取学院信息的方法
        {
            CollegeInfo co;
            List<CollegeInfo> list = new List<CollegeInfo>();
            string sql = "select * from CollegeInfo";
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql))
            {
                while (sdr.Read())
                {
                    co = new CollegeInfo();
                    co.CollegeID = int.Parse(sdr["CollegeID"].ToString());
                    //co.CollegeSimple = sdr["CollegeSimple"].ToString();
                    co.CollegeName = sdr["CollegeName"].ToString();
                    list.Add(co);
                }
            }

            return list;
        }


        public List<MajorInfo> GetAllMajorInfo(int collegeID) //以学院编号获取专业信息的方法
        {
            MajorInfo major;
            List<MajorInfo> list = new List<MajorInfo>();
            string sql = "select * from MajorInfo where CollegeID=@CollegeID";
            SqlParameter[] parameter = { new SqlParameter("@CollegeID", SqlDbType.Int) };
            parameter[0].Value = collegeID;
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql, parameter))
            {
                while (sdr.Read())
                {
                    major = new MajorInfo();
                    major.MajorInfoID = int.Parse(sdr["MajorInfoID"].ToString());
                    major.MajorSimple = sdr["MajorSimple"].ToString();
                    list.Add(major);
                }
            }
            return list;
        }


        public List<StudentClass> GetAllStudentClass(int collegeID) //获取班级信息的方法
        {
            StudentClass student;
            List<StudentClass> list = new List<StudentClass>();
            string sql = "select * from StudentClass where CollegeID=@CollegeID";
            SqlParameter[] parameter = { new SqlParameter("@CollegeID", SqlDbType.Int) };
            parameter[0].Value = collegeID;
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql, parameter))
            {
                while (sdr.Read())
                {
                    student = new StudentClass();
                    student.StudentClassID = int.Parse(sdr["StudentClassID"].ToString());
                    student.ClassName = sdr["ClassName"].ToString();
                    list.Add(student);
                }
            }

            return list;
        }
        public List<SchoolTerm> GetAllSchoolTerm() //获取学年学期的方法
        {
            SchoolTerm school;
            List<SchoolTerm> list = new List<SchoolTerm>();
            string sql = "select * from SchoolTerm";
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql))
            {
                while (sdr.Read())
                {
                    school = new SchoolTerm();
                    school.SchoolTermID = int.Parse(sdr["SchoolTermID"].ToString());
                    school.TermName = sdr["TermName"].ToString();
                    list.Add(school);
                }

            }
            return list;
        }
        public List<Course> GetAllCourse() //获取教材类型的方法
        {
            Course course;
            List<Course> list = new List<Course>();
            string sql = "select * from Course";
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql))
            {
                while (sdr.Read())
                {
                    course = new Course();
                    course.CourseID = int.Parse(sdr["CourseID"].ToString());
                    course.CourseType = sdr["CourseType"].ToString();
                    list.Add(course);
                }
            }
            return list;
        }

        private int MajorInfoID;
        public int GetAllMajorInfo_Class(int StudentClassID) //以班级编号获取专业信息的方法
        {

            string sql = "select * from StudentClass where StudentClassID=@StudentClassID";
            SqlParameter[] parameter = { new SqlParameter("@StudentClassID", SqlDbType.Int) };
            parameter[0].Value = StudentClassID;
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql, parameter))
            {
                while (sdr.Read())
                {
                    MajorInfoID = int.Parse(sdr["MajorInfoID"].ToString());
                }
            }
            return MajorInfoID;
        }

        // public 
        public StudentClass GetAllCollegeInfo_Class(string ClassName)  //以班级名称获取学院信息和专业信息的方法
        {
            StudentClass student = new StudentClass(); 
            string sql = "select * from StudentClass where ClassName=@ClassName";
            SqlParameter[] parameter = { new SqlParameter("@ClassName", SqlDbType.VarChar,50) };
            parameter[0].Value = ClassName;
            using (SqlDataReader sdr = DBHelpers.GetAllInfo(sql, parameter))
            {
                while (sdr.Read())
                {
                    student.CollegeID = int.Parse(sdr["CollegeID"].ToString());
                    student.MajorInfoID = int.Parse(sdr["MajorInfoID"].ToString());
                    student.StudentClassID = int.Parse(sdr["StudentClassID"].ToString());
                }
            }
            return student;
        }
    }
}
