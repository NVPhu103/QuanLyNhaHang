using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Lecturer
    {
        MyDB mydb = new MyDB();

        public bool InsertLecturer(int id, int userid, int course_id)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Lecturer (contact_id, course_id, userid)" + "VALUES (@id,@cid, @uid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = course_id;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

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
        public bool LecturerExist(int course_id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Lecturer WHERE course_id=@cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = course_id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateLecturer(int id, int course_id,int userid)
        {
            SqlCommand command = new SqlCommand("UPDATE Lecturer SET contact_id=@id, userid=@uid WHERE course_id=@cid", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = course_id;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

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
        public bool DeleteLecturer(int course_id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Lecturer WHERE course_id=@cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = course_id;

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
        public bool DeleteLecturerByContactID(int contactid)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Lecturer WHERE contact_id=@cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = contactid;

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
        public DataTable getCourse_idByContactID(int contactid,int userid)
        {
            SqlCommand command = new SqlCommand("SELECT course_id FROM Lecturer WHERE contact_id=@cid AND userid=@uid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = contactid;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
    }
}
