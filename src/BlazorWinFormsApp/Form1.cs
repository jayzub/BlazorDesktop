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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(
        //        owner: this,
        //        text: $"Current counter value is: {_appState.Counter}",
        //        caption: "Counter");
        //}

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
