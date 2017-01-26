namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.StartButton = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.Result = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Matrix = new System.Windows.Forms.DataGridView();
      this.CreateBurron = new System.Windows.Forms.Button();
      this.OpenButton = new System.Windows.Forms.Button();
      this.SaveButton = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(49, 83);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 0;
      // 
      // StartButton
      // 
      this.StartButton.Location = new System.Drawing.Point(33, 265);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(75, 23);
      this.StartButton.TabIndex = 1;
      this.StartButton.Text = "Найти";
      this.StartButton.UseVisualStyleBackColor = true;
      this.StartButton.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(33, 225);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(91, 20);
      this.textBox2.TabIndex = 2;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(12, 342);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(196, 20);
      this.textBox3.TabIndex = 3;
      // 
      // Result
      // 
      this.Result.AllowUserToAddRows = false;
      this.Result.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6});
      this.Result.Location = new System.Drawing.Point(577, 12);
      this.Result.Name = "Result";
      this.Result.Size = new System.Drawing.Size(669, 405);
      this.Result.TabIndex = 4;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "№ поколения";
      this.Column1.Name = "Column1";
      this.Column1.Width = 80;
      // 
      // Column2
      // 
      this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
      this.Column2.HeaderText = "Родители";
      this.Column2.Name = "Column2";
      this.Column2.Width = 80;
      // 
      // Column5
      // 
      this.Column5.HeaderText = "Приспособленность родителей";
      this.Column5.Name = "Column5";
      this.Column5.Width = 120;
      // 
      // Column3
      // 
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
      this.Column3.HeaderText = "Пары потомков";
      this.Column3.Name = "Column3";
      this.Column3.Width = 60;
      // 
      // Column4
      // 
      this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
      this.Column4.HeaderText = "Потомки";
      this.Column4.Name = "Column4";
      this.Column4.Width = 77;
      // 
      // Column6
      // 
      this.Column6.HeaderText = "Приспособленность потомков";
      this.Column6.Name = "Column6";
      this.Column6.Width = 120;
      // 
      // Matrix
      // 
      this.Matrix.AllowUserToAddRows = false;
      this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Matrix.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.Matrix.Location = new System.Drawing.Point(165, 67);
      this.Matrix.Name = "Matrix";
      this.Matrix.Size = new System.Drawing.Size(387, 243);
      this.Matrix.TabIndex = 5;
      // 
      // CreateBurron
      // 
      this.CreateBurron.Location = new System.Drawing.Point(49, 109);
      this.CreateBurron.Name = "CreateBurron";
      this.CreateBurron.Size = new System.Drawing.Size(75, 23);
      this.CreateBurron.TabIndex = 6;
      this.CreateBurron.Text = "Создать";
      this.CreateBurron.UseVisualStyleBackColor = true;
      this.CreateBurron.Click += new System.EventHandler(this.button2_Click);
      // 
      // OpenButton
      // 
      this.OpenButton.Location = new System.Drawing.Point(49, 25);
      this.OpenButton.Name = "OpenButton";
      this.OpenButton.Size = new System.Drawing.Size(75, 23);
      this.OpenButton.TabIndex = 7;
      this.OpenButton.Text = "Открыть";
      this.OpenButton.UseVisualStyleBackColor = true;
      this.OpenButton.Click += new System.EventHandler(this.button3_Click);
      // 
      // SaveButton
      // 
      this.SaveButton.Location = new System.Drawing.Point(49, 149);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(75, 23);
      this.SaveButton.TabIndex = 8;
      this.SaveButton.Text = "Сохранить";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.button4_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(55, 67);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Число вершин ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 209);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(144, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Число особей в поколении";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(188, 51);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(111, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Матрица смежности";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 326);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(196, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Нужная последовательность вершин";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(1258, 429);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.SaveButton);
      this.Controls.Add(this.OpenButton);
      this.Controls.Add(this.CreateBurron);
      this.Controls.Add(this.Matrix);
      this.Controls.Add(this.Result);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.StartButton);
      this.Controls.Add(this.textBox1);
      this.Name = "Form1";
      this.Text = "Лб 4. Генетические алгоритмы";
      ((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView Result;
        private System.Windows.Forms.DataGridView Matrix;
        private System.Windows.Forms.Button CreateBurron;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

