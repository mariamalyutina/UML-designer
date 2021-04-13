using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractArrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public bool IsCurved { get; set; }

        public abstract void Draw(Graphics graphics, Pen pen);

        protected List<Point> GetPoints(Point startPoint, Point endPoint) //точки для ломания линий (start point и end point у каждой линии разные из-за разных наконечников)
        {
            List<Point> points = new List<Point>();
            points.Add(startPoint);

            int middleX = (startPoint.X + endPoint.X) / 2;

            points.Add(new Point(middleX, startPoint.Y)); //1-ый излом
            points.Add(new Point(middleX, endPoint.Y));//2-ой излом

            points.Add(endPoint);

            return points;
        }

    }
}
