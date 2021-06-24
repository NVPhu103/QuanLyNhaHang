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
using Word = Microsoft.Office.Interop.Word;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class PrintStudent : Form
    {
        public PrintStudent()
        {
            InitializeComponent();
        }

        Student std = new Student();
        private void Print_Load(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            fillGrid(command);
            if(radioButtonNo.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }    

        }

        public void fillGrid(SqlCommand command)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet2.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.qLSVDBDataSet2.Student);
            //SqlCommand command = new SqlCommand("SELECT * FROM Student");
            dataGridViewPrintForm.ReadOnly = true;
            DataGridViewImageColumn piCol = new DataGridViewImageColumn();
            dataGridViewPrintForm.RowTemplate.Height = 50;
            dataGridViewPrintForm.DataSource = std.getStudents(command);
            piCol = (DataGridViewImageColumn)dataGridViewPrintForm.Columns[7];
            piCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewPrintForm.AllowUserToAddRows = false;
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string query;
            if(radioButtonYes.Checked)
            {
                string date1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                if(radioButtonMale.Checked)
                {
                    query = "SELECT * FROM Student WHERE gender='Male' AND bdate BETWEEN '" + date1 + "' AND '" + date2 + "'";
                }
                else if(radioButtonFemale.Checked)
                {
                    query = "SELECT * FROM Student WHEWE gender='Female' AND bdate BETWEEN '" + date1 + "'AND'" + date2 + "'";
                }
                else
                {
                    query = "SELECT * FROM Student WHERE bdate BETWEEN '" + date1 + "'AND'" + date2 + "'";
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }
            else
            {
                if(radioButtonMale.Checked)
                {
                    query = "SELECT * FROM Student WHERE gender='Male'";
                }
                else if(radioButtonFemale.Checked)
                {
                    query = "SELECT * FROM Student WHERE gender='Female'";
                }
                else
                {
                    query = "SELECT * FROM Student";
                }

                command = new SqlCommand(query);
                fillGrid(command);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            String path = "D:\\LapTrinhWindown\\luufile" + @"\ListStudent.txt";
            using (var writer = new StreamWriter(path))
            {
                if(!File.Exists(path))
                {
                    File.Create(path);
                }

                DateTime bdate;

                for(int i=0;i<dataGridViewPrintForm.Rows.Count;i++)
                {
                    for(int j=0;j<dataGridViewPrintForm.Columns.Count-1;j++)
                    {
                        if(j==3)
                        {
                            bdate = Convert.ToDateTime(dataGridViewPrintForm.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                        }
                        else if(j==dataGridViewPrintForm.Columns.Count-2)
                        {
                            writer.Write("\t" + dataGridViewPrintForm.Rows[i].Cells[j].Value.ToString()+"\t"+"|");
                        }
                        else
                        {
                            writer.Write("\t" + dataGridViewPrintForm.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                MessageBox.Show("SAVED SUCCESSFULLY", "PRINTER TO TEXT FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void buttonSaveMSWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridViewPrintForm, sfd.FileName);
            }
        }

        public void Export_Data_To_Word (DataGridView dgv,string filename)
        {
            if(dgv.Rows.Count != 0)
            {
                int RowCount = dgv.Rows.Count;
                int ColumnCount = dgv.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int i = 0; i <= ColumnCount - 1; i++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, i] = dgv.Rows[r].Cells[i].Value;
                    }
                }

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int i = 0; i <= ColumnCount - 1; i++)
                    {
                        if (i == 3)
                        {
                            DateTime bdate = Convert.ToDateTime(DataArray[r,i].ToString());
                            oTemp = oTemp + bdate.ToString("dd-MM-yyyy") + "\t";
                        }
                        else
                        {
                            oTemp = oTemp + DataArray[r, i] + "\t";
                        }
                    }
                }

                //table format
                oRange.Text = oTemp;
                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount, Type.Missing, Type.Missing, ref ApplyBorders, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Time new roman";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                for (int i = 0; i <= ColumnCount - 1; i++) 
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, i + 1).Range.Text = dgv.Columns[i].HeaderText;
                }

                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach(Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "STUDENTS LIST";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save image
                for (r = 0; r <= RowCount - 1; r++)
                {
                    byte[] imgbyte = (byte[])dgv.Rows[r].Cells[7].Value;
                    MemoryStream Ms = new MemoryStream(imgbyte);
                    Image finalPic = (Image)(new Bitmap(Image.FromStream(Ms), new Size(70, 70)));
                    Clipboard.SetDataObject(finalPic);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 8).Range.Paste();
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 8).Range.InsertParagraph();
                }

                //save file 
                oDoc.SaveAs(filename);
                MessageBox.Show("Save file successfully", "SAVE FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
