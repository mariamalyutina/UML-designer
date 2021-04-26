using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class DashStraightLine : StraightLine
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLine(pen, endPoint, startPoint);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }
    }
}
