using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IFigure
    {
        Point MouseUpPosition { get; set; }
        Point MouseDownPosition { get; set; }

        Color Color { get; set; }
        int Width { get; set; }
        public int Size { get; set; }
        public int CountString { get; set; }
        public bool IsCurved { get; set; }
        public List<string> Text { get; set; }

        bool IsHavingPoint(Point checkedPoint);

    }

}
