using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public partial class Form1 : Form
    {
        List<Bitmap> BitmapList= new List<Bitmap>();

        private Point _mouseDownPosition;
        private Point _mouseUpPosition;
        private String _choice;
        private bool _isMousDown = false;

        public Brush Brush;
        public IFigure Figure;


        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Brush = new Brush(pictureBox1);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if(_isMousDown && e.Location!= _mouseDownPosition && !(Figure is null))
            {
                _mouseUpPosition = e.Location;
                Brush.TrackBarWidth = trackBar1.Value;
                Brush.DrawMoveFigure(Figure, _mouseUpPosition, _mouseDownPosition);
                //pictureBox1.Invalidate();

            }

            //pictureBox1.Image = brush.bitmap;
        }             
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            _mouseDownPosition = e.Location;
            if(BitmapList.Count>1)
            {
                button_StepBack.Enabled = true;
            }
            _isMousDown = true;

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Brush.TmpToMainBitmap();
            _isMousDown = false;

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Brush.Clear();            
        }



        private void button_ArrowAssociation_Click(object sender, EventArgs e)
        {
            Figure = new ArrowAssociation();
        }

        private void button_ArrowInheritance_Click(object sender, EventArgs e)
        {
            Figure = new ArrowInheritance();
        }

        private void button_ArrowAggregation_Click(object sender, EventArgs e)
        {
            Figure = new ArrowAggregation();
        }

        private void button_ArrowAggregationPlus_Click(object sender, EventArgs e)
        {
            Figure = new ArrowAggregationPlus();
        }

        private void button_ArrowСomposition_Click(object sender, EventArgs e)
        {
            Figure = new ArrowСomposition();
        }

        private void button_ArrowCompositionPlus_Click(object sender, EventArgs e)
        {
            Figure = new ArrowСompositionPlus();
        }

        private void button_ArrowImplementation_Click(object sender, EventArgs e)
        {
            Figure = new ArrowImplementation();
        }


        private void button_StepBack_Click(object sender, EventArgs e)
        {
            //figure = new Class3();
            //brush.bitmap = BitmapList[BitmapList.Count - 1];
            //BitmapList.RemoveAt(BitmapList.Count - 1);
            //if (BitmapList.Count == 1)
            //{
            //    button_StepBack.Enabled = false;
            //}

            //pictureBox1.Image = brush.bitmap;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                Brush.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void button_Class1_Click(object sender, EventArgs e)
        {
            Figure = new Class1Figure();
        }

        private void button_Class2_Click(object sender, EventArgs e)
        {
            Figure = new Class2Figure();
        }

        private void button_Class3_Click(object sender, EventArgs e)
        {
            Figure = new Class3Figure();
        }

        private void button_ClassStack_Click(object sender, EventArgs e)
        {
            Figure = new ClassStackFigure();
        }
    }
}
