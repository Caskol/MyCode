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
            aboutToolStripMenuItem = new ToolStripMenuItem();
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
            splitContainer1 = new SplitContainer();
            waitingPanel = new Panel();
            progressBar1 = new ProgressBar();
            waitingLabel = new Label();
            MainMenu.SuspendLayout();
            StatusStrip.SuspendLayout();
            PanelWithButtons.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FCTBRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FCTBLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            waitingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, DBViewToolStripMenuItem, SettingsToolStripMenuItem, aboutToolStripMenuItem });
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
            SettingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(94, 20);
            aboutToolStripMenuItem.Text = "О программе";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
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
            FCTBRight.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
            FCTBRight.AutoScrollMinSize = new Size(2, 14);
            FCTBRight.BackBrush = null;
            FCTBRight.CharHeight = 14;
            FCTBRight.CharWidth = 8;
            FCTBRight.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            FCTBRight.Dock = DockStyle.Fill;
            FCTBRight.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FCTBRight.IsReplaceMode = false;
            FCTBRight.Location = new Point(0, 0);
            FCTBRight.Name = "FCTBRight";
            FCTBRight.Paddings = new Padding(0);
            FCTBRight.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            FCTBRight.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("FCTBRight.ServiceColors");
            FCTBRight.Size = new Size(339, 400);
            FCTBRight.TabIndex = 1;
            FCTBRight.Zoom = 100;
            FCTBRight.TextChanged += FCTBRight_TextChanged;
            FCTBRight.Click += FCTBRight_Click;
            FCTBRight.DragDrop += DragDrop;
            FCTBRight.DragEnter += DragEnter;
            // 
            // FCTBLeft
            // 
            FCTBLeft.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
            FCTBLeft.AutoScrollMinSize = new Size(2, 14);
            FCTBLeft.BackBrush = null;
            FCTBLeft.BorderStyle = BorderStyle.FixedSingle;
            FCTBLeft.CharHeight = 14;
            FCTBLeft.CharWidth = 8;
            FCTBLeft.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            FCTBLeft.Dock = DockStyle.Fill;
            FCTBLeft.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FCTBLeft.IsReplaceMode = false;
            FCTBLeft.Location = new Point(0, 0);
            FCTBLeft.Name = "FCTBLeft";
            FCTBLeft.Paddings = new Padding(0);
            FCTBLeft.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            FCTBLeft.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("FCTBLeft.ServiceColors");
            FCTBLeft.Size = new Size(310, 400);
            FCTBLeft.TabIndex = 0;
            FCTBLeft.Zoom = 100;
            FCTBLeft.TextChanged += FCTBLeft_TextChanged;
            FCTBLeft.Click += FCTBLeft_Click;
            FCTBLeft.DragDrop += DragDrop;
            FCTBLeft.DragEnter += DragEnter;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ActiveBorder;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(FCTBLeft);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(FCTBRight);
            splitContainer1.Panel2MinSize = 100;
            splitContainer1.Size = new Size(667, 404);
            splitContainer1.SplitterDistance = 314;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 4;
            // 
            // waitingPanel
            // 
            waitingPanel.BackColor = Color.Transparent;
            waitingPanel.Controls.Add(progressBar1);
            waitingPanel.Controls.Add(waitingLabel);
            waitingPanel.Dock = DockStyle.Fill;
            waitingPanel.Enabled = false;
            waitingPanel.Location = new Point(0, 24);
            waitingPanel.Name = "waitingPanel";
            waitingPanel.Size = new Size(667, 404);
            waitingPanel.TabIndex = 5;
            waitingPanel.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progressBar1.Location = new Point(181, 201);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(309, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 4;
            // 
            // waitingLabel
            // 
            waitingLabel.AutoSize = true;
            waitingLabel.Location = new Point(181, 183);
            waitingLabel.Name = "waitingLabel";
            waitingLabel.Size = new Size(309, 15);
            waitingLabel.TabIndex = 3;
            waitingLabel.Text = "Сравнивать код это очень сложно и долго. Подождите";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 450);
            Controls.Add(waitingPanel);
            Controls.Add(splitContainer1);
            Controls.Add(PanelWithButtons);
            Controls.Add(StatusStrip);
            Controls.Add(MainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            MinimumSize = new Size(600, 450);
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
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            waitingPanel.ResumeLayout(false);
            waitingPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem FileToolStripMenuItem;
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
        private Label labelPlagiat;
        private SplitContainer splitContainer1;
        private Panel waitingPanel;
        private Label waitingLabel;
        private ProgressBar progressBar1;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}