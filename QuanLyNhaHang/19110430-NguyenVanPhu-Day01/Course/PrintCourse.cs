using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class PrintCourse : Form
    {
        public PrintCourse()
        {
            InitializeComponent();
        }
        Course course = new Course();
        private void PrintCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet3.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.qLSVDBDataSet3.Course);
            SqlCommand command = new SqlCommand("SELECT * FROM Course");
            dataGridViewPrint.ReadOnly = true;
            dataGridViewPrint.DataSource = course.getCourses(command);
            dataGridViewPrint.AllowUserToAddRows = false;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDlg = new PrintDialog();
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = "Print Document";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;

                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
            catch
            {

            }
        }

        private void buttonSaveText_Click(object sender, EventArgs e)
        {
            String path = "D:\\LapTrinhWindown\\luufile" + @"\ListCourse.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                

                for (int i = 0; i < dataGridViewPrint.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewPrint.Columns.Count ; j++)
                    {
                            writer.Write("\t" + dataGridViewPrint.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    writer.WriteLine("");
                    writer.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
                }
                MessageBox.Show("SAVED SUCCESSFULLY", "PRINTER TO TEXT FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
