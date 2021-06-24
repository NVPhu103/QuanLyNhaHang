
namespace _19110430_NguyenVanPhu_Day01
{
    partial class LecturerForCourse
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
            this.comboBox_Lecturer = new System.Windows.Forms.ComboBox();
            this.label_Lecturer = new System.Windows.Forms.Label();
            this.comboBox_CourseID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Lecturer
            // 
            this.comboBox_Lecturer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Lecturer.FormattingEnabled = true;
            this.comboBox_Lecturer.Location = new System.Drawing.Point(285, 188);
            this.comboBox_Lecturer.Name = "comboBox_Lecturer";
            this.comboBox_Lecturer.Size = new System.Drawing.Size(390, 31);
            this.comboBox_Lecturer.TabIndex = 13;
            // 
            // label_Lecturer
            // 
            this.label_Lecturer.AutoSize = true;
            this.label_Lecturer.BackColor = System.Drawing.SystemColors.Highlight;
            this.label_Lecturer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Lecturer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Lecturer.Location = new System.Drawing.Point(106, 188);
            this.label_Lecturer.Name = "label_Lecturer";
            this.label_Lecturer.Size = new System.Drawing.Size(134, 32);
            this.label_Lecturer.TabIndex = 12;
            this.label_Lecturer.Text = "Lecturer";
            // 
            // comboBox_CourseID
            // 
            this.comboBox_CourseID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_CourseID.FormattingEnabled = true;
            this.comboBox_CourseID.Location = new System.Drawing.Point(285, 115);
            this.comboBox_CourseID.Name = "comboBox_CourseID";
            this.comboBox_CourseID.Size = new System.Drawing.Size(390, 31);
            this.comboBox_CourseID.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(89, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Course ID";
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.ForeColor = System.Drawing.Color.Lime;
            this.button_Add.Location = new System.Drawing.Point(111, 297);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(129, 52);
            this.button_Add.TabIndex = 16;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Edit.ForeColor = System.Drawing.Color.Orange;
            this.button_Edit.Location = new System.Drawing.Point(285, 297);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(129, 52);
            this.button_Edit.TabIndex = 17;
            this.button_Edit.Text = "Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove.ForeColor = System.Drawing.Color.Blue;
            this.button_Remove.Location = new System.Drawing.Point(463, 297);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(129, 52);
            this.button_Remove.TabIndex = 18;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.Red;
            this.button_cancel.Location = new System.Drawing.Point(643, 297);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(129, 52);
            this.button_cancel.TabIndex = 19;
            this.button_cancel.Text = "cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // LecturerForCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.comboBox_CourseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Lecturer);
            this.Controls.Add(this.label_Lecturer);
            this.Name = "LecturerForCourse";
            this.Text = "LecturerForCourse";
            this.Load += new System.EventHandler(this.LecturerForCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Lecturer;
        private System.Windows.Forms.Label label_Lecturer;
        private System.Windows.Forms.ComboBox comboBox_CourseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_cancel;
    }
}