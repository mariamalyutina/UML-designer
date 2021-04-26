using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {

        public Core Core;
        FontDialog fontDialog1 = new FontDialog();
        String _figureName;
        int selectRow;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Core = Core.GetInstance(pictureBox1);
            panel1.Controls.Add(pictureBox1);
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
                        Core.Figures.Remove(Core.SelectedFigures[i]);
                        Core.SelectedFigures[i] = Core.Factory.GetShape(Core.SelectedFigures[i].Color, Core.SelectedFigures[i].Width, Core.SelectedFigures[i].MouseDownPosition, Core.SelectedFigures[i].MouseUpPosition);
                        Core.Figures.Add(Core.SelectedFigures[i]);
                    }
                }
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
                Core.Brush.MarkAsSelected(Core.SelectedFigures);
            }
            else if (!(Core.Factory is null)) 
            {
                Core.Figure = Core.Factory.GetShape(Core.Brush.Color, Core.Brush.TrackBarWidth);
                Core.CrntMH = new MouseHandlerDrawing();
                pictureBox_Arrows.ImageLocation = @"ImagesArrows\Arrows.JPG";
                pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
            }
            
        }


        private void button_StepBack_Click(object sender, EventArgs e)
        {
            //Core.Brush.DrawMoveCore.Figure(Core.Figures);
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
            //Button b = (Button)sender;
            Core.CrntMH = new MouseHandlerEditing();
            //if (_editing)
            //{
            //    _editing = false;
            //    b.Text = "Drawing";
            //}
            //else
            //{
            //    _editing = true;
            //    b.Text = "Editing";
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLineOptions.Text = comboBox1.Text; //смена с ломаной на прямую
            SetFigure();
        }

        //private void KeyDeleteUp(object sender, PreviewKeyDownEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Delete:
        //            Core.Figures.RemoveAt(Core.Figures.Count - 1);
        //            Core.Brush.Clear();
        //            Core.Brush.DrawMoveCore.Figure(Core.Figure);
        //            break;
        //    }
        //}

        private void button_DeleteFigure_Click(object sender, EventArgs e)
        {
            //Core.Figures.RemoveAt(Core.Figures.Count - 1);
            Core.Brush.Clear();
            //foreach (IFigure figure in Core.Figures)
            //{
            //    foreach (IFigure selectedfigure in Core.SelectedFigures)
            //    {
            //        if (figure == selectedfigure)
            //        {
            //            Core.SelectedFigures.Remove(selectedfigure);
            //            Core.Figures.Remove(figure);
            //        }
            //    }
            //}
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Core.Figure is AbstractClassFigure && Core.Figure != null)
            {
                Core.Brush.Clear();
                if (Core.Figure is Class3Figure && selectRow > Core.Figure.CountFieldString)
                {
                    Core.Figure.TextMethod[selectRow - Core.Figure.CountFieldString - 1] = textBox1.Text;
                }
                else
                {
                    Core.Figure.TextField[selectRow] = textBox1.Text;
                }
                Core.Brush.DrawMoveFigure(Core.Figures);
                Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
                Core.Figure.Size = MaxStringSize();
                textBox1.Width = size.Width;
                textBox1.Height = size.Height;
            }
       
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (Core.Figure is AbstractClassFigure && Core.Figure != null)
            {
                Core.Figure.CountMethodString++;
                //if (Core.Figure.CountString >4) 
                // {
                //     Core.Figure.Text.Add("");
                // }

                Core.Brush.Clear();
                Core.Figures.Remove(Core.Figure);
                Core.Figures.Add(Core.Figure);
                Core.Brush.DrawMoveFigure(Core.Figures);
                //  Core.Figure.Text[Core.Figure.CountString - 1] = " ";


            }
        }



        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        //        {if (_editing)
        {

            if (Core.Figure is AbstractClassFigure && Core.Figure != null)
            {
                textBox1.Visible = true;

                if (RowSelection(e, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition) < 0)
                {
                    return;
                }
                selectRow = RowSelection(e, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition);
                textBox1.Location = RowPoint(selectRow, Core.Figure.MouseUpPosition, Core.Figure.MouseDownPosition);
                if (Core.Figure is Class3Figure && selectRow > Core.Figure.CountFieldString)
                {
                    textBox1.Text = ($"{Core.Figure.TextMethod[selectRow - Core.Figure.CountFieldString - 1]}");
                }
                else
                {
                    textBox1.Text = ($"{Core.Figure.TextField[selectRow]}");//TextField
                }
                Core.Brush.Clear();
                Core.Figures.Remove(Core.Figure);
                Core.Figure.TextField[selectRow] = textBox1.Text; //TextField
                Core.Figures.Add(Core.Figure);
                Core.Brush.DrawMoveFigure(Core.Figures);


            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Core.Brush.Clear();
                Core.Figures.Remove(Core.Figure);
                Core.Figure.TextField[selectRow] = textBox1.Text; //TextField
                Core.Figures.Add(Core.Figure);
                Core.Brush.DrawMoveFigure(Core.Figures);
                textBox1.Visible = false;
            }
            if (e.KeyCode == Keys.Tab)
            {
                selectRow += 1;
            }
        }

        private void PlusRowField_Click(object sender, EventArgs e)
        {
            if (Core.Figure is AbstractClassFigure)
            {
                Core.Figure.CountFieldString++;
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
            }
        }

        private void MinusRowField_Click(object sender, EventArgs e)
        {
            if (Core.Figure is AbstractClassFigure)
            {
                Core.Figure.CountFieldString--;
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
            }

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



        private int MaxStringSize()
        {
            int maxLenghtField = 0;
            int maxLenghtMethod = 0;
            Size size;
            for (int i = 0; i <= Core.Figure.CountFieldString; i++)
            {
                textBox2.Text = (Core.Figure.TextField[i]);
                size = TextRenderer.MeasureText(textBox2.Text, textBox2.Font);

                if (maxLenghtField < size.Width)
                {
                    maxLenghtField = size.Width;
                }
            }

            if (Core.Figure is Class3Figure)
            {
                for (int i = 0; i <= Core.Figure.CountMethodString; i++)
                {
                    textBox2.Text = (Core.Figure.TextMethod[i]);
                    size = TextRenderer.MeasureText(textBox2.Text, textBox2.Font);

                    if (maxLenghtMethod < size.Width)
                    {
                        maxLenghtMethod = size.Width;
                    }
                }               
            }
            if (maxLenghtField > maxLenghtMethod)
            {
                return maxLenghtField;
            }
            else
            {
                return maxLenghtMethod;
            }
        }

            private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            {
                fontDialog1.ShowColor = true;

                fontDialog1.Font = textBox1.Font;
                fontDialog1.Color = textBox1.ForeColor;
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    textBox1.Font = fontDialog1.Font;

                    textBox1.ForeColor = fontDialog1.Color;



                }
            }

        }

    }

