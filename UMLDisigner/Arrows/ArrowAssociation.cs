using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    class ArrowAssociation : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point mouseUpPosition, Point mouseDownPosition)
        {
            graphics.DrawLine(pen, mouseDownPosition, mouseUpPosition);
            graphics.DrawLine(pen, mouseUpPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[0]); //отрисовка крыльев стрелки
            graphics.DrawLine(pen, mouseUpPosition, Geometry.GetArrow(mouseUpPosition, mouseDownPosition)[2]); //отрисовка крыльев стрелки
        }


    }
}
