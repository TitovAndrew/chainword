namespace Chainword
{
    partial class FillingCross
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
            this.label2 = new System.Windows.Forms.Label();
            this.WordSearch = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AvailableWords = new System.Windows.Forms.ListBox();
            this.AddedWords = new System.Windows.Forms.ListBox();
            this.CreateCross_button = new System.Windows.Forms.Button();
            this.AddWord = new System.Windows.Forms.Button();
            this.DeleteLastWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(241, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 40);
            this.label2.TabIndex = 47;
            this.label2.Text = "Создание кроссворда";
            // 
            // WordSearch
            // 
            this.WordSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.WordSearch.Location = new System.Drawing.Point(12, 52);
            this.WordSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.WordSearch.Name = "WordSearch";
            this.WordSearch.Size = new System.Drawing.Size(121, 28);
            this.WordSearch.TabIndex = 48;
            this.WordSearch.Text = "Поиск слова";
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(133, 50);
            this.search_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(29, 30);
            this.search_button.TabIndex = 49;
            this.search_button.Text = "🔎";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "По алфавиту (от А до Я)",
            "По алфавиту (от Я до А)",
            "По возрастанию",
            "По убыванию"});
            this.comboBox1.Location = new System.Drawing.Point(169, 57);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 24);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AvailableWords
            // 
            this.AvailableWords.FormattingEnabled = true;
            this.AvailableWords.HorizontalScrollbar = true;
            this.AvailableWords.ItemHeight = 16;
            this.AvailableWords.Location = new System.Drawing.Point(12, 86);
            this.AvailableWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvailableWords.Name = "AvailableWords";
            this.AvailableWords.Size = new System.Drawing.Size(577, 356);
            this.AvailableWords.TabIndex = 51;
            // 
            // AddedWords
            // 
            this.AddedWords.Enabled = false;
            this.AddedWords.FormattingEnabled = true;
            this.AddedWords.HorizontalScrollbar = true;
            this.AddedWords.ItemHeight = 16;
            this.AddedWords.Location = new System.Drawing.Point(596, 87);
            this.AddedWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddedWords.Name = "AddedWords";
            this.AddedWords.Size = new System.Drawing.Size(192, 356);
            this.AddedWords.TabIndex = 52;
            // 
            // CreateCross_button
            // 
            this.CreateCross_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateCross_button.Location = new System.Drawing.Point(596, 448);
            this.CreateCross_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateCross_button.Name = "CreateCross_button";
            this.CreateCross_button.Size = new System.Drawing.Size(192, 39);
            this.CreateCross_button.TabIndex = 53;
            this.CreateCross_button.Text = "Создать";
            this.CreateCross_button.UseVisualStyleBackColor = true;
            // 
            // AddWord
            // 
            this.AddWord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWord.Location = new System.Drawing.Point(421, 448);
            this.AddWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(168, 39);
            this.AddWord.TabIndex = 54;
            this.AddWord.Text = "Добавить слово";
            this.AddWord.UseVisualStyleBackColor = true;
            this.AddWord.Click += new System.EventHandler(this.AddWord_Click);
            // 
            // DeleteLastWord
            // 
            this.DeleteLastWord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteLastWord.Location = new System.Drawing.Point(232, 447);
            this.DeleteLastWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteLastWord.Name = "DeleteLastWord";
            this.DeleteLastWord.Size = new System.Drawing.Size(184, 39);
            this.DeleteLastWord.TabIndex = 55;
            this.DeleteLastWord.Text = "Удалить последнее слово";
            this.DeleteLastWord.UseVisualStyleBackColor = true;
            this.DeleteLastWord.Click += new System.EventHandler(this.DeleteLastWord_Click);
            // 
            // FillingCross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.DeleteLastWord);
            this.Controls.Add(this.AddWord);
            this.Controls.Add(this.CreateCross_button);
            this.Controls.Add(this.AddedWords);
            this.Controls.Add(this.AvailableWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.WordSearch);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FillingCross";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание кроссворда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WordSearch;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox AvailableWords;
        private System.Windows.Forms.ListBox AddedWords;
        private System.Windows.Forms.Button CreateCross_button;
        private System.Windows.Forms.Button AddWord;
        private System.Windows.Forms.Button DeleteLastWord;
    }
}