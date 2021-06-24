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
    public partial class StaticResult : Form
    {
        public StaticResult()
        {
            InitializeComponent();
        }
        Score score = new Score();
        Result result = new Result();
        Course course = new Course();
        Student student = new Student();
        int CountStudent = 0;
        int CountCourse = 0;
        DataTable Course;   //Course_ID and label
        int Yeu = 0;
        int Kha = 0;
        int Trungbinh = 0;
        int Gioi = 0;
        int XuatSac = 0;
        private void StaticResult_Load(object sender, EventArgs e)
        {
            dataGridView_StaticResult.ReadOnly = true;
            dataGridView_StaticResult.AllowUserToAddRows = false;
            dataGridView_StaticResult.DataSource = score.getAVGScoreByCourse();
            int x =50;
            int y =100;
            for(int i = 0; i < dataGridView_StaticResult.Rows.Count; i++)
            {
                CreateLabel(x, y, i);
                y += 30;
            }

            dataGridView_StaticResult.DataSource = null;
            dataGridView_StaticResult.DataSource = result.getAllStudentResult();
            FillDataGridView();
            label_Yeu.Text = "Yeu: " + Yeu;
            label_TrungBinh.Text = "Trung Binh: " + Trungbinh;
            label_Kha.Text = "Kha: " + Kha;
            label_Gioi.Text = "Gioi: " + Gioi;
            label_XuatSac.Text = "Xuat Sac: " + XuatSac;


            //bieu do
            chart_Result.Series["ChartResult"].Points.Add(Yeu);
            chart_Result.Series["ChartResult"].Points[0].Label = "Yeu: " + Convert.ToString(Yeu);
            chart_Result.Series["ChartResult"].Points[0].Color = Color.Red;
            chart_Result.Series["ChartResult"].Points[0].AxisLabel = "Yeu: ";
            
            
            chart_Result.Series["ChartResult"].Points.Add(Trungbinh);
            chart_Result.Series["ChartResult"].Points[1].Label = "TB: " + Convert.ToString(Trungbinh);
            chart_Result.Series["ChartResult"].Points[1].Color = Color.Brown;
            chart_Result.Series["ChartResult"].Points[1].AxisLabel = "Trung Binh: ";

            chart_Result.Series["ChartResult"].Points.Add(Kha);
            chart_Result.Series["ChartResult"].Points[2].Label = "Kha: " + Convert.ToString(Kha);
            chart_Result.Series["ChartResult"].Points[2].Color = Color.Green;
            chart_Result.Series["ChartResult"].Points[2].AxisLabel = "Kha: ";

            chart_Result.Series["ChartResult"].Points.Add(Gioi);
            chart_Result.Series["ChartResult"].Points[3].Label = "Gioi: "+ Convert.ToString(Gioi);
            chart_Result.Series["ChartResult"].Points[3].Color = Color.Blue;
            chart_Result.Series["ChartResult"].Points[3].AxisLabel = "Gioi: ";

            chart_Result.Series["ChartResult"].Points.Add(XuatSac);
            chart_Result.Series["ChartResult"].Points[4].Label = "Xuat Sac: " + Convert.ToString(XuatSac);
            chart_Result.Series["ChartResult"].Points[4].Color = Color.Yellow;
            chart_Result.Series["ChartResult"].Points[4].AxisLabel = "Xuat Sac: ";
        }
        public void CreateLabel(int x,int y,int i)
        {
            Label lb = new Label();
            string lbtext= Convert.ToString(dataGridView_StaticResult.Rows[i].Cells[0].Value) + ": " + Convert.ToSingle(dataGridView_StaticResult.Rows[i].Cells[1].Value);
            lb.Text = lbtext;
            this.Controls.Add(lb);
            lb.BackColor = Color.DimGray;
            lb.ForeColor = Color.Black;
            lb.AutoSize = true;
            lb.Location = new Point(x, y);
            lb.Font = new Font("Arial Rounded MT Bold", 14);
        }

        public void Classification(float diemTB, DataGridView DGV, int Row, int Cell)
        {
            if (diemTB < 5)
            {
                Yeu += 1;
                DGV.Rows[Row].Cells[Cell].Value = "Yeu";
            }
            else if (diemTB >= 5 && diemTB < 6.5)
            {
                Trungbinh += 1;
                DGV.Rows[Row].Cells[Cell].Value = "Trung binh";
            }
            else if (diemTB >= 6.5 && diemTB < 8)
            {
                Kha += 1;
                DGV.Rows[Row].Cells[Cell].Value = "Kha";
            }
            else if (diemTB >= 8 && diemTB < 9)
            {
                Gioi += 1;
                DGV.Rows[Row].Cells[Cell].Value = "Gioi";
            }
            else
            {
                XuatSac += 1;
                DGV.Rows[Row].Cells[Cell].Value = "Xuat Sac";
            }
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
                dataGridView_StaticResult.Columns.Add(Course.Rows[i][0].ToString(), Course.Rows[i][1].ToString());
            }

            // ADD Average Score and Result Column
            dataGridView_StaticResult.Columns.Add("Average Score", "Average Score");
            dataGridView_StaticResult.Columns.Add("Result", "Result");


            // do du lieu vao DataGridView
            CountStudent = dataGridView_StaticResult.Rows.Count;
            int TotalDataColumn = dataGridView_StaticResult.Columns.Count;

            int Couse_id;
            int Student_id;
            float diem;
            float diemTB;           // diem trung binh cua cac khoa hoc ma hoc sinh nay hoc
            int CourseOfStudent;    // so khoa hoc ma hoc sinh nay hoc
            for (int i = 0; i < CountStudent; i++)
            {
                Student_id = Convert.ToInt32(dataGridView_StaticResult.Rows[i].Cells[0].Value.ToString());
                CourseOfStudent = 0;
                diemTB = 0;
                for (int j = 3; j < TotalDataColumn - 2; j++)
                {

                    Couse_id = Convert.ToInt32(dataGridView_StaticResult.Columns[j].Name.ToString());
                    diem = result.getScoreBy_SidCid(Student_id, Couse_id);
                    if (diem == -1)
                    {
                        dataGridView_StaticResult.Rows[i].Cells[j].Value = "null";

                    }
                    else
                    {
                        diemTB = diemTB + diem;
                        CourseOfStudent += 1;
                        dataGridView_StaticResult.Rows[i].Cells[j].Value = diem;
                    }
                }
                diemTB = diemTB / CourseOfStudent;
                dataGridView_StaticResult.Rows[i].Cells[TotalDataColumn - 2].Value = Math.Round(diemTB, 2);
                Classification(diemTB, dataGridView_StaticResult, i, TotalDataColumn - 1);
            }
        }
    }
}
