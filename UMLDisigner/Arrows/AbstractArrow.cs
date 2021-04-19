﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    abstract class AbstractArrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; }
        public int Width { get; set; }

        public AbstractLine LineType { get; set; }
        protected AbstractCap _capTypeBeginning;
        protected AbstractCap _capTypeEnding;

        public abstract void Draw(Graphics graphics, int deltaX, int deltaY);

        public bool IsHavingPoint(Point checkedPoint)
        {
            return false;
        }

        public void Move(double delta)
        {
            throw new NotImplementedException();
        }

        public abstract object Clone();

        protected void SetArrow(Graphics graphics, bool twoCaps)
        {
            Pen pen1 = new Pen(Color, Width);
            LineType.Draw(graphics, pen1, MouseUpPosition, MouseDownPosition);

            Point capBeginningStartPoint;
            Point capEndingEndPoint;
            if (LineType is StraightLine)
            {
                capBeginningStartPoint = MouseDownPosition;
                capEndingEndPoint = MouseUpPosition;
            }
            else
            {
                capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                capEndingEndPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[1];
            }
            _capTypeBeginning.Draw(graphics, pen1, MouseUpPosition, capBeginningStartPoint);

            if (twoCaps)
            {
                _capTypeEnding.Draw(graphics, pen1, MouseDownPosition, capEndingEndPoint);
            }
        }
    }
}
