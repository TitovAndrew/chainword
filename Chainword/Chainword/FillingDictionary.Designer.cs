namespace Chainword
{
    partial class FillingDictionary
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddDefinition_textBox = new System.Windows.Forms.TextBox();
            this.AddWord_textBox = new System.Windows.Forms.TextBox();
            this.AddWord = new System.Windows.Forms.Button();
            this.AvailableWords = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.WordSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteWord_button = new System.Windows.Forms.Button();
            this.SaveExit_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddDefinition_textBox);
            this.groupBox1.Controls.Add(this.AddWord_textBox);
            this.groupBox1.Controls.Add(this.AddWord);
            this.groupBox1.Location = new System.Drawing.Point(590, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 133);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление слова";
            // 
            // AddDefinition_textBox
            // 
            this.AddDefinition_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDefinition_textBox.ForeColor = System.Drawing.Color.Gray;
            this.AddDefinition_textBox.Location = new System.Drawing.Point(7, 55);
            this.AddDefinition_textBox.Name = "AddDefinition_textBox";
            this.AddDefinition_textBox.Size = new System.Drawing.Size(186, 27);
            this.AddDefinition_textBox.TabIndex = 1;
            this.AddDefinition_textBox.Text = "Определение";
            this.AddDefinition_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddDefinition_textBox_MouseClick);
            this.AddDefinition_textBox.Leave += new System.EventHandler(this.AddDefinition_textBox_Leave);
            // 
            // AddWord_textBox
            // 
            this.AddWord_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWord_textBox.ForeColor = System.Drawing.Color.Gray;
            this.AddWord_textBox.Location = new System.Drawing.Point(7, 22);
            this.AddWord_textBox.Name = "AddWord_textBox";
            this.AddWord_textBox.Size = new System.Drawing.Size(186, 27);
            this.AddWord_textBox.TabIndex = 0;
            this.AddWord_textBox.Text = "Слово";
            this.AddWord_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddWord_textBox_MouseClick);
            this.AddWord_textBox.Leave += new System.EventHandler(this.AddWord_textBox_Leave);
            // 
            // AddWord
            // 
            this.AddWord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWord.Location = new System.Drawing.Point(7, 87);
            this.AddWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(186, 39);
            this.AddWord.TabIndex = 57;
            this.AddWord.Text = "Добавить слово";
            this.AddWord.UseVisualStyleBackColor = true;
            this.AddWord.Click += new System.EventHandler(this.AddWord_Click);
            // 
            // AvailableWords
            // 
            this.AvailableWords.FormattingEnabled = true;
            this.AvailableWords.HorizontalScrollbar = true;
            this.AvailableWords.ItemHeight = 16;
            this.AvailableWords.Location = new System.Drawing.Point(9, 82);
            this.AvailableWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvailableWords.Name = "AvailableWords";
            this.AvailableWords.Size = new System.Drawing.Size(575, 356);
            this.AvailableWords.TabIndex = 67;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "По алфавиту (от А до Я)",
            "По алфавиту (от Я до А)",
            "По возрастанию",
            "По убыванию"});
            this.comboBox1.Location = new System.Drawing.Point(161, 49);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 24);
            this.comboBox1.TabIndex = 64;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(126, 45);
            this.search_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(29, 28);
            this.search_button.TabIndex = 63;
            this.search_button.Text = "🔎";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // WordSearch
            // 
            this.WordSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordSearch.ForeColor = System.Drawing.Color.Gray;
            this.WordSearch.Location = new System.Drawing.Point(9, 45);
            this.WordSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.WordSearch.Name = "WordSearch";
            this.WordSearch.Size = new System.Drawing.Size(121, 28);
            this.WordSearch.TabIndex = 62;
            this.WordSearch.Text = "Поиск слова";
            this.WordSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WordSearch_MouseClick);
            this.WordSearch.Leave += new System.EventHandler(this.WordSearch_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(215, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 40);
            this.label2.TabIndex = 61;
            this.label2.Text = "Редактирование словаря";
            // 
            // DeleteWord_button
            // 
            this.DeleteWord_button.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteWord_button.Location = new System.Drawing.Point(597, 220);
            this.DeleteWord_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteWord_button.Name = "DeleteWord_button";
            this.DeleteWord_button.Size = new System.Drawing.Size(186, 39);
            this.DeleteWord_button.TabIndex = 66;
            this.DeleteWord_button.Text = "Удалить слово";
            this.DeleteWord_button.UseVisualStyleBackColor = true;
            // 
            // SaveExit_button
            // 
            this.SaveExit_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveExit_button.Location = new System.Drawing.Point(590, 399);
            this.SaveExit_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveExit_button.Name = "SaveExit_button";
            this.SaveExit_button.Size = new System.Drawing.Size(199, 39);
            this.SaveExit_button.TabIndex = 65;
            this.SaveExit_button.Text = "Сохранить и выйти";
            this.SaveExit_button.UseVisualStyleBackColor = true;
            // 
            // Save_button
            // 
            this.Save_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save_button.Location = new System.Drawing.Point(590, 356);
            this.Save_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(199, 39);
            this.Save_button.TabIndex = 69;
            this.Save_button.Text = "Сохранить";
            this.Save_button.UseVisualStyleBackColor = true;
            // 
            // FillingDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 444);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AvailableWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.WordSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteWord_button);
            this.Controls.Add(this.SaveExit_button);
            this.MaximizeBox = false;
            this.Name = "FillingDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FillingDictionary";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AddDefinition_textBox;
        private System.Windows.Forms.TextBox AddWord_textBox;
        private System.Windows.Forms.Button AddWord;
        private System.Windows.Forms.ListBox AvailableWords;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox WordSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DeleteWord_button;
        private System.Windows.Forms.Button SaveExit_button;
        private System.Windows.Forms.Button Save_button;
    }
}