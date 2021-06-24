
namespace _19110430_NguyenVanPhu_Day01
{
    partial class RemoveCourse
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
            this.textBoxRemoveCID = new System.Windows.Forms.TextBox();
            this.labelCourseID = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRemoveCID
            // 
            this.textBoxRemoveCID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxRemoveCID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemoveCID.Location = new System.Drawing.Point(325, 80);
            this.textBoxRemoveCID.Multiline = true;
            this.textBoxRemoveCID.Name = "textBoxRemoveCID";
            this.textBoxRemoveCID.Size = new System.Drawing.Size(392, 32);
            this.textBoxRemoveCID.TabIndex = 6;
            // 
            // labelCourseID
            // 
            this.labelCourseID.AutoSize = true;
            this.labelCourseID.BackColor = System.Drawing.Color.SpringGreen;
            this.labelCourseID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourseID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCourseID.Location = new System.Drawing.Point(27, 80);
            this.labelCourseID.Name = "labelCourseID";
            this.labelCourseID.Size = new System.Drawing.Size(292, 32);
            this.labelCourseID.TabIndex = 5;
            this.labelCourseID.Text = "Enter The Course ID";
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonRemove.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.ForeColor = System.Drawing.Color.Navy;
            this.buttonRemove.Location = new System.Drawing.Point(723, 80);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(140, 32);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // RemoveCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.ClientSize = new System.Drawing.Size(875, 193);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textBoxRemoveCID);
            this.Controls.Add(this.labelCourseID);
            this.Name = "RemoveCourse";
            this.Text = "Remove Course";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRemoveCID;
        private System.Windows.Forms.Label labelCourseID;
        private System.Windows.Forms.Button buttonRemove;
    }
}