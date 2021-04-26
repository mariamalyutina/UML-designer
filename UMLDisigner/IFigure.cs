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

        void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0);

        bool IsHavingPoint(Point checkedPoint);

        List<Point> GetFigurePoints();

    }

}
