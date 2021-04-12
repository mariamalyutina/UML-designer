﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
   public class Brush
    {
        public Color Color { get; set; } = Color.Black;
        public int TrackBarWidth;
        Bitmap _mainBitmap;
        Bitmap _tmpBitmap;
        Graphics graphics;
        Pen pen;
        PictureBox pb;

        public Brush(PictureBox pb)
        {
            _mainBitmap = new Bitmap(pb.Width, pb.Height);
            _tmpBitmap = _mainBitmap;
            pen = new Pen(Color, TrackBarWidth);
            graphics = Graphics.FromImage(_mainBitmap);

            graphics.Clear(Color.White);
            this.pb = pb;
            pb.Image = _mainBitmap;
        }
        public void DrawMoveFigure(IFigure figure)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone(); 
            graphics = Graphics.FromImage(_tmpBitmap);
            pen.Color = Color;
            pen.Width = TrackBarWidth;
            figure.Draw(graphics, pen);
            pb.Image = _tmpBitmap;
           // GC.Collect();
            //pb.Invalidate();
        }

        public void DrawMoveFigure(List<IFigure> figure)
        {

            graphics = Graphics.FromImage(_mainBitmap);
            pen.Color = Color;
            pen.Width = TrackBarWidth;
            foreach (IFigure a in figure)
            {
                a.Draw(graphics, pen);
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
