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
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
        }
        User user = new User();
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            string fname = textBoxFirstName.Text;
            string lname = textBoxLastName.Text;
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            MemoryStream pic = new MemoryStream();


            if (verif())
            {
                PictureBox_EditUser.Image.Save(pic, PictureBox_EditUser.Image.RawFormat);
                if (user.UsernameExist(username, "edit",Global.GlobalUserID))
                {
                    if (user.UpdatetUser(Global.GlobalUserID,fname, lname, username, password, pic))
                    {
                        MessageBox.Show("UPDATE SUCCESS", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("UPDATE FAILED", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This Username doesn't exist", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            DataTable table = user.getUserById(Global.GlobalUserID);
            textBoxFirstName.Text = table.Rows[0][1].ToString();
            textBoxLastName.Text = table.Rows[0][2].ToString();
            textBoxUserName.Text = table.Rows[0][3].ToString();
            textBoxPassword.Text = table.Rows[0][4].ToString();
            PictureBox_EditUser.SizeMode = PictureBoxSizeMode.StretchImage;
            byte[] pic = (byte[])table.Rows[0][5];
            MemoryStream picture = new MemoryStream(pic);
            PictureBox_EditUser.Image = Image.FromStream(picture);
        }

        bool verif()
        {
            if ((textBoxFirstName.Text.Trim() == "") || (textBoxLastName.Text.Trim() == "") || (textBoxUserName.Text.Trim() == "") || (textBoxPassword.Text.Trim() == "") || (PictureBox_EditUser.Image == null))
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
                PictureBox_EditUser.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
