using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    public abstract class AbstractClassFigure : IFigure
    {
        protected Font _font = new Font("Arial", 16);
        protected SolidBrush _brush = new SolidBrush(Color.Black);

        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; } = Color.Black;
        public int Width { get; set; } = 1;

        public bool IsCurved { get; set; } //только для стрелочки

        public abstract object Clone();

        public abstract void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0);


        public bool IsHavingPoint(Point checkedPoint)
        {
            return Geometry.FindPointInClass(MouseUpPosition, MouseDownPosition, checkedPoint);
        }

        public Side SideForResizing(Point checkedPoint)
        {
            int minX = Math.Min(MouseDownPosition.X, MouseUpPosition.X);
            int maxX = Math.Max(MouseDownPosition.X, MouseUpPosition.X);
            int minY = Math.Min(MouseDownPosition.Y, MouseUpPosition.Y);
            int maxY = Math.Max(MouseDownPosition.Y, MouseUpPosition.Y);

            if (minX + 5 >= checkedPoint.X && minX - 3 <= checkedPoint.X && minY + 3 < checkedPoint.Y && maxY - 3 > checkedPoint.Y)
            {
                return Side.Left;
            }
             
            if (maxX - 5 >= checkedPoint.X && maxX + 3 <= checkedPoint.X && minY + 3 < checkedPoint.Y && maxY - 3 > checkedPoint.Y)
            {
                return Side.Right;
            }


            if (minY + 5 >= checkedPoint.Y && minY - 3 <= checkedPoint.Y && minX + 3 < checkedPoint.X && maxX - 3 > checkedPoint.X)
            {
                return Side.Up;
            }

            if (maxY - 5 >= checkedPoint.Y && maxY + 3 <= checkedPoint.Y && minX + 3 < checkedPoint.X && maxX - 3 > checkedPoint.X)
            {
                return Side.Down;
            }

            return Side.None; 
        }

        public Vertex VertexForResizing(Point checkedPoint)
        {
            int minX = Math.Min(MouseDownPosition.X, MouseUpPosition.X);
            int maxX = Math.Max(MouseDownPosition.X, MouseUpPosition.X);
            int minY = Math.Min(MouseDownPosition.Y, MouseUpPosition.Y);
            int maxY = Math.Max(MouseDownPosition.Y, MouseUpPosition.Y);

            if (minX + 3 >= checkedPoint.X && minX - 3 <= checkedPoint.X && minY - 3 <= checkedPoint.Y && minY + 3 >= checkedPoint.Y)
            {
                return Vertex.LeftUp;
            }

            if (minX + 3 >= checkedPoint.X && minX - 3 <= checkedPoint.X && maxY - 3 <= checkedPoint.Y && maxY + 3 >= checkedPoint.Y)
            {
                return Vertex.LeftDown;
            }

            if (maxX + 3 >= checkedPoint.X && maxX - 3 <= checkedPoint.X && minY - 3 <= checkedPoint.Y && minY + 3 >= checkedPoint.Y)
            {
                return Vertex.RightUp;
            }

            if (maxX + 3 >= checkedPoint.X && maxX - 3 <= checkedPoint.X && maxY - 3 <= checkedPoint.Y && maxY + 3 >= checkedPoint.Y)
            {
                return Vertex.RightDown;
            }

            return Vertex.None;
        }

        public void Resize(Side side)
        {
            if(side == Side.Left)
            {

            }

            if (side == Side.Right)
            {

            }

            if (side == Side.Up)
            {

            }

            if (side == Side.Down)
            {

            }
        }


    }
}
