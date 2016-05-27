using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using ManageBook.BLL;
using ManageBook.Modle;


namespace ManageBook
{
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
        }
        private BLLOrder bllo = new BLLOrder();
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            dgvOrderInfo();
        }

        private void dgvOrderInfo()
        {
            dgvOrder.DataSource = bllo.GetAllOrder(0, null);
            dgvOrder.Columns[0].Width = 250;
            dgvOrder.Columns[1].Width = 200;
            dgvOrder.Columns[2].Width = 100;
            dgvOrder.Columns[3].Width = 200;
            dgvOrder.Columns[4].Width = 100;
            dgvOrder.Columns[5].Width = 94;

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string txt= cmbInformation.SelectedItem.ToString();
            switch (txt) 
            {
                case "教材名称":
                    dgvOrder.DataSource = bllo.GetAllOrder(1, txtDelect.Text);
                    break;
                case "ISBN码":
                    dgvOrder.DataSource = bllo.GetAllOrder(2, txtDelect.Text);
                    break;
                case "作者":
                    dgvOrder.DataSource = bllo.GetAllOrder(3, txtDelect.Text);
                    break;
                case "出版社":
                    dgvOrder.DataSource = bllo.GetAllOrder(4, txtDelect.Text);
                    break;
            }
            
        }

        private void cmbInformation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbInformation.SelectedItem.ToString() == "———全部———") 
            {
                dgvOrder.DataSource = bllo.GetAllOrder(0, null);
                txtDelect.Text = string.Empty;
            }
        }

        public bool data(DataGridView dgv, bool flag) 
        {
            if (dgv.Rows.Count == 0) 
            {
                return false;
            }
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Application.Workbooks.Add(true);
            Excel.Visible = flag;
            for (int i = 0; i < dgv.Columns.Count; i++) 
            {
                Excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++) 
            {
                for (int j = 0; j < dgv.Columns.Count; j++) 
                {
                     Excel.Cells[i + 2 , j + 1] = dgv[j, i].Value.ToString();
                }
            }
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data(dgvOrder, true);
        }
    }
}
