using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public class CurvedLine : AbstractLine
    {
        public override void Draw(Graphics graphics, Pen pen, Point endPoint, Point startPoint)
        {
            //задать логику ломания + добавить метод в геометрии для другого типа ломания
            graphics.DrawLines(pen, Geometry.GetCurvedPoints(startPoint, endPoint).ToArray());
        }
    }
}
