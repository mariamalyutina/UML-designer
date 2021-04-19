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
            Pen pen1 = new Pen(Color, Width);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            LineType.Draw(graphics, pen1, MouseUpPosition, MouseDownPosition);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            Point capBeginningStartPoint;
            if (LineType is StraightLine)
            {
                capBeginningStartPoint = MouseDownPosition;
            }
            else
            {
                capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
            }

            _capTypeBeginning.Draw(graphics, pen1, MouseUpPosition, capBeginningStartPoint);

        }


        public override object Clone()
        {
            return new ArrowImplementation(this.Color, this.Width, this.LineType);
        }

    }
}
