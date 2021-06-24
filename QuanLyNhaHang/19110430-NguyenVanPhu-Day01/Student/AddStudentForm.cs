using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            int id = Convert.ToInt32(StudentID.Text);
            string fname = FirstName.Text;
            string lname = LastName.Text;
            DateTime bdate = BirthDate.Value;
            string phone = Phone.Text;
            string address = Address.Text;
            string gender = "Male";
            if(radioButtonFemale.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = BirthDate.Value.Year;
            int this_year = DateTime.Now.Year;
            if(((this_year-born_year)<10)||((this_year-born_year)>100))
            {
                MessageBox.Show("The student Age must be between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (verif())
            {
                PictureBoxStudent.Image.Save(pic, PictureBoxStudent.Image.RawFormat);
                if(student.InsertStudent(id,fname,lname,bdate,gender,phone,address,pic))
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

        private void UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if((opf.ShowDialog()==DialogResult.OK))
            {
                PictureBoxStudent.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
