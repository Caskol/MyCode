namespace MyCode
{
    partial class TokensAndTree
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
            dataGridViewTokens = new DataGridView();
            textBoxTree = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTokens).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTokens
            // 
            dataGridViewTokens.AllowUserToAddRows = false;
            dataGridViewTokens.AllowUserToDeleteRows = false;
            dataGridViewTokens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTokens.Dock = DockStyle.Left;
            dataGridViewTokens.Location = new Point(0, 0);
            dataGridViewTokens.Name = "dataGridViewTokens";
            dataGridViewTokens.ReadOnly = true;
            dataGridViewTokens.RowTemplate.Height = 25;
            dataGridViewTokens.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTokens.ShowCellErrors = false;
            dataGridViewTokens.ShowCellToolTips = false;
            dataGridViewTokens.ShowEditingIcon = false;
            dataGridViewTokens.ShowRowErrors = false;
            dataGridViewTokens.Size = new Size(362, 450);
            dataGridViewTokens.TabIndex = 0;
            // 
            // textBoxTree
            // 
            textBoxTree.Dock = DockStyle.Fill;
            textBoxTree.Location = new Point(362, 0);
            textBoxTree.Multiline = true;
            textBoxTree.Name = "textBoxTree";
            textBoxTree.ReadOnly = true;
            textBoxTree.ScrollBars = ScrollBars.Both;
            textBoxTree.Size = new Size(272, 450);
            textBoxTree.TabIndex = 1;
            // 
            // TokensAndTree
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 450);
            Controls.Add(textBoxTree);
            Controls.Add(dataGridViewTokens);
            Name = "TokensAndTree";
            Text = "TokensAndTree";
            Load += TokensAndTree_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTokens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTokens;
        private TextBox textBoxTree;
    }
}