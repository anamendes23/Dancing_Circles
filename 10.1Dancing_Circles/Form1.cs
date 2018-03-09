/*
 * Ana Mendes
 * anamendes23@gmail.com
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._1Dancing_Circles
{
    public partial class Form1 : Form
    {
        //declare a bitmap
        Bitmap bmap;
        //declare a Graphics object for a bitmap
        Graphics g;
        //array of colors
        Color[] pallet = { Color.Red, Color.Orange, Color.Yellow, Color.Green,
                           Color.Blue, Color.Indigo, Color.Purple };
        //number of circles
        public static int size = 7;
        //arrays to hold circle's arguments
        int[] d = new int[size]; //diameter
        int[] cs = new int[size]; //coordinates
        Pen[] pens = new Pen[size]; //pen
        //counter to set numbers of circles to 7
        int count = 0;
        //index to change circles' colors and sizes for first part
        int cIndex = 0;
        //index to change circles' colors for second part
        int index = 0;
        //variable to support color change
        int h = 0;
        
        /*******************************FORM1***********************************/
        public Form1()
        {
            InitializeComponent();
            //create a bitmap wiith same dimensions as picturebox
            bmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //create graphics object for this bitmap
            g = Graphics.FromImage(bmap);
        }
        /*******************************FORM LOAD*******************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            //starts timer
            timer1.Start();
            //populate arguments' arrays
            for (int i = 0; i < pallet.Length; i++)
            {
                pens[i] = new Pen(pallet[i], 15); //pens with different colors
                d[i] = 40 * (i + 1); //diameter increments by 40
                cs[i] = pictureBox1.Width / 2 - d[i] / 2; //circles' coordinates
            }
        }
        /*******************************TIMER1**********************************/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 7)
            {
                //draw circle
                g.DrawEllipse(pens[cIndex], cs[cIndex], cs[cIndex], d[cIndex], d[cIndex]);
                //display bitmap to picturebox
                pictureBox1.Image = bmap;
                //increment count and cIndex
                count++;
                cIndex++;
            }
            else
            {
                //reduce timer interval (makes colors to change faster)
                timer1.Interval = 300;
                //normalize index
                index = (index + 1) % pens.Length;
                //loop to change all 7 circles' color in one tick
                for (int i = 0; i < pens.Length; i++)
                {
                    //guarantee that index is valid
                    if (index + i < 7)
                    {
                        //draw circle
                        g.DrawEllipse(pens[index + i], cs[i], cs[i], d[i], d[i]);
                    }
                    else
                    {
                        //draw circle
                        g.DrawEllipse(pens[h], cs[i], cs[i], d[i], d[i]);
                        //increments h
                        h++;
                    }
                }
                //reset h
                h = 0;
                //display bitmap to picturebox
                pictureBox1.Image = bmap;
            }
        }
        /******************************BTN STOP*********************************/
        private void btnStop_Click(object sender, EventArgs e)
        {
            //stop timer
            timer1.Stop();
        }
    }
}
