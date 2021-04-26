﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    public interface IMouseHandler
    {
        void MouseDown(MouseEventArgs e);
        void MouseMove(MouseEventArgs e);
        void MouseUp(MouseEventArgs e);
    }
}
