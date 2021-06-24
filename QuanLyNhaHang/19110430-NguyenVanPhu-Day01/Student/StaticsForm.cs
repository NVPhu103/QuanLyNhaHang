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
    public partial class StaticsForm : Form
    {
        public StaticsForm()
        {
            InitializeComponent();
        }

        Color PanelTotalColor;
        Color PanelMaleColor;
        Color PanelFemaleColor;
        private void StaticsForm_Load(object sender, EventArgs e)
        {
            PanelTotalColor = PanelTotal.BackColor;
            PanelMaleColor = PanelMale.BackColor;
            PanelFemaleColor = PanelFemale.BackColor;

            Student student = new Student();
            double total = Convert.ToDouble(student.TotalStudent());
            double totalmale = Convert.ToDouble(student.MaleStudent());
            double totalfemale = Convert.ToDouble(student.FemaleStudent());
            double maleStudentsPercentage = ((totalmale / total) * 100);
            double femaleStudentsPercentage = ((totalfemale / total) * 100);

            labelTotal.Text = ("Total Students: " + total.ToString());
            labelMale.Text = ("Male: " + maleStudentsPercentage.ToString("0.00")+"%");
            labelFemale.Text = ("Female: " + femaleStudentsPercentage.ToString("0.00") + "%");

        }

        private void labelTotal_MouseEnter(object sender, EventArgs e)
        {
            labelTotal.ForeColor = PanelTotalColor;
            PanelTotal.BackColor = Color.White;
        }

        private void labelTotal_MouseLeave(object sender, EventArgs e)
        {
            labelTotal.ForeColor = Color.White;
            PanelTotal.BackColor = PanelTotalColor;
        }

        private void labelMale_MouseEnter(object sender, EventArgs e)
        {
            labelMale.ForeColor = PanelMaleColor;
            PanelMale.BackColor = Color.White;
        }

        private void labelMale_MouseLeave(object sender, EventArgs e)
        {
            labelMale.ForeColor = Color.White;
            PanelMale.BackColor = PanelMaleColor;
        }

        private void labelFemale_MouseEnter(object sender, EventArgs e)
        {
            labelFemale.ForeColor = PanelFemaleColor;
            PanelFemale.BackColor = Color.White;
        }

        private void labelFemale_MouseLeave(object sender, EventArgs e)
        {
            labelFemale.ForeColor = Color.White;
            PanelFemale.BackColor = PanelFemaleColor;
        }
    }
}
