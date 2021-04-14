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
        public bool IsCurved { get; set; }
        Color Color { get; set; } 
        int Width { get; set; }


        void Draw(Graphics graphics, Pen pen);

        void Move(double delta);

        bool IsHavingPoint(Point checkedPoint);
    }

}
