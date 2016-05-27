using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ManageBook.DAL;
using ManageBook.Modle;

namespace ManageBook.BLL
{
    /// <summary>
    /// 类名：BLLCommon
    /// 功能：DALCommon的业务逻辑层
    /// 内容详细：包括增添、删除、修改、查询等等方法
    /// </summary>
    public class BLLCommon
    {
        private DALCommon common = new DALCommon();
        public List<CollegeInfo> GetAllCollegeInfo() //获取学院信息的方法
        {
            return common.GetAllCollegeInfo();
        }

        public List<MajorInfo> GetAllMajorInfo(int collegeID) //获取专业信息的方法
        {
            return common.GetAllMajorInfo(collegeID);
        }

        public List<StudentClass> GetAllStudentClass(int collegeID) //获取班级信息的方法
        {
            return common.GetAllStudentClass(collegeID);
        }

        public List<SchoolTerm> GetAllSchoolTerm() //获取学年学期的方法
        {
            return common.GetAllSchoolTerm();
        }

        public List<Course> GetAllCourse() //获取教材类型的方法
        {
            return common.GetAllCourse();
        }

        public StudentClass GetAllCollegeInfo_Class(string ClassName)  //以班级名称获取学院信息和专业信息的方法
        {
            return common.GetAllCollegeInfo_Class(ClassName);
        }
    }
}
