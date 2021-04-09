using System;
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

        private void SetArrow(String nameArrow)
        {
            switch (nameArrow)
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

        }

        private void SetClass(String nameClass)
        {
            switch (nameClass)
            {
                case "Class1":
                    Figure = new Class1Figure();
                    break;
                case "Class2":
                    Figure = new Class2Figure();
                    break;
                case "Class3":
                    Figure = new Class3Figure();
                    break;
                case "ClassStack":
                    Figure = new ClassStackFigure();
                    break;
            }

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
                SetArrow(formArrows.Name);
                formArrows.Close();
            }
        }
        private void button_Classes_MouseHover(object sender, EventArgs e)
        {
            
            FormClasses formClasses = new FormClasses();
            formClasses.TopMost = true;
            formClasses.StartPosition = FormStartPosition.Manual;
            formClasses.Location = button_Classes.Location;
            formClasses.ShowDialog();
            if (formClasses.Name != null)
            {
                SetClass(formClasses.Name);
                formClasses.Close();
            }
        }


        //private void pictureBox2_MouseHover(object sender, EventArgs e)
        //{
        //    FormArrows formArrows = new FormArrows();
        //    formArrows.TopMost = true;
        //    formArrows.StartPosition = FormStartPosition.Manual;
        //    formArrows.Location = pictureBox_Arrows.Location;
        //    formArrows.ShowDialog();
        //    if (formArrows.Name != null)
        //    {
        //        SetArrow(formArrows.Name);
        //        pictureBox_Arrows.ImageLocation = @("ImagesArrows\aggregation.JPG");
        //        //pictureBox_Arrows.ImageLocation = ".\\ImagesArrows\\" + formArrows.Name + ".JPG";
        //        formArrows.Close();
        //    }
        //}


    }
}
