using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {


        List<Bitmap> BitmapList = new List<Bitmap>();

        private Point _mouseUpPosition;
        private Point _mouseDownPosition;
        private Point _pointMovingMouseDownPosition;
        private String _figureName;
        public Brush Brush;
        public IFigure Figure;
        public List<IFigure> Figures;
        bool _editing = false;
        bool _isMoving = false;
        bool _isResizing = false;
        Vertex _vertex;
        Side _side;
        int TextSize;
        int selectRow;

        IFigure _crntFigure;
        bool _isEnd = false;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            
            Brush = new Brush(pictureBox1);
            panel1.Controls.Add(pictureBox1);
           // panel1.Controls.Add(textBox1);
            //this.Controls.Add(pictureBox1);
            //pictureBox1.PreviewKeyDown += new PreviewKeyDownEventHandler(KeyDeleteUp);
            Figures = new List<IFigure>();


        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && _isMoving == true)
            {
                int deltaX = e.Location.X - _pointMovingMouseDownPosition.X;
                int deltaY = e.Location.Y - _pointMovingMouseDownPosition.Y;

                Brush.DrawMoveFigure(Figure, deltaX, deltaY);
            }

            if (!(Figure is null) && e.Button == MouseButtons.Left && e.Location != Figure.MouseDownPosition)
            {
                if (buttonLineOptions.Text == "Curved")
                {
                    Figure.IsCurved = true;
                }
                else
                {
                    Figure.IsCurved = false;
                }

                if (_isEnd)
                {
                    Figure.MouseDownPosition = e.Location;
                }
                else
                {
                    Figure.MouseUpPosition = e.Location;

                }

                Brush.DrawMoveFigure(Figure);
            }


            //if (e.Button == MouseButtons.Right && _isResizing == true)
            //{
            //    int deltaX = e.Location.X - _pointMovingMouseDownPosition.X;
            //    int deltaY = e.Location.Y - _pointMovingMouseDownPosition.Y;
            //    if (_side != Side.None)
            //    {
            //        Figure.MouseDownPosition = e.Location;
            //    }
            //    else
            //    {
            //        Figure.MouseUpPosition = e.Location;

            //        switch (_side)
            //        {
            //            case Side.Left:
            //                Figure.MouseDownPosition = new Point(_mouseDownPosition.X + deltaX, _mouseDownPosition.Y);
            //                break;
            //            case Side.Right:
            //                Figure.MouseDownPosition = new Point(_mouseDownPosition.X + deltaX, _mouseDownPosition.Y);
            //                break;
            //            case Side.Up:
            //                Figure.MouseDownPosition = new Point(_mouseDownPosition.X + deltaX, _mouseDownPosition.Y);
            //                break;
            //            case Side.Down:
            //                Figure.MouseDownPosition = new Point(_mouseDownPosition.X + deltaX, _mouseDownPosition.Y);
            //                break;

            //        }

            //        Brush.DrawResizingFigure(Figure, deltaX, deltaY, _side);
            //    }
            //    Brush.DrawMoveFigure(Figure);
            //}
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (Figures != null && e.Button == MouseButtons.Right)
            {
                foreach (IFigure figure in Figures)
                {
                    if (figure.IsHavingPoint(e.Location))
                    {
                        Brush.Clear();
                        Brush.DrawMoveTmpFigure(Figures);
                        Figures.Remove(figure);
                        Brush.DrawMoveFigure(Figures);
                        Figure = (IFigure)figure.Clone();
                        _isMoving = true;
                        _pointMovingMouseDownPosition = e.Location;
                        return;
                    }
                }
            }

            if (_editing)
            {
                findSelectedFigure(e);

                Brush.Clear();

                Brush.DrawMoveTmpFigure(Figures);
                Figures.Remove(_crntFigure);
                Brush.DrawMoveFigure(Figures);
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

            if (_isMoving)
            {
                Size delta = new Size(e.Location.X - _pointMovingMouseDownPosition.X, e.Location.Y - _pointMovingMouseDownPosition.Y);
                Figure.MouseDownPosition = Point.Add(Figure.MouseDownPosition, delta);
                Figure.MouseUpPosition = Point.Add(Figure.MouseUpPosition, delta);
                Figures.Add((IFigure)Figure.Clone());
                _isMoving = false;
                Brush.TmpToMainBitmap();
                return;
            }

            Brush.TmpToMainBitmap();

            if (Figure != null)
            {
                if (_isEnd)
                {
                    Figure.MouseDownPosition = e.Location;
                }
                else
                {
                    Figure.MouseUpPosition = e.Location;

                }
                Figures.Add(Figure);
                Figure = (IFigure)(Figure.Clone());
            }

            _crntFigure = null;

        }

        private void findSelectedFigure(MouseEventArgs e)
        {
            foreach (IFigure a in Figures)
            {
                if (a is AbstractArrow)
                {
                    if (Math.Abs(a.MouseDownPosition.X - e.X) < 10 && Math.Abs(a.MouseDownPosition.Y - e.Y) < 10)
                    {
                        _isEnd = true;
                        _crntFigure = a;
                        break;
                    }
                    if (Math.Abs(a.MouseUpPosition.X - e.X) < 10 && Math.Abs(a.MouseUpPosition.Y - e.Y) < 10)
                    {
                        _isEnd = false;
                        _crntFigure = a;
                        break;
                    }
                }
                if (a is AbstractClassFigure)
                {
                    Point[] Rectangle = Geometry.GetRectangle(a.MouseUpPosition, a.MouseDownPosition);


                    for (int i = 0; i < 4; ++i)
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
                            if (i == 3)
                            {
                                a.MouseDownPosition = Rectangle[1];
                                a.MouseUpPosition = Rectangle[3];
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
            Figures.Clear();
        }


        private void SetArrow()
        {
            switch (_figureName)
            {
                case "association":
                    Figure = new ArrowAssociation(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "inheritance":
                    Figure = new ArrowInheritance(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "aggregation":
                    Figure = new ArrowAggregation(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "aggregationPlus":
                    Figure = new ArrowAggregationPlus(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "composition":
                    Figure = new ArrowСomposition(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "compositionPlus":
                    Figure = new ArrowСompositionPlus(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "implementation":
                    Figure = new ArrowImplementation(Brush.Color, Brush.TrackBarWidth);
                    break;
            }

            pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
        }



        private void SetClass()
        {
            switch (_figureName)
            {
                case "Classes1":
                    Figure = new Class1Figure(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "Classes2":
                    Figure = new Class2Figure(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "Classes3":
                    Figure = new Class3Figure(Brush.Color, Brush.TrackBarWidth);
                    break;
                case "ClassStack":
                    Figure = new ClassStackFigure(Brush.Color, Brush.TrackBarWidth);
                    break;
            }

            pictureBox_Arrows.ImageLocation = @"ImagesArrows\Arrows.JPG";
        }


        private void button_StepBack_Click(object sender, EventArgs e)
        {
            textBox1.Location = new Point(750, 50);
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color.BackColor = colorDialog1.Color;
                Brush.Color = colorDialog1.Color;
                Figure.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            Brush.TrackBarWidth = trackBar1.Value;
            Figure.Width = trackBar1.Value;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_editing)
            {
                _editing = false;
                Button b = (Button)sender;
                b.Text = "Off";
            }
            else
            {
                _editing = true;
                Button b = (Button)sender;
                b.Text = "On";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLineOptions.Text = comboBox1.Text; //смена с ломаной на прямую
        }

        //private void KeyDeleteUp(object sender, PreviewKeyDownEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Delete:
        //            Figures.RemoveAt(Figures.Count - 1);
        //            Brush.Clear();
        //            Brush.DrawMoveFigure(Figure);
        //            break;
        //    }
        //}

        private void button_DeleteFigure_Click(object sender, EventArgs e)
        {
            Figures.RemoveAt(Figures.Count - 1);
            Brush.Clear();
            Brush.DrawMoveFigure(Figures);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Figure is AbstractClassFigure && Figure != null)
            {
                Brush.Clear();
                Figures.Remove(Figure);
                Figure.Text[selectRow]=textBox1.Text;
                Figures.Add(Figure);
                Brush.DrawMoveFigure(Figures);
                Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
           //    Figure.Size = size.Width;
              textBox1.Width = size.Width;
              textBox1.Height = size.Height;
            }
            // Size= size.Width;
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (Figure is AbstractClassFigure && Figure != null)
            {
                Figure.CountString++;
               //if (Figure.CountString >4) 
               // {
               //     Figure.Text.Add("");
               // }
                
                Brush.Clear();
                Figures.Remove(Figure);
                Figures.Add(Figure);
                Brush.DrawMoveFigure(Figures);
              //  Figure.Text[Figure.CountString - 1] = " ";


            }
        }



        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {if (_editing)
            {
               

                if (Figure is AbstractClassFigure && Figure != null)
                {
                    textBox1.Visible = true;
                    
                    if (RowSelection(e, Figure.MouseUpPosition, Figure.MouseDownPosition) <= 0)
                    {
                        return;
                    }
                    selectRow = RowSelection(e, Figure.MouseUpPosition, Figure.MouseDownPosition);
                    textBox1.Location = RowPoint(selectRow, Figure.MouseUpPosition, Figure.MouseDownPosition);
                    //MessageBox.Show($"X{textBox1.Location.X}   Y{textBox1.Location.Y}");
                    textBox1.Text=( $"{Figure.Text[selectRow]}");
                    //MessageBox.Show($"{selectRow}");
                    //Brush.Clear();
                    //Figures.Remove(Figure);
                    //Figure.Text[selectRow-1]= textBox1.Text;                    
                    //Figures.Add(Figure);
                    //Brush.DrawMoveFigure(Figures);


                }
            }
            // MessageBox.Show("По ебалу себе пощелкай");
        }



        private Point RowPoint(int selectRow, Point MouseUpPosition, Point MouseDownPosition)
        { int k = 25;
            int indent = 5;
            if ((MouseDownPosition.Y - MouseUpPosition.Y) > 0)
            {
                if (MouseUpPosition.X - MouseDownPosition.X > 0)//1 
                {                    
                    return new Point(MouseDownPosition.X+ indent, MouseUpPosition.Y + (k * selectRow));                      
                }
                else if (MouseDownPosition.X - MouseUpPosition.X > 0)//2
                {
                    return new Point(MouseUpPosition.X+ indent, MouseUpPosition.Y + k * selectRow);                  
                }
                
            }
            else if ((MouseUpPosition.Y - MouseDownPosition.Y) > 0)
            {
                if (MouseDownPosition.X - MouseUpPosition.X > 0)//3
                {
                     return new Point(MouseUpPosition.X+ indent, MouseDownPosition.Y + k * selectRow);                  
                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 0)//4 
                {
                 return new Point(MouseDownPosition.X+ indent, MouseDownPosition.Y + k * selectRow);                     
                }
            }
            return new Point(1000,50);         
        }
        private int RowSelection(MouseEventArgs e, Point MouseUpPosition, Point MouseDownPosition)
        {
            int k = 25;
            if ((MouseDownPosition.Y - MouseUpPosition.Y) > 10)
            {
                if (MouseUpPosition.X - MouseDownPosition.X > 10)//1 
                {
                    for (int i = 0; i <= Figure.CountString; i++)
                    {
                        if (Geometry.FindPointInClass(new Point(MouseDownPosition.X, MouseUpPosition.Y + k * i), new Point(MouseUpPosition.X, MouseUpPosition.Y + (k * i) + k), e.Location))
                        {
                            return i;
                        }
                    }
                }
                else if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    //2
                    for (int i = 0; i <= Figure.CountString; i++)
                    {
                        if (Geometry.FindPointInClass(new Point(MouseUpPosition.X, MouseUpPosition.Y + k * i), new Point(MouseDownPosition.X, MouseUpPosition.Y + (k * i) + k), e.Location))
                        {
                            return i;
                        }
                    }
                }

            }
            else if ((MouseUpPosition.Y - MouseDownPosition.Y) > 10)
            {

                if (MouseDownPosition.X - MouseUpPosition.X > 10)
                {
                    //3
                    for (int i = 0; i <= Figure.CountString; i++)
                    {
                        if (Geometry.FindPointInClass(new Point(MouseUpPosition.X, MouseDownPosition.Y + k * i), new Point(MouseDownPosition.X, MouseDownPosition.Y + (k * i) + k), e.Location))
                        {
                            return i;
                        }
                    }
                }
                else if (MouseUpPosition.X - MouseDownPosition.X > 10)
                {
                    //4
                    for (int i = 0; i <= Figure.CountString; i++)
                    {
                        if (Geometry.FindPointInClass(new Point(MouseDownPosition.X, MouseDownPosition.Y + k * i), new Point(MouseUpPosition.X, MouseDownPosition.Y + (k * i) + k), e.Location))
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Brush.Clear();
                Figures.Remove(Figure);
                Figure.Text[selectRow] = textBox1.Text;
                Figures.Add(Figure);
                Brush.DrawMoveFigure(Figures);
                 textBox1.Visible = false;
            }
            if (e.KeyCode == Keys.Tab)
            {
                selectRow += 1;
            }
        }

       
    }
}
