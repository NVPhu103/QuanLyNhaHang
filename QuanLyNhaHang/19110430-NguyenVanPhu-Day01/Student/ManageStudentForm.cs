using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            fillGrid(command);
        }

        Student student = new Student();

        private void fillGrid (SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            labelTotalStudents.Text = "Total Students: " + dataGridView1.Rows.Count;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            StudentID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Phone.Text = "";
            Address.Text = "";
            PictureBoxStudent.Image = null;
            radioButtonMale.Checked = true;
            BirthDate.Value = DateTime.Now;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE CONCAT(fname,lname,address,phone) LIKE '%" + textBoxSearch.Text + "%'");
            fillGrid(command);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            int id = Convert.ToInt32(StudentID.Text);
            string fn = FirstName.Text;
            string ln = LastName.Text;
            string phone = Phone.Text;
            string address = Address.Text;
            DateTime bdate = BirthDate.Value;
            string gender = "Male";
            if(radioButtonFemale.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = BirthDate.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The student Age must be between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (verif())
            {
                PictureBoxStudent.Image.Save(pic, PictureBoxStudent.Image.RawFormat);
                if (student.InsertStudent(id, fn, ln, bdate, gender, phone, address, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = FirstName.Text;
            string lname = LastName.Text;
            DateTime bdate = BirthDate.Value;
            string phone = Phone.Text;
            string address = Address.Text;
            string gender = "Male";
            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = BirthDate.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The student Age must be between 10 and 100 year", "Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(StudentID.Text);
                    PictureBoxStudent.Image.Save(pic, PictureBoxStudent.Image.RawFormat);
                    if (student.UpdateStudent(id, fname, lname, bdate, gender, phone, address, pic))
                    {
                        MessageBox.Show("Student Information Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int StudentId = Convert.ToInt32(StudentID.Text);
                if (MessageBox.Show("Are you SURE you want to DELETE this student", "DELETE STUDENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.DeleteStudent(StudentId))
                    {
                        MessageBox.Show("Student Delete", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StudentID.Text = "";
                        FirstName.Text = "";
                        LastName.Text = "";
                        Address.Text = "";
                        Phone.Text = "";
                        BirthDate.Value = DateTime.Now;
                        PictureBoxStudent.Image = null;
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

        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SELECT Image(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                PictureBoxStudent.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = ("student_" + StudentID.Text);
            if((PictureBoxStudent.Image==null))
            {
                MessageBox.Show("No Image in the PictureBox");
            }
            else if((sfd.ShowDialog()==DialogResult.OK))
            {
                PictureBoxStudent.Image.Save((sfd.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }

        }

        bool verif()
        {
            if ((FirstName.Text.Trim() == "") || (LastName.Text.Trim() == "") || (Address.Text.Trim() == "") || (Phone.Text.Trim() == "") || (PictureBoxStudent.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            StudentID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            LastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            BirthDate.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;

            if(dataGridView1.CurrentRow.Cells[4].Value.ToString()=="Female")
            {
                radioButtonFemale.Checked = true;
            }
            else
            {
                radioButtonMale.Checked = true;
            }

            Phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Address.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            //image
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picCol = new MemoryStream(pic);
            PictureBoxStudent.Image = Image.FromStream(picCol);
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                buttonSearch_Click(sender, e);
                textBoxSearch.Clear();
                
            }
        }
    }
}
