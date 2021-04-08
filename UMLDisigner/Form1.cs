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

            if(e.Button == MouseButtons.Left && e.Location!= mouseDownPosition && !(figure is null))
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

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            brush.TmpToMainBitmap();
            //pictureBox1.Invalidate();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            brush.Clear();            
        }

        private void SetArrow(String nameArrow)
        {
            switch (nameArrow)
            {
                case "association":
                    figure = new ArrowAssociation();
                    break;
                case "inheritance":
                    figure = new ArrowInheritance();
                    break;
                case "aggregation":
                    figure = new ArrowAggregation();
                    break;
                case "aggregationPlus":
                    figure = new ArrowAggregationPlus();
                    break;
                case "composition":
                    figure = new ArrowСomposition();
                    break;
                case "compositionPlus":
                    figure = new ArrowСompositionPlus();
                    break;
                case "implementation":
                    figure = new ArrowImplementation();
                    break;
            }

        }


        private void SetClass(String nameClass)
        {
            switch (nameClass)
            {
                case "Class1":
                    figure = new Class1();
                    break;
                case "Class2":
                    figure = new Class2();
                    break;
                case "Class3":
                    figure = new Class3();
                    break;
                case "ClassStack":
                    figure = new ClassStack();
                    break;
            }

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
