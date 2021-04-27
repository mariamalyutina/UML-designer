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
            
            Core = Core.GetInstance(pictureBox1,textBox1,textBox2);
            panel1.Controls.Add(pictureBox1);
            textBox1.BringToFront();         


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
            if (Core.SelectedFigures.Count == 1 && Core.SelectedFigures[0] is AbstractClassFigure && e.Button == MouseButtons.Right)
            {
                Core.textBox.Visible = true;              
              
                if (RowSelection(e, Core.SelectedFigures[0].MouseUpPosition, Core.SelectedFigures[0].MouseDownPosition) < 0)
                {
                    return;
                }
                selectRow = RowSelection(e, Core.SelectedFigures[0].MouseUpPosition, Core.SelectedFigures[0].MouseDownPosition);
                Core.textBox.Location = RowPoint(selectRow, Core.SelectedFigures[0].MouseUpPosition, Core.SelectedFigures[0].MouseDownPosition);
                if (Core.SelectedFigures[0] is Class3Figure && selectRow > Core.SelectedFigures[0].CountFieldString)
                {
                    Core.textBox.Text = ($"{Core.SelectedFigures[0].TextMethod[selectRow - Core.SelectedFigures[0].CountFieldString - 1]}");
                }
                else
                {
                    Core.textBox.Text = ($"{Core.SelectedFigures[0].TextField[selectRow]}");
                }
                Core.Brush.Clear();
                Core.Figures.Remove(Core.SelectedFigures[0]);
                Core.SelectedFigures[0].TextField[selectRow] = Core.textBox.Text;
                Core.Figures.Add(Core.SelectedFigures[0]);
                Core.Brush.DrawMoveFigure(Core.Figures);
                Core.textBox.Select(0, 0);

            }
            else if (!(Core.Figure is null) && !(e.Button == MouseButtons.Right) &&e.Button == MouseButtons.Left)
            {
                Core.CrntMH.MouseDown(e);
            }
        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Core.Brush.TmpToMainBitmap();

            if(Core.Figure!= null && !(e.Button == MouseButtons.Right))
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
            if (Core.SelectedFigures[0] is AbstractClassFigure && Core.Figure != null)
            {
             //   button_PlusRowField.Location = Core.SelectedFigures[0].MouseDownPosition;
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Core.SelectedFigures[0] is AbstractClassFigure && Core.SelectedFigures.Count == 1)
            {
                Core.Brush.Clear();
                if (Core.SelectedFigures[0] is Class3Figure && selectRow > Core.SelectedFigures[0].CountFieldString)
                {
                    Core.SelectedFigures[0].TextMethod[selectRow - Core.SelectedFigures[0].CountFieldString - 1] = Core.textBox.Text;
                }
                else
                {
                    Core.SelectedFigures[0].TextField[selectRow] = Core.textBox.Text;
                }
                Core.Brush.DrawMoveFigure(Core.Figures);
                Size size = TextRenderer.MeasureText(Core.textBox.Text, Core.textBox.Font);
                Core.SelectedFigures[0].Size = MaxStringSize();
                Core.textBox.Width = size.Width;
                Core.textBox.Height = size.Height;
            }
       
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (Core.SelectedFigures[0] is AbstractClassFigure && Core.Figure != null)
            {
                //Core.SelectedFigures[0].CountMethodString++;             

                //Core.Brush.Clear();
              
                //Core.Brush.DrawMoveFigure(Core.Figures);
               


            }
        }



       
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Core.SelectedFigures.Count == 1 && Core.SelectedFigures[0] is AbstractClassFigure)
                {
                    Core.Brush.Clear();
                    Core.SelectedFigures[0].TextField[selectRow] = Core.textBox.Text; //TextField             
                    Core.textBox.Visible = false;
                    Core.Brush.DrawMoveFigure(Core.Figures);
                }
                else
                {
                    textBox1.Visible = false;
                }
            }
            
         
        }

        private void button_PlusRowField_Click(object sender, EventArgs e)
        {
            if (Core.SelectedFigures.Count == 1&&Core.SelectedFigures[0] is AbstractClassFigure&&Core.SelectedFigures[0].CountFieldString<8)
            {
                Core.SelectedFigures[0].CountFieldString++;
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
                
            }
        }

        private void button_MinusRowField_Click(object sender, EventArgs e)
        {

            if (Core.SelectedFigures.Count == 1 && Core.SelectedFigures[0] is AbstractClassFigure && Core.SelectedFigures[0].CountFieldString > 0)
            {
                Core.SelectedFigures[0].CountFieldString--;
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);
            }
        }

        private void button_PlusRowMethod_Click(object sender, EventArgs e)
        {
            if (Core.SelectedFigures.Count == 1 && Core.SelectedFigures[0] is AbstractClassFigure && Core.SelectedFigures[0].CountMethodString < 9)
            {
                Core.SelectedFigures[0].CountMethodString++;
                Core.Brush.Clear();
                Core.Brush.DrawMoveFigure(Core.Figures);

            }
        }

        private void button_MinusRowMethod_Click(object sender, EventArgs e)
        {
            if (Core.SelectedFigures.Count == 1 && Core.SelectedFigures[0] is AbstractClassFigure && Core.SelectedFigures[0].CountFieldString > 0)
            {
                Core.SelectedFigures[0].CountMethodString--;
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
            if (Core.SelectedFigures[0] is Class3Figure)
            {
                for (int i = 0; i <= Core.SelectedFigures[0].CountFieldString + Core.SelectedFigures[0].CountMethodString; i++)
                {
                    if (Geometry.FindPointInClass(new Point(MouseDownPosition.X, MouseDownPosition.Y + k * i), new Point(MouseUpPosition.X, MouseDownPosition.Y + (k * i) + k), e.Location))
                    {
                        return i;
                    }
                }
            }

            for (int i = 0; i <= Core.SelectedFigures[0].CountFieldString; i++)
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
            for (int i = 0; i <= Core.SelectedFigures[0].CountFieldString; i++)
            {
                Core.textBoxForResizing.Text = (Core.SelectedFigures[0].TextField[i]);
                size = TextRenderer.MeasureText(Core.textBoxForResizing.Text, Core.textBoxForResizing.Font);

                if (maxLenghtField < size.Width)
                {
                    maxLenghtField = size.Width;
                }
            }

            if (Core.SelectedFigures[0] is Class3Figure)
            {
                for (int i = 0; i <= Core.SelectedFigures[0].CountMethodString; i++)
                {
                    Core.textBoxForResizing.Text = (Core.SelectedFigures[0].TextMethod[i]);
                    size = TextRenderer.MeasureText(Core.textBoxForResizing.Text, Core.textBoxForResizing.Font);

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

                fontDialog1.Font = Core.textBox.Font;
                fontDialog1.Color = Core.textBox.ForeColor;
                if (fontDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    Core.textBox.Font = fontDialog1.Font;

                    Core.textBox.ForeColor = fontDialog1.Color;

                }
                else
                {
                    Core.CrntMH = new MouseHandlerTextEditing();
                }
            }
                
            
        }

        private void button_Editing_Click(object sender, EventArgs e)
        {
            Core.Brush.Clear();
            Core.SelectedFigures.Clear();
            Core.Brush.DrawMoveFigure(Core.Figures);
            Core.CrntMH = new MouseHandlerEditing();

        }
    }

        
    }

    }

