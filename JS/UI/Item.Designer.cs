namespace JS.UI
{
    partial class Item
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
            this.textSeach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxItemType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxItemCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxItemCondition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textItemPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltop = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textSeach
            // 
            this.textSeach.Location = new System.Drawing.Point(101, 235);
            this.textSeach.Name = "textSeach";
            this.textSeach.Size = new System.Drawing.Size(574, 20);
            this.textSeach.TabIndex = 37;
            this.textSeach.TextChanged += new System.EventHandler(this.textSeach_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.PaleGreen;
            this.label4.Location = new System.Drawing.Point(42, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Search:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 261);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(709, 215);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.PaleGreen;
            this.button3.Location = new System.Drawing.Point(469, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 56);
            this.button3.TabIndex = 34;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.PaleGreen;
            this.button2.Location = new System.Drawing.Point(367, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 56);
            this.button2.TabIndex = 33;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.PaleGreen;
            this.button1.Location = new System.Drawing.Point(269, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 56);
            this.button1.TabIndex = 32;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textItemName
            // 
            this.textItemName.Location = new System.Drawing.Point(153, 56);
            this.textItemName.Name = "textItemName";
            this.textItemName.Size = new System.Drawing.Size(182, 20);
            this.textItemName.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.PaleGreen;
            this.label2.Location = new System.Drawing.Point(64, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Item Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PaleGreen;
            this.label1.Location = new System.Drawing.Point(72, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Item Type:";
            // 
            // comboBoxItemType
            // 
            this.comboBoxItemType.FormattingEnabled = true;
            this.comboBoxItemType.Items.AddRange(new object[] {
            "Amulet ",
            "Anklet",
            "Armlet",
            "Bangle ",
            "Belly Chain ",
            "Bolo tie ",
            "Body Piercing Jewellery ",
            "Bracelet  ",
            "Breastplate  ",
            "Brooch ",
            "Cameo ",
            "Carcanet ",
            "Choker",
            "Crowns ",
            "Celebacy vow ring ",
            "Cuff links  ",
            "Chatelaine ",
            "Ear Cuff ",
            "Emblem ",
            "Earrings  ",
            "Fascinator ",
            "Hairpin  ",
            "Hatpin ",
            "Locket",
            "Necklace ",
            "Medical alert Jewelry ",
            "Membership pin ",
            "Military dog tags  ",
            "Medallion  ",
            "Pendant ",
            "Puzzle Jewelry  ",
            "Prayer Jewelry  ",
            "Pledge pin ",
            "Ring ",
            "Sarpech ",
            "Signet ring ",
            "Slave Bracelet",
            "Toe ring ",
            "Torc",
            "Thumb ring "});
            this.comboBoxItemType.Location = new System.Drawing.Point(153, 88);
            this.comboBoxItemType.Name = "comboBoxItemType";
            this.comboBoxItemType.Size = new System.Drawing.Size(182, 21);
            this.comboBoxItemType.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.PaleGreen;
            this.label3.Location = new System.Drawing.Point(42, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Item Category:";
            // 
            // comboBoxItemCategory
            // 
            this.comboBoxItemCategory.FormattingEnabled = true;
            this.comboBoxItemCategory.Items.AddRange(new object[] {
            "Bronze",
            "Silver",
            "Gold",
            "Platinum",
            "Ruby",
            "Diamond"});
            this.comboBoxItemCategory.Location = new System.Drawing.Point(153, 121);
            this.comboBoxItemCategory.Name = "comboBoxItemCategory";
            this.comboBoxItemCategory.Size = new System.Drawing.Size(182, 21);
            this.comboBoxItemCategory.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.PaleGreen;
            this.label5.Location = new System.Drawing.Point(364, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Item Condition:";
            // 
            // comboBoxItemCondition
            // 
            this.comboBoxItemCondition.FormattingEnabled = true;
            this.comboBoxItemCondition.Items.AddRange(new object[] {
            "Brand New",
            "Second Hand"});
            this.comboBoxItemCondition.Location = new System.Drawing.Point(477, 90);
            this.comboBoxItemCondition.Name = "comboBoxItemCondition";
            this.comboBoxItemCondition.Size = new System.Drawing.Size(182, 21);
            this.comboBoxItemCondition.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.PaleGreen;
            this.label6.Location = new System.Drawing.Point(395, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "Item Price:";
            // 
            // textItemPrice
            // 
            this.textItemPrice.Location = new System.Drawing.Point(477, 59);
            this.textItemPrice.Name = "textItemPrice";
            this.textItemPrice.Size = new System.Drawing.Size(182, 20);
            this.textItemPrice.TabIndex = 47;
            this.textItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textItemPrice_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.labeltop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 25);
            this.panel1.TabIndex = 74;
            // 
            // labeltop
            // 
            this.labeltop.AutoSize = true;
            this.labeltop.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltop.ForeColor = System.Drawing.Color.LavenderBlush;
            this.labeltop.Location = new System.Drawing.Point(346, 5);
            this.labeltop.Name = "labeltop";
            this.labeltop.Size = new System.Drawing.Size(116, 16);
            this.labeltop.TabIndex = 0;
            this.labeltop.Text = "Add Item Details";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(786, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textItemPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxItemCondition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxItemCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxItemType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSeach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textItemName);
            this.Controls.Add(this.label2);
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textSeach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxItemType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxItemCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxItemCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textItemPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeltop;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}