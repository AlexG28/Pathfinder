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

        //int squaresX = 30;
        //int squaresY = 30;

        Grid newGrid = new Grid(150, 50, 20); // grid starts at 100,100     each square is 20px by 20px

        string currSelected = "Start";




        
        public Form1()
        {
            InitializeComponent();
            this.Width = 1600;
            this.Height = 900;          

            Bitmap surface = new Bitmap(300, 300);
            Graphics GFX = Graphics.FromImage(surface);

            //GFX.FillRectangle(Brushes.Red, 50, 50, 100, 100);
            GFX.FillEllipse(Brushes.Red, 50, 50, 100, 150);

            PB_bitmapTest.Image = surface;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            newGrid.Draw(e);  
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {   
            
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
