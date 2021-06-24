using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class RemoveScore : Form
    {
        public RemoveScore()
        {
            InitializeComponent();
        }
        Score score = new Score();
        private void RemoveScore_Load(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("SELECT CS.Student_id,fname,lname,Course_id,label,Student_score FROM Student, (SELECT Student_id,Course_id,label,Student_score FROM Course,Score WHERE Course.Id=Score.Course_id ) AS CS WHERE Student.Id=CS.Student_id ORDER BY Student_id,Course_id ASC");
            dataGridViewRemoveScore.ReadOnly = true;
            dataGridViewRemoveScore.AllowUserToAddRows = false;
            dataGridViewRemoveScore.DataSource = score.getScore(command);
        }
        int Student_ID;
        int Course_ID;
        private void dataGridViewRemoveScore_Click(object sender, EventArgs e)
        {
                Student_ID = Convert.ToInt32(dataGridViewRemoveScore.CurrentRow.Cells[0].Value.ToString());
                Course_ID = Convert.ToInt32(dataGridViewRemoveScore.CurrentRow.Cells[3].Value.ToString());
        }

        private void buttonRemoveScore_Click(object sender, EventArgs e)
        {
            try
            {
                if (score.StudentScoreExist(Student_ID, Course_ID))
                {
                    if (score.DeleteScore(Student_ID, Course_ID))
                    {
                        MessageBox.Show("Student Score Deleted", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RemoveScore_Load(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("Student Score NOT Deleted", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Score for this Course of the Student is not Set", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
