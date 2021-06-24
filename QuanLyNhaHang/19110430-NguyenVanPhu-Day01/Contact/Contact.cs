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
    class Contact
    {
        MyDB mydb = new MyDB();

        public bool InsertContact(int id,string fname, string lname,string phone,string address,string email,int userid,int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Contact (Id, fname, lname, group_id, phone, email, address, picture, user_id)" + "VALUES (@id, @fn, @ln, @gid, @phone, @email, @addr, @pic, @uid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@addr", SqlDbType.Text).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
        public bool ContactExist(int Id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Contact WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
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
        public int SupportAdd()
        {
            int goiy = 1;
            while (ContactExist(goiy))
            {
                goiy++;
            }
            return goiy;
        }
        public DataTable GetAllContact(int uid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Contact WHERE user_id=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = uid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetContact(int contactID,int uid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Contact WHERE user_id=@uid AND Id=@cid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = uid;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = contactID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool UpdateContact(int id,string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Contact SET Id=@id, fname=@fn, lname=@ln, group_id=@gid, phone=@phone, email=@email, address=@addr, picture=@pic WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@addr", SqlDbType.Text).Value = address;
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
        public bool DeleteContact(int contactid)
        {
            SqlCommand command = new SqlCommand("DELETE Contact WHERE Id=@cid", mydb.getConnection);
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
        public DataTable getShowAllContact(int userid)
        {
            SqlCommand command = new SqlCommand("SELECT Id AS 'Contact ID',fname AS 'First Name',lname AS 'Last Name',group_id AS 'Group ID',phone AS Phone,email AS Email,address AS Address,picture AS Picture FROM Contact WHERE user_id=@uid ", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getShowContact(int userid,int groupid)
        {
            SqlCommand command = new SqlCommand("SELECT Id AS 'Contact ID',fname AS 'First Name',lname AS 'Last Name',phone AS Phone,email AS Email,address AS Address,picture AS Picture FROM Contact WHERE user_id=@uid AND group_id=@gid ", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
