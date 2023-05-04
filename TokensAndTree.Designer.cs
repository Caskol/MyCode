namespace MyCode
{
    partial class TokensReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokensReview));
            dataGridViewTokens = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTokens).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTokens
            // 
            dataGridViewTokens.AllowUserToAddRows = false;
            dataGridViewTokens.AllowUserToDeleteRows = false;
            dataGridViewTokens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTokens.Dock = DockStyle.Fill;
            dataGridViewTokens.Location = new Point(0, 0);
            dataGridViewTokens.Name = "dataGridViewTokens";
            dataGridViewTokens.ReadOnly = true;
            dataGridViewTokens.RowTemplate.Height = 25;
            dataGridViewTokens.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTokens.ShowCellErrors = false;
            dataGridViewTokens.ShowCellToolTips = false;
            dataGridViewTokens.ShowEditingIcon = false;
            dataGridViewTokens.ShowRowErrors = false;
            dataGridViewTokens.Size = new Size(364, 401);
            dataGridViewTokens.TabIndex = 0;
            // 
            // TokensReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 401);
            Controls.Add(dataGridViewTokens);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(380, 12000);
            MinimumSize = new Size(380, 440);
            Name = "TokensReview";
            Text = "Tokens Review";
            Load += TokensAndTree_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTokens).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewTokens;
    }
}