
namespace _19110430_NguyenVanPhu_Day01
{
    partial class ShowContactForm
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.listBox_ShowGroup = new System.Windows.Forms.ListBox();
            this.dataGridView_ShowlistContact = new System.Windows.Forms.DataGridView();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowlistContact)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel1.Location = new System.Drawing.Point(12, 80);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 28);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Group";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel2.Location = new System.Drawing.Point(256, 80);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(110, 28);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Show all";
            // 
            // listBox_ShowGroup
            // 
            this.listBox_ShowGroup.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_ShowGroup.FormattingEnabled = true;
            this.listBox_ShowGroup.ItemHeight = 20;
            this.listBox_ShowGroup.Location = new System.Drawing.Point(17, 122);
            this.listBox_ShowGroup.Name = "listBox_ShowGroup";
            this.listBox_ShowGroup.Size = new System.Drawing.Size(225, 364);
            this.listBox_ShowGroup.TabIndex = 2;
            this.listBox_ShowGroup.Click += new System.EventHandler(this.listBox_ShowGroup_Click);
            // 
            // dataGridView_ShowlistContact
            // 
            this.dataGridView_ShowlistContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowlistContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ShowlistContact.Location = new System.Drawing.Point(261, 122);
            this.dataGridView_ShowlistContact.Name = "dataGridView_ShowlistContact";
            this.dataGridView_ShowlistContact.RowHeadersWidth = 51;
            this.dataGridView_ShowlistContact.RowTemplate.Height = 24;
            this.dataGridView_ShowlistContact.Size = new System.Drawing.Size(1123, 500);
            this.dataGridView_ShowlistContact.TabIndex = 3;
            this.dataGridView_ShowlistContact.Click += new System.EventHandler(this.dataGridView_ShowlistContact_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.DarkGray;
            this.button_Cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(1094, 663);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(162, 50);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.BackColor = System.Drawing.Color.DarkGray;
            this.button_Refresh.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.Location = new System.Drawing.Point(493, 663);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(162, 50);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = false;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // ShowContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1427, 755);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.dataGridView_ShowlistContact);
            this.Controls.Add(this.listBox_ShowGroup);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Name = "ShowContactForm";
            this.Text = "ShowContactForm";
            this.Load += new System.EventHandler(this.ShowContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowlistContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ListBox listBox_ShowGroup;
        private System.Windows.Forms.DataGridView dataGridView_ShowlistContact;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Refresh;
    }
}