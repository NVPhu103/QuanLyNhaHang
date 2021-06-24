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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm ASF = new AddStudentForm();
            ASF.Show(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentListForm SList = new StudentListForm();
            SList.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm SF = new StaticsForm();
            SF.Show(this);
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm ManageSF = new ManageStudentForm();
            ManageSF.Show(this);
        }

        private void printStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudent print = new PrintStudent();
            print.Show(this);
        }

        private void AddCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse AddCourse = new AddCourse();
            AddCourse.Show(this);
        }

        private void removeCouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourse RC = new RemoveCourse();
            RC.Show(this);
        }

        private void editCouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourse EC = new EditCourse();
            EC.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCoursesForm MCF = new ManageCoursesForm();
            MCF.Show(this);
        }

        private void printCourseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourse PC = new PrintCourse();
            PC.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScore AC = new AddScore();
            AC.Show(this);
        }

        private void avgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgScore AS = new AvgScore();
            AS.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScore RS = new RemoveScore();
            RS.Show(this);
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageScore MS = new ManageScore();
            MS.Show(this);
        }

        private void aVGResultByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm RF = new ResultForm();
            RF.Show(this);
        }

        private void addLecturerForCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LecturerForCourse LFC = new LecturerForCourse();
            LFC.Show(this);
        }

        private void staticResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticResult SR = new StaticResult();
            SR.Show(this);
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm YDSF = new UpdateDeleteStudentForm();
            YDSF.Show(this);
        }
    }
}
