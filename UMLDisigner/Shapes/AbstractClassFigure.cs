using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    [Serializable]
    public abstract class AbstractClassFigure : IFigure
    {
        public Font _font = new Font("Arial", 16);
        public SolidBrush _brush = new SolidBrush(Color.Black);

        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public abstract void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0);

        public List<Point> GetFigurePoints()
        {
            List<Point> points = new List<Point>();
            foreach(Point p in Geometry.GetRectangle(MouseUpPosition, MouseDownPosition))
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
