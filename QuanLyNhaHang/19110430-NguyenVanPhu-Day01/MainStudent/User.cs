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
    class User
    {
        MyDB mydb = new MyDB();

        public bool InsertUser(string fname,string lname,string username,string password,MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Hr (Id, fname, lname, username, password, picture)" + "VALUES (@id, @fn, @ln,@un, @pw,@pic)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = TotalUser()+1;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", SqlDbType.VarChar).Value = password;
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


        public DataTable getUserById(int userID)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Hr WHERE Id=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userID;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public bool UsernameExist(string username,string operation,int userId=0)
        {
            string query = "";
            if (operation == "register")
            {
                query = "SELECT * FROM Hr WHERE username=@un";
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM Hr WHERE username=@un AND Id = @uid";
            }
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
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

        public bool UpdatetUser(int userID,string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Hr SET fname=@fn, lname=@ln, username=@un, password=@pw, picture=@pic WHERE Id=@uid" , mydb.getConnection);

            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userID;

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
        private int TotalUser()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(Id) FROM Hr ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0]);
        }
    }
}
