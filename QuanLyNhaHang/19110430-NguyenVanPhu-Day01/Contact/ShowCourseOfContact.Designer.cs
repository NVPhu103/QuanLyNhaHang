
namespace _19110430_NguyenVanPhu_Day01
{
    partial class ShowCourseOfContact
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
            this.dataGridView_ShowCourseOfContact = new System.Windows.Forms.DataGridView();
            this.listBox_ShowCourseOfContact = new System.Windows.Forms.ListBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_SaveTextFile = new System.Windows.Forms.Button();
            this.button_SaveMSWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowCourseOfContact)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ShowCourseOfContact
            // 
            this.dataGridView_ShowCourseOfContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ShowCourseOfContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ShowCourseOfContact.Location = new System.Drawing.Point(267, 128);
            this.dataGridView_ShowCourseOfContact.Name = "dataGridView_ShowCourseOfContact";
            this.dataGridView_ShowCourseOfContact.RowHeadersWidth = 51;
            this.dataGridView_ShowCourseOfContact.RowTemplate.Height = 24;
            this.dataGridView_ShowCourseOfContact.Size = new System.Drawing.Size(1123, 500);
            this.dataGridView_ShowCourseOfContact.TabIndex = 7;
            // 
            // listBox_ShowCourseOfContact
            // 
            this.listBox_ShowCourseOfContact.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_ShowCourseOfContact.FormattingEnabled = true;
            this.listBox_ShowCourseOfContact.ItemHeight = 20;
            this.listBox_ShowCourseOfContact.Location = new System.Drawing.Point(23, 128);
            this.listBox_ShowCourseOfContact.Name = "listBox_ShowCourseOfContact";
            this.listBox_ShowCourseOfContact.Size = new System.Drawing.Size(225, 364);
            this.listBox_ShowCourseOfContact.TabIndex = 6;
            this.listBox_ShowCourseOfContact.Click += new System.EventHandler(this.listBox_ShowCourseOfContact_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel2.Location = new System.Drawing.Point(262, 86);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(110, 28);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Show all";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel1.Location = new System.Drawing.Point(18, 86);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 28);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Group";
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.DarkGray;
            this.button_Cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(1084, 647);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(197, 50);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_SaveTextFile
            // 
            this.button_SaveTextFile.BackColor = System.Drawing.Color.DarkGray;
            this.button_SaveTextFile.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SaveTextFile.Location = new System.Drawing.Point(368, 647);
            this.button_SaveTextFile.Name = "button_SaveTextFile";
            this.button_SaveTextFile.Size = new System.Drawing.Size(197, 50);
            this.button_SaveTextFile.TabIndex = 9;
            this.button_SaveTextFile.Text = "Save Text File";
            this.button_SaveTextFile.UseVisualStyleBackColor = false;
            this.button_SaveTextFile.Click += new System.EventHandler(this.button_SaveTextFile_Click);
            // 
            // button_SaveMSWord
            // 
            this.button_SaveMSWord.BackColor = System.Drawing.Color.DarkGray;
            this.button_SaveMSWord.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SaveMSWord.Location = new System.Drawing.Point(728, 647);
            this.button_SaveMSWord.Name = "button_SaveMSWord";
            this.button_SaveMSWord.Size = new System.Drawing.Size(226, 50);
            this.button_SaveMSWord.TabIndex = 10;
            this.button_SaveMSWord.Text = "Save MS Word";
            this.button_SaveMSWord.UseVisualStyleBackColor = false;
            this.button_SaveMSWord.Click += new System.EventHandler(this.button_SaveMSWord_Click);
            // 
            // ShowCourseOfContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1415, 709);
            this.Controls.Add(this.button_SaveMSWord);
            this.Controls.Add(this.button_SaveTextFile);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.dataGridView_ShowCourseOfContact);
            this.Controls.Add(this.listBox_ShowCourseOfContact);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Name = "ShowCourseOfContact";
            this.Text = "ShowCourseOfContact";
            this.Load += new System.EventHandler(this.ShowCourseOfContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ShowCourseOfContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ShowCourseOfContact;
        private System.Windows.Forms.ListBox listBox_ShowCourseOfContact;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_SaveTextFile;
        private System.Windows.Forms.Button button_SaveMSWord;
    }
}