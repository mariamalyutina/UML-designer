using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    public class Core
    {
        public Brush Brush;
        public IFigure Figure;

        public List<IFigure> Figures;
        public List<IFigure> SelectedFigures;
        public AbstractFactory Factory;
        public IMouseHandler CrntMH;
        static Core _instance;


        private Core(PictureBox pb)
        {
            Brush = new Brush(pb);
            Figures = new List<IFigure>();
            SelectedFigures = new List<IFigure>();
        }

        public static Core GetInstance(PictureBox pb)
        {
            if (_instance is null)
            {
                _instance = new Core(pb);
            }
            return _instance;
        }
    }
}
