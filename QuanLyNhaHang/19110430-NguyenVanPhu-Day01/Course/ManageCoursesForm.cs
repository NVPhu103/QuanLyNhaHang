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
    public partial class ManageCoursesForm : Form
    {
        public ManageCoursesForm()
        {
            InitializeComponent();
        }

        Course course = new Course();
        int pos;



        private void ManageCoursesForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        void reloadListBoxData()
        {
            ListBoxCourse.DataSource = course.getAllCourses();
            ListBoxCourse.ValueMember = "Id";
            ListBoxCourse.DisplayMember = "label";
            ListBoxCourse.SelectedItem = null;

            labelTotal.Text = ("Total Courses: " + course.TotalCourses());
        }

        void showData(int index)
        {
            DataRow dr = course.getAllCourses().Rows[index];
            ListBoxCourse.SelectedIndex = index;
            textBoxID.Text = dr.ItemArray[0].ToString();
            textBoxLable.Text = dr.ItemArray[1].ToString();
            numericUpDownPeriod.Value = int.Parse(dr.ItemArray[2].ToString());
            textBoxDescription.Text = dr.ItemArray[3].ToString();
        }
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pos < (course.getAllCourses().Rows.Count - 1))
            {
                pos = pos + 1;
                showData(pos);
            }
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if(pos>0)
            {
                pos = pos - 1;
                showData(pos);
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            pos = course.getAllCourses().Rows.Count - 1;
            showData(pos);
        }

        private void ListBoxCourse_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)ListBoxCourse.SelectedItem;
            pos = ListBoxCourse.SelectedIndex;
            showData(pos);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                int CourseId = Convert.ToInt32(textBoxID.Text);
                string Label = textBoxLable.Text;
                int Period = Convert.ToInt32(numericUpDownPeriod.Value);
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
                            textBoxID.Clear();
                            textBoxLable.Clear();
                            textBoxDescription.Clear();
                            numericUpDownPeriod.Value = 15;
                            reloadListBoxData();
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
            if ((textBoxID.Text.Trim() == "") || (textBoxLable.Text.Trim() == "") || (textBoxDescription.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name = textBoxLable.Text;
            int hrs = (int)numericUpDownPeriod.Value;
            string descrip = textBoxDescription.Text;
            int id = Convert.ToInt32(textBoxID.Text.ToString());

            if (!course.checkCourseName(name, id))
            {
                MessageBox.Show("This Course Name Already Exist", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (course.UpdateCourse(id, name, hrs, descrip))
            {
                MessageBox.Show("Course updated", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadListBoxData();
            }
            else
            {
                MessageBox.Show("Course Not Updated", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pos = 0;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int CourseID = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you SURE you want to DELETE this course", "DELETE COURSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (course.DeleteCourse(CourseID))
                    {
                        MessageBox.Show("Course Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxID.Clear();
                        textBoxLable.Clear();
                        textBoxDescription.Clear();
                        numericUpDownPeriod.Value = 15;
                        reloadListBoxData();
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
            pos = 0;
        }
    }
}
