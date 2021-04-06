using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
   public class Brush
    {
        public Color Color { get; set; } = Color.Black;
        Bitmap _mainBitmap;
        Bitmap _tmpBitmap;
        Graphics graphics;
        Pen pen;
        PictureBox pb;

        public Brush(PictureBox pb)
        {
            _mainBitmap = new Bitmap(pb.Width, pb.Height);
            pen = new Pen(Color, 3);
            graphics = Graphics.FromImage(_mainBitmap);

            graphics.Clear(Color.White);
            this.pb = pb;
            pb.Image = _mainBitmap;
        }
        public void DrawMoveFigure(IFigure figure, Points p)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            graphics = Graphics.FromImage(_tmpBitmap);
            pen.Color = Color;
            figure.Draw(graphics, pen, p);
            pb.Image = _tmpBitmap;
            GC.Collect();
            //pb.Invalidate();
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
