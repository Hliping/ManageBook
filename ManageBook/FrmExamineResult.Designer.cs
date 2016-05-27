namespace ManageBook
{
    partial class FrmExamineResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabtrlResult = new System.Windows.Forms.TabControl();
            this.AllBook = new System.Windows.Forms.TabPage();
            this.dgvAllBook = new System.Windows.Forms.DataGridView();
            this.ExamineBook = new System.Windows.Forms.TabPage();
            this.dgvExamineBook = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.NoExamineBook = new System.Windows.Forms.TabPage();
            this.dgvNoExamineBook = new System.Windows.Forms.DataGridView();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.tsmiCencel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmishengcheng = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiquxiao = new System.Windows.Forms.ToolStripMenuItem();
            this.tabtrlResult.SuspendLayout();
            this.AllBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBook)).BeginInit();
            this.ExamineBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineBook)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.NoExamineBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoExamineBook)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabtrlResult
            // 
            this.tabtrlResult.Controls.Add(this.AllBook);
            this.tabtrlResult.Controls.Add(this.ExamineBook);
            this.tabtrlResult.Controls.Add(this.NoExamineBook);
            this.tabtrlResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabtrlResult.Location = new System.Drawing.Point(0, 0);
            this.tabtrlResult.Name = "tabtrlResult";
            this.tabtrlResult.SelectedIndex = 0;
            this.tabtrlResult.Size = new System.Drawing.Size(988, 806);
            this.tabtrlResult.TabIndex = 0;
            // 
            // AllBook
            // 
            this.AllBook.Controls.Add(this.dgvAllBook);
            this.AllBook.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllBook.Location = new System.Drawing.Point(4, 26);
            this.AllBook.Name = "AllBook";
            this.AllBook.Padding = new System.Windows.Forms.Padding(3);
            this.AllBook.Size = new System.Drawing.Size(980, 776);
            this.AllBook.TabIndex = 0;
            this.AllBook.Text = "全部预定教材";
            this.AllBook.UseVisualStyleBackColor = true;
            // 
            // dgvAllBook
            // 
            this.dgvAllBook.AllowUserToAddRows = false;
            this.dgvAllBook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllBook.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllBook.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllBook.Location = new System.Drawing.Point(1, 0);
            this.dgvAllBook.Name = "dgvAllBook";
            this.dgvAllBook.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllBook.RowTemplate.Height = 23;
            this.dgvAllBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBook.Size = new System.Drawing.Size(978, 776);
            this.dgvAllBook.TabIndex = 2;
            // 
            // ExamineBook
            // 
            this.ExamineBook.Controls.Add(this.dgvExamineBook);
            this.ExamineBook.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExamineBook.Location = new System.Drawing.Point(4, 26);
            this.ExamineBook.Name = "ExamineBook";
            this.ExamineBook.Padding = new System.Windows.Forms.Padding(3);
            this.ExamineBook.Size = new System.Drawing.Size(980, 776);
            this.ExamineBook.TabIndex = 1;
            this.ExamineBook.Text = "已通过审核教材";
            this.ExamineBook.UseVisualStyleBackColor = true;
            // 
            // dgvExamineBook
            // 
            this.dgvExamineBook.AllowUserToAddRows = false;
            this.dgvExamineBook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamineBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExamineBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamineBook.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExamineBook.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExamineBook.Location = new System.Drawing.Point(1, 0);
            this.dgvExamineBook.Name = "dgvExamineBook";
            this.dgvExamineBook.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamineBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExamineBook.RowTemplate.Height = 23;
            this.dgvExamineBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamineBook.Size = new System.Drawing.Size(978, 776);
            this.dgvExamineBook.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrder,
            this.tsmiCencel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiOrder
            // 
            this.tsmiOrder.Name = "tsmiOrder";
            this.tsmiOrder.Size = new System.Drawing.Size(124, 22);
            this.tsmiOrder.Text = "生成订单";
            this.tsmiOrder.Click += new System.EventHandler(this.tsmiOrder_Click);
            // 
            // NoExamineBook
            // 
            this.NoExamineBook.Controls.Add(this.dgvNoExamineBook);
            this.NoExamineBook.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NoExamineBook.Location = new System.Drawing.Point(4, 26);
            this.NoExamineBook.Name = "NoExamineBook";
            this.NoExamineBook.Size = new System.Drawing.Size(980, 776);
            this.NoExamineBook.TabIndex = 2;
            this.NoExamineBook.Text = "未通过审核教材";
            this.NoExamineBook.UseVisualStyleBackColor = true;
            // 
            // dgvNoExamineBook
            // 
            this.dgvNoExamineBook.AllowUserToAddRows = false;
            this.dgvNoExamineBook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoExamineBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvNoExamineBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNoExamineBook.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvNoExamineBook.Location = new System.Drawing.Point(1, 0);
            this.dgvNoExamineBook.Name = "dgvNoExamineBook";
            this.dgvNoExamineBook.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoExamineBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvNoExamineBook.RowTemplate.Height = 23;
            this.dgvNoExamineBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNoExamineBook.Size = new System.Drawing.Size(978, 776);
            this.dgvNoExamineBook.TabIndex = 5;
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrder.Location = new System.Drawing.Point(334, 815);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(119, 44);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "一键生成订单";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCencel.Location = new System.Drawing.Point(519, 815);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(119, 44);
            this.btnCencel.TabIndex = 3;
            this.btnCencel.Text = "一键取消订单";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // tsmiCencel
            // 
            this.tsmiCencel.Name = "tsmiCencel";
            this.tsmiCencel.Size = new System.Drawing.Size(124, 22);
            this.tsmiCencel.Text = "取消订单";
            this.tsmiCencel.Click += new System.EventHandler(this.tsmiCencel_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmishengcheng,
            this.tsmiquxiao});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmishengcheng
            // 
            this.tsmishengcheng.Name = "tsmishengcheng";
            this.tsmishengcheng.Size = new System.Drawing.Size(124, 22);
            this.tsmishengcheng.Text = "生成订单";
            this.tsmishengcheng.Click += new System.EventHandler(this.tsmishengcheng_Click);
            // 
            // tsmiquxiao
            // 
            this.tsmiquxiao.Name = "tsmiquxiao";
            this.tsmiquxiao.Size = new System.Drawing.Size(124, 22);
            this.tsmiquxiao.Text = "取消订单";
            this.tsmiquxiao.Click += new System.EventHandler(this.tsmiquxiao_Click);
            // 
            // FrmExamineResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 868);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.tabtrlResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExamineResult";
            this.Text = "FrmExamineResult";
            this.Load += new System.EventHandler(this.FrmExamineResult_Load);
            this.tabtrlResult.ResumeLayout(false);
            this.AllBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBook)).EndInit();
            this.ExamineBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineBook)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.NoExamineBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoExamineBook)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabtrlResult;
        private System.Windows.Forms.TabPage AllBook;
        private System.Windows.Forms.TabPage ExamineBook;
        private System.Windows.Forms.TabPage NoExamineBook;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.DataGridView dgvAllBook;
        private System.Windows.Forms.DataGridView dgvExamineBook;
        private System.Windows.Forms.DataGridView dgvNoExamineBook;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrder;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.ToolStripMenuItem tsmiCencel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmishengcheng;
        private System.Windows.Forms.ToolStripMenuItem tsmiquxiao;
    }
}