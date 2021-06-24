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
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        Student student = new Student();
        Course course = new Course();
        Score score = new Score();
        private void AddScore_Load(object sender, EventArgs e)
        {
            // lay thong tin all course
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";

            // lay thong tin student ra datagridview
            SqlCommand command = new SqlCommand("SELECT Id,fname,lname FROM Student");
            dataGridViewStudent.ReadOnly = true;
            dataGridViewStudent.AllowUserToAddRows = false;
            dataGridViewStudent.DataSource = student.getStudents(command);
        }

        private void dataGridViewStudent_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Text = dataGridViewStudent.CurrentRow.Cells[0].Value.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(textBoxStudentID.Text);
                int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue);
                float scoreValue = Convert.ToSingle(textBoxScore.Text);
                string description = textBoxDescription.Text;

                if(!score.StudentScoreExist(studentId,courseID))
                {
                    if(score.InsertScore(studentId,courseID,scoreValue,description))
                    {
                        MessageBox.Show("Student Score Inserted", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student Score NOT Inserted", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Score for this Course is already Set", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
