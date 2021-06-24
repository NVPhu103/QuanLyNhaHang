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
    public partial class RemoveCourse : Form
    {
        public RemoveCourse()
        {
            InitializeComponent();
        }
        Course course = new Course();

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int CourseID = Convert.ToInt32(textBoxRemoveCID.Text);
                if (MessageBox.Show("Are you SURE you want to DELETE this course", "DELETE COURSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (course.DeleteCourse(CourseID))
                    {
                        MessageBox.Show("Course Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxRemoveCID.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Course NOT deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
