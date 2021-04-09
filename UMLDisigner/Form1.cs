﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {
        List<Bitmap> BitmapList= new List<Bitmap>();

        private Point _mouseUpPosition;

        public Brush Brush;
        public IFigure Figure;


        private String _figureName;
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
            //_mouseUpPosition = e.Location;
            if (e.Button == MouseButtons.Left && e.Location!= _mouseUpPosition && !(Figure is null))
            {
                Figure.MouseUpPosition = e.Location;
                Brush.TrackBarWidth = trackBar1.Value;
                Brush.DrawMoveFigure(Figure);
                //pictureBox1.Invalidate();

            }

            //pictureBox1.Image = brush.bitmap;
        }             
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(Figure is null)) 
            {
                Figure.MouseDownPosition = e.Location;
            }
            
            if(BitmapList.Count>1)
            {
                button_StepBack.Enabled = true;
            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Brush.TmpToMainBitmap();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Brush.Clear();            
        }

        

        private void button_ArrowAssociation_Click(object sender, EventArgs e)
        {
            figure = new ArrowAssociation();
        }

        private void SetArrow()
        {
            switch (_figureName)
            {
                case "association":
                    Figure = new ArrowAssociation();
                    break;
                case "inheritance":
                    Figure = new ArrowInheritance();
                    break;
                case "aggregation":
                    Figure = new ArrowAggregation();
                    break;
                case "aggregationPlus":
                    Figure = new ArrowAggregationPlus();
                    break;
                case "composition":
                    Figure = new ArrowСomposition();
                    break;
                case "compositionPlus":
                    Figure = new ArrowСompositionPlus();
                    break;
                case "implementation":
                    Figure = new ArrowImplementation();
                    break;
            }

            pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
        }

        private void button_ArrowAggregationPlus_Click(object sender, EventArgs e)
        {
            figure = new ArrowAggregationPlus();
        }


        private void button_ArrowCompositionPlus_Click(object sender, EventArgs e)
        {
            figure = new ArrowСompositionPlus();
        }

        private void button_ArrowImplementation_Click(object sender, EventArgs e)
        {
            figure = new ArrowImplementation();
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


        private void button_Arrows_MouseHover(object sender, EventArgs e)
        {
            FormArrows formArrows = new FormArrows();
            formArrows.TopMost = true;
            formArrows.StartPosition = FormStartPosition.Manual;
            formArrows.Location = button_Arrows.Location;
            formArrows.ShowDialog();
            if (formArrows.Name != null)
            {
                SetArrow();
                formArrows.Close();
            }
        }

        private void button_Classes_MouseHover(object sender, EventArgs e)
        {
            figure = new Class2();
        }



        private void pictureBox_Arrows_MouseHover(object sender, EventArgs e)
        {
            figure = new Class3();
        }

        private void pictureBox_Classes_MouseHover(object sender, EventArgs e)
        {
            FormClasses formClasses = new FormClasses();
            formClasses.TopMost = true;
            formClasses.StartPosition = FormStartPosition.Manual;
            formClasses.Location = pictureBox_Classes.Location;
            formClasses.ShowDialog();
            if (formClasses.Name != null)
            {
                if (formClasses.Name == "close")
                {
                    if (_figureName == "association" || _figureName == "inheritance" || _figureName == "aggregation"
                        || _figureName == "aggregationPlus" || _figureName == "composition" || _figureName == "compositionPlus" || _figureName == "implementation")
                    {
                        pictureBox_Classes.ImageLocation = @"ImagesClasses\" + _figureName + ".JPG";
                    }
                    else
                    {
                        pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
                    }
                    pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                    formClasses.Close();
                    return;
                }

                _figureName = formClasses.Name;
                SetClass();
                pictureBox_Classes.ImageLocation = @"ImagesClasses\" + formClasses.Name + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formClasses.Close();
            }


        }
    }
}
