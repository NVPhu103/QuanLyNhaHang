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
    public partial class EditContact : Form
    {
        public EditContact()
        {
            InitializeComponent();
        }
        int ContactID = 0;
        Contact contact = new Contact();
        Group group = new Group();
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
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
        bool verif()
        {
            if ((textBox_FirstName.Text.Trim() == "") || (textBox_LastName.Text.Trim() == "") || (textBox_Email.Text.Trim() == "") || (PictureBox.Image == null)
                || (textBox_Address.Text.Trim() == "") || (textBox_Phone.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = textBox_FirstName.Text;
                string lname = textBox_LastName.Text;
                int groupid = (int)comboBox_Group.SelectedValue;
                string phone = textBox_Phone.Text;
                string email = textBox_Email.Text;
                string address = textBox_Address.Text;
                MemoryStream pic = new MemoryStream();

                if (verif())
                {
                    PictureBox.Image.Save(pic, PictureBox.Image.RawFormat);
                    if (contact.ContactExist(ContactID))
                    {
                        if (contact.UpdateContact(ContactID, fname, lname, phone, address, email, groupid, pic))
                        {
                            MessageBox.Show("The Contact has been edited successfully", "EDIT CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Contact hasn't been edited successfully", "EDIT CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Contact doesn't exist", "EDIT CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void setContactID(int ID)
        {
            ContactID = ID;
        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            DataTable table = contact.GetContact(ContactID, Global.GlobalUserID);
            textBox_FirstName.Text = table.Rows[0][1].ToString();
            textBox_LastName.Text = table.Rows[0][2].ToString();
            textBox_Phone.Text= table.Rows[0][4].ToString();
            textBox_Email.Text = table.Rows[0][5].ToString();
            textBox_Address.Text = table.Rows[0][6].ToString();

            //image
            byte[] pic = (byte[])table.Rows[0][7];
            MemoryStream picture = new MemoryStream(pic);
            PictureBox.Image = Image.FromStream(picture);

            //combobox
            comboBox_Group.DataSource = group.getGroups(Global.GlobalUserID);
            comboBox_Group.DisplayMember = "groupname";
            comboBox_Group.ValueMember = "Id";
            comboBox_Group.SelectedValue = Convert.ToInt32(table.Rows[0][3].ToString());
        }

        private void comboBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
