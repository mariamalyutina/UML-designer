﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UMLDisigner
{
    public partial class FormClasses : Form
    {
        public String Name { get; private set; }

        public FormClasses()
        {
            InitializeComponent();
        }

        private void pictureBox_Class1_Click(object sender, EventArgs e)
        {
            Name = "Class1";
            this.Close();
        }

        private void pictureBox_Class2_Click(object sender, EventArgs e)
        {
            Name = "Class2";
            this.Close();
        }

        private void pictureBox_Class3_Click(object sender, EventArgs e)
        {
            Name = "Class3";
            this.Close();
        }

        private void pictureBox_ClassStack_Click(object sender, EventArgs e)
        {
            Name = "ClassStack";
            this.Close();
        }
    }
}
