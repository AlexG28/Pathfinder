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
        Grid newGrid = new Grid(150, 50, 20); // grid starts at 100,100     each square is 20px by 20px

        string currSelected = "Start";
       

        int counter;
        Graphics GFX;
        Bitmap surface;
        
        public Form1()
        {
            InitializeComponent();
            this.Width = 1600;
            this.Height = 900;

            counter = 0;

            surface = new Bitmap(405, 405);
            GFX = Graphics.FromImage(surface);
            GFX.Clear(Color.White);
            //PB_bitmapTest.Image = surface;
            PB_bitmapTest.Image = newGrid.testDraw(surface, GFX);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //newGrid.Draw(e);  
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {   
            /*
            // replace 50 with an actual variable 
            if (e.X >= 151 && 
                e.X <= 749 && // 150 + (30 * 20) - 1
                e.Y >= 51 &&
                e.Y <= 649) // 50 + (20 * 30) - 1
            {                                             
                if (currSelected == "Start")
                {
                    newGrid.addSquare(e.X, e.Y, 1);

                } else if (currSelected == "Target")
                {
                    newGrid.addSquare(e.X, e.Y, 2);

                } else if (currSelected == "Wall")
                {
                    newGrid.addSquare(e.X, e.Y, 3);
                }

                Refresh();
            } 
            
            */
        }

        private void start_button_Click(object sender, EventArgs e)
        { 

            PB_bitmapTest.Image = newGrid.findPath2(surface, GFX);        
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            currSelected = type.Text;
            //Console.WriteLine(currSelected);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {          
            GFX.Clear(Color.White);
            PB_bitmapTest.Image = newGrid.testDraw(surface, GFX);

            newGrid.resetGraph();
            //Refresh();
        }
       

        private void PB_bitmapTest_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("The horizontal is: " + e.X.ToString());
            //Console.WriteLine("The vertical is: " + e.Y.ToString());

            if (currSelected == "Start")
            {
                //newGrid.addSquare(e.X, e.Y, 1);
                PB_bitmapTest.Image = newGrid.addSquare1(surface, GFX, e.X, e.Y, 1);
            }
            else if (currSelected == "Target")
            {
                //newGrid.addSquare(e.X, e.Y, 2);
                PB_bitmapTest.Image = newGrid.addSquare1(surface, GFX, e.X, e.Y, 2);
            }
            else if (currSelected == "Wall")
            {
                //newGrid.addSquare(e.X, e.Y, 3);
                PB_bitmapTest.Image = newGrid.addSquare1(surface, GFX, e.X, e.Y, 3);
            }
        }
    }
}
