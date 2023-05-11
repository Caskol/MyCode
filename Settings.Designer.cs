namespace MyCode
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            labelPlagiarism = new Label();
            toolTipPlagiat = new ToolTip(components);
            trackBarPlagiat = new TrackBar();
            numericUpDownPlagiat = new NumericUpDown();
            buttonSave = new Button();
            labelMaximumSymbols = new Label();
            numericUpDownSymbols = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)trackBarPlagiat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPlagiat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSymbols).BeginInit();
            SuspendLayout();
            // 
            // labelPlagiarism
            // 
            labelPlagiarism.AutoSize = true;
            labelPlagiarism.Location = new Point(12, 28);
            labelPlagiarism.Name = "labelPlagiarism";
            labelPlagiarism.Size = new Size(107, 15);
            labelPlagiarism.TabIndex = 0;
            labelPlagiarism.Text = "Процент плагиата";
            toolTipPlagiat.SetToolTip(labelPlagiarism, "Позволяет настроить процент плагиата, при котором текст будет считаться сходим (по умолчанию - 70%)");
            // 
            // trackBarPlagiat
            // 
            trackBarPlagiat.Location = new Point(125, 28);
            trackBarPlagiat.Maximum = 100;
            trackBarPlagiat.Minimum = 40;
            trackBarPlagiat.Name = "trackBarPlagiat";
            trackBarPlagiat.Size = new Size(237, 45);
            trackBarPlagiat.TabIndex = 1;
            trackBarPlagiat.Value = 40;
            trackBarPlagiat.ValueChanged += trackBarPlagiat_ValueChanged;
            // 
            // numericUpDownPlagiat
            // 
            numericUpDownPlagiat.Location = new Point(365, 28);
            numericUpDownPlagiat.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDownPlagiat.Name = "numericUpDownPlagiat";
            numericUpDownPlagiat.Size = new Size(47, 23);
            numericUpDownPlagiat.TabIndex = 2;
            numericUpDownPlagiat.Value = new decimal(new int[] { 40, 0, 0, 0 });
            numericUpDownPlagiat.ValueChanged += numericUpDownPlagiat_ValueChanged;
            // 
            // buttonSave
            // 
            buttonSave.DialogResult = DialogResult.OK;
            buttonSave.Location = new Point(298, 127);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 32);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelMaximumSymbols
            // 
            labelMaximumSymbols.AutoSize = true;
            labelMaximumSymbols.Location = new Point(12, 76);
            labelMaximumSymbols.Name = "labelMaximumSymbols";
            labelMaximumSymbols.Size = new Size(164, 15);
            labelMaximumSymbols.TabIndex = 4;
            labelMaximumSymbols.Text = "Макс. количество символов";
            // 
            // numericUpDownSymbols
            // 
            numericUpDownSymbols.Location = new Point(292, 74);
            numericUpDownSymbols.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numericUpDownSymbols.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSymbols.Name = "numericUpDownSymbols";
            numericUpDownSymbols.Size = new Size(120, 23);
            numericUpDownSymbols.TabIndex = 5;
            numericUpDownSymbols.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 171);
            Controls.Add(numericUpDownSymbols);
            Controls.Add(labelMaximumSymbols);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownPlagiat);
            Controls.Add(trackBarPlagiat);
            Controls.Add(labelPlagiarism);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(440, 210);
            Name = "Settings";
            Text = "Параметры";
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarPlagiat).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPlagiat).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSymbols).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPlagiarism;
        private ToolTip toolTipPlagiat;
        private TrackBar trackBarPlagiat;
        private NumericUpDown numericUpDownPlagiat;
        private Button buttonSave;
        private Label labelMaximumSymbols;
        private NumericUpDown numericUpDownSymbols;
    }
}