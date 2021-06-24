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
using Word = Microsoft.Office.Interop.Word;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class ManageScore : Form
    {
        public ManageScore()
        {
            InitializeComponent();
        }
        Student student = new Student();
        Score score = new Score();
        Course course = new Course();
        string check = "NO";
        int Student_ID;
        int Course_ID;
        
        private void ManageScore_Load(object sender, EventArgs e)
        {
            // lay thong tin all course
            comboBoxCourse.DataSource = course.getAllCourses();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "Id";
            //set dataGridView
            dataGridViewManageScore.ReadOnly = true;
            dataGridViewManageScore.AllowUserToAddRows = false;
        }

        private void buttonAverage_Click(object sender, EventArgs e)
        {
            load();
            dataGridViewManageScore.DataSource = score.getAVGScoreByCourse();
            check = "NO";
        }

        private void buttonShowStudent_Click(object sender, EventArgs e)
        {
            load();
            SqlCommand command = new SqlCommand("SELECT Id,fname,lname,gender FROM Student");
            dataGridViewManageScore.DataSource = student.getStudents(command);
            check = "Add Score";
        }

       
        private void buttonShowScores_Click(object sender, EventArgs e)
        {
            load();
            SqlCommand command = new SqlCommand("SELECT CS.Student_id,fname,lname,Course_id,label,Student_score FROM Student, (SELECT Student_id,Course_id,label,Student_score FROM Course,Score WHERE Course.Id=Score.Course_id ) AS CS WHERE Student.Id=CS.Student_id ORDER BY Student_id,Course_id ASC");
            dataGridViewManageScore.DataSource = score.getScore(command);
            check = "Remove Score";
        }

        private void dataGridViewManageScore_Click(object sender, EventArgs e)
        {
            if(check=="Add Score")
            {
                textBoxStudentID.Text = dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString();
            }
            else if(check=="Remove Score")
            {
                textBoxStudentID.Text = dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString();
                textBoxScore.Text = dataGridViewManageScore.CurrentRow.Cells[5].Value.ToString();

                // Lay ten Course
                /*SqlCommand command = new SqlCommand("SELECT label FROM Course WHERE Id=" + dataGridViewManageScore.CurrentRow.Cells[3].Value.ToString());
                DataTable table =course.getCourses(command);
                comboBoxCourse.Text = table.Rows[0][0].ToString();*/
                comboBoxCourse.Text = dataGridViewManageScore.CurrentRow.Cells[4].Value.ToString();
                //id student va course de xoa
                Student_ID = Convert.ToInt32(dataGridViewManageScore.CurrentRow.Cells[0].Value.ToString());
                Course_ID = Convert.ToInt32(dataGridViewManageScore.CurrentRow.Cells[3].Value.ToString());
            }
            else
            {
                check = "NO";
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (check != "Remove Score")
                {
                    MessageBox.Show("Please, Click Show Score and then choose one of courses!!!", "MANAGE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (score.StudentScoreExist(Student_ID, Course_ID))
                {
                    if (score.DeleteScore(Student_ID, Course_ID))
                    {
                        MessageBox.Show("Student Score Deleted", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonShowScores_Click(sender, e);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Student Score NOT Deleted", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Score for this Course of the Student is not Set", "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DELETE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddManage_Click(object sender, EventArgs e)
        {
            try
            {
                if (check != "Add Score")
                {
                    MessageBox.Show("Please, Click Show Student and then choose one of students!!!", "MANAGE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int studentId = Convert.ToInt32(textBoxStudentID.Text);
                    int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue);
                    float scoreValue = Convert.ToSingle(textBoxScore.Text);
                    string description = textBoxDescription.Text;
                    if (!score.StudentScoreExist(studentId, courseID))
                    {
                        if (score.InsertScore(studentId, courseID, scoreValue, description))
                        {
                            MessageBox.Show("Student Score Inserted", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Student Score NOT Inserted", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Score for this Course is already Set", "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ADD SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load()
        {
            textBoxStudentID.Text = "";
            textBoxScore.Text = "";
            textBoxDescription.Text = "";
        }

        private void buttonSaveTextFile_Click(object sender, EventArgs e)
        {
            if (check=="Remove Score")
            {
                String path = "D:\\LapTrinhWindown\\luufile" + @"\ManageScore.txt";
                using (var writer = new StreamWriter(path))
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }

                    for (int i = 0; i < dataGridViewManageScore.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridViewManageScore.Columns.Count; j++)
                        {
                            writer.Write("\t" + dataGridViewManageScore.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                        writer.WriteLine("");
                        writer.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                    }
                    MessageBox.Show("SAVED SUCCESSFULLY", "SAVE SCORE TO TEXT FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please, Click Show Score and then click Save!!!", "SAVE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonSaveMSWORD_Click(object sender, EventArgs e)
        {
            if (check == "Remove Score")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word Documents (*.docx)|*.docx";
                sfd.FileName = "ManageScore.docx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveMSWord(dataGridViewManageScore, sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Please, Click Show Score and then click Save!!!", "SAVE SCORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i <= ColumnCount -1; i++)
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
                    headerRange.Text = "STUDENT SCORE";
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
