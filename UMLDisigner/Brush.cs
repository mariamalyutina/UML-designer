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

        public void DrawAllFigures(List<IFigure> ListFigures)
        {
            _mainBitmap = new Bitmap(pb.Width, pb.Height);
            graphics = Graphics.FromImage(_mainBitmap);
            graphics.Clear(Color.White);

            foreach (IFigure figure in ListFigures)
            {
                pen.Color = figure.Color;
                pen.Width = figure.Width;
                figure.Draw(graphics, pen);
            }
            pb.Image = _mainBitmap;
        }

        //public void DrawMovingFigure(IFigure figure, int deltaX, int deltaY)
        //{
        //    _tmpBitmap = (Bitmap)_mainBitmap.Clone();
        //    graphics = Graphics.FromImage(_tmpBitmap);
        //    pen.Color = figure.Color;
        //    pen.Width = figure.Width;
        //    figure.Draw(graphics, pen, deltaX, deltaY);
        //    pb.Image = _tmpBitmap;
        //    GC.Collect();
        //}

        //public void DrawMoveFigure(IFigure figure)
        //{
        //    _tmpBitmap = (Bitmap)_mainBitmap.Clone();
        //    graphics = Graphics.FromImage(_tmpBitmap);

        //    figure.Color = Color;
        //    figure.Width = TrackBarWidth;

        //    pen.Color = Color;
        //    pen.Width = TrackBarWidth;

        //    figure.Draw(graphics, pen);
        //    pb.Image = _tmpBitmap;
        //    GC.Collect();
        //    //pb.Invalidate();
        //}

        public void DrawMoveFigure(IFigure figure, int deltaX = 0, int deltaY = 0)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tmpBitmap);
            pen.Color = figure.Color;
            pen.Width = figure.Width;
            figure.Draw(graphics, pen, deltaX, deltaY);
            pb.Image = _tmpBitmap;
            // GC.Collect();
            //pb.Invalidate();
        }


        public void DrawMoveFigure(List<IFigure> figure)
        {

            graphics = Graphics.FromImage(_mainBitmap);
            
            foreach (IFigure a in figure)
            {
                pen.Color = a.Color;
                pen.Width = a.Width;
                a.Draw(graphics, pen);
            }
            pb.Invalidate();

        }

        public void DrawMoveTmpFigure(List<IFigure> figure)
        {
            _tempBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tempBitmap);
            
            foreach (IFigure a in figure)
            {
                pen.Color = a.Color;
                pen.Width = a.Width;
                a.Draw(graphics, pen);
            }
            pb.Image = _tempBitmap;
            pb.Invalidate();
            //GC.Collect();

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
