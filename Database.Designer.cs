namespace MyCode
{
    partial class Database
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
            groupBox1 = new GroupBox();
            buttonDelete = new Button();
            panelInfoButton = new Panel();
            panel1 = new Panel();
            DataBaseGrid = new DataGridView();
            panelInfoButton.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataBaseGrid).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 431);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация:";
            // 
            // buttonDelete
            // 
            buttonDelete.Dock = DockStyle.Bottom;
            buttonDelete.Location = new Point(0, 431);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(200, 30);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // panelInfoButton
            // 
            panelInfoButton.Controls.Add(groupBox1);
            panelInfoButton.Controls.Add(buttonDelete);
            panelInfoButton.Dock = DockStyle.Right;
            panelInfoButton.Location = new Point(574, 0);
            panelInfoButton.Name = "panelInfoButton";
            panelInfoButton.Size = new Size(200, 461);
            panelInfoButton.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(DataBaseGrid);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(574, 461);
            panel1.TabIndex = 2;
            // 
            // DataBaseGrid
            // 
            DataBaseGrid.AllowUserToAddRows = false;
            DataBaseGrid.AllowUserToDeleteRows = false;
            DataBaseGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataBaseGrid.Dock = DockStyle.Fill;
            DataBaseGrid.Location = new Point(0, 0);
            DataBaseGrid.Name = "DataBaseGrid";
            DataBaseGrid.ReadOnly = true;
            DataBaseGrid.RowTemplate.Height = 25;
            DataBaseGrid.Size = new Size(574, 461);
            DataBaseGrid.TabIndex = 2;
            // 
            // Database
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 461);
            Controls.Add(panel1);
            Controls.Add(panelInfoButton);
            MinimumSize = new Size(790, 500);
            Name = "Database";
            Text = "Просмотр базы данных";
            Load += Database_Load;
            panelInfoButton.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataBaseGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button buttonDelete;
        private Panel panelInfoButton;
        private Panel panel1;
        private DataGridView DataBaseGrid;
    }
}