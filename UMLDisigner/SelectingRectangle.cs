using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class SelectingRectangle : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }

        public SelectingRectangle(Color color, int width = 3)
        {
            Color = color;
            Width = width;
        }
        public SelectingRectangle()
        {

        }




        public void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0)
        {
            Pen pen = new Pen(Color.Red, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Point[] p = Geometry.GetRectangle(MouseUpPosition, MouseDownPosition);
            graphics.DrawPolygon(pen, Geometry.GetRectangle(MouseUpPosition, MouseDownPosition));
        }

        public List<Point> GetFigurePoints()
        {
            List<Point> points = new List<Point>();
            foreach (Point p in Geometry.GetRectangle(MouseUpPosition, MouseDownPosition))
            {
                points.Add(p);
            }
            return points;
        }

        public bool IsHavingPoint(Point checkedPoint)
        {
            return Geometry.FindPointInClass(MouseUpPosition, MouseDownPosition, checkedPoint);
        }
    }
}
