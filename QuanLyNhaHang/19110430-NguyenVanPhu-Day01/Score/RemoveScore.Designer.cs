
namespace _19110430_NguyenVanPhu_Day01
{
    partial class RemoveScore
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
            this.dataGridViewRemoveScore = new System.Windows.Forms.DataGridView();
            this.buttonRemoveScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRemoveScore
            // 
            this.dataGridViewRemoveScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRemoveScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRemoveScore.Location = new System.Drawing.Point(77, 42);
            this.dataGridViewRemoveScore.Name = "dataGridViewRemoveScore";
            this.dataGridViewRemoveScore.RowHeadersWidth = 51;
            this.dataGridViewRemoveScore.RowTemplate.Height = 24;
            this.dataGridViewRemoveScore.Size = new System.Drawing.Size(849, 337);
            this.dataGridViewRemoveScore.TabIndex = 0;
            this.dataGridViewRemoveScore.Click += new System.EventHandler(this.dataGridViewRemoveScore_Click);
            // 
            // buttonRemoveScore
            // 
            this.buttonRemoveScore.BackColor = System.Drawing.Color.Red;
            this.buttonRemoveScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveScore.Location = new System.Drawing.Point(375, 385);
            this.buttonRemoveScore.Name = "buttonRemoveScore";
            this.buttonRemoveScore.Size = new System.Drawing.Size(253, 65);
            this.buttonRemoveScore.TabIndex = 1;
            this.buttonRemoveScore.Text = "Remove Score";
            this.buttonRemoveScore.UseVisualStyleBackColor = false;
            this.buttonRemoveScore.Click += new System.EventHandler(this.buttonRemoveScore_Click);
            // 
            // RemoveScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(986, 474);
            this.Controls.Add(this.buttonRemoveScore);
            this.Controls.Add(this.dataGridViewRemoveScore);
            this.Name = "RemoveScore";
            this.Text = "RemoveScore";
            this.Load += new System.EventHandler(this.RemoveScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemoveScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRemoveScore;
        private System.Windows.Forms.Button buttonRemoveScore;
    }
}