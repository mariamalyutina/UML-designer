using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class Class3Figure : AbstractClassFigure
    {
        
       

        public Class3Figure()
        {
        }

        public Class3Figure(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        public Class3Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;
        }

        public override void Draw(Graphics graphics, int deltaX = 0, int deltaY = 0)
        {
           
            Pen pen1 = new Pen(Color, Width);
            Size delta = new Size(deltaX, deltaY);
            int height = 120;
            int width = 200;
            int bottomLineHeight = 70;
            int topLineHeight = 27;
            int tmpMouseDownPositionX = MouseDownPosition.X;
            int tmpMouseDownPositionY = MouseDownPosition.Y;
            int tmpMouseUpPositionX = MouseDownPosition.X + width;
            int tmpMouseUpPositionY = MouseDownPosition.Y + height;
            int k = 20;
            int indent = 0;

            for (int i = 0; i <= CountFieldString; i++)
            {
                int fac = k * (i) + 5;
                if (tmpMouseUpPositionX - tmpMouseDownPositionX < Size)
                {
                    tmpMouseUpPositionX += (Size - (tmpMouseUpPositionX - tmpMouseDownPositionX) + k);
                }
                if (tmpMouseUpPositionY - tmpMouseDownPositionY < fac + k)
                {
                    bottomLineHeight += (fac - (tmpMouseUpPositionY - tmpMouseDownPositionY) + 25 );
                    tmpMouseUpPositionY += (fac - (tmpMouseUpPositionY - tmpMouseDownPositionY) + 25 );
                }
                if ((tmpMouseDownPositionY+bottomLineHeight) - tmpMouseDownPositionY < fac + k)
                {
                    tmpMouseUpPositionY += (fac - ((tmpMouseDownPositionY + bottomLineHeight) - tmpMouseDownPositionY) + 25 );
                    bottomLineHeight += (fac - ((tmpMouseDownPositionY + bottomLineHeight) - tmpMouseDownPositionY) + 25 );
                }

                    graphics.DrawString(TextField[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX + indent, tmpMouseDownPositionY + deltaY + fac));

            }

            graphics.DrawLine(pen1, new Point(MouseDownPosition.X + deltaX, MouseDownPosition.Y + bottomLineHeight + deltaY),
                new Point(tmpMouseUpPositionX + deltaX, MouseDownPosition.Y + bottomLineHeight + deltaY));
            for (int i = 0; i <= CountMethodString; i++)
            {
                int fac = k * (i) + 5;
                if (tmpMouseUpPositionX - tmpMouseDownPositionX < Size)
                {
                    tmpMouseUpPositionX += (Size - (tmpMouseUpPositionX - tmpMouseDownPositionX) + k);
                }
                if ((tmpMouseUpPositionY - (tmpMouseDownPositionY + bottomLineHeight) < fac + k))
                {
                    tmpMouseUpPositionY += (fac - (tmpMouseUpPositionY - (tmpMouseDownPositionY + bottomLineHeight)) + 25 );
                }
                graphics.DrawString(TextMethod[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX + indent, tmpMouseDownPositionY + bottomLineHeight - 10 + deltaY + fac));

            }
            graphics.DrawPolygon(pen1, Geometry.GetRectangle(Point.Add(new Point(tmpMouseUpPositionX, tmpMouseUpPositionY), delta), Point.Add(MouseDownPosition, delta)));

           
            graphics.DrawLine(pen1, new Point(MouseDownPosition.X + deltaX, MouseDownPosition.Y + topLineHeight + deltaY),
             new Point(tmpMouseUpPositionX + deltaX, MouseDownPosition.Y + topLineHeight + deltaY));

            
            MouseUpPosition = new Point(tmpMouseUpPositionX, tmpMouseUpPositionY);
         
           
        }

    }
}