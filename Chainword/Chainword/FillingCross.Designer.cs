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
            this.DeleteLastWord = new System.Windows.Forms.Button();
            this.AddWord = new System.Windows.Forms.Button();
            this.CreateCross_button = new System.Windows.Forms.Button();
            this.AddedWords = new System.Windows.Forms.ListBox();
            this.AvailableWords = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.WordSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteLastWord
            // 
            this.DeleteLastWord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteLastWord.Location = new System.Drawing.Point(174, 333);
            this.DeleteLastWord.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteLastWord.Name = "DeleteLastWord";
            this.DeleteLastWord.Size = new System.Drawing.Size(138, 32);
            this.DeleteLastWord.TabIndex = 63;
            this.DeleteLastWord.Text = "Удалить последнее слово";
            this.DeleteLastWord.UseVisualStyleBackColor = true;
            this.DeleteLastWord.Click += new System.EventHandler(this.DeleteLastWord_Click);
            // 
            // AddWord
            // 
            this.AddWord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWord.Location = new System.Drawing.Point(316, 333);
            this.AddWord.Margin = new System.Windows.Forms.Padding(2);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(126, 32);
            this.AddWord.TabIndex = 62;
            this.AddWord.Text = "Добавить слово";
            this.AddWord.UseVisualStyleBackColor = true;
            this.AddWord.Click += new System.EventHandler(this.AddWord_Click);
            // 
            // CreateCross_button
            // 
            this.CreateCross_button.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateCross_button.Location = new System.Drawing.Point(446, 333);
            this.CreateCross_button.Margin = new System.Windows.Forms.Padding(2);
            this.CreateCross_button.Name = "CreateCross_button";
            this.CreateCross_button.Size = new System.Drawing.Size(146, 32);
            this.CreateCross_button.TabIndex = 61;
            this.CreateCross_button.Text = "Сохранить и выйти";
            this.CreateCross_button.UseVisualStyleBackColor = true;
            this.CreateCross_button.Click += new System.EventHandler(this.CreateCross_button_Click);
            // 
            // AddedWords
            // 
            this.AddedWords.Enabled = false;
            this.AddedWords.FormattingEnabled = true;
            this.AddedWords.HorizontalScrollbar = true;
            this.AddedWords.Location = new System.Drawing.Point(447, 40);
            this.AddedWords.Margin = new System.Windows.Forms.Padding(2);
            this.AddedWords.Name = "AddedWords";
            this.AddedWords.Size = new System.Drawing.Size(145, 290);
            this.AddedWords.TabIndex = 60;
            // 
            // AvailableWords
            // 
            this.AvailableWords.FormattingEnabled = true;
            this.AvailableWords.HorizontalScrollbar = true;
            this.AvailableWords.Location = new System.Drawing.Point(9, 39);
            this.AvailableWords.Margin = new System.Windows.Forms.Padding(2);
            this.AvailableWords.Name = "AvailableWords";
            this.AvailableWords.Size = new System.Drawing.Size(434, 290);
            this.AvailableWords.TabIndex = 59;
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleDescription = "";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "По алфавиту (от А до Я)",
            "По алфавиту (от Я до А)",
            "По возрастанию",
            "По убыванию"});
            this.comboBox1.Location = new System.Drawing.Point(200, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 58;
            this.comboBox1.Tag = "";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(98, 11);
            this.search_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(22, 23);
            this.search_button.TabIndex = 57;
            this.search_button.Text = "🔎";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // WordSearch
            // 
            this.WordSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordSearch.ForeColor = System.Drawing.Color.Gray;
            this.WordSearch.Location = new System.Drawing.Point(9, 11);
            this.WordSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.WordSearch.Name = "WordSearch";
            this.WordSearch.Size = new System.Drawing.Size(92, 24);
            this.WordSearch.TabIndex = 56;
            this.WordSearch.Text = "Поиск слова";
            this.WordSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WordSearch_MouseClick);
            this.WordSearch.TextChanged += new System.EventHandler(this.WordSearch_TextChanged);
            this.WordSearch.Leave += new System.EventHandler(this.WordSearch_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Сортировка:";
            // 
            // FillingCross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteLastWord);
            this.Controls.Add(this.AddWord);
            this.Controls.Add(this.CreateCross_button);
            this.Controls.Add(this.AddedWords);
            this.Controls.Add(this.AvailableWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.WordSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FillingCross";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование кроссворда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteLastWord;
        private System.Windows.Forms.Button AddWord;
        private System.Windows.Forms.Button CreateCross_button;
        private System.Windows.Forms.ListBox AddedWords;
        private System.Windows.Forms.ListBox AvailableWords;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox WordSearch;
        private System.Windows.Forms.Label label1;
    }
}