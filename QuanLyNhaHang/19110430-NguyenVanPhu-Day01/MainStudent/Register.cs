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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            MemoryStream pic = new MemoryStream();
            

            if (verif())
            {
                PictureBox.Image.Save(pic, PictureBox.Image.RawFormat);
                if (!user.UsernameExist(username, "register"))
                {
                    if (user.InsertUser(fname, lname, username, password, pic))
                    {
                        MessageBox.Show("REGISTER SUCCESS", "Register User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("REGISTER FAILED", "Register User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                { 
                    MessageBox.Show("This Username already exist", "Register User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Register User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool verif()
        {
            if((textBoxFirstName.Text.Trim()=="") || (textBoxLastName.Text.Trim() == "") || (textBoxUserName.Text.Trim() == "") || (textBoxPassword.Text.Trim() == "") || (PictureBox.Image == null))
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
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBox.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
