using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {

        public Core Core;
        String _figureName;

        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Core = Core.GetInstance(pictureBox1);
            //this.Controls.Add(pictureBox1);
            //pictureBox1.PreviewKeyDown += new PreviewKeyDownEventHandler(KeyDeleteUp);
            

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(Core.Figure is null) && e.Button == MouseButtons.Left && e.Location != Core.Figure.MouseDownPosition)
            {
                Core.CrntMH.MouseMove(e);
            }
         }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (!(Core.Figure is null))
            {
                Core.CrntMH.MouseDown(e);
            }
        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Core.Brush.TmpToMainBitmap();

            if(Core.Figure!= null)
            {
                Core.CrntMH.MouseUp(e);

            }

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Core.Brush.Clear();
            Core.Figures.Clear();
            Core.SelectedFigures.Clear();
        }

        
        private void SetFigure()
        {
            bool isCurved = false;
            if (buttonLineOptions.Text == "Curved")
            {
                isCurved = true;
            }
            switch (_figureName)
            {
                case "association":
                    Core.Factory = new AssociationFactory(isCurved);
                    break;
                case "inheritance":
                    Core.Factory = new InheritanceFactory(isCurved);
                    break;
                case "aggregation":
                    Core.Factory = new AggregationFactory(isCurved);
                    break;
                case "aggregationPlus":
                    Core.Factory = new AggregationPlusFactory(isCurved);
                    break;
                case "composition":
                    Core.Factory = new CompositionFactory(isCurved);
                    break;
                case "compositionPlus":
                    Core.Factory = new CompositionPlusFactory(isCurved);
                    break;
                case "implementation":
                    Core.Factory = new ImplementationFactory(isCurved);
                    break;
                case "Classes1":
                    Core.Factory = new Class1Factory();
                    break;
                case "Classes2":
                    Core.Factory = new Class2Factory();
                    break;
                case "Classes3":
                    Core.Factory = new Class3Factory();
                    break;
                case "ClassStack":
                    Core.Factory = new ClassStackFactory();
                    break;
            }
            if (Core.CrntMH is MouseHandlerEditing && Core.SelectedFigures.Count > 0)
            {
                for (int i = 0; i < Core.SelectedFigures.Count; i++)
                {
                    if (Core.SelectedFigures[i] is Arrow)
                    {
                        if (Core.Factory is AbstractArrowFactory)
                        {
                            Core.Figures.Remove(Core.SelectedFigures[i]);
                            Core.SelectedFigures[i] = Core.Factory.GetShape(Core.SelectedFigures[i].Color, Core.SelectedFigures[i].Width, Core.SelectedFigures[i].MouseDownPosition, Core.SelectedFigures[i].MouseUpPosition);
                            Core.Figures.Add(Core.SelectedFigures[i]);
                        }
                    }
                }
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
                Core.Brush.MarkAsSelected(Core.SelectedFigures);
            }
            else if (!(Core.Factory is null)) 
            {
                Core.Figure = Core.Factory.GetShape(Core.Brush.Color, Core.Brush.TrackBarWidth);
                Core.SelectedFigures.Clear();
                Core.CrntMH = new MouseHandlerDrawing();
                pictureBox_Arrows.ImageLocation = @"ImagesArrows\Arrows.JPG";
                pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
            }
            
        }


        private void button_StepBack_Click(object sender, EventArgs e)
        {
            //Core.Brush.DrawMoveFigure(figures);
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color.BackColor = colorDialog1.Color;
                Core.Brush.Color = colorDialog1.Color;
                if(Core.CrntMH is MouseHandlerEditing && Core.SelectedFigures.Count > 0)
                {
                    foreach(IFigure figure in Core.SelectedFigures)
                    {
                        figure.Color = colorDialog1.Color;
                    }
                    Core.Brush.Clear();
                    Core.Brush.DrawMoveFigure(Core.Figures);
                    Core.Brush.MarkAsSelected(Core.SelectedFigures);
                }
                if (!(Core.Figure is null))
                {
                    Core.Figure.Color = colorDialog1.Color; //если убрать, рисует сначала старым цветом, потом новым
                }
                    
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            Core.Brush.TrackBarWidth = trackBar1.Value;
            if (Core.CrntMH is MouseHandlerEditing && Core.SelectedFigures.Count > 0)
            {
                foreach (IFigure figure in Core.SelectedFigures)
                {
                    figure.Width = trackBar1.Value;
                }
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
                Core.Brush.MarkAsSelected(Core.SelectedFigures);
            }
            if (!(Core.Figure is null))
            {
                Core.Figure.Width = trackBar1.Value;
            }
                
        }

        private void pictureBox_Arrows_Click(object sender, EventArgs e)
        {
            FormArrows formArrows = new FormArrows();
            formArrows.TopMost = true;
            formArrows.StartPosition = FormStartPosition.Manual;
            formArrows.Location = pictureBox_Arrows.Location;
            formArrows.ShowDialog();
            if (formArrows.Name != null)
            {
                _figureName = formArrows.Name;
                SetFigure();
                pictureBox_Arrows.ImageLocation = @"ImagesArrows\" + _figureName + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formArrows.Close();
            }
        }

        private void pictureBox_Classes_Click(object sender, EventArgs e)
        {

            FormClasses formClasses = new FormClasses();
            formClasses.TopMost = true;
            formClasses.StartPosition = FormStartPosition.Manual;
            formClasses.Location = pictureBox_Classes.Location;
            formClasses.ShowDialog();
            if (formClasses.Name != null)
            {
                _figureName = formClasses.Name;
                SetFigure();
                pictureBox_Classes.ImageLocation = @"ImagesClasses\" + formClasses.Name + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formClasses.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Core.Brush.Clear();
            Core.SelectedFigures.Clear();
            Core.Brush.DrawMoveFigure(Core.Figures);
            Core.CrntMH = new MouseHandlerEditing();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLineOptions.Text = comboBox1.Text; //смена с ломаной на прямую
            SetFigure();
        }



        private void button_DeleteFigure_Click(object sender, EventArgs e)
        {
            Core.Brush.Clear();

            for(int i=0;i<Core.Figures.Count; ++i)
            {
                for (int j = 0; j < Core.SelectedFigures.Count; ++j)
                {
                    if (Core.Figures[i] == Core.SelectedFigures[j])
                    {
                        Core.Figures.Remove(Core.SelectedFigures[j]);
                       
                    }
                }
            }
            Core.SelectedFigures.Clear();

            Core.Brush.DrawMoveFigure(Core.Figures);
        }

    }
}
