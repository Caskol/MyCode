namespace MyCode
{
    partial class WaitingForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            timerWaitCounter = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 61);
            label1.Name = "label1";
            label1.Size = new Size(309, 15);
            label1.TabIndex = 0;
            label1.Text = "Сравнивать код это очень сложно и долго. Подождите";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 79);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(387, 23);
            progressBar1.TabIndex = 1;
            // 
            // WaitingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 153);
            ControlBox = false;
            Controls.Add(progressBar1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "WaitingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer timerWaitCounter;
        private ProgressBar progressBar1;
    }
}