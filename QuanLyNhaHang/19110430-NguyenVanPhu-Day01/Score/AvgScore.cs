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
    public partial class AvgScore : Form
    {
        public AvgScore()
        {
            InitializeComponent();
        }
        Score score = new Score();
        private void AvgScore_Load(object sender, EventArgs e)
        {
            dataGridViewScore.ReadOnly = true;
            dataGridViewScore.AllowUserToAddRows = false;
            dataGridViewScore.DataSource = score.getAVGScoreByCourse();
        }
    }
}
