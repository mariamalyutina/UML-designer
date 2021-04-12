using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    class ArrowAssociation : AbstractArrow
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, MouseDownPosition, MouseUpPosition);
            graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[0]); //отрисовка крыльев стрелки
            graphics.DrawLine(pen, MouseUpPosition, Geometry.GetArrow(MouseUpPosition, MouseDownPosition)[2]); //отрисовка крыльев стрелки
        }

        public override object Clone()
        {
            return new ArrowAssociation();
        }
    }
}
