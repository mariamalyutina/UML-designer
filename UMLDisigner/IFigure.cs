using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure : ICloneable
    {
        Point MouseUpPosition { get; set; }
        Point MouseDownPosition { get; set; }

        void Draw(Graphics graphics, Pen pen);
        protected List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();

            points.Add(MouseDownPosition);

            points.Add(MouseUpPosition);

            return points;
        }
    }

}
