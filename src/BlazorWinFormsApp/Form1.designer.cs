namespace BlazorWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blazorWebView1 = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            this.SuspendLayout();
            // 
            // blazorWebView1
            // 
            this.blazorWebView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blazorWebView1.Location = new System.Drawing.Point(10, 141);
            this.blazorWebView1.Margin = new System.Windows.Forms.Padding(2);
            this.blazorWebView1.Name = "blazorWebView1";
            this.blazorWebView1.Size = new System.Drawing.Size(1568, 474);
            this.blazorWebView1.TabIndex = 20;
            this.blazorWebView1.Click += new System.EventHandler(this.blazorWebView1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 624);
            this.Controls.Add(this.blazorWebView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Blazor Web in Windows Forms";
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebView1;
    }
}
