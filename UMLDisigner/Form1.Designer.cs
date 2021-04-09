
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_StepBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Arrows = new System.Windows.Forms.Button();
            this.button_Classes = new System.Windows.Forms.Button();
            this.pictureBox_Arrows = new System.Windows.Forms.PictureBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.pictureBox_Classes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Arrows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Classes)).BeginInit();
            this.SuspendLayout();
            // 
            // button_StepBack
            // 
            this.button_StepBack.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button_StepBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_StepBack.Location = new System.Drawing.Point(636, 20);
            this.button_StepBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_StepBack.Name = "button_StepBack";
            this.button_StepBack.Size = new System.Drawing.Size(125, 30);
            this.button_StepBack.TabIndex = 9;
            this.button_StepBack.Text = "Step back";
            this.button_StepBack.UseVisualStyleBackColor = true;
            this.button_StepBack.Click += new System.EventHandler(this.button_StepBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 82);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1244, 557);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(301, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(11, 20);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(283, 56);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "1";
            // 
            // button_Arrows
            // 
            this.button_Arrows.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_Arrows.Location = new System.Drawing.Point(506, 20);
            this.button_Arrows.Margin = new System.Windows.Forms.Padding(2);
            this.button_Arrows.Name = "button_Arrows";
            this.button_Arrows.Size = new System.Drawing.Size(125, 30);
            this.button_Arrows.TabIndex = 19;
            this.button_Arrows.Text = "Arrows";
            this.button_Arrows.UseVisualStyleBackColor = false;
            this.button_Arrows.MouseHover += new System.EventHandler(this.button_Arrows_MouseHover);
            // 
            // button_Classes
            // 
            this.button_Classes.BackColor = System.Drawing.SystemColors.Control;
            this.button_Classes.Location = new System.Drawing.Point(377, 19);
            this.button_Classes.Margin = new System.Windows.Forms.Padding(2);
            this.button_Classes.Name = "button_Classes";
            this.button_Classes.Size = new System.Drawing.Size(125, 31);
            this.button_Classes.TabIndex = 20;
            this.button_Classes.Text = "Classes";
            this.button_Classes.UseVisualStyleBackColor = false;
            this.button_Classes.MouseHover += new System.EventHandler(this.button_Classes_MouseHover);
            // 
            // pictureBox_Arrows
            // 
            this.button_Class2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button_Class2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Class2.Location = new System.Drawing.Point(993, 95);
            this.button_Class2.Name = "button_Class2";
            this.button_Class2.Size = new System.Drawing.Size(133, 27);
            this.button_Class2.TabIndex = 18;
            this.button_Class2.Text = "Class2";
            this.button_Class2.UseVisualStyleBackColor = true;
            this.button_Class2.Click += new System.EventHandler(this.button_Class2_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(961, 29);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(112, 34);
            this.button_Clear.TabIndex = 22;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click_1);
            // 
            // pictureBox_Classes
            // 
            this.pictureBox_Classes.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Classes.Image")));
            this.pictureBox_Classes.ImageLocation = "ImagesClasses\\Classes.JPG";
            this.pictureBox_Classes.Location = new System.Drawing.Point(923, 255);
            this.pictureBox_Classes.Name = "pictureBox_Classes";
            this.pictureBox_Classes.Size = new System.Drawing.Size(150, 75);
            this.pictureBox_Classes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Classes.TabIndex = 23;
            this.pictureBox_Classes.TabStop = false;
            this.pictureBox_Classes.MouseHover += new System.EventHandler(this.pictureBox_Classes_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 570);
            this.Controls.Add(this.button_Class2);
            this.Controls.Add(this.button_ClassStack);
            this.Controls.Add(this.button_Class3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_StepBack);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Class3;
        private System.Windows.Forms.Button button_ClassStack;
        private System.Windows.Forms.Button button_Class2;
    }
}

