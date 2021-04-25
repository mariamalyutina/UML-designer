using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public static class Geometry
    {
        
        public static Point[] GetArrow(Point endPoint, Point stratPoint) //стрелочки в начале
        {
            double d = Math.Sqrt(Math.Pow(endPoint.X - stratPoint.X, 2) + Math.Pow(endPoint.Y - stratPoint.Y, 2));

            double X = endPoint.X - stratPoint.X;
            double Y = endPoint.Y - stratPoint.Y;

            // координаты точки, удалённой от конца  отрезка на 20px
            double X4 = endPoint.X - (X / d) * 20;
            double Y4 = endPoint.Y - (Y / d) * 20;

            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = endPoint.Y - stratPoint.Y;
            double Yp = stratPoint.X - endPoint.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 15px в разные стороны
            double X5 = X4 + (Xp / d) * 15;
            double Y5 = Y4 + (Yp / d) * 15;
            double X6 = X4 - (Xp / d) * 15;
            double Y6 = Y4 - (Yp / d) * 15;

            Point[] ArrowsSholders = new Point[] {new Point ((int)X5, (int)Y5), new Point(endPoint.X, endPoint.Y),
                                                        new Point((int)X6, (int)Y6), new Point((int)X4, (int)Y4)}; 
            return ArrowsSholders;
        }

        public static Point[] GetRomb(Point endPoint, Point startPoint) //ромбик
        {
            double d = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));

            double X = endPoint.X - startPoint.X;
            double Y = endPoint.Y - startPoint.Y;

            // координаты точки, удалённой от конца  отрезка на 20px - середина ромбика
            double X4 = endPoint.X - (X / d) * 20;
            double Y4 = endPoint.Y - (Y / d) * 20;

            // координаты точки, удалённой от конца  отрезка на 40px - линияя до этой точки (начало ромба)
            double X5 = endPoint.X - (X / d) * 40;
            double Y5 = endPoint.Y - (Y / d) * 40;

            // полученные множители x и y => координаты вектора перпендикуляра
            double Xp = endPoint.Y - startPoint.Y;
            double Yp = startPoint.X - endPoint.X;

            // координаты перпендикуляров, удалённой от точки X4;Y4 на 15px в разные стороны
            double X6 = X4 + (Xp / d) * 15;
            double Y6 = Y4 + (Yp / d) * 15;
            double X7 = X4 - (Xp / d) * 15;
            double Y7 = Y4 - (Yp / d) * 15;
            

            Point[] RombsSholders = new Point[] {new Point ((int)X6, (int)Y6), new Point(endPoint.X, endPoint.Y),
                                                        new Point((int)X7, (int)Y7), new Point((int)X5, (int)Y5)};
            return RombsSholders;
        }


        public static Point[] GetRectangle(Point mouseUpPosition, Point mouseDownPosition)
        {
            return new Point[] { new Point(mouseDownPosition.X, mouseDownPosition.Y),new Point(mouseDownPosition.X, mouseUpPosition.Y),
        new Point(mouseUpPosition.X, mouseUpPosition.Y),new Point(mouseUpPosition.X, mouseDownPosition.Y)}; //правильная последоватьльность точек)
        }

        public static List<Point> GetCurvedPoints(Point startPoint, Point endPoint) //точки для ломания линий 
        {
            List<Point> points = new List<Point>();
            points.Add(startPoint);

            int middleX = (startPoint.X + endPoint.X) / 2;

            points.Add(new Point(middleX, startPoint.Y)); //1-ый излом
            points.Add(new Point(middleX, endPoint.Y));//2-ой излом

            points.Add(endPoint);

            return points;
        }
        
        public static bool FindPointInArrow(Point leftPosition, Point rightPosition, Point checkedPoint)
        {
            int delta = 10;
            int minX;
            int maxX;
            int minY;
            int maxY;
            if (leftPosition.X > rightPosition.X)
            {
                minX = rightPosition.X;
                maxX = leftPosition.X;
            }
            else
            {
                minX = leftPosition.X;
                maxX = rightPosition.X;
            }

            if (leftPosition.Y > rightPosition.Y)
            {
                minY = rightPosition.Y;
                maxY = leftPosition.Y;
            }
            else
            {
                minY = leftPosition.Y;
                maxY = rightPosition.Y;
            }

            int middleX = minX + (maxX - minX) / 2;
            int middleY = minY + (maxY - minY) / 2;

            if (middleX + delta >= checkedPoint.X && middleX - delta <= checkedPoint.X && middleY + delta >= checkedPoint.Y && middleY - delta <= checkedPoint.Y)
            {
                return true;
            }
            if (maxX - minX <= delta && maxY - minY <= delta)
            {
                return false;
            }
            if (FindPointInArrow(leftPosition, new Point(middleX, middleY), checkedPoint)
                || FindPointInArrow(new Point(middleX, middleY), rightPosition, checkedPoint) 
                )
            {
                return true;
            }
            return false;
        }

        public static bool FindPointInClass(Point mouseUpPosition, Point mouseDownPosition, Point checkedPoint)
        {
            int delta = 10;
            int minX;
            int maxX;
            int minY;
            int maxY;
            if (mouseUpPosition.X > mouseDownPosition.X)
            {
                minX = mouseDownPosition.X;
                maxX = mouseUpPosition.X;
            }
            else
            {
                minX = mouseUpPosition.X;
                maxX = mouseDownPosition.X;
            }

            if (mouseUpPosition.Y > mouseDownPosition.Y)
            {
                minY = mouseDownPosition.Y;
                maxY = mouseUpPosition.Y;
            }
            else
            {
                minY = mouseUpPosition.Y;
                maxY = mouseDownPosition.Y;
            }

            if ( minX - delta <= checkedPoint.X && maxX + delta >= checkedPoint.X
                 && minY - delta <= checkedPoint.Y && maxY + delta >= checkedPoint.Y)
            {
                return true;
            }

            return false;
        }
    }
}
