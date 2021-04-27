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
        //public bottom bottom;
        public TextBox textBox;
        public TextBox textBoxForResizing;


        private Core(PictureBox pb,TextBox textBox, TextBox textBoxForResizing)
        {
            this.textBox = textBox;
            this.textBoxForResizing = textBoxForResizing;

            Brush = new Brush(pb);
            Figures = new List<IFigure>();
            SelectedFigures = new List<IFigure>();
        }

        public static Core GetInstance(PictureBox pb, TextBox textBox, TextBox textBoxForResizing)
        {
            if (_instance is null)
            {
                _instance = new Core(pb,textBox,textBoxForResizing);
            }
            return _instance;
        }

        public static Core GetInstance()
        {
            return _instance;
        }
    }
}
