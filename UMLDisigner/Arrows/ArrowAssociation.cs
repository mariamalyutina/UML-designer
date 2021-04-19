using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLDisigner
{
    class ArrowAssociation : AbstractArrow
    {
      public  ArrowAssociation(Color color, int width, AbstractLine lineType)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = new WingsCap();
        }

        public override void Draw(Graphics graphics, int deltaX, int deltaY)
        {
            SetArrow(graphics, false);
        }

        public override object Clone()
        {
            return new ArrowAssociation(this.Color, this.Width, this.LineType);
        }
    }
}
