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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace youtube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btn1.Click += btn1Click;
            btn2.Click += btn2Click;
        }

        private void btn1Click(object sender, EventArgs e){
            if(btn1.Text.Length<3){
                btn1.Text+="?";
            }
            else{
                btn1.Text = "";
            }
            Console.WriteLine(btn1.Text);
        }

        private void btn2Click(object sender, EventArgs e){//폴더 선택 이벤트
            CommonOpenFileDialog d = new CommonOpenFileDialog();
            d.IsFolderPicker = true;
            if(d.ShowDialog()==CommonFileDialogResult.Ok){
                btn1.Text = d.FileName;
                Console.WriteLine(btn1.Text);
                String option = "-o "+d.FileName+"\"\\download\\%(title)s.%(ext)s\" https://www.youtube.com/watch?v=1vryJp_ylVQ -v";
                var sample = Process.Start(Application.StartupPath+"/yt-dlp.exe",option);
                Console.WriteLine(option);
            }
        }

        private void MousePointXY(object sender, MouseEventArgs e){
            Console.WriteLine("Sender : {0}", ((Form)sender).Text);
            Console.WriteLine("X : {0}, Y : {1}", e.X, e.Y);
            Console.WriteLine("Button : {0}, Clicks : {1}", e.Button, e.Clicks);
            Console.WriteLine();
        }
    }
}
