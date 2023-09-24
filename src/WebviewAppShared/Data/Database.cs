using Radzen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Security.Cryptography.Xml;
using Org.BouncyCastle.Utilities.Collections;
using System.Security.Cryptography;

namespace WebviewAppShared.Data
{
    public class Database
    {
        public SQLiteConnection sqlite_conn;

        public SQLiteConnection CreateConnection()
        {
            //string databaseFile = "quickmill.db";
            //if (!File.Exists(databaseFile))
            //{
            //    SQLiteConnection.CreateFile(databaseFile);
            //}
            //sqlite_conn = new SQLiteConnection("Data Source=quickmill.db;Version=3;New=False;Compress=Trues;");

            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=quickmill.db;New=True;Compress=Trues;");
                sqlite_conn.Open();
                string databaseFile = "quickmill.db";
                if (File.Exists(databaseFile))
                {
                    CreateTableA(sqlite_conn);
                    CreateTableB(sqlite_conn);
                    CreateTableC(sqlite_conn);
                    CreateTableD(sqlite_conn);
                    CreateTableE(sqlite_conn);
                    CreateTableF(sqlite_conn);
                    CreateTableG(sqlite_conn);
                    CreateTableMC(sqlite_conn);
                    CreateTableS(sqlite_conn);
                    CreateTableM(sqlite_conn);
                    CreateTableTD(sqlite_conn);

                }      
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlite_conn;
        }

        //public void CreateDB()
        //{
        //    try
        //    {
        //        sqlite_conn = new SQLiteConnection();
        //        SQLiteConnection.CreateFile("quickmill.db");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void CreateTableA(SQLiteConnection connection)
        {
            string query = "CREATE TABLE IF NOT EXISTS A(A0 INTEGER,A1 INTEGER PRIMARY KEY AUTOINCREMENT,A2 TEXT,A3 TEXT);";
            

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void CreateTableB(SQLiteConnection connection)
        {

            string query = $@"create table if not exists B( B1  integer,B2  varchar,B3  varchar,B4  numeric,B5  varchar,B6  numeric,B7  numeric,B8  numeric,B9  numeric,B10 numeric,B11 varchar,B12 varchar,B13 numeric,B14 varchar,B15 varchar,B16 varchar,B17 varchar,B18 varchar,B19 varchar,B20 varchar,B21 numeric,B22 numeric,B23 varchar);";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableC(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS C(
                                                C0 INTEGER,
                                                C1 VARCHAR,
                                                C2 NUMERIC,
                                                C3 VARCHAR,
                                                C4 VARCHAR);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void CreateTableD(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS D (
                                                D1 INTEGER,
                                                D2 VARCHAR);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableE(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS E (
                                                            E0 NUMERIC,    
                                                            E1 VARCHAR,
                                                            E2 NUMERIC,
                                                            E3 NUMERIC,
                                                            E4 NUMERIC,
                                                            E5 NUMERIC,
                                                            E6 NUMERIC);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableF(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS F (
                                                F1 INTEGER,
                                                F2 VARCHAR,
                                                F3 NUMERIC,
                                                F4 NUMERIC,
                                                F5 NUMERIC);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableG(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS G (
                                                G0 NUMERIC,
                                                G1 NUMERIC,
                                                G2 VARCHAR,
                                                G3 VARCHAR,
                                                G4 VARCHAR);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableMC(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS MC (
                                                MC1 NUMERIC,
                                                MC2 INTEGER,
                                                MC3 VARCHAR,
                                                MC4 VARCHAR,
                                                MC5 VARCHAR,
                                                MC6 VARCHAR);";

            // Need to write query to insert data of MC
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
            InsertDataIntoMC(connection);
        }

        private void InsertDataIntoMC(SQLiteConnection connection)
        {
            // Check if the table exists and is empty
            if (IsMCTableEmpty(connection))
            {
                // Define SQL INSERT statements for each row of data
                string[] insertStatements =
                {
                    "INSERT INTO MC (MC1, MC2, MC3, MC4, MC5, MC6) VALUES (1, 'Intimidator', 'Spindle', 'DE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-S-DE');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(2, 'Intimidator', 'Spindle', 'ODE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-S-ODE');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(3, 'Intimidator', 'W', 'Ballscrew DE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-W-DE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(4, 'Intimidator', 'W', 'Ballscrew ODE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-W-ODE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(5, 'Intimidator', 'W', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'INT-W-BN-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(6, 'Intimidator', 'W', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'INT-W-LB-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(7, 'Intimidator', 'X', 'Ballscrew DE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-X-DE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(8, 'Intimidator', 'X', 'Ballscrew ODE Bearing', '0,0,1;0,1,0;1,0,0', 'INT-X-ODE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(9, 'Intimidator', 'X', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'INT-X-BN-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(10, 'Intimidator', 'X', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'INT-X-LB-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(11, 'Intimidator', 'Y', 'Ballscrew DE Bearing', '1,0,0;0,0,1;0,1,0', 'INT-Y-DE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(12, 'Intimidator', 'Y', 'Ballscrew ODE Bearing', '0,0,1;1,0,0;0,1,0', 'INT-Y-ODE-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(13, 'Intimidator', 'Y', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'INT-Y-BN-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(14, 'Intimidator', 'Y', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'INT-Y-LB-120');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(15, 'Intimidator', 'Z', 'Ballscrew DE Bearing', '1,0,0;0,0,1;0,1,0', 'INT-Z-DE');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(16, 'Intimidator', 'Z', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'INT-Z-BN');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(17, 'Intimidator', 'Z', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'INT-Z-LB');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(18, 'Annihilator', 'Spindle', 'ODE Bearing', '1,0,0;0,1,0;0,0,1', 'ANI-S-ODE');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(19, 'Annihilator', 'X', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'ANI-X-BN-230');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(20, 'Annihilator', 'X', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'ANI-X-LB-230');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(21, 'Annihilator', 'Y', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'ANI-Y-BN-96');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(22, 'Annihilator', 'Y', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'ANI-Y-LB-96');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(23, 'Annihilator', 'Z', 'Ballscrew DE Bearing', '1,0,0;0,0,1;0,1,0', 'INT-Z-DE');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(24, 'Annihilator', 'Z', 'Linear Bearing', '1,0,0;0,1,0;0,0,1', 'INT-Z-LB');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(25, 'Annihilator', 'Z', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'ANI-Z-BN');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(26, 'Annihilator', 'W', 'Ball Nut', '1,0,0;0,1,0;0,0,1', 'ANI-W-BN-230');",
                    "INSERT INTO MC(MC1, MC2, MC3, MC4, MC5, MC6) VALUES(27, 'Annihilator', 'W', 'Liner Bearing', '1,0,0;0,1,0;0,0,1', 'ANI-W-LB-230');"

                    // Add more INSERT statements for the remaining data rows
                };

                foreach (string insertQuery in insertStatements)
                {
                    using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertDataCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool IsMCTableEmpty(SQLiteConnection connection)
        {
            string query = "SELECT COUNT(*) FROM MC;";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                //connection.Open();
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                //connection.Close();

                return rowCount == 0;
            }
        }


        private void CreateTableS(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS S (
                                                S1 INTEGER PRIMARY KEY AUTOINCREMENT,
                                                S2 TEXT,
                                                S3 TEXT,
                                                S4 INTEGER,
                                                S5 INTEGER,
                                                S6 NUMERIC,
                                                S7 NUMERIC,
                                                S8 NUMERIC,
                                                S9 INTEGER);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void CreateTableM(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS M (
                                                             M1 VARCHAR (50),
                                                            M2 TEXT,
                                                            M3 VARCHAR (50),
                                                            M4 VARCHAR (50),
                                                            M5 DATETIME,
                                                            M6 VARCHAR(50));";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }


        private void CreateTableTD(SQLiteConnection connection)
        {
            string query = @"CREATE TABLE IF NOT EXISTS TD (
                                                TD1 INTEGER PRIMARY KEY AUTOINCREMENT,
                                                TD2 VARCHAR,
                                                TD3 VARCHAR,
                                                TD4 VARCHAR,
                                                TD5 VARCHAR,
                                                TD6 VARCHAR,
                                                TD7 VARCHAR,
                                                TD8 VARCHAR);";


            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
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

        public int GetCount(string query)
        {
            try
            {
                SQLiteConnection conn = CreateConnection();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = query;

                int count = Convert.ToInt32(sqlite_cmd.ExecuteScalar());
                //SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);
                //da.Fill(dataTable);
                //conn.Close();

                return count;
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
