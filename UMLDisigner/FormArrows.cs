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
        public String String { get; private set; }

        public FormArrows()
        { 
            InitializeComponent();
        }

        private void pictureBox_Association_Click(object sender, EventArgs e)
        {
            String = "ArrowAssociation";
            this.Close();
        }

        private void pictureBox_Aggregation_Click(object sender, EventArgs e)
        {
            String = "ArrowAggregation";
            this.Close();
        }


    }
}
