using System;
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

        //string currSelected = "Start";

        
        
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
            /*
            // replace 50 with an actual variable 
            if (e.X >= 50 && 
                e.X <= 50 + 200 &&
                e.Y >= 50 &&
                e.Y <= 50 + 200)
            {              
                switch (currSelected)
                {
                    case "Start":
                       
                        break;

                    case "target":

                        break;

                    case "wall":

                        break;
                    
                    default:
                        break;
                }
                
                
                //first.click(e.X, e.Y);
            
            
            } else
            {
                //first.click(-1, -1);
            }
            
            Refresh();
            */
        }

        private void start_button_Click(object sender, EventArgs e)
        {           
            newGrid.active();
            Refresh();
        }
    }
}
