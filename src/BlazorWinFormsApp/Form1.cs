// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WebviewAppShared;
using WebviewAppTest;
using WebviewAppTest.Data;
using Microsoft.Data.SqlClient;
using DataAccessLibrary;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Radzen;
/*
using NationalInstruments.DAQmx;
using Task = NationalInstruments.DAQmx.Task;
using System.Data;
using System.Collections.Generic;
*/

namespace BlazorWinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly AppState _appState = new();

        public Form1()
        {
            //string connectionString =  ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

            //SqlConnection con = new SqlConnection(connectionString);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWindowsFormsBlazorWebView();
            serviceCollection.AddSingleton<AppState>(_appState);

            serviceCollection.AddSingleton<WeatherForecastService>();

            serviceCollection.AddScoped<DialogService>();
            serviceCollection.AddScoped<NotificationService>();
            serviceCollection.AddScoped<TooltipService>();
            serviceCollection.AddScoped<ContextMenuService>();

            //serviceCollection.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            //serviceCollection.AddSingleton<IDeviceData, DeviceData>();

            InitializeComponent();

            blazorWebView1.HostPage = @"wwwroot\index.html";
            blazorWebView1.Services = serviceCollection.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                owner: this,
                text: $"Current counter value is: {_appState.Counter}",
                caption: "Counter");
        }

        private void blazorWebView1_Click(object sender, EventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            serviceCollection.AddSingleton<IDeviceData, DeviceData>();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString =  ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            String sqlQuery = "INSERT INTO quickmill.dbo.Devices(SerialNumber, Name) VALUES (@SerialNumber, @Name)";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            var SerialNumberParameter = new SqlParameter("SerialNumber", System.Data.SqlDbType.VarChar);
            SerialNumberParameter.Value = textBox1.Text;
            cmd.Parameters.Add(SerialNumberParameter);

            var NameParameter = new SqlParameter("Name", System.Data.SqlDbType.VarChar);
            NameParameter.Value = textBox2.Text;
            cmd.Parameters.Add(NameParameter);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        
        // To be changed as required
        // The following function is used to triger teh get data function and store data in db
        /*
         private void button1_Click(object sender, EventArgs e)
        {

            DataTable d = getData("cDAQ1Mod1");

            int i = 0;
            foreach (DataRow dtRow in d.Rows)
            {

                Console.Write("Row " + i + ": ");
                foreach (var item in dtRow.ItemArray)
                {
                    Console.Write(item.ToString() + "  ");
                }
                i++;
                Console.WriteLine();
            }






            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuickMill;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                bulkCopy.DestinationTableName = "TestTable";

                bulkCopy.WriteToServer(d);



            }
            Console.WriteLine("Done All End");


        }
        */


        // Code to acquire data from the sensor and return that data in form of a data table

        /*
        private DataTable getData(string deviceName)
        {
            var timeStamp = new List<string>();
            double start;
            double end;


            DataTable dt = new DataTable();

            // Define Parameters
            int rate = 500;
            int _samplesPerChannel = 10;
            int bufferSize = rate * _samplesPerChannel;

            //Inilitiaze task
            NationalInstruments.DAQmx.Task acelerometerTask1 = new Task();

            //Define Channels
            acelerometerTask1.AIChannels.CreateAccelerometerChannel($"{deviceName}/ai0", "A00", AITerminalConfiguration.Pseudodifferential, -5, 5, 100, AIAccelerometerSensitivityUnits.MillivoltsPerG, AIExcitationSource.None, 0, AIAccelerationUnits.G);
            acelerometerTask1.AIChannels.CreateAccelerometerChannel($"{deviceName}/ai1", "A01", AITerminalConfiguration.Pseudodifferential, -5, 5, 100, AIAccelerometerSensitivityUnits.MillivoltsPerG, AIExcitationSource.None, 0, AIAccelerationUnits.G);
            acelerometerTask1.AIChannels.CreateAccelerometerChannel($"{deviceName}/ai2", "A02", AITerminalConfiguration.Pseudodifferential, -5, 5, 100, AIAccelerometerSensitivityUnits.MillivoltsPerG, AIExcitationSource.None, 0, AIAccelerationUnits.G);

            acelerometerTask1.Timing.ConfigureSampleClock("", rate, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, bufferSize);


            acelerometerTask1.Control(TaskAction.Verify);
            start = DateTime.Now.ToOADate();
            acelerometerTask1.Start();

            AnalogMultiChannelReader reader1 = new AnalogMultiChannelReader(acelerometerTask1.Stream);

            double[,] data = reader1.ReadMultiSample(bufferSize);

            acelerometerTask1.Dispose();
            end = DateTime.Now.ToOADate();

            Console.WriteLine(DateTime.FromOADate(start).ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
            Console.WriteLine(DateTime.FromOADate(end).ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));


            //Calculate time difference between each sample
            double diff = (end - start) / (double)bufferSize;


            //Define data columns
            DataColumn dtColumn;
            DataRow dtRow;

            // Create TimeStamp column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = "TimeStamp";
            //dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            dt.Columns.Add(dtColumn);

            // Create X-axis column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "X-Axis";
            //dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            dt.Columns.Add(dtColumn);



            // Create y-axis column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Y-Axis";
            //dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            dt.Columns.Add(dtColumn);


            // Create z-axis column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Z-Axis";
            //dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            dt.Columns.Add(dtColumn);


            // Filling the dataTable
            for (int i = 0; i < data.GetLength(1); i++)
            {
                dtRow = dt.NewRow();
                dtRow["TimeStamp"] = start + (diff * i);
                dtRow["X-Axis"] = data[0, i];
                dtRow["Y-Axis"] = data[1, i];
                dtRow["Z-Axis"] = data[2, i];
                dt.Rows.Add(dtRow);
            }



            return dt;
        }*/
    }
}
