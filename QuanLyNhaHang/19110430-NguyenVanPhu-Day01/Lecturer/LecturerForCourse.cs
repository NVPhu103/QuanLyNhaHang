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
    public partial class LecturerForCourse : Form
    {
        public LecturerForCourse()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        DataTable table = new DataTable();
        Lecturer lecturer = new Lecturer();
        Course course = new Course();
        private void LecturerForCourse_Load(object sender, EventArgs e)
        {
            
            table = contact.GetAllContact(Global.GlobalUserID);
            table.Columns.Add("fullname");
            for(int i = 0; i < table.Rows.Count; i++)
            {
                string fullname = Convert.ToString(table.Rows[i][1]) +" "+ Convert.ToString(table.Rows[i][2]);
                table.Rows[i]["fullname"] = fullname;
            }
            comboBox_Lecturer.DataSource = table;
            comboBox_Lecturer.DisplayMember = "fullname";
            comboBox_Lecturer.ValueMember = "Id";



            comboBox_CourseID.DataSource = course.getAllCourses();
            comboBox_CourseID.DisplayMember = "label";
            comboBox_CourseID.ValueMember = "Id";
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int course_id = (int)comboBox_CourseID.SelectedValue;
                int contactid = (int)comboBox_Lecturer.SelectedValue;
                if (!lecturer.LecturerExist(course_id))
                {
                    if (lecturer.InsertLecturer(contactid, Global.GlobalUserID, course_id))
                    {
                        MessageBox.Show("The lecturer has been added successfully", "ADD LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The lecturer HASN'T been added successfully", "ADD LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The lecturer already exists", "ADD LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {

            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int course_id = (int)comboBox_CourseID.SelectedValue;
                int contactid = (int)comboBox_Lecturer.SelectedValue;
                if (lecturer.LecturerExist(course_id))
                {
                    if (lecturer.UpdateLecturer(contactid, course_id,Global.GlobalUserID))
                    {
                        MessageBox.Show("The lecturer has been edited successfully", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The lecturer HASN'T been edited successfully", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The lecturer doesn't exists", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {

            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                int course_id = (int)comboBox_CourseID.SelectedValue;
                if(MessageBox.Show("Do you want to DELETE The Lecturer for the course","DELETE LECTURER",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (lecturer.LecturerExist(course_id))
                    {
                        if (lecturer.DeleteLecturer(course_id))
                        {
                            MessageBox.Show("The lecturer has been edited successfully", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The lecturer HASN'T been edited successfully", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The lecturer doesn't exists", "EDIT LECTURER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
            catch
            {

            }
        }
    }
}
