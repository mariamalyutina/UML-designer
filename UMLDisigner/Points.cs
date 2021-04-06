using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UMLDisigner
{
   public struct Points
    {
        public Point[] ShouldersArrows;
        public Point[] Positions;
        public Point[] ArrowAtFront;
       
        public Points(Point[] ShouldersArrows, Point mouseDownPosition, Point mouseUpPosition, Point[] ArrowAtFront = null)
        {
            this.ShouldersArrows = ShouldersArrows;
            this.Positions = new Point[] { mouseDownPosition, mouseUpPosition };
            this.ArrowAtFront = ArrowAtFront;
        }
    }
}
