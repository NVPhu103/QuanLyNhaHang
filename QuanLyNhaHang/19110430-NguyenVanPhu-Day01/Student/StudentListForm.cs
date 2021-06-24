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
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        Student student = new Student();
        
        //private readonly object stdTableAdapter;

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet1.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter1.Fill(this.qLSVDBDataSet1.Student);
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm UDSF = new UpdateDeleteStudentForm();
            UDSF.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            UDSF.textBoxFName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            UDSF.textBoxLName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           
            UDSF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            //gender
            if ((dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() == "Female"))
            {
                
                UDSF.Female.Checked = true;
            }
            else
            {
                UDSF.Male.Checked = true;
            }
            UDSF.textBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            UDSF.textBoxAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            UDSF.pictureBox1.Image = Image.FromStream(picture);
            this.Show();
            UDSF.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");

            dataGridView1.ReadOnly = true;      // nap lai du lieu len datagrid view

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            dataGridView1.DataSource = student.getStudents(command);

            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];

            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
