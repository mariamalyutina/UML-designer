using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure
    {
        Point MouseUpPosition { get; set; }
        Point MouseDownPosition { get; set; }

        Color Color { get; set; }
        int Width { get; set; }

        public List<string> TextField { get; set; }
        public List<string> TextMethod { get; set; }
        public int Size { get; set; }
        public int CountFieldString { get; set; }
        public int CountMethodString { get; set; }

        void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0);

        bool IsHavingPoint(Point checkedPoint);

        List<Point> GetFigurePoints();

    }

}
