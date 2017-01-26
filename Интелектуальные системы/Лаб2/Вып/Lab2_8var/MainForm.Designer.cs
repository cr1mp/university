namespace Lab2_8var
{
    partial class MainForm
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
			this.LoadDataButton = new System.Windows.Forms.Button();
			this.LoadDataDialog = new System.Windows.Forms.OpenFileDialog();
			this.AddFactToTrueListButton = new System.Windows.Forms.Button();
			this.RSTree = new System.Windows.Forms.TreeView();
			this.FactToCheck = new System.Windows.Forms.ComboBox();
			this.DeductionType = new System.Windows.Forms.ComboBox();
			this.TruthMethod = new System.Windows.Forms.ComboBox();
			this.ConflictMethod = new System.Windows.Forms.ComboBox();
			this.RemoveFactFromTrueListButton = new System.Windows.Forms.Button();
			this.AllFactsList = new System.Windows.Forms.ListBox();
			this.TrueFactsList = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.leftPanel = new System.Windows.Forms.Panel();
			this.rightPanel = new System.Windows.Forms.Panel();
			this.leftPanel.SuspendLayout();
			this.rightPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// LoadDataButton
			// 
			this.LoadDataButton.Location = new System.Drawing.Point(12, 275);
			this.LoadDataButton.Name = "LoadDataButton";
			this.LoadDataButton.Size = new System.Drawing.Size(367, 35);
			this.LoadDataButton.TabIndex = 0;
			this.LoadDataButton.Text = "Загрузка базы";
			this.LoadDataButton.UseVisualStyleBackColor = true;
			this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
			// 
			// LoadDataDialog
			// 
			this.LoadDataDialog.FileName = "openFileDialog1";
			this.LoadDataDialog.Filter = "Базы знаний (*.kdb)|*.kdb|Все файлы (*.*)|*.*";
			this.LoadDataDialog.Title = "Выберите файл с базой знаний";
			// 
			// AddFactToTrueListButton
			// 
			this.AddFactToTrueListButton.Location = new System.Drawing.Point(12, 227);
			this.AddFactToTrueListButton.Name = "AddFactToTrueListButton";
			this.AddFactToTrueListButton.Size = new System.Drawing.Size(367, 23);
			this.AddFactToTrueListButton.TabIndex = 1;
			this.AddFactToTrueListButton.Text = "Добавить";
			this.AddFactToTrueListButton.UseVisualStyleBackColor = true;
			this.AddFactToTrueListButton.Click += new System.EventHandler(this.AddFactToTrueListButton_Click);
			// 
			// RSTree
			// 
			this.RSTree.Location = new System.Drawing.Point(12, 332);
			this.RSTree.Name = "RSTree";
			this.RSTree.Size = new System.Drawing.Size(367, 299);
			this.RSTree.TabIndex = 5;
			// 
			// FactToCheck
			// 
			this.FactToCheck.FormattingEnabled = true;
			this.FactToCheck.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
			this.FactToCheck.Location = new System.Drawing.Point(34, 332);
			this.FactToCheck.Name = "FactToCheck";
			this.FactToCheck.Size = new System.Drawing.Size(300, 21);
			this.FactToCheck.TabIndex = 6;
			this.FactToCheck.SelectedIndexChanged += new System.EventHandler(this.FactToCheck_SelectedIndexChanged);
			// 
			// DeductionType
			// 
			this.DeductionType.FormattingEnabled = true;
			this.DeductionType.Items.AddRange(new object[] {
            "Обратный"});
			this.DeductionType.Location = new System.Drawing.Point(34, 369);
			this.DeductionType.Name = "DeductionType";
			this.DeductionType.Size = new System.Drawing.Size(300, 21);
			this.DeductionType.TabIndex = 10;
			// 
			// TruthMethod
			// 
			this.TruthMethod.FormattingEnabled = true;
			this.TruthMethod.Items.AddRange(new object[] {
            "Выбор последнего правила из конфликтного множества"});
			this.TruthMethod.Location = new System.Drawing.Point(34, 408);
			this.TruthMethod.Name = "TruthMethod";
			this.TruthMethod.Size = new System.Drawing.Size(300, 21);
			this.TruthMethod.TabIndex = 11;
			// 
			// ConflictMethod
			// 
			this.ConflictMethod.FormattingEnabled = true;
			this.ConflictMethod.Items.AddRange(new object[] {
            "Минимум из достоверности правила и достоверности посылки"});
			this.ConflictMethod.Location = new System.Drawing.Point(34, 446);
			this.ConflictMethod.Name = "ConflictMethod";
			this.ConflictMethod.Size = new System.Drawing.Size(300, 21);
			this.ConflictMethod.TabIndex = 12;
			// 
			// RemoveFactFromTrueListButton
			// 
			this.RemoveFactFromTrueListButton.Location = new System.Drawing.Point(27, 218);
			this.RemoveFactFromTrueListButton.Name = "RemoveFactFromTrueListButton";
			this.RemoveFactFromTrueListButton.Size = new System.Drawing.Size(356, 23);
			this.RemoveFactFromTrueListButton.TabIndex = 13;
			this.RemoveFactFromTrueListButton.Text = "Удалить";
			this.RemoveFactFromTrueListButton.UseVisualStyleBackColor = true;
			this.RemoveFactFromTrueListButton.Click += new System.EventHandler(this.RemoveFactFromTrueListButton_Click);
			// 
			// AllFactsList
			// 
			this.AllFactsList.FormattingEnabled = true;
			this.AllFactsList.HorizontalScrollbar = true;
			this.AllFactsList.Location = new System.Drawing.Point(15, 49);
			this.AllFactsList.Name = "AllFactsList";
			this.AllFactsList.Size = new System.Drawing.Size(367, 147);
			this.AllFactsList.Sorted = true;
			this.AllFactsList.TabIndex = 2;
			// 
			// TrueFactsList
			// 
			this.TrueFactsList.FormattingEnabled = true;
			this.TrueFactsList.Location = new System.Drawing.Point(27, 65);
			this.TrueFactsList.Name = "TrueFactsList";
			this.TrueFactsList.Size = new System.Drawing.Size(356, 147);
			this.TrueFactsList.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Верные факты";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Возможные факты";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 313);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(156, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Последовательность вывода";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 313);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Проверить, будет ли:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(34, 356);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Методы вывода:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(34, 393);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(171, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Метод разрешения конфликтов:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(34, 432);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(185, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Метод вычисления достоверности:";
			// 
			// leftPanel
			// 
			this.leftPanel.Controls.Add(this.label3);
			this.leftPanel.Controls.Add(this.LoadDataButton);
			this.leftPanel.Controls.Add(this.AddFactToTrueListButton);
			this.leftPanel.Controls.Add(this.RSTree);
			this.leftPanel.Controls.Add(this.AllFactsList);
			this.leftPanel.Controls.Add(this.label4);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.Size = new System.Drawing.Size(405, 661);
			this.leftPanel.TabIndex = 21;
			// 
			// rightPanel
			// 
			this.rightPanel.Controls.Add(this.label2);
			this.rightPanel.Controls.Add(this.TrueFactsList);
			this.rightPanel.Controls.Add(this.label7);
			this.rightPanel.Controls.Add(this.FactToCheck);
			this.rightPanel.Controls.Add(this.label6);
			this.rightPanel.Controls.Add(this.DeductionType);
			this.rightPanel.Controls.Add(this.label5);
			this.rightPanel.Controls.Add(this.TruthMethod);
			this.rightPanel.Controls.Add(this.label1);
			this.rightPanel.Controls.Add(this.ConflictMethod);
			this.rightPanel.Controls.Add(this.RemoveFactFromTrueListButton);
			this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.rightPanel.Location = new System.Drawing.Point(442, 0);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.Size = new System.Drawing.Size(404, 661);
			this.rightPanel.TabIndex = 22;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 661);
			this.Controls.Add(this.rightPanel);
			this.Controls.Add(this.leftPanel);
			this.Name = "MainForm";
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			this.rightPanel.ResumeLayout(false);
			this.rightPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Button AddFactToTrueListButton;
        private System.Windows.Forms.Button RemoveFactFromTrueListButton;
        private System.Windows.Forms.ListBox AllFactsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		public System.Windows.Forms.OpenFileDialog LoadDataDialog;
		public System.Windows.Forms.ListBox TrueFactsList;
		public System.Windows.Forms.TreeView RSTree;
		public System.Windows.Forms.ComboBox FactToCheck;
		public System.Windows.Forms.ComboBox TruthMethod;
		public System.Windows.Forms.ComboBox DeductionType;
		public System.Windows.Forms.ComboBox ConflictMethod;
		private System.Windows.Forms.Panel leftPanel;
		private System.Windows.Forms.Panel rightPanel;
	}
}

