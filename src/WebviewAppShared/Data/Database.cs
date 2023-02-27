using Radzen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public void BulkInsert(DataTable dt)
        {
            try
            {

                


                string connectionString = "Data Source=quickmill.db;Version=3;New=True;Compress=Trues;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.CommandText = "INSERT INTO Test (TimeStamp, X_Axis, Y_Axis, Z_Axis, G_Test_Id, Component_Id, Test_Round) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7)";

                            command.Parameters.Add("@value1", System.Data.DbType.Decimal);
                            command.Parameters.Add("@value2", System.Data.DbType.Decimal);
                            command.Parameters.Add("@value3", System.Data.DbType.Decimal);
                            command.Parameters.Add("@value4", System.Data.DbType.Decimal);
                            command.Parameters.Add("@value5", System.Data.DbType.Int64);
                            command.Parameters.Add("@value6", System.Data.DbType.Int64);
                            command.Parameters.Add("@value7", System.Data.DbType.Int64);


                            foreach (DataRow dtRow in dt.Rows)
                            {

                                int i = 1;
                                foreach (var item in dtRow.ItemArray)
                                {
                                    command.Parameters["@value" + i].Value = item;
                                    i++;

                                    
                                }
                                command.ExecuteNonQuery();
                            }

                           
                            transaction.Commit();
                        }
                    }
                }

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
                Console.Write("Done and dusted!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //public void BulkInsert(DataTable dt)
        //{
        //    try
        //    {

                


        //        string connectionString = "Data Source=quickmill.db;Version=3;New=True;Compress=Trues;";
        //        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (SQLiteTransaction transaction = connection.BeginTransaction())
        //            {
        //                using (SQLiteCommand command = new SQLiteCommand(connection))
        //                {
        //                    command.CommandText = "INSERT INTO Test (TimeStamp, X_Axis, Y_Axis, Z_Axis) VALUES (@value1, @value2, @value3, @value4)";

        //                    command.Parameters.Add("@value1", System.Data.DbType.Decimal);
        //                    command.Parameters.Add("@value2", System.Data.DbType.Decimal);
        //                    command.Parameters.Add("@value3", System.Data.DbType.Decimal);
        //                    command.Parameters.Add("@value4", System.Data.DbType.Decimal);

        //                    foreach (DataRow dtRow in dt.Rows)
        //                    {

        //                        int i = 1;
        //                        foreach (var item in dtRow.ItemArray)
        //                        {
        //                            command.Parameters["@value" + i].Value = item;
        //                            i++;

                                    
        //                        }
        //                        command.ExecuteNonQuery();
        //                    }

                           
        //                    transaction.Commit();
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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
