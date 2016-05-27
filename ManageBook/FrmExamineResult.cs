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
    public partial class FrmExamineResult : Form
    {
        public FrmExamineResult()
        {
            InitializeComponent();
        }

        private void FrmExamineResult_Load(object sender, EventArgs e)
        {
            BookResult();
        }
        private BLLExamineBook beb = new BLLExamineBook();
        private BLLResultExamine bre = new BLLResultExamine();
        public void BookResult()
        {
            dgvAllBook.DataSource = beb.GetOrderBook(1, 0).Tables[0];
            dgvExamineBook.DataSource = beb.GetOrderBook(1, 1).Tables[0];
            dgvNoExamineBook.DataSource = beb.GetOrderBook(0, 0).Tables[0];
        }

        private void tsmiOrder_Click(object sender, EventArgs e)
        {
            bre.UpdateBookStock(dgvExamineBook.CurrentRow.Cells[7].Value.ToString());
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            bre.deleteStockBookID(null);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            bre.deleteStockBookID(null);
            bre.UpdateBookStock(null);
        }

        private void tsmiCencel_Click(object sender, EventArgs e)
        {
            bre.deleteStockBookID(dgvExamineBook.CurrentRow.Cells[7].Value.ToString());
        }

        private void tsmishengcheng_Click(object sender, EventArgs e)
        {
            if (bre.UpdateBookStock(dgvAllBook.CurrentRow.Cells[7].Value.ToString()) == 0) 
            {
                MessageBox.Show("审核未通过生成失败");
            }
        }

        private void tsmiquxiao_Click(object sender, EventArgs e)
        {
            bre.deleteStockBookID(dgvAllBook.CurrentRow.Cells[7].Value.ToString());
        }

    }
}
