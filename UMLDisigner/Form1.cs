using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace UMLDisigner
{
    public partial class Form1 : Form
    {
        List<Bitmap> BitmapList= new List<Bitmap>();

        private String _figureName;
        public Brush Brush;
        public IFigure Figure;


        public Form1()
        {
            InitializeComponent();
        }
                
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Brush = new Brush(pictureBox1);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location!= Figure.MouseDownPosition && !(Figure is null))
            {
                Figure.MouseUpPosition = e.Location;
                Brush.TrackBarWidth = trackBar1.Value;
                Brush.DrawMoveFigure(Figure);
            }

        }             
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(Figure is null)) 
            {
                Figure.MouseDownPosition = e.Location;
            }
            
            if(BitmapList.Count>1)
            {
                button_StepBack.Enabled = true;
            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Brush.TmpToMainBitmap();
            Figure = (IFigure)Figure.Clone();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Brush.Clear();            
        }

        
        private void SetArrow()
        {
            switch (_figureName)
            {
                case "association":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowAssociationCurved();
                    }
                    else
                    {
                        Figure = new ArrowAssociation();
                    }
                    break;
                case "inheritance":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowInheritanceCurved();
                    }
                    else
                    {
                        Figure = new ArrowInheritance();
                    }
                    break;
                case "aggregation":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowAggregationCurved();
                    }
                    else
                    {
                        Figure = new ArrowAggregation();
                    }
                    break;
                case "aggregationPlus":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowAggregationPlusCurved();
                    }
                    else
                    {
                        Figure = new ArrowAggregationPlus();
                    }
                    break;
                case "composition":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowСompositionCurved();
                    }
                    else
                    {
                        Figure = new ArrowСomposition();
                    }
                    break;
                case "compositionPlus":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowСompositionPlusCurved();
                    }
                    else
                    {
                        Figure = new ArrowСompositionPlus();
                    }
                    break;
                case "implementation":
                    if (buttonLineOptions.Text == "Curved")
                    {
                        Figure = new ArrowImplementationCurved();
                    }
                    else
                    {
                        Figure = new ArrowImplementation();
                    }
                    break;
            }

            pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
        }



        private void SetClass()
        {
            switch (_figureName)
            {
                case "Classes1":
                    Figure = new Class1Figure();
                    break;
                case "Classes2":
                    Figure = new Class2Figure();
                    break;
                case "Classes3":
                    Figure = new Class3Figure();
                    break;
                case "ClassStack":
                    Figure = new ClassStackFigure();
                    break;
            }

            pictureBox_Arrows.ImageLocation = @"ImagesArrows\Arrows.JPG";
        }


        private void button_StepBack_Click(object sender, EventArgs e)
        {
            //figure = new Class3();
            //brush.bitmap = BitmapList[BitmapList.Count - 1];
            //BitmapList.RemoveAt(BitmapList.Count - 1);
            //if (BitmapList.Count == 1)
            //{
            //    button_StepBack.Enabled = false;
            //}

            //pictureBox1.Image = brush.bitmap;
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color.BackColor = colorDialog1.Color;
                Brush.Color = colorDialog1.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }


        private void pictureBox_Arrows_MouseHover(object sender, EventArgs e)
        {
            FormArrows formArrows = new FormArrows();
            formArrows.TopMost = true;
            formArrows.StartPosition = FormStartPosition.Manual;
            formArrows.Location = pictureBox_Arrows.Location;
            formArrows.ShowDialog();
            if (formArrows.Name != null)
            {
                _figureName = formArrows.Name;
                SetArrow();
                pictureBox_Arrows.ImageLocation = @"ImagesArrows\" + _figureName + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formArrows.Close();
            }
        }

        private void pictureBox_Classes_MouseHover_1(object sender, EventArgs e)
        {
            FormClasses formClasses = new FormClasses();
            formClasses.TopMost = true;
            formClasses.StartPosition = FormStartPosition.Manual;
            formClasses.Location = pictureBox_Classes.Location;
            formClasses.ShowDialog();
            if (formClasses.Name != null)
            {
                //    if (formClasses.Name == "close")
                //    {
                //        if (_figureName == "association" || _figureName == "inheritance" || _figureName == "aggregation"
                //            || _figureName == "aggregationPlus" || _figureName == "composition" || _figureName == "compositionPlus" || _figureName == "implementation")
                //        {
                //            pictureBox_Classes.ImageLocation = @"ImagesClasses\" + _figureName + ".JPG";
                //        }
                //        else
                //        {
                //            pictureBox_Classes.ImageLocation = @"ImagesClasses\Classes.JPG";
                //        }
                //        pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                //        formClasses.Close();
                //        return;
                //    }

                _figureName = formClasses.Name;
                SetClass();
                pictureBox_Classes.ImageLocation = @"ImagesClasses\" + formClasses.Name + ".JPG";
                pictureBox_Classes.SizeMode = PictureBoxSizeMode.Zoom;
                formClasses.Close();
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonLineOptions.Text = comboBox1.Text;
        }

    }
}
