using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManageBook
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPlanBook frm = new FrmPlanBook();
            FrmShow(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmExamine frm = new FrmExamine();
            FrmShow(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmExamineResult frm = new FrmExamineResult();
            FrmShow(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmOrder frm = new FrmOrder();
            FrmShow(frm);
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            FrmAddBook frm = new FrmAddBook();
            FrmShow(frm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmGetBook frm=new FrmGetBook();
            FrmShow(frm);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            FrmNoArriveBook frm = new FrmNoArriveBook();
            FrmShow(frm);
        }

        private void FrmShow(Form form)
        {
            pnlMainCentre.Controls.Clear();
            form.TopLevel = false;
            form.Parent = this.pnlMainCentre;
            form.Show();
        }

    }
}
