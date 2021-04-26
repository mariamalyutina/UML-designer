using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public abstract class AbstractClassFigure : IFigure
    {
        protected Font _font = new Font("Arial", 16);
        protected SolidBrush _brush = new SolidBrush(Color.Black);

        public List<string> TextField { get; set; } = new List<string>() { "Classname", "+ field : type", "+ field : type", "+ field : type", "+ field : type", "+ field : type", "+ field : type", "" };
        public List<string> TextMethod { get; set; } = new List<string>() { "+ method : type", "+ method : type", "+ method : type", "+ method : type", "+ method : type", "+ method : type", "", "" };

        public int Size { get; set; }
        public int CountFieldString { get; set; }
        public int CountMethodString { get; set; }
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
