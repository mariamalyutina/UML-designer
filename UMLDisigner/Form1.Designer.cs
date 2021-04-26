﻿
namespace UMLDisigner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_StepBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_Color = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_Arrows = new System.Windows.Forms.PictureBox();
            this.pictureBox_Classes = new System.Windows.Forms.PictureBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonLineOptions = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_DeleteFigure = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MinusRowField = new System.Windows.Forms.Button();
            this.PlusRowField = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Arrows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Classes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_StepBack
            // 
            this.button_StepBack.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button_StepBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_StepBack.Location = new System.Drawing.Point(727, 26);
            this.button_StepBack.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.button_StepBack.Name = "button_StepBack";
            this.button_StepBack.Size = new System.Drawing.Size(143, 40);
            this.button_StepBack.TabIndex = 9;
            this.button_StepBack.Text = "Step back";
            this.button_StepBack.UseVisualStyleBackColor = true;
            this.button_StepBack.Click += new System.EventHandler(this.button_StepBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2000, 2000);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_Color
            // 
            this.button_Color.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Color.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_Color.Location = new System.Drawing.Point(344, 26);
            this.button_Color.Margin = new System.Windows.Forms.Padding(2);
            this.button_Color.Name = "button_Color";
            this.button_Color.Size = new System.Drawing.Size(30, 34);
            this.button_Color.TabIndex = 12;
            this.button_Color.UseVisualStyleBackColor = false;
            this.button_Color.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(13, 26);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(323, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "1";
            // 
            // pictureBox_Arrows
            // 
            this.pictureBox_Arrows.ImageLocation = "ImagesArrows\\Arrows.JPG";
            this.pictureBox_Arrows.Location = new System.Drawing.Point(408, 26);
            this.pictureBox_Arrows.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Arrows.Name = "pictureBox_Arrows";
            this.pictureBox_Arrows.Size = new System.Drawing.Size(96, 34);
            this.pictureBox_Arrows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Arrows.TabIndex = 16;
            this.pictureBox_Arrows.TabStop = false;
            this.pictureBox_Arrows.Click += new System.EventHandler(this.pictureBox_Arrows_Click);
            // 
            // pictureBox_Classes
            // 
            this.pictureBox_Classes.ImageLocation = "ImagesClasses\\Classes.JPG";
            this.pictureBox_Classes.Location = new System.Drawing.Point(548, 10);
            this.pictureBox_Classes.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Classes.Name = "pictureBox_Classes";
            this.pictureBox_Classes.Size = new System.Drawing.Size(133, 72);
            this.pictureBox_Classes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Classes.TabIndex = 17;
            this.pictureBox_Classes.TabStop = false;
            this.pictureBox_Classes.Click += new System.EventHandler(this.pictureBox_Classes_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(918, 26);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(138, 40);
            this.button_Clear.TabIndex = 18;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Straight",
            "Curved"});
            this.comboBox1.Location = new System.Drawing.Point(408, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 23);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.Text = "Line options";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonLineOptions
            // 
            this.buttonLineOptions.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLineOptions.Location = new System.Drawing.Point(408, 78);
            this.buttonLineOptions.Name = "buttonLineOptions";
            this.buttonLineOptions.Size = new System.Drawing.Size(96, 28);
            this.buttonLineOptions.TabIndex = 19;
            this.buttonLineOptions.Text = "Line options";
            this.buttonLineOptions.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(992, -4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 89);
            this.button1.TabIndex = 19;
            this.button1.Text = "Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1072, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 40);
            this.button3.TabIndex = 22;
            this.button3.Text = "Editing";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_DeleteFigure
            // 
            this.button_DeleteFigure.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_DeleteFigure.Location = new System.Drawing.Point(758, 79);
            this.button_DeleteFigure.Margin = new System.Windows.Forms.Padding(2);
            this.button_DeleteFigure.Name = "button_DeleteFigure";
            this.button_DeleteFigure.Size = new System.Drawing.Size(90, 27);
            this.button_DeleteFigure.TabIndex = 23;
            this.button_DeleteFigure.Text = "Delete";
            this.button_DeleteFigure.UseVisualStyleBackColor = false;
            this.button_DeleteFigure.Click += new System.EventHandler(this.button_DeleteFigure_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1026, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 24;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(918, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 26);
            this.button2.TabIndex = 25;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(10, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 477);
            this.panel1.TabIndex = 26;
            // 
            // MinusRowField
            // 
            this.MinusRowField.Location = new System.Drawing.Point(548, 87);
            this.MinusRowField.Name = "MinusRowField";
            this.MinusRowField.Size = new System.Drawing.Size(21, 26);
            this.MinusRowField.TabIndex = 27;
            this.MinusRowField.Text = "-";
            this.MinusRowField.UseVisualStyleBackColor = true;
            this.MinusRowField.Click += new System.EventHandler(this.MinusRowField_Click);
            // 
            // PlusRowField
            // 
            this.PlusRowField.Location = new System.Drawing.Point(587, 87);
            this.PlusRowField.Name = "PlusRowField";
            this.PlusRowField.Size = new System.Drawing.Size(21, 26);
            this.PlusRowField.TabIndex = 28;
            this.PlusRowField.Text = "+";
            this.PlusRowField.UseVisualStyleBackColor = true;
            this.PlusRowField.Click += new System.EventHandler(this.PlusRowField_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(1026, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 25;
            this.textBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 615);
            this.Controls.Add(this.PlusRowField);
            this.Controls.Add(this.MinusRowField);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_DeleteFigure);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonLineOptions);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.pictureBox_Classes);
            this.Controls.Add(this.pictureBox_Arrows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_Color);
            this.Controls.Add(this.button_StepBack);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Off";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Arrows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Classes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_StepBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_ArrowImplementation;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button_ArrowAggregationPlus;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_Color;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Class3;
        private System.Windows.Forms.Button button_ClassStack;
        private System.Windows.Forms.Button button_Class2;
        private System.Windows.Forms.PictureBox pictureBox_Arrows;
        private System.Windows.Forms.PictureBox pictureBox_Classes;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonLineOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_DeleteFigure;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PlusString;
        public System.Windows.Forms.Button MinusRowField;
        private System.Windows.Forms.Button PlusRowField;
        private System.Windows.Forms.TextBox textBox2;
    }
}

