using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    public class Class1Figure : AbstractClassFigure
    {
        public Class1Figure()
        {
            
        }

        public Class1Figure(Color color, int width)
        {
            TextField[0] = "Interface";
            Color = color;
            Width = width;
        }

        public Class1Figure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width)
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
            int height = 100;
            int width = 150;
            int tmpMouseDownPositionX = MouseDownPosition.X;
            int tmpMouseDownPositionY = MouseDownPosition.Y;
            int tmpMouseUpPositionX = MouseDownPosition.X + width;
            int tmpMouseUpPositionY = MouseDownPosition.Y + height;


            
            int k = 20;
            int indent = 0;
            for (int i = 0; i <= CountFieldString; i++)
            {
                int fac = k * (i)+5;
                if (tmpMouseUpPositionX - tmpMouseDownPositionX < Size)
                {
                    tmpMouseUpPositionX+= (Size - (tmpMouseUpPositionX - tmpMouseDownPositionX)+k);
                }
                if(tmpMouseUpPositionY - tmpMouseDownPositionY < fac+k)
                {
                    tmpMouseUpPositionY += (fac - (tmpMouseUpPositionY - tmpMouseDownPositionY) + 25);
                }
                graphics.DrawString(TextField[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX + indent, tmpMouseDownPositionY + deltaY + fac));

            }
            graphics.DrawPolygon(pen1, Geometry.GetRectangle(Point.Add(new Point(tmpMouseUpPositionX, tmpMouseUpPositionY), delta), Point.Add(MouseDownPosition, delta)));
            MouseUpPosition = new Point(tmpMouseUpPositionX, tmpMouseUpPositionY);



          
        }
    }
}