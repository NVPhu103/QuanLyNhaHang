using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Score
    {
        MyDB mydb = new MyDB();

        public bool InsertScore(int S_id,int C_id,float score,string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (Student_id,Course_id,Student_score,description) VALUES (@sid,@cid,@scr"+",@descrip)", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = S_id;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = C_id;
            command.Parameters.Add("@scr", SqlDbType.Float).Value = Math.Round(Convert.ToSingle(score),2);
            command.Parameters.Add("@descrip", SqlDbType.Text).Value = description;
            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool StudentScoreExist(int studentID,int CourseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Score WHERE Student_id = @sid AND Course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = CourseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable getAVGScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Course.label,AVG(Score.Student_score) AS AverageGrade FROM Course,Score WHERE Course.Id=Score.Course_id GROUP BY Course.label";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for(int i=0;i<table.Rows.Count;i++)
            {
                table.Rows[i][1] = Math.Round(Convert.ToSingle(table.Rows[i][1].ToString()), 2);
            }
            return table;
        }
        public bool DeleteScore (int Student_ID,int Course_ID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE Student_id=@SID AND Course_id=@CID", mydb.getConnection);
            command.Parameters.Add("@SID", SqlDbType.Int).Value = Student_ID;
            command.Parameters.Add("@CID", SqlDbType.Int).Value = Course_ID;
            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteScore(int Student_ID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE Student_id=@SID", mydb.getConnection);
            command.Parameters.Add("@SID", SqlDbType.Int).Value = Student_ID;
            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getScore(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllScores()
        {
            SqlCommand command = new SqlCommand("SELECT (*) FROM Score");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void getStudentScores()
        {

        }
        public DataTable getScoresByCourseID(int CourseID)
        {
            SqlCommand command = new SqlCommand("SELECT Student_id,Student_score,description FROM Score WHERE Course_id=@cid");
            command.Connection = mydb.getConnection;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = CourseID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


    }
}
