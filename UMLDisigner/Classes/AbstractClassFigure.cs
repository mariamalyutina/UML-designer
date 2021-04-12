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

        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }
        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public abstract object Clone();

        public abstract void Draw(Graphics graphics, Pen pen, int deltaX, int deltaY);

        public bool IsHavingPoint(Point checkedPoint)
        {
            //    if (Math.Min(MouseDownPosition.X, MouseUpPosition.X) <= checkedPoint.X && Math.Max(MouseDownPosition.X, MouseUpPosition.X) >= checkedPoint.X 
            //        && Math.Min(MouseDownPosition.Y, MouseUpPosition.Y) <= checkedPoint.Y && Math.Max(MouseDownPosition.Y, MouseUpPosition.Y) >= checkedPoint.Y)
            //    {
            //        return true;
            //    }

            //    return false;

            int xMax;
            int xMin;
            int yMax;
            int yMin;

            if (MouseDownPosition.X > MouseUpPosition.X)
            {
                xMax = MouseDownPosition.X;
                xMin = MouseUpPosition.X;
            }
            else
            {
                xMin = MouseDownPosition.X;
                xMax = MouseUpPosition.X;
            }

            if (MouseDownPosition.Y > MouseUpPosition.Y)
            {
                yMax = MouseDownPosition.Y;
                yMin = MouseUpPosition.Y;
            }
            else
            {
                yMin = MouseDownPosition.Y;
                yMax = MouseUpPosition.Y;
            }

            if (checkedPoint.X <= xMax && checkedPoint.X >= xMin
             && checkedPoint.Y <= yMax && checkedPoint.Y >= yMin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  void Move(double delta)
        {

        }

    }
}
