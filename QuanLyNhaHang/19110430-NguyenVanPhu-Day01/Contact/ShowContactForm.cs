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
    public partial class ShowContactForm : Form
    {
        public ShowContactForm()
        {
            InitializeComponent();
        }
        Group group = new Group();
        Contact contact = new Contact();
        private void ShowContactForm_Load(object sender, EventArgs e)
        {
            listBox_ShowGroup.DataSource = group.getGroups(Global.GlobalUserID);
            listBox_ShowGroup.DisplayMember = "groupname";
            listBox_ShowGroup.ValueMember = "Id";
            listBox_ShowGroup.SelectedItem = null;

            dataGridView_ShowlistContact.ReadOnly = true;
            dataGridView_ShowlistContact.AllowUserToAddRows = false;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView_ShowlistContact.RowTemplate.Height = 80;
            dataGridView_ShowlistContact.DataSource = contact.getShowAllContact(Global.GlobalUserID);
            //picture
            
            picCol = (DataGridViewImageColumn)dataGridView_ShowlistContact.Columns["picture"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox_ShowGroup_Click(object sender, EventArgs e)
        {
            dataGridView_ShowlistContact.DataSource = contact.getShowContact(Global.GlobalUserID, (int)listBox_ShowGroup.SelectedValue);

        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            dataGridView_ShowlistContact.DataSource = null;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView_ShowlistContact.RowTemplate.Height = 80;
            dataGridView_ShowlistContact.DataSource = contact.getShowAllContact(Global.GlobalUserID);
            picCol = (DataGridViewImageColumn)dataGridView_ShowlistContact.Columns["picture"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            listBox_ShowGroup.SelectedItem = null;
        }

        private void dataGridView_ShowlistContact_Click(object sender, EventArgs e)
        {
            int contactid=Convert.ToInt32(dataGridView_ShowlistContact.CurrentRow.Cells[0].Value);
            ShowCourseOfContact SCOC = new ShowCourseOfContact();
            SCOC.getContactID(contactid);
            SCOC.Show(this);
        }
    }
}
