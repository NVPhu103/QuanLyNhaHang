using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Course
    {
        MyDB mydb = new MyDB();

        public bool checkCourseName(string CourseName, int CourseId =0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE label=@CName AND Id<>@CID", mydb.getConnection);

            command.Parameters.Add("@CName", SqlDbType.VarChar).Value = CourseName;
            command.Parameters.Add("@CID", SqlDbType.Int).Value = CourseId;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = getCourses(command);
            if ((table.Rows.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertCourse(int CID,string label,int period,string descrip)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (Id, label, period, description)" + " VALUES (@id, @lb, @per, @des)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = CID;
            command.Parameters.Add("@lb", SqlDbType.VarChar).Value = label;
            command.Parameters.Add("@per", SqlDbType.Int).Value = period;
            command.Parameters.Add("@des", SqlDbType.Text).Value = descrip;
            

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

        public bool DeleteCourse(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE Id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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

        public bool UpdateCourse(int id, string label, int period, string descrip)
        {
            SqlCommand command = new SqlCommand("UPDATE Course SET label=@lb, period=@prd, description=@dct WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@lb", SqlDbType.VarChar).Value = label;
            command.Parameters.Add("@prd", SqlDbType.Int).Value = period;
            command.Parameters.Add("@dct", SqlDbType.Text).Value = descrip;
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
        public DataTable getCourses(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseByID(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE Id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            return getCourses(command);
        }
        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string TotalCourses()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(Id) FROM Course",mydb.getConnection);
            DataTable table = getCourses(command);
            return table.Rows[0][0].ToString();
        }
        public DataTable getCourseByID(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                string query = "SELECT * FROM Course WHERE Id = " + Convert.ToString(table.Rows[0][0].ToString());
                if (table.Rows.Count > 1)
                {
                    for(int i = 1; i < table.Rows.Count; i++)
                    {
                        query = query+" OR Id =" + Convert.ToString(table.Rows[i][0].ToString());
                    }
                }
                SqlCommand command = new SqlCommand(query, mydb.getConnection);
                return getCourses(command);
            }
            else
            {
                return table;
            }
            
        }
    }
}
