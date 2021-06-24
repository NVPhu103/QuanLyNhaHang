using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new StudentListForm());
            Form1 loginForm = new Form1();
            while(loginForm.ShowDialog()==DialogResult.OK)
            {
                if(Global.Status == "Student")
                {
                    Application.Run(new Main());
                }
                else if (Global.Status == "HR")
                {
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
