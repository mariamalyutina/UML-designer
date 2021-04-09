
namespace UMLDisigner
{
    partial class FormClasses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_Class1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Class2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Class3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_ClassStack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClassStack)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Class1
            // 
            this.pictureBox_Class1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox_Class1.ImageLocation = "ImagesClasses\\Classes1.JPG";
            this.pictureBox_Class1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox_Class1.Name = "pictureBox_Class1";
            this.pictureBox_Class1.Size = new System.Drawing.Size(147, 97);
            this.pictureBox_Class1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Class1.TabIndex = 0;
            this.pictureBox_Class1.TabStop = false;
            this.pictureBox_Class1.Click += new System.EventHandler(this.pictureBox_Class1_Click);
            // 
            // pictureBox_Class2
            // 
            this.pictureBox_Class2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox_Class2.ImageLocation = "ImagesClasses\\Classes2.JPG";
            this.pictureBox_Class2.Location = new System.Drawing.Point(165, 10);
            this.pictureBox_Class2.Name = "pictureBox_Class2";
            this.pictureBox_Class2.Size = new System.Drawing.Size(139, 97);
            this.pictureBox_Class2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Class2.TabIndex = 1;
            this.pictureBox_Class2.TabStop = false;
            this.pictureBox_Class2.Click += new System.EventHandler(this.pictureBox_Class2_Click);
            // 
            // pictureBox_Class3
            // 
            this.pictureBox_Class3.ImageLocation = "ImagesClasses\\Classes3.JPG";
            this.pictureBox_Class3.Location = new System.Drawing.Point(12, 124);
            this.pictureBox_Class3.Name = "pictureBox_Class3";
            this.pictureBox_Class3.Size = new System.Drawing.Size(147, 106);
            this.pictureBox_Class3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Class3.TabIndex = 2;
            this.pictureBox_Class3.TabStop = false;
            this.pictureBox_Class3.Click += new System.EventHandler(this.pictureBox_Class3_Click);
            // 
            // pictureBox_ClassStack
            // 
            this.pictureBox_ClassStack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox_ClassStack.ImageLocation = "ImagesClasses\\ClassStack.JPG";
            this.pictureBox_ClassStack.Location = new System.Drawing.Point(165, 124);
            this.pictureBox_ClassStack.Name = "pictureBox_ClassStack";
            this.pictureBox_ClassStack.Size = new System.Drawing.Size(139, 106);
            this.pictureBox_ClassStack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ClassStack.TabIndex = 3;
            this.pictureBox_ClassStack.TabStop = false;
            this.pictureBox_ClassStack.Click += new System.EventHandler(this.pictureBox_ClassStack_Click);
            // 
            // FormClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 241);
            this.Controls.Add(this.pictureBox_ClassStack);
            this.Controls.Add(this.pictureBox_Class3);
            this.Controls.Add(this.pictureBox_Class2);
            this.Controls.Add(this.pictureBox_Class1);
            this.Name = "FormClasses";
            this.Text = "FormClasses";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClassStack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Class1;
        private System.Windows.Forms.PictureBox pictureBox_Class2;
        private System.Windows.Forms.PictureBox pictureBox_Class3;
        private System.Windows.Forms.PictureBox pictureBox_ClassStack;
    }
}