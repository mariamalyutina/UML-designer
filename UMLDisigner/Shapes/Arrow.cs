using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class Arrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; }
        public int Width { get; set; }
        public int CountFieldString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> TextField { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> TextMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CountMethodString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AbstractLine LineType;
        protected AbstractCap _capTypeBeginning;
        protected AbstractCap _capTypeEnding;


        public Arrow(Color color, int width, AbstractLine lineType, AbstractCap firstCap, AbstractCap endCap)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = firstCap;
            _capTypeEnding = endCap;
        }


        public void Draw(Graphics graphics, int deltaX, int deltaY)

        {
            Point tmpMouseDownPosition = MouseDownPosition;
            Point tmpMouseUpPosition = MouseUpPosition;
            Size delta = new Size(deltaX, deltaY);
            MouseDownPosition = Point.Add(MouseDownPosition, delta);
            MouseUpPosition = Point.Add(MouseUpPosition, delta);
            

            Pen pen = new Pen(Color, Width);
            SolidBrush brush = new SolidBrush(Color.White);

            LineType.Draw(graphics, pen, MouseUpPosition, MouseDownPosition);

            Point capBeginningStartPoint = MouseDownPosition;
            Point capEndingEndPoint = MouseUpPosition;

            if (LineType is CurvedLine)
            {
                capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                capEndingEndPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[1];
            }

            _capTypeBeginning.Draw(graphics, pen, brush, MouseUpPosition, capBeginningStartPoint);

            if (!(_capTypeEnding is null))
            {
                _capTypeEnding.Draw(graphics, pen, brush, MouseDownPosition, capEndingEndPoint);
            }

            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;
        }


        public bool IsHavingPoint(Point checkedPoint)
        {
            if (Geometry.FindPointInClass(MouseUpPosition, MouseDownPosition, checkedPoint))
            {
                if (LineType is CurvedLine)
                {
                    Point capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                    Point capEndingEndPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[1];
                    if (Geometry.FindPointInArrow(MouseDownPosition, capEndingEndPoint, checkedPoint) 
                        || Geometry.FindPointInArrow(capEndingEndPoint, capBeginningStartPoint, checkedPoint)
                        || Geometry.FindPointInArrow(capBeginningStartPoint, MouseUpPosition, checkedPoint))
                    {
                        return true;
                    }

                }
                else 
                {
                    return Geometry.FindPointInArrow(MouseUpPosition, MouseDownPosition, checkedPoint);
                }
            }
 
            return false;
            
        }


        public List<Point> GetFigurePoints()
        {
            List<Point> points = new List<Point>();
            points.Add(MouseDownPosition);
            if (LineType is CurvedLine)
            {
                points.Add(Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition)[1]);
                points.Add(Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition)[2]);
            }
            points.Add(MouseUpPosition);
            return points;
        }

        //public void MarkAsSelected(Graphics graphics) //для выделения фигуры точками
        //{
        //    Pen pen = new Pen(Color.Red, 2);
        //    foreach (Point p in GetFigurePoints())
        //    {
        //        graphics.DrawEllipse(pen, p.X - (pen.Width * 3) / 2, p.Y - (pen.Width * 3) / 2, pen.Width * 3, pen.Width * 3);
        //    }
        //}



    }
}
