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
using Word = Microsoft.Office.Interop.Word;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class ShowCourseOfContact : Form
    {
        public ShowCourseOfContact()
        {
            InitializeComponent();
        }
        int ContactID;
        Lecturer lecturer = new Lecturer();
        Course course = new Course();
        Score score = new Score();
        Student student = new Student();
        public void getContactID(int cid)
        {
            ContactID = cid;
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowCourseOfContact_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_ShowCourseOfContact.ReadOnly = true;
                dataGridView_ShowCourseOfContact.AllowUserToAddRows = false;
                DataTable table = lecturer.getCourse_idByContactID(ContactID, Global.GlobalUserID);
                if (table.Rows.Count > 0)
                {
                    listBox_ShowCourseOfContact.DataSource = course.getCourseByID(table);
                    listBox_ShowCourseOfContact.DisplayMember = "label";
                    listBox_ShowCourseOfContact.ValueMember = "Id";
                    listBox_ShowCourseOfContact.SelectedItem = null;
                }
            }
            catch
            {

            }
        }

        private void listBox_ShowCourseOfContact_Click(object sender, EventArgs e)
        {
            try
            {
                int courseID = (int)listBox_ShowCourseOfContact.SelectedValue;
                DataTable table1 = score.getScoresByCourseID(courseID);
                DataTable table = new DataTable();
                string fullname = "";
                table.Columns.Add("Student ID");
                table.Columns.Add("Full name");
                table.Columns.Add("Score");
                table.Columns.Add("description");
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    fullname = student.fullnameStudent(Convert.ToInt32(table1.Rows[i][0]));
                    //DataRow dr;

                    table.Rows.Add();
                    table.Rows[i][0] = table1.Rows[i][0];
                    table.Rows[i][1] = fullname;
                    table.Rows[i][2] = table1.Rows[i][1];
                    table.Rows[i][3] = table1.Rows[i][2];

                }
                dataGridView_ShowCourseOfContact.DataSource = table;
            }
            catch
            {

            }
        }

        private void button_SaveTextFile_Click(object sender, EventArgs e)
        {
            String path = "D:\\LapTrinhWindown" + @"\ScoreOfStudentOfContact.txt";
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                for (int i = 0; i < dataGridView_ShowCourseOfContact.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_ShowCourseOfContact.Columns.Count - 1; j++)
                    { 
                        writer.Write("\t" + dataGridView_ShowCourseOfContact.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    writer.WriteLine("");
                    writer.WriteLine("---------------------------------------------------------");
                }
                MessageBox.Show("SAVED SUCCESSFULLY", "PRINTER TO TEXT FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_SaveMSWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "StudentClass.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveMSWord(dataGridView_ShowCourseOfContact, sfd.FileName);
            }
        }
        public void SaveMSWord(DataGridView DGV, string FileName)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int i = 0; i <= ColumnCount - 1; i++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, i] = DGV.Rows[r].Cells[i].Value;
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
                        oTemp = oTemp + DataArray[r, i] + "\t";
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
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                for (int i = 0; i <= ColumnCount - 1; i++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, i + 1).Range.Text = DGV.Columns[i].HeaderText;
                }

                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "STUDENT OF CLASS";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save file 
                oDoc.SaveAs(FileName);
                MessageBox.Show("Save file successfully", "SAVE FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
