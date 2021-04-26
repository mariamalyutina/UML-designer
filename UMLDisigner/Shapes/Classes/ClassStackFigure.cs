using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
    class ClassStackFigure : AbstractClassFigure
    {
        public ClassStackFigure(Color color, int width)
        {
            Color = color;
            Width = width;
            //_font = font;
            //_brush = brush;
        }

        public ClassStackFigure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width            )
        {
            MouseDownPosition = mouseDownPosition;
            MouseUpPosition = mouseUpPosition;
            Color = color;
            Width = width;        
        }

        public override void Draw(Graphics graphics,  int deltaX = 0, int deltaY = 0)
        {
            Pen pen = new Pen(Color, Width);
            int height = 120;
            int width = 200;
            int tmpMouseDownPositionX = MouseDownPosition.X;
            int tmpMouseDownPositionY = MouseDownPosition.Y;
            int tmpMouseUpPositionX = MouseDownPosition.X + width;
            int tmpMouseUpPositionY = MouseDownPosition.Y + height;



            int crntMouseDownX = tmpMouseDownPositionX;
            int crntMouseDownY = tmpMouseDownPositionY;
            int crntMouseUpX = tmpMouseUpPositionX;
            int crntMouseUpY = tmpMouseUpPositionY;
            SolidBrush _whiteBrush = new SolidBrush(Color.White);
            pen.Width += 1;


            int j = 0;

            for (int i = 0; i < 5; i++, j += 5)
            {
                int fac = 25 * CountFieldString + 5;
                if (crntMouseUpX - crntMouseDownX < Size)
                {
                    crntMouseUpX = (Size - (crntMouseUpX - crntMouseDownX) + tmpMouseUpPositionX - j + deltaX);
                }
                else
                {
                    crntMouseUpX = tmpMouseUpPositionX - j + deltaX;
                }
                if (crntMouseUpY - crntMouseDownY < fac + 25)
                {
                    crntMouseUpY += (fac - (crntMouseUpY - crntMouseDownY) + 25);
                }
                else
                {
                    crntMouseUpY = tmpMouseUpPositionY - j + deltaY;
                }


                crntMouseDownX = tmpMouseDownPositionX - j + deltaX;
                 crntMouseDownY = tmpMouseDownPositionY - j + deltaY;                 
              //  crntMouseUpX = MouseUpPosition.X - j + deltaX;
                /// crntMouseUpY = tmpMouseUpPositionY - j + deltaY;


                graphics.DrawPolygon(pen, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
                graphics.FillPolygon(_whiteBrush, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));

               
            }
            pen.Width -= 2;

           
            int k = 25;
            int indent = 0;
            for (int i = 0; i <= CountFieldString; i++)
            {
                int fac = k * (i);


                graphics.DrawString(TextField[i], _font, _brush, new Point(tmpMouseDownPositionX + deltaX + indent, tmpMouseDownPositionY + deltaY + fac));
                MouseUpPosition = new Point(tmpMouseUpPositionX, tmpMouseUpPositionY);

              
            }
        



        }


    }
}