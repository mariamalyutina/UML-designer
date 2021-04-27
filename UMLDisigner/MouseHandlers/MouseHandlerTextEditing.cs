using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    class MouseHandlerTextEditing : IMouseHandler
    {
        Core Core;
        public int selectRow;
        public MouseHandlerTextEditing(/*Point mouseDownPosition*/)
        {
            Core = Core.GetInstance();
            //_select.MouseDownPosition = mouseDownPosition;
        }
        public void MouseDown(MouseEventArgs e)
        {
            Core.textBox.Visible = true;

            if (RowSelection(e, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition) < 0)
            {
                return;
            }
            selectRow = RowSelection(e, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition);
            Core.textBox.Location = RowPoint(selectRow, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition);
            if (Core.Figure is Class3Figure && selectRow > Core.Figure.CountFieldString)
            {
                Core.textBox.Text = ($"{Core.Figure.TextMethod[selectRow - Core.Figure.CountFieldString - 1]}");
            }
            else
            {
                Core.textBox.Text = ($"{Core.Figure.TextField[selectRow]}");//TextField
            }
            Core.Brush.Clear();
            Core.Figures.Remove(Core.Figure);
            Core.Figure.TextField[selectRow] = Core.textBox.Text;
            Core.Figures.Add(Core.Figure);
            Core.Brush.DrawMoveFigure(Core.Figures);
        }

        public void MouseMove(MouseEventArgs e)
        {
            
        }

        public void MouseUp(MouseEventArgs e)
        {
           
        }
        private Point RowPoint(int selectRow, Point MouseUpPosition, Point MouseDownPosition)
        {
            int k = 20;
            int indent = 5;

            return new Point(MouseDownPosition.X + indent, MouseDownPosition.Y + k * selectRow + 5);

        }


        private int RowSelection(MouseEventArgs e, Point MouseUpPosition, Point MouseDownPosition)
        {
            int k = 20;
            if (Core.Figure is Class3Figure)
            {
                for (int i = 0; i <= Core.Figure.CountFieldString + Core.Figure.CountMethodString; i++)
                {
                    if (Geometry.FindPointInClass(new Point(MouseDownPosition.X, MouseDownPosition.Y + k * i), new Point(MouseUpPosition.X, MouseDownPosition.Y + (k * i) + k), e.Location))
                    {
                        return i;
                    }
                }
            }

            for (int i = 0; i <= Core.Figure.CountFieldString; i++)
            {
                if (Geometry.FindPointInClass(new Point(MouseDownPosition.X, MouseDownPosition.Y + k * i), new Point(MouseUpPosition.X, MouseDownPosition.Y + (k * i) + k), e.Location))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
