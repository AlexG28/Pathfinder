﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinder
{
    public partial class Form1 : Form
    {
        
        Grid newGrid = new Grid(50, 50, 20);
        //StartSquare first = new StartSquare(new PointF(50, 50));

        string currSelected = "Start";

        
        
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;       
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            newGrid.Draw(e);  
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {   
            
            // replace 50 with an actual variable 
            if (e.X >= 50 && 
                e.X <= 50 + 200 &&
                e.Y >= 50 &&
                e.Y <= 50 + 200)
            {                               
                //first.click(e.X, e.Y);

                if (currSelected == "Start")
                {
                    newGrid.addTarget(e.X, e.Y, 1);

                } else if (currSelected == "Target")
                {
                    newGrid.addTarget(e.X, e.Y, 2);

                } else if (currSelected == "Wall")
                {
                    newGrid.addTarget(e.X, e.Y, 3);
                }

                Refresh();
            } 
            
            //Refresh();
        }

        private void start_button_Click(object sender, EventArgs e)
        {           
            newGrid.findPath();
            Refresh();
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            currSelected = type.Text;
            Console.WriteLine(currSelected);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            newGrid.clear();
            Refresh();
        }
    }
}
