using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("d:/user.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void TextBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void bt_Login_Click(object sender, EventArgs e)
        {
            if (radioButton_Student.Checked)
            {
                Global.Status = "Student";
            }
            else
            {
                Global.Status = "HR";
            }
            MyDB mydb = new MyDB();

            SqlDataAdapter adapter = new SqlDataAdapter();
            
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM Hr WHERE username = @User AND password = @Pass", mydb.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUserName.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            if(table.Rows.Count>0)
            {
                this.DialogResult = DialogResult.OK;
                Global.SetGlobalUserID(Convert.ToInt32(table.Rows[0][0]));
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "LOGIN ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void labelRegister_Click(object sender, EventArgs e)
        {
            Register registerform = new Register();
            registerform.Show(this);
        }

        private void labelRegister_MouseEnter(object sender, EventArgs e)
        {
            labelRegister.ForeColor = Color.DodgerBlue;
        }

        private void labelRegister_MouseLeave(object sender, EventArgs e)
        {
            labelRegister.ForeColor = Color.Black;
        }
    }
}
