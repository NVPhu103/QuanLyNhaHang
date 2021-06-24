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
    public partial class EditCourse : Form
    {
        public EditCourse()
        {
            InitializeComponent();
        }

        Course course = new Course();

        private void buttonEditCourse_Click(object sender, EventArgs e)
        {
            string name = textBoxLable.Text;
            int hrs = (int)numericUpDownPeriod.Value;
            string descrip = textBoxDescription.Text;
            int id = (int)comboBoxCourse.SelectedValue;

            if(!course.checkCourseName(name,Convert.ToInt32(comboBoxCourse.SelectedValue)))
            {
                MessageBox.Show("This Course Name Already Exist", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(course.UpdateCourse(id,name,hrs,descrip))
            {
                MessageBox.Show("Course updated", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillCombo(comboBoxCourse.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Course Not Updated", "EDIT COURSE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet3.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet3.Course);
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";
            comboBoxCourse.SelectedItem = null;

        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBoxCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseByID(id);
                textBoxLable.Text = table.Rows[0][1].ToString();
                numericUpDownPeriod.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBoxDescription.Text = table.Rows[0][3].ToString();
            }
            catch
            {

            }
        }

        public void fillCombo(int index)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet3.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet3.Course);
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";
            comboBoxCourse.SelectedItem = index;
        }
    }
}
