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
using System.Data.SqlClient;

namespace ManageBook
{
    public partial class FrmExamine : Form
    {
        public FrmExamine()
        {
            InitializeComponent();
        }
        private BLLCommon common = new BLLCommon();
        public BLLCommon comm = new BLLCommon();
        public void cmbSelect()
        {
            List<CollegeInfo> collegeinfo = common.GetAllCollegeInfo();         //调用GetAllCollegeInfo()方法获取学院信息并赋值给数组a
            collegeinfo.Insert(0, new CollegeInfo { CollegeName = "———全部———", CollegeID = 0 }); //为数组添加一条记录
            cmbCollege.DataSource = collegeinfo;      //绑定数组的数据源
            cmbCollege.DisplayMember = "CollegeName";  //绑定下拉框显示的内容
            cmbCollege.ValueMember = "CollegeID";      //绑定下拉框的属性值
            //cmbCollege.DataSource = comm.GetAllCollegeInfo();
        }
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行

        public DataTable dtInfo;  //定义一个数据表
        private BLLExamineBook bob = new BLLExamineBook(); //实例化BLLExamineBook逻辑类
        private void FrmExamine_Load(object sender, EventArgs e) //载入事件
        {
            cmbSelect();  //下拉框的数据赋值方法
            DataInfo();   //为数据源赋值并且刷新的方法

            //bdsInfo.DataSource = dt;
            //dgvInfo.DataSource = bdsInfo;
            //dgvInfo.DataSource = dt;
            //dgvInfo.DataSource= PlanBookinfo(0,4).Tables["one"].DefaultView;
            //PlanBookinfo();
        }

        private void DataInfo() //为数据源赋值并且刷新的方法
        {
            dtInfo = bob.GetOrderBook(1,0).Tables[0]; //为数据源dtInfo赋值
            InitDataSet();  //页面数据设置和刷新数据的方法
        }

        private void InitDataSet() //页面数据设置和刷新数据的方法
        {
            pageSize = 20;      //设置页面行数
            nMax = dtInfo.Rows.Count;  //得出dtInfo数据源中的总记录数并赋值给nMax
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0) pageCount++;  //如果总记录数除以 页面行数的余数大于0 则总页数pageCount++
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData();      //数据源的设置、绑定（刷新）的方法
        }

        private void LoadData()  //数据源的设置和绑定的方法
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount) //如果总页数=当前页数
            {
                nEndPos = nMax;     //当前页面结束的记录行nEndPos 的行数就等于总的记录数
            }
            else
            {
                nEndPos = pageSize * pageCurrent; //当前页面结束的记录行的 数目等于页面行数pageSize*pageCurrent当前页数
            }

            nStartPos = nCurrent;    //当前页面开始记录行等于当前记录行
            lblPageCount.Text = pageCount.ToString();  //总页数
            txtCurrentPage.Text = Convert.ToString(pageCurrent);//当前页数

            for (int i = nStartPos; i < nEndPos; i++)
            {
                try
                {
                    dtTemp.ImportRow(dtInfo.Rows[i]); //每次复制一行记录进dtTemp数据表中
                }
                catch (Exception)
                {
                    //throw;
                }
                nCurrent++;    //每复制一次则当前记录行加1
            }
            bdsInfo.DataSource = dtTemp;  //绑定数据源bdsInfo  的数据源为数据表dtTemp
            bdnInfo.BindingSource = bdsInfo;   //绑定数据控件bdnInfo  的数据源为数据源bdsInfo
            dgvInfo.DataSource = bdsInfo;      //绑定DataGridView列表控件dgvInfo  的数据源为数据源bdsInfo
            
        }

        private void bdnInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (e.ClickedItem.Text == "上一页")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            if (e.ClickedItem.Text == "下一页")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
        }

        private void cmbCollege_SelectionChangeCommitted(object sender, EventArgs e) //下拉框选择了项并且已经关闭下拉列表的方法
        {
            if (cmbCollege.SelectedIndex == 0)
            {
                DataInfo(); //刷新全部数据
            }
            else
            {
                dtInfo = bob.GetSelectCollege(cmbCollege.SelectedIndex, null).Tables[0];  //重新绑定数据源
                InitDataSet();  //刷新局部数据
            }
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbCollege.SelectedIndex == 0 && txtDelect.Text != null) 
            {
                dtInfo = bob.GetSelectCollege(-1, txtDelect.Text).Tables[0];  //重新绑定数据源
                InitDataSet();  //刷新局部数据
            }

            else if (cmbCollege.SelectedIndex == 0 && txtDelect.Text == null) { }

            else
            {
                dtInfo = bob.GetSelectCollege(cmbCollege.SelectedIndex, txtDelect.Text).Tables[0]; //重新绑定数据源
                InitDataSet();   //刷新局部数据
            }
        }


        private BLLPlanBook planbook = new BLLPlanBook();
        private void cntxtDelete_Click(object sender, EventArgs e)
        {
            planbook.DeletePlanBook(dgvInfo.CurrentRow.Cells[7].Value.ToString());  //删除数据
            DataInfo(); //刷新全部数据
        }

        private void cntxtExamine_Click(object sender, EventArgs e)
        {
            bob.UpdateExamine(dgvInfo.CurrentRow.Cells[7].Value.ToString(), 1);  //修改数据
            DataInfo(); //刷新全部数据
        }

        private void cntxtNoExamine_Click(object sender, EventArgs e)
        {
            bob.UpdateExamine(dgvInfo.CurrentRow.Cells[7].Value.ToString(), -1); //修改数据
            DataInfo(); //刷新全部数据
        }

        private void btnAllExamine_Click(object sender, EventArgs e)
        {
            int a = dgvInfo.RowCount;
            for (int i = 0; i < a; i++) 
            {
                bob.UpdateExamine(dgvInfo.Rows[i].Cells[7].Value.ToString(), 1); //修改数据
            }
            DataInfo(); //刷新全部数据
        }

        private void btnAllNoExamine_Click(object sender, EventArgs e)
        {
            int a = dgvInfo.RowCount;
            for (int i = 0; i < a; i++)
            {
                bob.UpdateExamine(dgvInfo.Rows[i].Cells[7].Value.ToString(), -1); //修改数据
            }
            DataInfo(); //刷新全部数据
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            bob.UpdateOrderBookRemark(txtRemark.Text, dgvInfo.CurrentRow.Cells[7].Value.ToString()); //修改数据
            txtRemark.Text = "";
            DataInfo();  //刷新全部数据
        }

    }
}
