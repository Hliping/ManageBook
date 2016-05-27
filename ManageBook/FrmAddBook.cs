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
    public partial class FrmAddBook : Form
    {
        public FrmAddBook()
        {
            InitializeComponent();
        }
        private void FrmAddBook_Load(object sender, EventArgs e)
        {
            dgvOrder.DataSource = bllo.GetAllOrder(5, null);
            dgvOrderInfo();
        }
        private void dgvOrderInfo()
        {
            
            dgvOrder.Columns[0].Width = 250;
            dgvOrder.Columns[1].Width = 200;
            dgvOrder.Columns[2].Width = 100;
            dgvOrder.Columns[3].Width = 200;
            dgvOrder.Columns[4].Width = 100;
            dgvOrder.Columns[5].Width = 94;

        }
        private BLLOrder bllo = new BLLOrder();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string txt = cmbInformation.SelectedItem.ToString();
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

        private void dgvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtInfo();
        }

        private void txtInfo()
        {
            txtBookName.Text = dgvOrder.CurrentRow.Cells[0].Value.ToString();
            txtISBN.Text = dgvOrder.CurrentRow.Cells[1].Value.ToString();
            txtAuthor.Text = dgvOrder.CurrentRow.Cells[2].Value.ToString();
            txtPublish.Text = dgvOrder.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Text = dgvOrder.CurrentRow.Cells[4].Value.ToString();
            txtNum.Text = dgvOrder.CurrentRow.Cells[5].Value.ToString();
            btnAddBook.Enabled = true;
        }

        private BLLBookStock bllbs = new BLLBookStock();
        private BookStock bs;
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            bs = new BookStock();
            bs.ArriveQuantity = int.Parse(txtNetNum.Text);
            bs.Discount = float.Parse(txtDiscount.Text);
            bs.NetPrice = float.Parse(txtNetPrice.Text);
            bs.NoArriveQuantity=int.Parse(txtNum.Text)-int.Parse(txtNetNum.Text);
            bs.ISBN = txtISBN.Text;
            bllbs.UpdateBookStock(bs);
            txtText();
            dgvOrder.DataSource = bllo.GetAllOrder(5, null);
        }

        private void txtText() //清空文本信息
        {
            txtNetPrice.Text = string.Empty;
            txtNetNum.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPublish.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtNum.Text = string.Empty;
            btnAddBook.Enabled = false;
        }
    }
}
