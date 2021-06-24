using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19110430_NguyenVanPhu_Day01
{
    class Result
    {
        MyDB mydb = new MyDB();

        public DataTable getAllStudentResult()
        {
            SqlCommand command = new SqlCommand("SELECT Id AS 'Student ID',fname AS 'First Name',lname AS 'Last Name' FROM Student");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getStudentResult(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getCourseResult()
        {
            SqlCommand command = new SqlCommand("SELECT Id,label FROM Course ORDER BY Id");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public float getScoreBy_SidCid(int Student_id,int Course_id)
        {
            try
            {
                SqlCommand commnad = new SqlCommand("SELECT Student_score FROM Score WHERE Student_id=@Sid AND Course_id=@Cid;");
                commnad.Parameters.Add("@Sid", SqlDbType.Int).Value = Student_id;
                commnad.Parameters.Add("@Cid", SqlDbType.Int).Value = Course_id;
                commnad.Connection = mydb.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(commnad);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return Convert.ToSingle(table.Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }
        }

        
    }
}
