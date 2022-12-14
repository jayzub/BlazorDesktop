using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebviewAppShared.Data
{
    public class Database
    {
        public SQLiteConnection sqlite_conn;

        public SQLiteConnection CreateConnection()
        {
            sqlite_conn = new SQLiteConnection("Data Source=quickmill.db;Version=3;New=True;Compress=Trues;");

            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlite_conn;
        }

        public void CreateDB()
        {
            try
            {
                sqlite_conn = new SQLiteConnection();
                SQLiteConnection.CreateFile("quickmill.db");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateTable(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                string Createsql = query;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetData(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = query;

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);
                da.Fill(dataTable);
                //conn.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertData(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateData(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
