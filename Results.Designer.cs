namespace MyCode
{
    partial class Results
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Results));
            resultsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)resultsGridView).BeginInit();
            SuspendLayout();
            // 
            // resultsGridView
            // 
            resultsGridView.AllowUserToAddRows = false;
            resultsGridView.AllowUserToDeleteRows = false;
            resultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsGridView.Dock = DockStyle.Fill;
            resultsGridView.Location = new Point(0, 0);
            resultsGridView.Name = "resultsGridView";
            resultsGridView.ReadOnly = true;
            resultsGridView.RowTemplate.Height = 25;
            resultsGridView.ShowCellToolTips = false;
            resultsGridView.Size = new Size(800, 450);
            resultsGridView.TabIndex = 0;
            // 
            // Results
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultsGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Results";
            Text = "Результаты сравнения";
            ((System.ComponentModel.ISupportInitialize)resultsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultsGridView;
    }
}