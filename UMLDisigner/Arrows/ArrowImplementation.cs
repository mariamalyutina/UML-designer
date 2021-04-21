using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ArrowImplementation : AbstractArrow
    {

        public ArrowImplementation(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new TriangleCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            Point tmpMouseDownPosition = MouseDownPosition;
            Point tmpMouseUpPosition = MouseUpPosition;
            Size delta = new Size(deltaX, deltaY);
            MouseDownPosition = Point.Add(MouseDownPosition, delta);
            MouseUpPosition = Point.Add(MouseUpPosition, delta);
            Pen pen = new Pen(Color, Width);
            SolidBrush brush = new SolidBrush(Color.White);

            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            LineType.Draw(graphics, pen, MouseUpPosition, MouseDownPosition);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            Point capBeginningStartPoint;
            if (LineType is StraightLine)
            {
                capBeginningStartPoint = MouseDownPosition;
            }
            else
            {
                capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            }

            _capTypeBeginning.Draw(graphics, pen, brush, MouseUpPosition, capBeginningStartPoint);

            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;
        }


        public override object Clone()
        {
            return new ArrowImplementation(this.Color, this.Width, this.LineType)
            {
                MouseDownPosition = this.MouseDownPosition,
                MouseUpPosition = this.MouseUpPosition
            };
        }
    }
}
