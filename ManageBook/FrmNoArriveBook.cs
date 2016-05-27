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
    public partial class FrmNoArriveBook : Form
    {
        public FrmNoArriveBook()
        {
            InitializeComponent();
        }
        private BLLBookStock bllbs = new BLLBookStock();
        private void FrmNoArriveBook_Load(object sender, EventArgs e)
        {
            dgvOrder.DataSource = bllbs.NoArriveBook().Tables[0];
        
        }
    }
}
