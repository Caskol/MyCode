namespace MyCode
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainMenu = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenFileToolStripMenuItem = new ToolStripMenuItem();
            DBViewToolStripMenuItem = new ToolStripMenuItem();
            SettingsToolStripMenuItem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            StatusStripLabel = new ToolStripStatusLabel();
            PanelWithButtons = new Panel();
            comboBoxLanguage = new ComboBox();
            buttonShowTokens = new Button();
            groupBox1 = new GroupBox();
            labelPlagiat = new Label();
            labelPlagiatPercent = new Label();
            labelRightCount = new Label();
            labelLeftCount = new Label();
            buttonCompare = new Button();
            openFileDialog = new OpenFileDialog();
            FCTBRight = new FastColoredTextBoxNS.FastColoredTextBox();
            FCTBLeft = new FastColoredTextBoxNS.FastColoredTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            MainMenu.SuspendLayout();
            StatusStrip.SuspendLayout();
            PanelWithButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FCTBRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FCTBLeft).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, DBViewToolStripMenuItem, SettingsToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(875, 24);
            MainMenu.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenFileToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(48, 20);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenFileToolStripMenuItem
            // 
            OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            OpenFileToolStripMenuItem.Size = new Size(121, 22);
            OpenFileToolStripMenuItem.Text = "Открыть";
            OpenFileToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            // 
            // DBViewToolStripMenuItem
            // 
            DBViewToolStripMenuItem.Name = "DBViewToolStripMenuItem";
            DBViewToolStripMenuItem.Size = new Size(94, 20);
            DBViewToolStripMenuItem.Text = "Просмотр БД";
            DBViewToolStripMenuItem.Click += DBViewToolStripMenuItem_Click;
            // 
            // SettingsToolStripMenuItem
            // 
            SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            SettingsToolStripMenuItem.Size = new Size(83, 20);
            SettingsToolStripMenuItem.Text = "Параметры";
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { StatusStripLabel });
            StatusStrip.Location = new Point(0, 428);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(875, 22);
            StatusStrip.TabIndex = 1;
            // 
            // StatusStripLabel
            // 
            StatusStripLabel.Name = "StatusStripLabel";
            StatusStripLabel.Size = new Size(362, 17);
            StatusStripLabel.Text = "Откройте файл для отображения дополнительной информации";
            // 
            // PanelWithButtons
            // 
            PanelWithButtons.Controls.Add(comboBoxLanguage);
            PanelWithButtons.Controls.Add(buttonShowTokens);
            PanelWithButtons.Controls.Add(groupBox1);
            PanelWithButtons.Controls.Add(buttonCompare);
            PanelWithButtons.Dock = DockStyle.Right;
            PanelWithButtons.Location = new Point(667, 24);
            PanelWithButtons.Name = "PanelWithButtons";
            PanelWithButtons.Size = new Size(208, 404);
            PanelWithButtons.TabIndex = 3;
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Items.AddRange(new object[] { "C#", "C++", "C", "Python", "Pascal", "Java" });
            comboBoxLanguage.Location = new Point(3, 75);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(202, 23);
            comboBoxLanguage.TabIndex = 3;
            // 
            // buttonShowTokens
            // 
            buttonShowTokens.Location = new Point(3, 39);
            buttonShowTokens.Name = "buttonShowTokens";
            buttonShowTokens.Size = new Size(202, 30);
            buttonShowTokens.TabIndex = 2;
            buttonShowTokens.Text = "Показать токены";
            buttonShowTokens.UseVisualStyleBackColor = true;
            buttonShowTokens.Click += buttonShowTokens_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(labelPlagiat);
            groupBox1.Controls.Add(labelPlagiatPercent);
            groupBox1.Controls.Add(labelRightCount);
            groupBox1.Controls.Add(labelLeftCount);
            groupBox1.Location = new Point(3, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(202, 292);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация о текстах";
            // 
            // labelPlagiat
            // 
            labelPlagiat.AutoSize = true;
            labelPlagiat.Location = new Point(3, 92);
            labelPlagiat.Name = "labelPlagiat";
            labelPlagiat.Size = new Size(80, 15);
            labelPlagiat.TabIndex = 3;
            labelPlagiat.Text = "Плагиат: Н/Д";
            // 
            // labelPlagiatPercent
            // 
            labelPlagiatPercent.AutoSize = true;
            labelPlagiatPercent.Location = new Point(3, 68);
            labelPlagiatPercent.Name = "labelPlagiatPercent";
            labelPlagiatPercent.Size = new Size(191, 15);
            labelPlagiatPercent.TabIndex = 2;
            labelPlagiatPercent.Text = "Текущее значение схожести: Н/Д";
            // 
            // labelRightCount
            // 
            labelRightCount.AutoSize = true;
            labelRightCount.Location = new Point(3, 44);
            labelRightCount.Name = "labelRightCount";
            labelRightCount.Size = new Size(159, 15);
            labelRightCount.TabIndex = 1;
            labelRightCount.Text = "Количество строк справа: 1";
            // 
            // labelLeftCount
            // 
            labelLeftCount.AutoSize = true;
            labelLeftCount.Location = new Point(3, 19);
            labelLeftCount.Name = "labelLeftCount";
            labelLeftCount.Size = new Size(152, 15);
            labelLeftCount.TabIndex = 0;
            labelLeftCount.Text = "Количество строк слева: 1";
            // 
            // buttonCompare
            // 
            buttonCompare.Location = new Point(3, 3);
            buttonCompare.Name = "buttonCompare";
            buttonCompare.Size = new Size(202, 30);
            buttonCompare.TabIndex = 0;
            buttonCompare.Text = "Сравнить";
            buttonCompare.UseVisualStyleBackColor = true;
            buttonCompare.Click += buttonCompare_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "Все файлы|*.*";
            // 
            // FCTBRight
            // 
            FCTBRight.AutoCompleteBracketsList = (new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' });
            FCTBRight.AutoScrollMinSize = new Size(27, 14);
            FCTBRight.BackBrush = null;
            FCTBRight.CharHeight = 14;
            FCTBRight.CharWidth = 8;
            FCTBRight.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            FCTBRight.Dock = DockStyle.Fill;
            FCTBRight.IsReplaceMode = false;
            FCTBRight.Location = new Point(337, 5);
            FCTBRight.Name = "FCTBRight";
            FCTBRight.Paddings = new Padding(0);
            FCTBRight.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            FCTBRight.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("FCTBRight.ServiceColors");
            FCTBRight.Size = new Size(325, 394);
            FCTBRight.TabIndex = 1;
            FCTBRight.Zoom = 100;
            FCTBRight.TextChanged += FCTBRight_TextChanged;
            FCTBRight.Click += FCTBRight_Click;
            // 
            // FCTBLeft
            // 
            FCTBLeft.AutoCompleteBracketsList = (new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' });
            FCTBLeft.AutoScrollMinSize = new Size(27, 14);
            FCTBLeft.BackBrush = null;
            FCTBLeft.CharHeight = 14;
            FCTBLeft.CharWidth = 8;
            FCTBLeft.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            FCTBLeft.Dock = DockStyle.Fill;
            FCTBLeft.IsReplaceMode = false;
            FCTBLeft.Location = new Point(5, 5);
            FCTBLeft.Name = "FCTBLeft";
            FCTBLeft.Paddings = new Padding(0);
            FCTBLeft.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            FCTBLeft.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("FCTBLeft.ServiceColors");
            FCTBLeft.Size = new Size(324, 394);
            FCTBLeft.TabIndex = 0;
            FCTBLeft.Zoom = 100;
            FCTBLeft.TextChanged += FCTBLeft_TextChanged;
            FCTBLeft.Click += FCTBLeft_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(FCTBLeft, 0, 0);
            tableLayoutPanel1.Controls.Add(FCTBRight, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(667, 404);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(PanelWithButtons);
            Controls.Add(StatusStrip);
            Controls.Add(MainMenu);
            MainMenuStrip = MainMenu;
            Name = "MainForm";
            Text = "MyCode";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            PanelWithButtons.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FCTBRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)FCTBLeft).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel StatusStripLabel;
        private Panel PanelWithButtons;
        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem DBViewToolStripMenuItem;
        private Button buttonCompare;
        private GroupBox groupBox1;
        private Button buttonShowTokens;
        private Label labelPlagiatPercent;
        private Label labelRightCount;
        private Label labelLeftCount;
        private ComboBox comboBoxLanguage;
        private ToolStripMenuItem SettingsToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox FCTBRight;
        private FastColoredTextBoxNS.FastColoredTextBox FCTBLeft;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelPlagiat;
    }
}