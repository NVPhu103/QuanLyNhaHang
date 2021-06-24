using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
        Student student = new Student();
        Score score = new Score();
        private void Find_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(textBoxID.Text);
            SqlCommand command = new SqlCommand("SELECT Id, fname, lname, bdate, gender, phone, address, picture FROM Student WHERE Id = " + int.Parse(textBoxID.Text));
            DataTable table = student.getStudents(command);
            
            if(table.Rows.Count>0)
            {
                textBoxFName.Text = table.Rows[0]["fname"].ToString();
                textBoxLName.Text = table.Rows[0]["lname"].ToString();
                dateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                string gender = Convert.ToString(table.Rows[0]["gender"].ToString());
                if (gender == "Male      ")
                {
                    Male.Checked = true;
                    //Female.Checked = false;
                }
                else
                {
                    Female.Checked = true;
                    //Male.Checked = false;
                }
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxAddress.Text = table.Rows[0]["address"].ToString();
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
            }

        }

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = textBoxFName.Text;
            string lname = textBoxLName.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string gender = "Male";
            if(Female.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The student Age must be between 10 and 100 year", "Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(textBoxID.Text);
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (student.UpdateStudent(id, fname, lname, bdate, gender, phone, address, pic))
                    {
                        MessageBox.Show("Student Information Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                int StudentId = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you SURE you want to DELETE this student", "DELETE STUDENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.DeleteStudent(StudentId))
                    {
                        MessageBox.Show("Student Delete", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        score.DeleteScore(StudentId);
                        textBoxID.Text = "";
                        textBoxFName.Text = "";
                        textBoxLName.Text = "";
                        textBoxAddress.Text = "";
                        textBoxPhone.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student NOT delete", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg;*.png;*.gif|*.jpg;*.png;*.gif";
            if(opf.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        bool verif()
        {
            if((textBoxID.Text.Trim()=="") || (textBoxFName.Text.Trim() == "") || (textBoxLName.Text.Trim() == "") || (textBoxAddress.Text.Trim() == "") || (textBoxPhone.Text.Trim() == "") || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
