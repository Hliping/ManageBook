using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ManageBook.BLL;
using ManageBook.Modle;

namespace ManageBook
{
    public partial class FrmGetBook : Form
    {
        public FrmGetBook()
        {
            InitializeComponent();
        }

        private void FrmGetBook_Load(object sender, EventArgs e)
        {
            DgvInfo();
            cmbData();
        }

        private BLLCommon common = new BLLCommon();
        private BLLBookStock bllbs = new BLLBookStock();
        private void DgvInfo()
        {
            dgvStockInfo.DataSource = bllbs.SelectBookStock().Tables[0];
        }
        private void cmbData()
        {
            //cmbCollege.Items.Insert(0, "——请选择学院——"); //添加下拉框第一项的值
            List<CollegeInfo> collegeinfo = common.GetAllCollegeInfo();         //调用GetAllCollegeInfo()方法获取学院信息并赋值给数组a
            collegeinfo.Insert(0, new CollegeInfo { CollegeName = "——请选择学院——", CollegeID = 0 });
            cmbCollege.DataSource = collegeinfo;
            cmbCollege.DisplayMember = "CollegeName";
            cmbCollege.ValueMember = "CollegeID";

            List<SchoolTerm> studentclass = common.GetAllSchoolTerm();
            studentclass.Insert(0, new SchoolTerm { TermName = "——请选择学年——", SchoolTermID = 0 });
            cmbSchoolTerm.DataSource = studentclass;
            cmbSchoolTerm.DisplayMember = "TermName";
            cmbSchoolTerm.ValueMember = "SchoolTermID";
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
            studentclass.Insert(0, new StudentClass { ClassName = "——请选择班级——", StudentClassID = 0 });
            cmbStudentClass.DataSource = studentclass;
            cmbStudentClass.DisplayMember = "ClassName";
            cmbStudentClass.ValueMember = "StudentClassID";
        }

        private void dgvStockInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtBookName.Text = dgvStockInfo.CurrentRow.Cells[0].Value.ToString();
            txtISBN.Text = dgvStockInfo.CurrentRow.Cells[1].Value.ToString();
            txtAuthor.Text = dgvStockInfo.CurrentRow.Cells[2].Value.ToString();
            txtPublish.Text = dgvStockInfo.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Text = dgvStockInfo.CurrentRow.Cells[4].Value.ToString();
            btnAddBook.Enabled = true;
            txtNum.Enabled = true;
            txtSigner.Enabled = true;
            txtSignerPhone.Enabled = true;
            cmbIdentity.Enabled = true;
        }

        private BLLGetBook bllgb = new BLLGetBook();
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(dgvStockInfo.CurrentRow.Cells[7].Value.ToString()) - int.Parse(txtNum.Text) < 0)
                {
                    MessageBox.Show("输入的数量大于库存数量");
                }
                else
                {

                    GetBook gb = new GetBook();
                    gb.GetBookNum = int.Parse(txtNum.Text);
                    gb.ISBN = txtISBN.Text;
                    gb.Signer = txtSigner.Text;
                    gb.SignerPhone = txtSignerPhone.Text;
                    gb.SignerIdentity = cmbIdentity.Text;

                    if (cmbIdentity.SelectedItem.ToString() == "学生代表")
                    {
                        StudentClass student = common.GetAllCollegeInfo_Class(cmbStudentClass.Text);//以下拉框班级的文本值作参数调用方法GetAllCollegeInfo_Class（）并赋值给实体类
                        gb.MajorInfoID = student.MajorInfoID;       //获取实体类StudentClass中的专业编号赋值给实体类PlanBook中的专业编号
                        gb.StudentClassID = student.StudentClassID; //获取实体类StudentClass中的学院编号赋值给实体类PlanBook中的学院编号

                        gb.SchoolTermID = cmbSchoolTerm.SelectedIndex; //获取下拉框学年学期的索引值并赋值给实体类PlanBook里面的SchoolTermID字段
                        gb.CollegeID = cmbCollege.SelectedIndex;    //获取下拉框学院名称的索引值并赋值给实体类PlanBook里面的CollegeID字段 
                    }
                    else
                    {
                        gb.CollegeID = 0;
                        gb.SchoolTermID = 0;
                        gb.StudentClassID = 0;
                    }
                    bllgb.UpdateGetBook(gb);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请检查输入的值的类型是否正确");
                //throw;
            }
        }

        private void cmbIdentity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbIdentity.SelectedItem.ToString() == "学生代表")
            {
                cmbCollege.Enabled = true;
                cmbStudentClass.Enabled = true;
                cmbSchoolTerm.Enabled = true;
            }
            else
            {
                cmbCollege.Enabled = false;
                cmbStudentClass.Enabled = false;
                cmbSchoolTerm.Enabled = false;
            }
        }
    }
}
