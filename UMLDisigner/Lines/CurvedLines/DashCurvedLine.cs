using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class DashCurvedLine : CurvedLine
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            ////задать логику ломания + добавить метод в геометрии для другого типа ломания
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawLines(pen, Geometry.GetCurvedPoints(startPoint, endPoint).ToArray());
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }
    }
}
