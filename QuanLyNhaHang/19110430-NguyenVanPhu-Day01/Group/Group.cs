using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19110430_NguyenVanPhu_Day01
{
    class Group
    {
        MyDB mydb = new MyDB();

        public bool InsertGroup(string groupname,int userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO myGroup (Id, groupname, userid)" + "VALUES (@id, @ng, @uid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = TotalGroup() + 1;
            command.Parameters.Add("@ng", SqlDbType.VarChar).Value = groupname;
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
        public bool UpdateGroup(int groupID,string groupname)
        {
            SqlCommand command = new SqlCommand("UPDATE myGroup SET groupname=@gn WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = groupID;
            command.Parameters.Add("@gn", SqlDbType.VarChar).Value = groupname;

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
        public bool DeleteGroup(int groupID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM myGroup WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = groupID;

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
        public bool groupExist(string groupname,string operation,int userid=0,int groupid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if (operation == "add")
            {
                query = "SELECT * FROM myGroup WHERE groupname=@gn AND userid=@uid";
                command.Parameters.Add("@gn", SqlDbType.VarChar).Value = groupname;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM myGroup WHERE groupname=@gn AND userid=@uid AND Id = @gid";
                command.Parameters.Add("@gn", SqlDbType.VarChar).Value = groupname;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            }
            command.CommandText = query;
            command.Connection = mydb.getConnection;
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
        public DataTable getGroups(int userid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM myGroup WHERE userid=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getGroups(int groupID,int userid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM myGroup WHERE Id=@gid AND userid=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        
        private int TotalGroup()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(Id) FROM myGroup ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public bool SupportDelete(int newgroupID)
        {
            SqlCommand command = new SqlCommand("UPDATE myGroup SET Id=@newgid WHERE Id=@oldgid", mydb.getConnection);
            command.Parameters.Add("@newgid", SqlDbType.Int).Value = newgroupID;
            int oldgroupID = TotalGroup()+1;
            command.Parameters.Add("@oldgid", SqlDbType.Int).Value = oldgroupID;

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
    }
}
