using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ManageBook.Modle;
using ManageBook.BLL;
using System.Data.SqlClient;

namespace ManageBook
{
    public partial class FrmPlanBook : Form
    {
        public FrmPlanBook()
        {
            InitializeComponent();
        }

        private BLLCommon common = new BLLCommon();
        private BLLPlanBook planbook = new BLLPlanBook();

        private void FrmPlanBook_Load(object sender, EventArgs e)
        {
            CmbData();  //调用下拉框的赋值方法
            cmbData();
            PlanBookinfo(); //调用列表绑定数据源的方法
            //dgvPlanBook.DataSource = planbook.DelectPlanBook();
        }

        public void CmbData()  //查询各个表的信息赋值给下拉框
        {
            //cmbCollege.Items.Insert(0, "——请选择学院——"); //添加下拉框第一项的值
            List<CollegeInfo> collegeinfo = common.GetAllCollegeInfo();         //调用GetAllCollegeInfo()方法获取学院信息并赋值给数组a
            collegeinfo.Insert(0, new CollegeInfo { CollegeName = "——请选择学院——", CollegeID = 0 });
            cmbCollege.DataSource = collegeinfo;
            cmbCollege.DisplayMember = "CollegeName";
            cmbCollege.ValueMember = "CollegeID";
        }

        private void cmbData()
        {
            List<SchoolTerm> studentclass = common.GetAllSchoolTerm();
            studentclass.Insert(0, new SchoolTerm { TermName = "——请选择学年——", SchoolTermID = 0 });
            cmbSchoolTerm.DataSource = studentclass;
            cmbSchoolTerm.DisplayMember = "TermName";
            cmbSchoolTerm.ValueMember = "SchoolTermID";

            List<Course> course = common.GetAllCourse();
            course.Insert(0, new Course { CourseType = "——请选择类型——", CourseID = 0 });
            cmbCourseType.DataSource = course;
            cmbCourseType.DisplayMember = "CourseType";
            cmbCourseType.ValueMember = "CourseID";
        }

        private void cmbCollege_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int collegeID = cmbCollege.SelectedIndex; //当下拉框选了值并且下拉框关闭后 获取学院编号collegeID
            cmbstudentclass(collegeID);       //以学院编号collegeID调用方法cmbstudentclass（）
            //cmbStudentClass.DataSource = common.GetAllStudentClass(collegeID);
            //cmbStudentClass.ValueMember = "StudentClassID";
            //cmbStudentClass.DisplayMember = "ClassName";
        }

        private void cmbstudentclass(int collegeID)
        {

            List<StudentClass> studentclass = common.GetAllStudentClass(collegeID);
            studentclass.Insert(0, new StudentClass { ClassName = "——请选择班级——",StudentClassID=0 });
            cmbStudentClass.DataSource = studentclass;
            cmbStudentClass.DisplayMember = "ClassName";
            cmbStudentClass.ValueMember = "StudentClassID";
        }
        public void PlanBookinfo()  //多表联合查询并且为列表绑定数据源
        {
            dgvPlanBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //列表的选中为整行选中
            dgvPlanBook.DataSource = planbook.PlanBookinfo().Tables[0];     //为列表绑定数据源
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Text == "确认提交")
            {
                InsertPlanBook();
                txtAuthor.Text = "";
                txtBookName.Text = "";
                txtCourseName.Text = "";
                txtISBN.Text = "";
                txtPrice.Text = "";
                txtPublish.Text = "";
                txtStudentBookNum.Text = "";
                txtTeacherBookNum.Text = "";
            }
            if (btnOK.Text == "确认修改") 
            {
                UpdatePlanBook();
                txtAuthor.Text = "";
                txtBookName.Text = "";
                txtCourseName.Text = "";
                txtISBN.Text = "";
                txtPrice.Text = "";
                txtPublish.Text = "";
                txtStudentBookNum.Text = "";
                txtTeacherBookNum.Text = "";
                btnOK.Text = "确认提交";
            }
            PlanBookinfo();
            //dgvPlanBook.DataSource = planbook.DelectPlanBook();
        }


        private void InsertPlanBook()  //向数据库中添加一条记录
        {
            PlanBook plan = new PlanBook();  //初始化实体类PlanBook
            try
            {                           //txtText()方法为本类中返回类型是PlanBook实体类的方法
                planbook.InsertPlanBook(txtText());  //以本类中的txtText()方法为参数调用业务逻辑层中类BLLPlanBook中的方法UpdatePlanBook
            }
            catch (Exception)
            {
                MessageBox.Show("请检查信息是否填写完整或者格式是否错误");
                //throw;
            }
        }
        private void UpdatePlanBook()   //修改预定教材
        {
            try
            {                         //txtText()方法为本类中返回类型是PlanBook实体类的方法
                planbook.UpdatePlanBook(txtText(), isbn);  //以本类中的txtText()方法和静态字段isbn为参数调用业务逻辑层中类BLLPlanBook中的方法UpdatePlanBook
            }
            catch (Exception)
            {
                MessageBox.Show("请检查信息是否填写完整或者格式是否错误");
                //throw;
            } 
        }
        private PlanBook txtText()
        {
            PlanBook plan = new PlanBook();  //初始化实体类PlanBook
            plan.CourseName = txtCourseName.Text; //为实体类里面的字段赋值
            plan.BookName = txtBookName.Text;
            plan.Author = txtAuthor.Text;
            plan.ISBN = txtISBN.Text;
            plan.Price = float.Parse(txtPrice.Text.Trim());
            plan.Publish = txtPublish.Text;
            plan.StudentBookNum = int.Parse(txtStudentBookNum.Text.Trim());
            plan.TeacherBookNum = int.Parse(txtTeacherBookNum.Text.Trim());

            StudentClass student = common.GetAllCollegeInfo_Class(cmbStudentClass.Text);//以下拉框班级的文本值作参数调用方法GetAllCollegeInfo_Class（）并赋值给实体类
            plan.MajorInfoID = student.MajorInfoID;       //获取实体类StudentClass中的专业编号赋值给实体类PlanBook中的专业编号
            plan.StudentClassID = student.StudentClassID; //获取实体类StudentClass中的学院编号赋值给实体类PlanBook中的学院编号

            plan.SchoolTermID = cmbSchoolTerm.SelectedIndex; //获取下拉框学年学期的索引值并赋值给实体类PlanBook里面的SchoolTermID字段
            plan.CourseID = cmbCourseType.SelectedIndex;   //获取下拉框课程类型的索引值并赋值给实体类PlanBook里面的CourseID字段
            plan.CollegeID = cmbCollege.SelectedIndex;    //获取下拉框学院名称的索引值并赋值给实体类PlanBook里面的CollegeID字段

            plan.YearMonth = DateTime.Now;
            plan.BookTotalNum = plan.StudentBookNum + plan.TeacherBookNum;

            return plan;
        }

        private void cntxtmsDelete_Click(object sender, EventArgs e) //右键删除列表信息的方法
        {
            string isbn = dgvPlanBook.CurrentRow.Cells[7].Value.ToString();  //获取所选中的行  的名称为ISBN码的单元格  的值
            //string studentclassid = dgvPlanBook.CurrentRow.Cells[1].Value.ToString();//获取所选中的行  的名称为班级的单元格  的值
            //MessageBox.Show(studentclassid);
            planbook.DeletePlanBook(isbn);
            PlanBookinfo();
        }

        private static string isbn;
        private void cntxtmsUpdate_Click(object sender, EventArgs e)  //右键修改列表信息的方法
        {
            cmbSchoolTerm.Text = dgvPlanBook.CurrentRow.Cells[0].Value.ToString();  //获取选中的行  索引值为0的单元格的值  当成 下拉框学年学期 初始化的值
            cmbCollege.Text = dgvPlanBook.CurrentRow.Cells[1].Value.ToString();     //获取选中的行  索引值为1的单元格的值 当成 下拉框学院名称 初始化的值

            StudentClass student = common.GetAllCollegeInfo_Class(dgvPlanBook.CurrentRow.Cells[3].Value.ToString());//获取选中的行  索引值为3的单元格的值为方法GetAllCollegeInfo_Class（）的参数 并把返回值赋值给CollegeID
            int CollegeID = student.CollegeID;
            cmbstudentclass(CollegeID);                                             //以CollegeID作为参数调用方法cmbstudentclass（）重新加载年级下拉框的各个项
            cmbStudentClass.Text = dgvPlanBook.CurrentRow.Cells[3].Value.ToString();//获取选中的行  索引值为3的单元格的值 当成 下拉框班别名称 初始化的值

            cmbCourseType.Text = dgvPlanBook.CurrentRow.Cells[4].Value.ToString();//获取选中的行  索引值为4的单元格的值 当成 下拉框课程类型 初始化的值
            txtAuthor.Text=dgvPlanBook.CurrentRow.Cells[8].Value.ToString();

            txtBookName.Text=dgvPlanBook.CurrentRow.Cells[6].Value.ToString();
            txtCourseName.Text=dgvPlanBook.CurrentRow.Cells[5].Value.ToString();
            txtISBN.Text=dgvPlanBook.CurrentRow.Cells[7].Value.ToString();

            txtPrice.Text=dgvPlanBook.CurrentRow.Cells[10].Value.ToString();
            txtPublish.Text=dgvPlanBook.CurrentRow.Cells[9].Value.ToString();
            txtStudentBookNum.Text=dgvPlanBook.CurrentRow.Cells[12].Value.ToString();

            txtTeacherBookNum.Text=dgvPlanBook.CurrentRow.Cells[11].Value.ToString();

            isbn = dgvPlanBook.CurrentRow.Cells[7].Value.ToString();
            btnOK.Text = "确认修改";
            
        }

        private void cmbSchoolTerm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show(cmbSchoolTerm.SelectedIndex.ToString());
        }
    }
}
