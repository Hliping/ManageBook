using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageBook.Modle
{
    public class PlanBook
    {
        public int PlanBookID { get; set; }
        public int CourseID { get; set; }
        public int MajorInfoID { get; set; }
        public int CollegeID { get; set; }
        public int StudentClassID { get; set; }
        public int SchoolTermID { get; set; }
        public string CourseName { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publish { get; set; }
        public float Price { get; set; }
        public DateTime YearMonth { get; set; }
        public int TeacherBookNum { get; set; }
        public int StudentBookNum { get; set; }
        public int BookTotalNum { get; set; }
    }
}
