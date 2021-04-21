﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace UMLDisigner
{
    class Arrow : IFigure
    {
        public Point MouseUpPosition { get; set; }
        public Point MouseDownPosition { get; set; }

        public Color Color { get; set; }
        public int Width { get; set; }

        public AbstractLine LineType;
        protected AbstractCap _capTypeBeginning;
        protected AbstractCap _capTypeEnding;

        public Arrow()
        {
            //только для клона, когда уберем клон - можно убрать это
        }

        public Arrow(Color color, int width, AbstractLine lineType, AbstractCap firstCap, AbstractCap endCap)
        {
            Color = color;
            Width = width;
            LineType = lineType;
            _capTypeBeginning = firstCap;
            _capTypeEnding = endCap;
        }


        public void Draw(Graphics graphics, int deltaX, int deltaY)

        {
            Point tmpMouseDownPosition = MouseDownPosition;
            Point tmpMouseUpPosition = MouseUpPosition;
            Size delta = new Size(deltaX, deltaY);
            MouseDownPosition = Point.Add(MouseDownPosition, delta);
            MouseUpPosition = Point.Add(MouseUpPosition, delta);
            

            Pen pen = new Pen(Color, Width);
            SolidBrush brush = new SolidBrush(Color.White);

            LineType.Draw(graphics, pen, MouseUpPosition, MouseDownPosition);

            Point capBeginningStartPoint = MouseDownPosition;
            Point capEndingEndPoint = MouseUpPosition;

            if (LineType is CurvedLine)
            {
                capBeginningStartPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[2];
                capEndingEndPoint = Geometry.GetCurvedPoints(MouseDownPosition, MouseUpPosition).ToArray()[1];
            }

            _capTypeBeginning.Draw(graphics, pen, brush, MouseUpPosition, capBeginningStartPoint);

            if (!(_capTypeEnding is null))
            {
                _capTypeEnding.Draw(graphics, pen, brush, MouseDownPosition, capEndingEndPoint);
            }

            MouseDownPosition = tmpMouseDownPosition;
            MouseUpPosition = tmpMouseUpPosition;
        }


        public bool IsHavingPoint(Point checkedPoint)
        {
            if (Geometry.FindPointInClass(MouseUpPosition, MouseDownPosition, checkedPoint))
            {
                return Geometry.FindPointInArrow(MouseUpPosition, MouseDownPosition, checkedPoint);
            }
            else
            {
                return false;
            }
        }

        public Side SideForResizing(Point checkedPoint)
        {
            throw new NotImplementedException();
        }

        public Vertex VertexForResizing(Point checkedPoint)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return new Arrow();
        }
    }
}
