using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }
        
        private void AddCourse_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                int CourseId = Convert.ToInt32(textBoxCourseID.Text);
                string Label = textBoxLable.Text;
                int Period = Convert.ToInt32(textBoxPeriod.Text);
                string Descrip = textBoxDescription.Text;
                
                if (Period < 10)
                {
                    MessageBox.Show("Period must be greater than 10", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (verif())
                {
                    if (course.checkCourseName(Label))
                    {
                        if (course.InsertCourse(CourseId, Label, Period, Descrip))
                        {
                            MessageBox.Show("New Course Inserted", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
                        }
                        else
                        {
                            MessageBox.Show("Course Not Inserted", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Course Name Already Exists", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Course Not Inserted", "ADD COURSE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool verif()
        {
            if ((textBoxCourseID.Text.Trim() == "") || (textBoxPeriod.Text.Trim() == "") || (textBoxLable.Text.Trim() == "") || (textBoxDescription.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
