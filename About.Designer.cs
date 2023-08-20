namespace MyCode
{
    partial class About
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
            pictureBoxLogo = new PictureBox();
            buttonClose = new Button();
            labelAbout = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(12, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(12, 78);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(135, 48);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelAbout
            // 
            labelAbout.Location = new Point(12, 129);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(38, 15);
            labelAbout.TabIndex = 2;
            labelAbout.Text = "label1";
            labelAbout.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 299);
            Controls.Add(labelAbout);
            Controls.Add(buttonClose);
            Controls.Add(pictureBoxLogo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private Button buttonClose;
        private Label labelAbout;
    }
}