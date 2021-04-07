using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {
       // Bitmap brush.bitmap;
        List<Bitmap> BitmapList= new List<Bitmap>();

        //Graphics brush.graphics;
        //Pen brush.pen;
        //SolidBrush brush.brushBlack;
        Brush brush;
        Point mouseDownPosition;
        Point mouseUpPosition;
        IFigure figure;
        Points p;
        bool isMousDown = false;
        //Graph 
        //Arrow arrow = new Arrow(graph);
        //table (graph)
        //arrow.adasdad(Point)
      
       
        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load_1(object sender, EventArgs e)
        {
            brush = new Brush(pictureBox1);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if(isMousDown && e.Location!= mouseDownPosition && !(figure is null))
            {
                mouseUpPosition = e.Location;
                p = new Points(FindingPointsAndPerpendiculars(), mouseDownPosition, mouseUpPosition, FindingPointsAndPerpendicularsAtFirst());
                brush.TrackBarWidth = trackBar1.Value;
                brush.DrawMoveFigure(figure, p);
                //pictureBox1.Invalidate();

            }
            

            //pictureBox1.Image = brush.bitmap;
        }             
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            mouseDownPosition = e.Location;
            if(BitmapList.Count>1)
            {
                button_StepBack.Enabled = true;
            }
            isMousDown = true;

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            brush.TmpToMainBitmap();
            //pictureBox1.Invalidate();
            isMousDown = false;

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            brush.Clear();            
        }

        private void SetArrow(String nameArrow)
        {

            switch (nameArrow)
            {
                case "ArrowAssociation":
                    figure = new ArrowAssociation();
                    break;
                case "ArrowInheritance":
                    figure = new ArrowInheritance();
                    break;
                case "ArrowAggregation":
                    figure = new ArrowAggregation();
                    break;
                case "ArrowAggregationPlus":
                    figure = new ArrowAggregationPlus();
                    break;
                case "ArrowСomposition":
                    figure = new ArrowСomposition();
                    break;
                case "ArrowСompositionPlus":
                    figure = new ArrowСompositionPlus();
                    break;
                case "ArrowImplementation":
                    figure = new ArrowImplementation();
                    break;
                case "Rectangle":
                    figure = new Rectangle();
                    break;
            }

        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            figure = new Rectangle();
        }

        private void button_ArrowAssociation_Click(object sender, EventArgs e)
        {
            figure = new ArrowAssociation();
        }

        private void button_ArrowInheritance_Click(object sender, EventArgs e)
        {
            figure = new ArrowInheritance();
        }

        private void button_ArrowAggregation_Click(object sender, EventArgs e)
        {
            figure = new ArrowAggregation();
        }

        private void button_ArrowAggregationPlus_Click(object sender, EventArgs e)
        {
            figure = new ArrowAggregationPlus();
        }

        private void button_ArrowСomposition_Click(object sender, EventArgs e)
        {
            figure = new ArrowСomposition();
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
            figure = new Class3();
            //brush.bitmap = BitmapList[BitmapList.Count - 1];
            //BitmapList.RemoveAt(BitmapList.Count - 1);
            //if (BitmapList.Count == 1)
            //{
            //    button_StepBack.Enabled = false;
            //}

            //pictureBox1.Image = brush.bitmap;
        }

        private Point[] FindingPointsAndPerpendiculars()
        {
            // длина отрезка
            double d = Math.Sqrt(Math.Pow(this.mouseUpPosition.X - this.mouseDownPosition.X, 2) + Math.Pow(this.mouseUpPosition.Y - this.mouseDownPosition.Y, 2));

            // координаты вектора
            double X = this.mouseUpPosition.X - this.mouseDownPosition.X;
            double Y = this.mouseUpPosition.Y - this.mouseDownPosition.Y;

            // координаты точки, удалённой от конца  отрезка на 20px
            double X4 = mouseUpPosition.X - (X / d) * 20;
            double Y4 = mouseUpPosition.Y - (Y / d) * 20;

            
            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = this.mouseUpPosition.Y - this.mouseDownPosition.Y;
            double Yp = this.mouseDownPosition.X - this.mouseUpPosition.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 5px в разные стороны
            double X5 = X4 + (Xp / d) * 15;
            double Y5 = Y4 + (Yp / d) * 15;
            double X6 = X4 - (Xp / d) * 15;
            double Y6 = Y4 - (Yp / d) * 15;
            Point[] ShouldersArrows = new Point[] { new Point((int)X5, (int)Y5), new Point((int)X6, (int)Y6), new Point((int)X4, (int)Y4), new Point((int)X, (int)Y) };
            return ShouldersArrows;
        }

        private Point[] FindingPointsAndPerpendicularsAtFirst()
        {
            // длина отрезка
            double d = Math.Sqrt(Math.Pow(this.mouseUpPosition.X - this.mouseDownPosition.X, 2) + Math.Pow(this.mouseUpPosition.Y - this.mouseDownPosition.Y, 2));

            // координаты вектора
            double X = this.mouseDownPosition.X - this.mouseUpPosition.X;//
            double Y = this.mouseDownPosition.Y - this.mouseUpPosition.Y;

            // координаты точки, удалённой от конца  отрезка на 20px
            double X4 = mouseDownPosition.X - (X / d) * 20;
            double Y4 = mouseDownPosition.Y - (Y / d) * 20;

            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = mouseDownPosition.Y - mouseUpPosition.Y;
            double Yp = this.mouseUpPosition.X - this.mouseDownPosition.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 5px в разные стороны
            double X5 = X4 + (Xp / d) * 15;
            double Y5 = Y4 + (Yp / d) * 15;
            double X6 = X4 - (Xp / d) * 15;
            double Y6 = Y4 - (Yp / d) * 15;
            Point[] ArrowAtFront = new Point[] { new Point((int)X5, (int)Y5), new Point((int)X6, (int)Y6), new Point((int)X, (int)Y) };
            return ArrowAtFront;
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                brush.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void button_Class1_Click(object sender, EventArgs e)
        {
            figure = new Class1();
        }

        private void button_Class2_Click(object sender, EventArgs e)
        {
            figure = new Class2();
        }

        private void button_Class3_Click(object sender, EventArgs e)
        {
            figure = new Class3();
        }

        private void button_ClassStack_Click(object sender, EventArgs e)
        {
            figure = new ClassStack();
        }


        private void button_ArrowsList_MouseHover(object sender, EventArgs e)
        {
            FormArrows formArrows = new FormArrows();
            formArrows.Location = button_ArrowsList.Location;
            formArrows.ShowDialog();
            if(formArrows.String != null)
            {
                SetArrow(formArrows.String);
            }
            
        }

        private void formArrows_pictureBox_Association_Click()
        {
            figure = new ArrowAssociation();
        }
    }
}
