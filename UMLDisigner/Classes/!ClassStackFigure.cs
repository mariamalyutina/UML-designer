//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;

//namespace UMLDisigner
//{
//    class ClassStackFigure : AbstractClassFigure
//    {
//        public ClassStackFigure(Color color, int width)
//        {
//            Color = color;
//            Width = width;
//            //_font = font;
//            //_brush = brush;
//        }

//        public ClassStackFigure(Point mouseDownPosition, Point mouseUpPosition, Color color, int width,
//            List<string> text, int size, int countString=1)
//        {
//            MouseDownPosition = mouseDownPosition;
//            MouseUpPosition = mouseUpPosition;
//            Color = color;
//            Width = width;
            
//            //  Text = new List<string>();               
//            Text = text;           
//            //   Size = size;
//            CountString = countString;
//            //_font = font;
//            //_brush = brush;
//        }

//        public override void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0)
//        {
            
//            SolidBrush _whiteBrush = new SolidBrush(Color.White);
//            pen.Width += 1;
//            int j = 0;
//            for (int i = 0; i < 5; i++, j += 5)
//            {
//                int crntMouseDownX = MouseDownPosition.X + j + deltaX;
//                int crntMouseDownY = MouseDownPosition.Y + j + deltaY;
//                int crntMouseUpX = MouseUpPosition.X + j + deltaX;
//                int crntMouseUpY = MouseUpPosition.Y + j + deltaY;
//                graphics.DrawPolygon(pen, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
//                graphics.FillPolygon(_whiteBrush, Geometry.GetRectangle(new Point(crntMouseDownX, crntMouseDownY), new Point(crntMouseUpX, crntMouseUpY)));
//            }

           

//            int k = 25;
//            pen.Width -= 2;
//            for (int i = 0; i <= CountString; i++)
//            {
//                int fac = k * (i+1);
                

//                if ((MouseDownPosition.Y - MouseUpPosition.Y) >fac)
//                {
                    
//                    graphics.DrawLine(pen, new Point(MouseDownPosition.X + deltaX + 20, MouseUpPosition.Y + fac + 25 + deltaY),
//                          new Point(MouseUpPosition.X + 20 + deltaX, MouseUpPosition.Y + fac+25 + deltaY));
//                    if (MouseDownPosition.X - MouseUpPosition.X > Size)
//                    {
//                        graphics.DrawString(Text[i], _font, _brush, new Point(MouseUpPosition.X + deltaX + 20, MouseUpPosition.Y + fac + deltaY));

//                    }
//                    else if (MouseUpPosition.X - MouseDownPosition.X >0)
//                    {
//                        //if(MouseUpPosition.X - MouseDownPosition.X > Size)
//                        //{
//                        //    MouseUpPosition.X += 10;
//                        //}
//                        graphics.DrawString(Text[i], _font, _brush, new Point(MouseDownPosition.X + deltaX + 20, MouseUpPosition.Y + fac + deltaY));
//                    }
//                }
//                if ((MouseUpPosition.Y - MouseDownPosition.Y) > fac)
//                {
//                    if (MouseDownPosition.X - MouseUpPosition.X > Size)
//                    {
//                        graphics.DrawString(Text[i], _font, _brush, new Point(MouseUpPosition.X +  20, MouseDownPosition.Y + fac + deltaY));
//                    }
//                    else if (MouseUpPosition.X - MouseDownPosition.X > Size)
//                    {
//                        graphics.DrawString(Text[i], _font, _brush, new Point(MouseDownPosition.X + deltaX + 20, MouseDownPosition.Y + fac + deltaY));
//                    }
//                }

//            }
//        }

       
//    }
//}