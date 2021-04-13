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
        private Point _pointMovingMouseDownPosition;
        private String _figureName;
        public Brush Brush;
        public IFigure Figure;
        public List<IFigure> figures;
        bool editing = false;
        bool isMoving = false;
        IFigure _crntFigure;
        bool isEnd = false;
        //IFigure Figure;


        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Brush = new Brush(pictureBox1);
            figures = new List<IFigure>();
            
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //начало движения классов с помощью правой клавиши мыши
            //if (e.Button == MouseButtons.Left && e.Location != _mouseUpPosition && !(Figure is null))
            //{
            //    Figure.MouseUpPosition = e.Location;
            //    Brush.DrawMoveFigure(Figure);
            //    //pictureBox1.Invalidate();
            //}
            //if (e.Button == MouseButtons.Right && isMoving == true)
            //{
            //    int deltaX = e.Location.X - _pointMovingMouseDownPosition.X;
            //    int deltaY = e.Location.Y - _pointMovingMouseDownPosition.Y;
            //    Brush.DrawMovingFigure(Figure, deltaX, deltaY);
            //}
            //конец движения классов

            

            if (!(Figure is null) && e.Button == MouseButtons.Left && e.Location != Figure.MouseDownPosition)
            {
                if(isEnd)
                {
                    Figure.MouseDownPosition = e.Location;
                }
                else
                {
                    Figure.MouseUpPosition = e.Location;

                }
                Brush.TrackBarWidth = trackBar1.Value;
                Brush.DrawMoveFigure(Figure);
            }
        }             
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
                       // начало движения классов с помощью правой клавиши мыши
            //if (ListFigures != null && e.Button == MouseButtons.Right)
            //{
            //    foreach (IFigure figure in ListFigures)
            //    {
            //        if (figure.IsHavingPoint(e.Location))
            //        {
            //            ListFigures.Remove(figure);
            //            Figure = (IFigure)figure.Clone();
            //            isMoving = true;
            //            _pointMovingMouseDownPosition = e.Location;
            //            Brush.DrawAllFigures(ListFigures);
            //            return;
            //        }
            //    }
            //}
             
            //if (!(Figure is null) && e.Button == MouseButtons.Left) 
            //{
            //    isMoving = false;
            //    Figure.MouseDownPosition = e.Location;
            //    Figure.Color = colorDialog1.Color;
            //    Figure.Width = trackBar1.Value;

            //}
            //конец движения классов

            if (editing)
            {
                findSelectedFigure(e);
                figures.Remove(_crntFigure);
                Brush.Clear();

                Brush.DrawMoveFigure(figures);
                
                // Brush.DrawMoveFigure(_crntFigure);
                Figure = _crntFigure;
            }
          
            else
            {
                if (!(Figure is null)) 
                {
                    Figure.MouseDownPosition = e.Location;
     
                }
                
            }
        }
       

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            // начало движения классов с помощью правой клавиши мыши
            //if(!isMoving && !(Figure is null))
            //{               
            //    ListFigures.Add((IFigure)Figure.Clone());
            //}

            //if (isMoving)
            //{
            //    Size delta = new Size(e.Location.X - _pointMovingMouseDownPosition.X, e.Location.Y - _pointMovingMouseDownPosition.Y);
            //    Figure.MouseDownPosition = Point.Add(Figure.MouseDownPosition, delta);
            //    Figure.MouseUpPosition = Point.Add(Figure.MouseUpPosition, delta);
            //    ListFigures.Add((IFigure)Figure.Clone());
            //    isMoving = false;
            //}
                        //конец движения классов

            Brush.TmpToMainBitmap();

            if(Figure!= null)
            {
                if (isEnd)
                {
                    Figure.MouseDownPosition = e.Location;
                }
                else
                {
                    Figure.MouseUpPosition = e.Location;

                }
                figures.Add(Figure);
                Figure = (IFigure)(Figure.Clone());
            }

            
            _crntFigure = null;
            
            
        }

        private void findSelectedFigure(MouseEventArgs e)
        {
            foreach (IFigure a in figures)
            {
                if (a is AbstractArrow)
                {
                    if (Math.Abs(a.MouseDownPosition.X - e.X) < 10 && Math.Abs(a.MouseDownPosition.Y - e.Y) < 10)
                    {
                        isEnd = true;
                        _crntFigure = a;
                        break;
                    }
                    if (Math.Abs(a.MouseUpPosition.X - e.X) < 10 && Math.Abs(a.MouseUpPosition.Y - e.Y) < 10)
                    {
                        isEnd = false;
                        _crntFigure = a;
                        break;
                    }
                }
                if (a is AbstractClassFigure)
                {
                    Point[] Rectangle = Geometry.GetRectangle(a.MouseUpPosition, a.MouseDownPosition);


                    for(int i=0;i<4;++i)
                    {
                        if (Math.Abs(Rectangle[i].X - e.X) < 10 && Math.Abs(Rectangle[i].Y - e.Y) < 10)
                        {
                            if (i == 0)
                            {
                                Point tmp = a.MouseDownPosition;
                                a.MouseDownPosition = a.MouseUpPosition;
                                a.MouseUpPosition = tmp;
                            }
                            if (i == 1)
                            {
                                a.MouseDownPosition = Rectangle[3];
                                a.MouseUpPosition = Rectangle[1];
                            }
                            if (i==3)
                            {
                                a.MouseDownPosition =  Rectangle[1];
                                a.MouseUpPosition =  Rectangle[3];
                            }
                            
                            _crntFigure = a;
                            break;
                        }
                    }

                }

            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Brush.Clear();
            figures.Clear();
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



        private void SetClass()
        {
            switch (_figureName)
            {
                case "Classes1":
                    Figure = new Class1Figure();
                    break;
                case "Classes2":
                    Figure = new Class2Figure();
                    break;
                case "Classes3":
                    Figure = new Class3Figure();
                    break;
                case "ClassStack":
                    Figure = new ClassStackFigure();
                    break;
            }

            pictureBox_Arrows.ImageLocation = @"ImagesArrows\Arrows.JPG";
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

            
            Brush.DrawMoveFigure(figures);
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color.BackColor = colorDialog1.Color;
                Brush.Color = colorDialog1.Color;
            }
        }
        private void pictureBox_Arrows_Click(object sender, EventArgs e)
        {
            FormArrows formArrows = new FormArrows();
            formArrows.TopMost = true;
            formArrows.StartPosition = FormStartPosition.Manual;
            formArrows.Location = pictureBox_Arrows.Location;
            formArrows.ShowDialog();
            if (formArrows.Name != null)
            {
                _figureName = formArrows.Name;
                SetArrow();
                pictureBox_Arrows.ImageLocation = @"ImagesArrows\" + _figureName + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formArrows.Close();
            }
        }

        private void pictureBox_Classes_Click(object sender, EventArgs e)
        {
            FormClasses formClasses = new FormClasses();
            formClasses.TopMost = true;
            formClasses.StartPosition = FormStartPosition.Manual;
            formClasses.Location = pictureBox_Classes.Location;
            formClasses.ShowDialog();
            if (formClasses.Name != null)
            {
                //    if (formClasses.Name == "close")
                //    {
                //        if (_figureName == "association" || _figureName == "inheritance" || _figureName == "aggregation"
                //            || _figureName == "aggregationPlus" || _figureName == "composition" || _figureName == "compositionPlus" || _figureName == "implementation")
                //        {
                //            pictureBox_Classes.ImageLocation = @"ImagesClasses\" + _figureName + ".JPG";
                //        }
                //        else
                //        {
                //            pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
                //        }
                //        pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                //        formClasses.Close();
                //        return;
                //    }

                _figureName = formClasses.Name;
                SetClass();
                pictureBox_Classes.ImageLocation = @"ImagesClasses\" + formClasses.Name + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formClasses.Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            Brush.TrackBarWidth = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                editing = false;
                Button b = (Button)sender;
                b.Text = "Off";
            }
            else
            {
                editing = true;
                Button b = (Button)sender;
                b.Text = "On";
            }
            
            
        }


    }
}
