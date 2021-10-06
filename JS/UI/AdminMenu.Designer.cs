namespace JS.UI
{
    partial class AdminMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cashierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLoginName = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelSmall = new System.Windows.Forms.Label();
            this.labelBig = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cashierToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.invoiceDetailToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cashierToolStripMenuItem
            // 
            this.cashierToolStripMenuItem.ForeColor = System.Drawing.Color.PaleGreen;
            this.cashierToolStripMenuItem.Name = "cashierToolStripMenuItem";
            this.cashierToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.cashierToolStripMenuItem.Text = "Admin";
            this.cashierToolStripMenuItem.Click += new System.EventHandler(this.cashierToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.ForeColor = System.Drawing.Color.PaleGreen;
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.customerToolStripMenuItem.Text = "Cashier";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.ForeColor = System.Drawing.Color.PaleGreen;
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.ForeColor = System.Drawing.Color.PaleGreen;
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.transactionToolStripMenuItem.Text = "Stock";
            this.transactionToolStripMenuItem.Click += new System.EventHandler(this.transactionToolStripMenuItem_Click);
            // 
            // invoiceDetailToolStripMenuItem
            // 
            this.invoiceDetailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceToolStripMenuItem,
            this.invoiceDetailsToolStripMenuItem});
            this.invoiceDetailToolStripMenuItem.ForeColor = System.Drawing.Color.PaleGreen;
            this.invoiceDetailToolStripMenuItem.Name = "invoiceDetailToolStripMenuItem";
            this.invoiceDetailToolStripMenuItem.Size = new System.Drawing.Size(127, 29);
            this.invoiceDetailToolStripMenuItem.Text = "Bill Records";
            this.invoiceDetailToolStripMenuItem.Click += new System.EventHandler(this.invoiceDetailToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.BackColor = System.Drawing.Color.GreenYellow;
            this.invoiceToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.invoiceToolStripMenuItem.Text = "Transaction Details";
            this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.invoiceToolStripMenuItem_Click);
            // 
            // invoiceDetailsToolStripMenuItem
            // 
            this.invoiceDetailsToolStripMenuItem.BackColor = System.Drawing.Color.GreenYellow;
            this.invoiceDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.invoiceDetailsToolStripMenuItem.Name = "invoiceDetailsToolStripMenuItem";
            this.invoiceDetailsToolStripMenuItem.Size = new System.Drawing.Size(251, 30);
            this.invoiceDetailsToolStripMenuItem.Text = "Invoice Details";
            this.invoiceDetailsToolStripMenuItem.Click += new System.EventHandler(this.invoiceDetailsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 46);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(561, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database Design and Development Management";
            // 
            // labelLoginName
            // 
            this.labelLoginName.AutoSize = true;
            this.labelLoginName.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginName.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelLoginName.Location = new System.Drawing.Point(78, 53);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(0, 25);
            this.labelLoginName.TabIndex = 5;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.Cyan;
            this.labelLogin.Location = new System.Drawing.Point(12, 41);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(75, 37);
            this.labelLogin.TabIndex = 6;
            this.labelLogin.Text = "User";
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // labelSmall
            // 
            this.labelSmall.AutoSize = true;
            this.labelSmall.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSmall.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelSmall.Location = new System.Drawing.Point(14, 367);
            this.labelSmall.Name = "labelSmall";
            this.labelSmall.Size = new System.Drawing.Size(284, 25);
            this.labelSmall.TabIndex = 8;
            this.labelSmall.Text = "Invoice and Stock Management";
            // 
            // labelBig
            // 
            this.labelBig.AutoSize = true;
            this.labelBig.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBig.ForeColor = System.Drawing.Color.Cyan;
            this.labelBig.Location = new System.Drawing.Point(12, 327);
            this.labelBig.Name = "labelBig";
            this.labelBig.Size = new System.Drawing.Size(228, 40);
            this.labelBig.TabIndex = 7;
            this.labelBig.Text = "JEWELRY SHOP";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.Cyan;
            this.labelDate.Location = new System.Drawing.Point(12, 115);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(85, 37);
            this.labelDate.TabIndex = 15;
            this.labelDate.Text = "Date:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.Cyan;
            this.labelTime.Location = new System.Drawing.Point(12, 78);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(88, 37);
            this.labelTime.TabIndex = 14;
            this.labelTime.Text = "Time:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(845, 450);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSmall);
            this.Controls.Add(this.labelBig);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelLoginName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AdminMenu";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMenu_FormClosed);
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cashierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLoginName;
        private System.Windows.Forms.ToolStripMenuItem invoiceDetailToolStripMenuItem;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelSmall;
        private System.Windows.Forms.Label labelBig;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceDetailsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer2;
    }
}