
namespace UMLDisigner
{
    partial class FormArrows
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
            this.pictureBox_Association = new System.Windows.Forms.PictureBox();
            this.pictureBox_Aggregation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Association)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Aggregation)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Association
            // 
            this.pictureBox_Association.ImageLocation = "C:\\Users\\kushk\\source\\repos\\UML-designer\\UMLDisigner\\ImagesArrows\\association.JPG" +
    "";
            this.pictureBox_Association.Location = new System.Drawing.Point(21, 40);
            this.pictureBox_Association.Name = "pictureBox_Association";
            this.pictureBox_Association.Size = new System.Drawing.Size(78, 28);
            this.pictureBox_Association.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Association.TabIndex = 0;
            this.pictureBox_Association.TabStop = false;
            this.pictureBox_Association.Click += new System.EventHandler(this.pictureBox_Association_Click);
            // 
            // pictureBox_Aggregation
            // 
            this.pictureBox_Aggregation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_Aggregation.ImageLocation = "C:\\Users\\kushk\\source\\repos\\UML-designer\\UMLDisigner\\ImagesArrows\\aggregation.JPG" +
    "";
            this.pictureBox_Aggregation.Location = new System.Drawing.Point(127, 40);
            this.pictureBox_Aggregation.Name = "pictureBox_Aggregation";
            this.pictureBox_Aggregation.Size = new System.Drawing.Size(77, 28);
            this.pictureBox_Aggregation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Aggregation.TabIndex = 1;
            this.pictureBox_Aggregation.TabStop = false;
            this.pictureBox_Aggregation.Click += new System.EventHandler(this.pictureBox_Aggregation_Click);
            // 
            // FormArrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 142);
            this.Controls.Add(this.pictureBox_Aggregation);
            this.Controls.Add(this.pictureBox_Association);
            this.Name = "FormArrows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Arrows";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Association)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Aggregation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Association;
        private System.Windows.Forms.PictureBox pictureBox_Aggregation;
    }
}