using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
   public class Brush
    {
        public Color Color { get; set; } =  Color.Black;
        public int TrackBarWidth { get; set; } = 2;
        Bitmap _mainBitmap;
        Bitmap _tmpBitmap;
        Bitmap _tempBitmap;
        Graphics graphics;
        Pen pen;
        PictureBox pb;
        

        public Brush(PictureBox pb)
        {
            _mainBitmap = new Bitmap(pb.Width, pb.Height);
            
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            pen = new Pen(Color, TrackBarWidth);
            graphics = Graphics.FromImage(_mainBitmap);

            graphics.Clear(Color.White);
            this.pb = pb;
            pb.Image = _mainBitmap;
        }


        public void DrawMoveFigure(List<IFigure> figure)
        {
            graphics = Graphics.FromImage(_mainBitmap);

            foreach (IFigure a in figure)
            {
                //pen.Color = a.Color;
                //pen.Width = a.Width;
                a.Draw(graphics);
            }
            pb.Invalidate();

        }

        public void DrawMoveFigure(List<IFigure> figure, int deltaX = 0, int deltaY = 0)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tmpBitmap);

            foreach (IFigure a in figure)
            {
                a.Draw(graphics, deltaX, deltaY);
            }
            pb.Image = _tmpBitmap;
            pb.Invalidate();

        }



        public void DrawMoveFigure(IFigure figure, int deltaX = 0, int deltaY = 0)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone(); 
            graphics = Graphics.FromImage(_tmpBitmap);
            //pen.Color = figure.Color;
            //pen.Width = figure.Width;
            figure.Draw(graphics, deltaX, deltaY);
            pb.Image = _tmpBitmap;
            
            GC.Collect();
            //pb.Invalidate();
        }


        public void DrawMoveTmpFigure(List<IFigure> figure, int deltaX = 0, int deltaY = 0)
        {
            _tempBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tempBitmap);

            foreach (IFigure a in figure)
            {
                //pen.Color = a.Color;
                //pen.Width = a.Width;
                a.Draw(graphics, deltaX, deltaY);
            }
            pb.Image = _tempBitmap;
            pb.Invalidate();
            //GC.Collect();

        }

        public void MarkAsSelectedTmp(List<IFigure> figures)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tempBitmap);
            Pen pen = new Pen(Color.Red, 3);
            foreach (IFigure figure in figures)
            {
                if (figure is Arrow)
                {
                    foreach (Point p in figure.GetFigurePoints())
                    {
                        graphics.DrawEllipse(pen, p.X - (pen.Width * 4) / 2, p.Y - (pen.Width * 4) / 2, pen.Width * 4, pen.Width * 4);
                    }
                }
                else
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    Size sizeOne = new Size(10, 10);
                    Size sizeTwo = new Size(-10, -10);

                    graphics.DrawPolygon(pen, Geometry.GetRectangle(Point.Add(figure.MouseUpPosition, sizeOne),
                        Point.Add(figure.MouseDownPosition, sizeTwo)));
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                }
                pb.Invalidate();
            }
            
        }

        public void MarkAsSelected(List<IFigure> figures)
        {
            graphics = Graphics.FromImage(_mainBitmap);

            
            Pen pen = new Pen(Color.Red, 3);
            foreach(IFigure figure in figures)
            { 
                if (figure is Arrow)
                {
                    foreach (Point p in figure.GetFigurePoints())
                    {
                        graphics.DrawEllipse(pen, p.X - (pen.Width * 4) / 2, p.Y - (pen.Width * 4) / 2, pen.Width * 4, pen.Width * 4);
                    }
                }
                else
                {
                    Size sizeOne = new Size(10,10);
                    Size sizeTwo = new Size(-10, -10);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    graphics.DrawPolygon(pen, Geometry.GetRectangle(Point.Add(figure.MouseUpPosition,sizeOne), Point.Add(figure.MouseDownPosition, sizeTwo)));

                }
            }
            pb.Invalidate();
        }

        public void TmpToMainBitmap()
        {
            _mainBitmap = _tmpBitmap;
            
        }

        public void Clear()
        {
            graphics = Graphics.FromImage(_mainBitmap);
            graphics.Clear(Color.White);
            pb.Image = _mainBitmap;
        }

    }
}
