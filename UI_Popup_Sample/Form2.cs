﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Popup_Sample
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close

        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        
        private enmAction action;

        private int x, y;

        public void showAlert(string msg, enmType type )
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form2 forma = (Form2)Application.OpenForms[fname];
                if (forma == null)
                {
                    this.Name = fname;
                    //od lewej
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    //margines od dołu
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }
            //margines od prawej
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            
            switch(type)
            {
                case enmType.Success:
                    //this.picturebox1.Image = Resources.[typ Wiadomości]
                    this.BackColor = Color.SeaGreen;
                    break;

                case enmType.Error:
                    //this.picturebox1.Image = Resources.[typ Wiadomości]
                    this.BackColor = Color.DarkRed;
                    break;

                case enmType.Warning:
                    //this.picturebox1.Image = Resources.[typ Wiadomości]
                    this.BackColor = Color.DarkOrange;
                    break;

                case enmType.Info:
                    //this.picturebox1.Image = Resources.[typ Wiadomości]
                    this.BackColor = Color.RoyalBlue;
                    break;
            }
            //przypisanie tekstu z konstruktora
            this.label1.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 4000;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
            this.Close();
        }
    }
}
