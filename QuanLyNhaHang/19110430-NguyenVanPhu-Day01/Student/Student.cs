using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Student
    {
        MyDB mydb = new MyDB();
        //internal object std;

        public bool InsertStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Student (Id, fname, lname, bdate, gender, phone, address, picture)" + " VALUES (@id, @fn, @ln, @bd, @gdr, @phn, @adrs, @pic)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            
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

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool DeleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id = @id", mydb.getConnection);
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

        public bool UpdateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Student SET fname=@fn, lname=@ln, bdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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

        public string TotalStudent()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT (Id) FROM Student",mydb.getConnection);
            DataTable table = getStudents(command);
            return table.Rows[0][0].ToString();
        }
        public string MaleStudent()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT (Id) FROM Student WHERE gender = 'Male'", mydb.getConnection);
            DataTable table = getStudents(command);
            return table.Rows[0][0].ToString();
        }
        public string FemaleStudent()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT (Id) FROM Student WHERE gender = 'Female'", mydb.getConnection);
            DataTable table = getStudents(command);
            return table.Rows[0][0].ToString();

        }
        private void closeConnection()
        {
            throw new NotImplementedException();
        }

        private void openConnection()
        {
            throw new NotImplementedException();
        }

        public string fullnameStudent(int StudentID)
        {
            SqlCommand command = new SqlCommand("SELECT fname,lname FROM Student WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = StudentID;
            DataTable table = getStudents(command);
            return (table.Rows[0][0].ToString()+" "+ table.Rows[0][1].ToString());
        }
    }
}
