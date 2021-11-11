﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Threading;

namespace MaterialDesign
{
    public partial class Form1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        protected void RePaint()
        {
            GraphicsPath graphicpath = new GraphicsPath();
            graphicpath.StartFigure();
            graphicpath.AddArc(0, 0, 25, 25, 180, 90);
            graphicpath.AddLine(25, 0, this.Width - 25, 0);
            graphicpath.AddArc(this.Width - 25, 0, 25, 25, 270, 90);
            graphicpath.AddLine(this.Width, 25, this.Width, this.Height - 25);
            graphicpath.AddArc(this.Width - 25, this.Height - 25, 25, 25, 0, 90);
            graphicpath.AddLine(this.Width - 25, this.Height, 25, this.Height);
            graphicpath.AddArc(0, this.Height - 25, 25, 25, 90, 90);
            graphicpath.CloseFigure();
            this.Region = new Region(graphicpath);
}


        public Form1()
        {
             Thread th = new Thread(new ThreadStart(Splashscreen));
            th.Start();

            string loading = string.Empty;
            for (int i = 0; i < 100000; i++)
            {
                loading += i;
            }
            th.Abort();

            InitializeComponent();
            materialSkinManager= MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue600, MaterialSkin.Primary.Green300, MaterialSkin.Primary.Blue300, MaterialSkin.Accent.Yellow700,MaterialSkin.TextShade.WHITE);

            RePaint();

            
        }
        void Splashscreen()
        {
            SplashScreen.SplashForm fm1 = new SplashScreen.SplashForm();
            fm1.AppName=("TASK MANAGER");
            Application.Run(fm1);
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "showPlots.py";
                process.StartInfo.WorkingDirectory = @".\backend";
                process.StartInfo.Arguments = "python";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();

            }
            catch (Exception)
            {

                Console.WriteLine("Invalid input!");
            }
        }
    }
}
