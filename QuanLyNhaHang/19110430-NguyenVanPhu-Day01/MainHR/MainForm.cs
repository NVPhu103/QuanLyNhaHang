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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        Group group = new Group();
        string groupname = "";
        Contact contact = new Contact();
        Lecturer lecturer = new Lecturer();
        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Hr WHERE Id=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Global.GlobalUserID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            pictureBox_User.SizeMode = PictureBoxSizeMode.StretchImage;
            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox_User.Image = Image.FromStream(picture);
                label_Username.Text = "Welcome back " + table.Rows[0]["fname"].ToString()+" " + table.Rows[0]["lname"].ToString();
            }

            //tao duong ke doc
            label_Line.AutoSize = false;
            label_Line.Width = 10;
            label_Line.Height = 400;
            label_Line.BorderStyle = BorderStyle.Fixed3D;

            //tao combobox
            FillCombobox();
        }
        private void FillCombobox()
        {
            
            //remove
            comboBox_SelectGroupRemove.DataSource = group.getGroups(Global.GlobalUserID);
            comboBox_SelectGroupRemove.DisplayMember = "groupname";
            comboBox_SelectGroupRemove.ValueMember = "Id";
            
            //edit
            comboBox_SelectGroupEdit.DataSource = group.getGroups(Global.GlobalUserID);
            comboBox_SelectGroupEdit.DisplayMember = "groupname";
            comboBox_SelectGroupEdit.ValueMember = "Id";

            comboBox_SelectContact.DataSource = contact.GetAllContact(Global.GlobalUserID);
            comboBox_SelectContact.DisplayMember = "Id";
            comboBox_SelectContact.ValueMember = "Id";

            comboBox_SelectContact.SelectedItem = null;
            comboBox_SelectGroupRemove.SelectedItem = null;
            comboBox_SelectGroupEdit.SelectedItem = null;
            textBox_GroupNameEdit.Clear();
        }

        private void label_editUser_MouseEnter(object sender, EventArgs e)
        {
            label_editUser.ForeColor = Color.DodgerBlue;
        }

        private void label_editUser_MouseLeave(object sender, EventArgs e)
        {
            label_editUser.ForeColor=Color.Black;
        }

        private void label_Refresh_MouseEnter(object sender, EventArgs e)
        {
            label_Refresh.ForeColor = Color.DodgerBlue;
        }

        private void label_Refresh_MouseLeave(object sender, EventArgs e)
        {
            label_Refresh.ForeColor = Color.Black;
        }

        private void label_Logout_MouseEnter(object sender, EventArgs e)
        {
            label_Logout.ForeColor = Color.DodgerBlue;
        }

        private void label_Logout_MouseLeave(object sender, EventArgs e)
        {
            label_Logout.ForeColor = Color.Black;
        }

        private void label_Logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label_editUser_Click(object sender, EventArgs e)
        {
            EditUserForm EUF = new EditUserForm();
            EUF.Show(this);
        }

        private void label_Refresh_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender,e);
        }

        private void button_AddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string groupname = textBox_GroupNameAdd.Text;
                if (groupname != "")
                {
                    if (!group.groupExist(groupname, "add", Global.GlobalUserID))
                    {
                        if (group.InsertGroup(groupname, Global.GlobalUserID))
                        {
                            MessageBox.Show("The group has been added successfully", "ADD GROUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillCombobox();
                            textBox_GroupNameAdd.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Add group failed", "ADD GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The group already exists", "ADD GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The group name is empty", "ADD GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
            
        }

        private void button_RemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int groupID = Convert.ToInt32(comboBox_SelectGroupRemove.SelectedValue);
                if (MessageBox.Show("Do you want to delete group ?", "DELETE GROUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (group.DeleteGroup(groupID))
                    {
                        MessageBox.Show("The group has been deleted successfully", "DELETE GROUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        group.SupportDelete(groupID);
                        FillCombobox();
                    }
                    else
                    {
                        MessageBox.Show("Delete group failed", "DELETE GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {

            }
        }

        private void button_EditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int groupID = Convert.ToInt32(comboBox_SelectGroupEdit.SelectedValue.ToString());
                string newgroupname = textBox_GroupNameEdit.Text;
                if (newgroupname != "")
                {
                    if (group.groupExist(groupname,"edit",Global.GlobalUserID,groupID))
                    {
                        if (group.UpdateGroup(groupID,newgroupname))
                        {
                            MessageBox.Show("The group has been edited successfully", "EDIT GROUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillCombobox();
                        }
                        else
                        {
                            MessageBox.Show("Edit group failed", "EDIT GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The group doesn't exists", "EDIT GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The group name is empty", "EDIT GROUP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                
            }
        }

        private void comboBox_SelectGroupEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int groupID = Convert.ToInt32(comboBox_SelectGroupEdit.SelectedValue);
                DataTable table = group.getGroups(groupID, Global.GlobalUserID);
                textBox_GroupNameEdit.Text = table.Rows[0][1].ToString();
                groupname = textBox_GroupNameEdit.Text;
            }
            catch
            {
                
            }
            
        }

        

        private void button_AddContact_Click(object sender, EventArgs e)
        {
            AddContact AC = new AddContact();
            AC.Show(this);
        }

        private void comboBox_SelectContact_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_EditContact_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = (int)comboBox_SelectContact.SelectedValue;
                EditContact ED = new EditContact();
                ED.setContactID(Id);
                ED.Show(this);
            }
            catch
            {
                MessageBox.Show("Pleas choose one of all ID", "EDIT CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_RemoveContact_Click(object sender, EventArgs e)
        {
            try
            {
                int contactid = (int)comboBox_SelectContact.SelectedValue;
                if (MessageBox.Show("Do you want to REMOVE this contact","REMOVE CONTACT",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (contact.ContactExist(contactid))
                    {
                        if (contact.DeleteContact(contactid))
                        {
                            MessageBox.Show("This contact has been deleted ", "REMOVE CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lecturer.DeleteLecturerByContactID(contactid);
                            label_Refresh_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("This contact HASN'T been deleted ", "REMOVE CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This contact doesn't exist", "REMOVE CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
               
                
            }
            catch
            {
                MessageBox.Show("Pleas choose one of all ID", "REMOVE CONTACT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_ShowListContact_Click(object sender, EventArgs e)
        {
            ShowContactForm SCF = new ShowContactForm();
            SCF.Show(this);
        }

    }
}
