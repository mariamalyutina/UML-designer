using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractArrow : IFigure
    {
        //protected ICap _capType;
        protected AbstractCap _capType;

        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public bool IsCurved { get; set; }
        public AbstractArrow(Point MouseDownPosition, Point MouseUpPosition)
        {
            this.MouseDownPosition = MouseDownPosition;
            this.MouseUpPosition = MouseUpPosition;
        }

        public AbstractArrow()
        {

        public abstract object Clone();
        public abstract void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0);

        public bool IsHavingPoint(Point checkedPoint)
        {
            return false;
        }

        public Side SideForResizing(Point checkedPoint)
        {
            return Side.None;
        }

        public Vertex VertexForResizing(Point checkedPoint)
        {
            throw new NotImplementedException();
        }


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
