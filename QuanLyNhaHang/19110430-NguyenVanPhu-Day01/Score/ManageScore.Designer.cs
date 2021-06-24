
namespace _19110430_NguyenVanPhu_Day01
{
    partial class ManageScore
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
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.textBoxStudentID = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelSelectCourse = new System.Windows.Forms.Label();
            this.labelStudentID = new System.Windows.Forms.Label();
            this.dataGridViewManageScore = new System.Windows.Forms.DataGridView();
            this.buttonShowStudent = new System.Windows.Forms.Button();
            this.buttonShowScores = new System.Windows.Forms.Button();
            this.buttonAddManage = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAverage = new System.Windows.Forms.Button();
            this.buttonSaveMSWORD = new System.Windows.Forms.Button();
            this.buttonSaveTextFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageScore)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(270, 98);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(316, 28);
            this.comboBoxCourse.TabIndex = 29;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(270, 217);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(316, 112);
            this.textBoxDescription.TabIndex = 28;
            // 
            // textBoxScore
            // 
            this.textBoxScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxScore.Location = new System.Drawing.Point(270, 154);
            this.textBoxScore.Multiline = true;
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(169, 30);
            this.textBoxScore.TabIndex = 27;
            // 
            // textBoxStudentID
            // 
            this.textBoxStudentID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStudentID.Location = new System.Drawing.Point(270, 27);
            this.textBoxStudentID.Multiline = true;
            this.textBoxStudentID.Name = "textBoxStudentID";
            this.textBoxStudentID.Size = new System.Drawing.Size(169, 30);
            this.textBoxStudentID.TabIndex = 26;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.Aqua;
            this.labelDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelDescription.Location = new System.Drawing.Point(52, 217);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(175, 32);
            this.labelDescription.TabIndex = 25;
            this.labelDescription.Text = "Description";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Aqua;
            this.labelScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelScore.Location = new System.Drawing.Point(121, 154);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(97, 32);
            this.labelScore.TabIndex = 24;
            this.labelScore.Text = "Score";
            // 
            // labelSelectCourse
            // 
            this.labelSelectCourse.AutoSize = true;
            this.labelSelectCourse.BackColor = System.Drawing.Color.Aqua;
            this.labelSelectCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectCourse.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelSelectCourse.Location = new System.Drawing.Point(18, 90);
            this.labelSelectCourse.Name = "labelSelectCourse";
            this.labelSelectCourse.Size = new System.Drawing.Size(209, 32);
            this.labelSelectCourse.TabIndex = 23;
            this.labelSelectCourse.Text = "Select Course";
            // 
            // labelStudentID
            // 
            this.labelStudentID.AutoSize = true;
            this.labelStudentID.BackColor = System.Drawing.Color.Aqua;
            this.labelStudentID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStudentID.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelStudentID.Location = new System.Drawing.Point(76, 27);
            this.labelStudentID.Name = "labelStudentID";
            this.labelStudentID.Size = new System.Drawing.Size(160, 32);
            this.labelStudentID.TabIndex = 22;
            this.labelStudentID.Text = "Student ID";
            // 
            // dataGridViewManageScore
            // 
            this.dataGridViewManageScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManageScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManageScore.Location = new System.Drawing.Point(613, 67);
            this.dataGridViewManageScore.Name = "dataGridViewManageScore";
            this.dataGridViewManageScore.RowHeadersWidth = 51;
            this.dataGridViewManageScore.RowTemplate.Height = 24;
            this.dataGridViewManageScore.Size = new System.Drawing.Size(727, 399);
            this.dataGridViewManageScore.TabIndex = 30;
            this.dataGridViewManageScore.Click += new System.EventHandler(this.dataGridViewManageScore_Click);
            // 
            // buttonShowStudent
            // 
            this.buttonShowStudent.BackColor = System.Drawing.Color.Yellow;
            this.buttonShowStudent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowStudent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonShowStudent.Location = new System.Drawing.Point(698, 10);
            this.buttonShowStudent.Name = "buttonShowStudent";
            this.buttonShowStudent.Size = new System.Drawing.Size(191, 49);
            this.buttonShowStudent.TabIndex = 31;
            this.buttonShowStudent.Text = "Show Students";
            this.buttonShowStudent.UseVisualStyleBackColor = false;
            this.buttonShowStudent.Click += new System.EventHandler(this.buttonShowStudent_Click);
            // 
            // buttonShowScores
            // 
            this.buttonShowScores.BackColor = System.Drawing.Color.Yellow;
            this.buttonShowScores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowScores.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonShowScores.Location = new System.Drawing.Point(1063, 12);
            this.buttonShowScores.Name = "buttonShowScores";
            this.buttonShowScores.Size = new System.Drawing.Size(191, 45);
            this.buttonShowScores.TabIndex = 32;
            this.buttonShowScores.Text = "Show Scores";
            this.buttonShowScores.UseVisualStyleBackColor = false;
            this.buttonShowScores.Click += new System.EventHandler(this.buttonShowScores_Click);
            // 
            // buttonAddManage
            // 
            this.buttonAddManage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddManage.Location = new System.Drawing.Point(93, 356);
            this.buttonAddManage.Name = "buttonAddManage";
            this.buttonAddManage.Size = new System.Drawing.Size(194, 54);
            this.buttonAddManage.TabIndex = 33;
            this.buttonAddManage.Text = "Add";
            this.buttonAddManage.UseVisualStyleBackColor = true;
            this.buttonAddManage.Click += new System.EventHandler(this.buttonAddManage_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(293, 356);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(194, 54);
            this.buttonRemove.TabIndex = 34;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAverage
            // 
            this.buttonAverage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAverage.Location = new System.Drawing.Point(93, 425);
            this.buttonAverage.Name = "buttonAverage";
            this.buttonAverage.Size = new System.Drawing.Size(394, 54);
            this.buttonAverage.TabIndex = 35;
            this.buttonAverage.Text = "Average Score By Course";
            this.buttonAverage.UseVisualStyleBackColor = true;
            this.buttonAverage.Click += new System.EventHandler(this.buttonAverage_Click);
            // 
            // buttonSaveMSWORD
            // 
            this.buttonSaveMSWORD.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveMSWORD.Location = new System.Drawing.Point(671, 486);
            this.buttonSaveMSWORD.Name = "buttonSaveMSWORD";
            this.buttonSaveMSWORD.Size = new System.Drawing.Size(275, 53);
            this.buttonSaveMSWORD.TabIndex = 36;
            this.buttonSaveMSWORD.Text = "Save Score To MS Word";
            this.buttonSaveMSWORD.UseVisualStyleBackColor = true;
            this.buttonSaveMSWORD.Click += new System.EventHandler(this.buttonSaveMSWORD_Click);
            // 
            // buttonSaveTextFile
            // 
            this.buttonSaveTextFile.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveTextFile.Location = new System.Drawing.Point(1011, 486);
            this.buttonSaveTextFile.Name = "buttonSaveTextFile";
            this.buttonSaveTextFile.Size = new System.Drawing.Size(275, 53);
            this.buttonSaveTextFile.TabIndex = 37;
            this.buttonSaveTextFile.Text = "Save Score To Text File";
            this.buttonSaveTextFile.UseVisualStyleBackColor = true;
            this.buttonSaveTextFile.Click += new System.EventHandler(this.buttonSaveTextFile_Click);
            // 
            // ManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1392, 553);
            this.Controls.Add(this.buttonSaveTextFile);
            this.Controls.Add(this.buttonSaveMSWORD);
            this.Controls.Add(this.buttonAverage);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddManage);
            this.Controls.Add(this.buttonShowScores);
            this.Controls.Add(this.buttonShowStudent);
            this.Controls.Add(this.dataGridViewManageScore);
            this.Controls.Add(this.comboBoxCourse);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxScore);
            this.Controls.Add(this.textBoxStudentID);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelSelectCourse);
            this.Controls.Add(this.labelStudentID);
            this.Name = "ManageScore";
            this.Text = "ManageScore";
            this.Load += new System.EventHandler(this.ManageScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManageScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.TextBox textBoxStudentID;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelSelectCourse;
        private System.Windows.Forms.Label labelStudentID;
        private System.Windows.Forms.Button buttonShowStudent;
        private System.Windows.Forms.Button buttonShowScores;
        private System.Windows.Forms.Button buttonAddManage;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAverage;
        public System.Windows.Forms.DataGridView dataGridViewManageScore;
        private System.Windows.Forms.Button buttonSaveMSWORD;
        private System.Windows.Forms.Button buttonSaveTextFile;
    }
}