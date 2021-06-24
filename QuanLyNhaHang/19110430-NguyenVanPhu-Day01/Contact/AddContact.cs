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
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group group = new Group();
        private void AddContact_Load(object sender, EventArgs e)
        {
            comboBox_Group.DataSource = group.getGroups(Global.GlobalUserID);
            comboBox_Group.DisplayMember = "groupname";
            comboBox_Group.ValueMember = "Id";
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

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(textBox_ID.Text);
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
                    if (!contact.ContactExist(Id))
                    {
                        if (contact.InsertContact(Id, fname, lname, phone, address, email, Global.GlobalUserID, groupid, pic))
                        {
                            MessageBox.Show("The Contact has been added successfully", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Contact hasn't been added successfully", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Contact already exist", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        int goiy = contact.SupportAdd();
                        MessageBox.Show("You can use ID " + Convert.ToString(goiy) + " for contact", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ADD CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        bool verif()
        {
            if ((textBox_ID.Text.Trim() == "") || (textBox_FirstName.Text.Trim() == "") || (textBox_LastName.Text.Trim() == "") || (textBox_Email.Text.Trim() == "") || (PictureBox.Image == null)
                || (textBox_Address.Text.Trim() == "") || (textBox_Phone.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comboBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
