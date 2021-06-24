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
using Word = Microsoft.Office.Interop.Word;

namespace _19110430_NguyenVanPhu_Day01
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }
        Result result = new Result();
        Course course = new Course();
        Student student = new Student();
        int CountStudent = 0;
        int CountCourse = 0;
        DataTable Course;   //Course_ID and label
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            // thiet dat cho datagridview
            dataGridViewResult.ReadOnly = true;
            dataGridViewResult.AllowUserToAddRows = false;

            //ID,fname,lname Student
            dataGridViewResult.DataSource = result.getAllStudentResult();

            //Fill DataGridView
            FillDataGridView();

            
        }
        public void FillDataGridView()
        {
            //Add Course into DataGridView
            Course = result.getCourseResult();
            CountCourse = Convert.ToInt32(course.TotalCourses());
            Course = result.getCourseResult();          // fill id and label into Course Table
            for (int i = 0; i < CountCourse; i++)
            {
                //DataColumn DataCol = new DataColumn(Course.Rows[i][1].ToString());
                dataGridViewResult.Columns.Add(Course.Rows[i][0].ToString(), Course.Rows[i][1].ToString());
            }

            // ADD Average Score and Result Column
            dataGridViewResult.Columns.Add("Average Score", "Average Score");
            dataGridViewResult.Columns.Add("Result", "Result");
            

            // do du lieu vao DataGridView
            CountStudent = dataGridViewResult.Rows.Count;
            int TotalDataColumn = dataGridViewResult.Columns.Count;
            
            int Couse_id;
            int Student_id;
            float diem;
            float diemTB;           // diem trung binh cua cac khoa hoc ma hoc sinh nay hoc
            int CourseOfStudent;    // so khoa hoc ma hoc sinh nay hoc
            for (int i = 0; i < CountStudent; i++)
            {
                Student_id = Convert.ToInt32(dataGridViewResult.Rows[i].Cells[0].Value.ToString());
                CourseOfStudent = 0;
                diemTB = 0;
                for (int j = 3; j < TotalDataColumn - 2; j++)
                {

                    Couse_id = Convert.ToInt32(dataGridViewResult.Columns[j].Name.ToString());
                    diem = result.getScoreBy_SidCid(Student_id, Couse_id);
                    if (diem == -1)
                    {
                        dataGridViewResult.Rows[i].Cells[j].Value = "null";
                        
                    }
                    else
                    {
                        diemTB = diemTB + diem;
                        CourseOfStudent += 1;
                        dataGridViewResult.Rows[i].Cells[j].Value = diem;
                    }
                }
                diemTB = diemTB / CourseOfStudent;
                dataGridViewResult.Rows[i].Cells[TotalDataColumn - 2].Value = Math.Round(diemTB, 2);
                Classification(diemTB, dataGridViewResult, i, TotalDataColumn - 1);
            }
        }

        public void Classification(float diemTB,DataGridView DGV,int Row,int Cell)
        {
            if(diemTB<5)
            {
                DGV.Rows[Row].Cells[Cell].Value = "Yeu";
            }
            else if(diemTB>=5 && diemTB <6.5)
            {
                DGV.Rows[Row].Cells[Cell].Value = "Trung binh";
            }
            else if (diemTB >= 6.5 && diemTB < 8)
            {
                DGV.Rows[Row].Cells[Cell].Value = "Kha";
            }
            else if (diemTB >= 8 && diemTB < 9)
            {
                DGV.Rows[Row].Cells[Cell].Value = "Gioi";
            }
            else
            {
                DGV.Rows[Row].Cells[Cell].Value = "Xuat Sac";
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
                    headerRange.Text = "STUDENTS RESULT";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save file 
                oDoc.SaveAs(FileName);
                MessageBox.Show("Save file successfully", "SAVE FILE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "StudentsResult.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveMSWord(dataGridViewResult, sfd.FileName);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DeleteDataGridView(dataGridViewResult);         
            string search = textBoxSearch.Text;
            SqlCommand command = new SqlCommand("SELECT Id AS 'Student ID',fname AS 'First Name',lname AS 'Last Name' FROM Student WHERE CONCAT(Id,fname,lname) LIKE '%" + search+"%'");
            dataGridViewResult.DataSource = result.getStudentResult(command);
            FillDataGridView();
        }
        public void DeleteDataGridView(DataGridView DGV)
        {
            DGV.DataSource = null;              // xóa các cột sử dụng dataSource
            while(DGV.Columns.Count!=0)         // xóa các cột được add vào
            {
                DGV.Columns.RemoveAt(0);
            }
        }

        private void dataGridViewResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID.Text=Convert.ToString(dataGridViewResult.CurrentRow.Cells[0].Value.ToString());
            FirstName.Text = Convert.ToString(dataGridViewResult.CurrentRow.Cells[1].Value.ToString());
            LastName.Text = Convert.ToString(dataGridViewResult.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
