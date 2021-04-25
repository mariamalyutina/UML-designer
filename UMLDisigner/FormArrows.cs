using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    public partial class FormArrows : Form
    {
        public String Name { get; private set; }


        public FormArrows()
        {
            InitializeComponent();
        }


        private void pictureBox_Association_Click(object sender, EventArgs e)
        {
            Name = "association";
            this.Close();
        }

        private void pictureBox_Aggregation_Click(object sender, EventArgs e)
        {
            Name = "aggregation";
            this.Close();
        }

        private void pictureBox_AggregationPlus_Click(object sender, EventArgs e)
        {
            Name = "aggregationPlus";
            this.Close();
        }

        private void pictureBox_Composition_Click(object sender, EventArgs e)
        {                    
            Name = "composition";
            this.Close();
        }

        private void pictureBox_CompositionPlus_Click(object sender, EventArgs e)
        {
            Name = "compositionPlus";
            this.Close();
        }

        private void pictureBox_Implementation_Click(object sender, EventArgs e)
        {
            Name = "implementation";
            this.Close();
        }

        private void pictureBox_Inheritance_Click(object sender, EventArgs e)
        {
            Name = "inheritance";
            this.Close();
        }

    }
}
