using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public static class Geometry
    {
        public static Point[] GetArrow(Point mouseUpPosition, Point mouseDownPosition) //стрелочки в начале
        {
            double d = Math.Sqrt(Math.Pow(mouseUpPosition.X - mouseDownPosition.X, 2) + Math.Pow(mouseUpPosition.Y - mouseDownPosition.Y, 2));

            double X = mouseUpPosition.X - mouseDownPosition.X;
            double Y = mouseUpPosition.Y - mouseDownPosition.Y;

            // координаты точки, удалённой от конца  отрезка на 20px
            double X4 = mouseUpPosition.X - (X / d) * 20;
            double Y4 = mouseUpPosition.Y - (Y / d) * 20;

            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = mouseUpPosition.Y - mouseDownPosition.Y;
            double Yp = mouseDownPosition.X - mouseUpPosition.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 15px в разные стороны
            double X5 = X4 + (Xp / d) * 15;
            double Y5 = Y4 + (Yp / d) * 15;
            double X6 = X4 - (Xp / d) * 15;
            double Y6 = Y4 - (Yp / d) * 15;

            Point[] ArrowsSholders = new Point[] {new Point ((int)X5, (int)Y5), new Point(mouseUpPosition.X, mouseUpPosition.Y),
                                                        new Point((int)X6, (int)Y6), new Point((int)X4, (int)Y4)};
            return ArrowsSholders;
        }

        public static Point[] GetRomb(Point mouseUpPosition, Point mouseDownPosition) //ромбик в начале
        {
            double d = Math.Sqrt(Math.Pow(mouseUpPosition.X - mouseDownPosition.X, 2) + Math.Pow(mouseUpPosition.Y - mouseDownPosition.Y, 2));

            double X = mouseUpPosition.X - mouseDownPosition.X;
            double Y = mouseUpPosition.Y - mouseDownPosition.Y;

            // координаты точки, удалённой от конца  отрезка на 20px - середина ромбика
            double X4 = mouseUpPosition.X - (X / d) * 20;
            double Y4 = mouseUpPosition.Y - (Y / d) * 20;

            // координаты точки, удалённой от конца  отрезка на 40px - линияя до этой точки
            double X5 = mouseUpPosition.X - (X / d) * 40;
            double Y5 = mouseUpPosition.Y - (Y / d) * 40;

            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = mouseUpPosition.Y - mouseDownPosition.Y;
            double Yp = mouseDownPosition.X - mouseUpPosition.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 15px в разные стороны
            double X6 = X4 + (Xp / d) * 15;
            double Y6 = Y4 + (Yp / d) * 15;
            double X7 = X4 - (Xp / d) * 15;
            double Y7 = Y4 - (Yp / d) * 15;

            Point[] RombsSholders = new Point[] {new Point ((int)X6, (int)Y6), new Point(mouseUpPosition.X, mouseUpPosition.Y),
                                                        new Point((int)X7, (int)Y7), new Point((int)X5, (int)Y5)};
            return RombsSholders;
        }


        public static Point[] GetRectangle(Point mouseUpPosition, Point mouseDownPosition)
        {
            return new Point[] { new Point(mouseDownPosition.X, mouseDownPosition.Y),new Point(mouseDownPosition.X, mouseUpPosition.Y),
        new Point(mouseUpPosition.X, mouseUpPosition.Y),new Point(mouseUpPosition.X, mouseDownPosition.Y)}; //правильная последоватьльность точек)
        }
    }
}
