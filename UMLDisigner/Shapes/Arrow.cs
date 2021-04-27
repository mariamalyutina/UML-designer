using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
  //  [Serializable]
    public class Arrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; }
        public int Width { get; set; }

        public AbstractLine LineType;
        public AbstractCap _capTypeBeginning;
        public AbstractCap _capTypeEnding;

        public Arrow()
        {

        }

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

        //public override bool Equals(object obj)
        //{
            
        //        Arrow arrow = (Arrow)obj;
        //        String lineType = Convert.ToString(this.LineType);
        //        String lineTypeArrow = Convert.ToString(arrow.LineType);
        //        String capTypeBeginning = Convert.ToString(this._capTypeBeginning);
        //        String capTypeBeginningArrow = Convert.ToString(arrow._capTypeBeginning);
        //        String capTypeEnding = Convert.ToString(this._capTypeEnding);
        //        String capTypeEndingArrow = Convert.ToString(arrow._capTypeEnding);

        //        if (this.MouseUpPosition != arrow.MouseUpPosition || this.MouseDownPosition != arrow.MouseDownPosition
        //            || this.Color != arrow.Color || this.Width != arrow.Width || lineType != lineTypeArrow
        //            || capTypeBeginning != capTypeBeginningArrow || capTypeEnding != capTypeEndingArrow)
        //        {
        //            return false;
        //        }
        //        return true;
            
        //}

        //public override string ToString()
        //{
        //    string s = $"MouseDownPosition: {MouseDownPosition} MouseUpPosition {MouseUpPosition} Color: {Color} Width: {Width} LineType: {LineType} _capTypeBeginnig: {_capTypeBeginning} _capTypeEnding: {_capTypeEnding}";

        //    return s;
        //}


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




    }
}
