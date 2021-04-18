using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure : ICloneable
    {
        Point MouseUpPosition { get; set; }
        Point MouseDownPosition { get; set; }

        Color Color { get; set; } 
        int Width { get; set; }

        public bool IsCurved { get; set; }

        void Draw(Graphics graphics, Pen pen, int deltaX = 0, int deltaY = 0);

        bool IsHavingPointForMoving(Point checkedPoint);
        Side SideForResizing(Point checkedPoint);
        Vertex VertexForResizing(Point checkedPoint);

        Object Clone();

        protected List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();

            points.Add(MouseDownPosition);

            points.Add(MouseUpPosition);

            return points;
        }
    }

}
