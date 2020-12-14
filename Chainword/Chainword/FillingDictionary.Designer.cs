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
            this.Save_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddDefinition_textBox = new System.Windows.Forms.TextBox();
            this.AddWord_textBox = new System.Windows.Forms.TextBox();
            this.AddConcept_button = new System.Windows.Forms.Button();
            this.AvailableWords = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.WordSearch = new System.Windows.Forms.TextBox();
            this.DeleteConcept_button = new System.Windows.Forms.Button();
            this.SaveExit_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save_button
            // 
            this.Save_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save_button.Location = new System.Drawing.Point(442, 267);
            this.Save_button.Margin = new System.Windows.Forms.Padding(2);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(149, 32);
            this.Save_button.TabIndex = 85;
            this.Save_button.Text = "Сохранить";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddDefinition_textBox);
            this.groupBox1.Controls.Add(this.AddWord_textBox);
            this.groupBox1.Controls.Add(this.AddConcept_button);
            this.groupBox1.Location = new System.Drawing.Point(442, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(149, 108);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление слова";
            // 
            // AddDefinition_textBox
            // 
            this.AddDefinition_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddDefinition_textBox.ForeColor = System.Drawing.Color.Gray;
            this.AddDefinition_textBox.Location = new System.Drawing.Point(5, 45);
            this.AddDefinition_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddDefinition_textBox.Name = "AddDefinition_textBox";
            this.AddDefinition_textBox.Size = new System.Drawing.Size(140, 23);
            this.AddDefinition_textBox.TabIndex = 1;
            this.AddDefinition_textBox.Text = "Определение";
            this.AddDefinition_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddDefinition_textBox_MouseClick);
            this.AddDefinition_textBox.TextChanged += new System.EventHandler(this.AddDefinition_textBox_TextChanged);
            this.AddDefinition_textBox.MouseLeave += new System.EventHandler(this.AddDefinition_textBox_Leave);
            // 
            // AddWord_textBox
            // 
            this.AddWord_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddWord_textBox.ForeColor = System.Drawing.Color.Gray;
            this.AddWord_textBox.Location = new System.Drawing.Point(5, 18);
            this.AddWord_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddWord_textBox.Name = "AddWord_textBox";
            this.AddWord_textBox.Size = new System.Drawing.Size(140, 23);
            this.AddWord_textBox.TabIndex = 0;
            this.AddWord_textBox.Text = "Слово";
            this.AddWord_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddWord_textBox_MouseClick);
            this.AddWord_textBox.TextChanged += new System.EventHandler(this.AddWord_textBox_TextChanged);
            this.AddWord_textBox.MouseLeave += new System.EventHandler(this.AddWord_textBox_Leave);
            // 
            // AddConcept_button
            // 
            this.AddConcept_button.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddConcept_button.Location = new System.Drawing.Point(5, 71);
            this.AddConcept_button.Margin = new System.Windows.Forms.Padding(2);
            this.AddConcept_button.Name = "AddConcept_button";
            this.AddConcept_button.Size = new System.Drawing.Size(140, 32);
            this.AddConcept_button.TabIndex = 57;
            this.AddConcept_button.Text = "Добавить слово";
            this.AddConcept_button.UseVisualStyleBackColor = true;
            this.AddConcept_button.Click += new System.EventHandler(this.AddConcept_button_Click);
            // 
            // AvailableWords
            // 
            this.AvailableWords.FormattingEnabled = true;
            this.AvailableWords.HorizontalScrollbar = true;
            this.AvailableWords.Location = new System.Drawing.Point(7, 45);
            this.AvailableWords.Margin = new System.Windows.Forms.Padding(2);
            this.AvailableWords.Name = "AvailableWords";
            this.AvailableWords.Size = new System.Drawing.Size(432, 290);
            this.AvailableWords.TabIndex = 83;
            this.AvailableWords.SelectedIndexChanged += new System.EventHandler(this.AvailableWords_SelectedIndexChanged);
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
            this.comboBox1.Location = new System.Drawing.Point(136, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 80;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(98, 14);
            this.search_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(26, 26);
            this.search_button.TabIndex = 79;
            this.search_button.Text = "🔎";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click_1);
            // 
            // WordSearch
            // 
            this.WordSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordSearch.ForeColor = System.Drawing.Color.Gray;
            this.WordSearch.Location = new System.Drawing.Point(7, 15);
            this.WordSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.WordSearch.Name = "WordSearch";
            this.WordSearch.Size = new System.Drawing.Size(92, 24);
            this.WordSearch.TabIndex = 78;
            this.WordSearch.Text = "Поиск слова";
            this.WordSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WordSearch_MouseClick);
            this.WordSearch.TextChanged += new System.EventHandler(this.WordSearch_TextChanged);
            this.WordSearch.Leave += new System.EventHandler(this.WordSearch_Leave);
            // 
            // DeleteConcept_button
            // 
            this.DeleteConcept_button.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteConcept_button.Location = new System.Drawing.Point(448, 157);
            this.DeleteConcept_button.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteConcept_button.Name = "DeleteConcept_button";
            this.DeleteConcept_button.Size = new System.Drawing.Size(140, 32);
            this.DeleteConcept_button.TabIndex = 82;
            this.DeleteConcept_button.Text = "Удалить слово";
            this.DeleteConcept_button.UseVisualStyleBackColor = true;
            this.DeleteConcept_button.Click += new System.EventHandler(this.DeleteConcept_button_Click);
            // 
            // SaveExit_button
            // 
            this.SaveExit_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveExit_button.Location = new System.Drawing.Point(442, 303);
            this.SaveExit_button.Margin = new System.Windows.Forms.Padding(2);
            this.SaveExit_button.Name = "SaveExit_button";
            this.SaveExit_button.Size = new System.Drawing.Size(149, 32);
            this.SaveExit_button.TabIndex = 81;
            this.SaveExit_button.Text = "Сохранить и выйти";
            this.SaveExit_button.UseVisualStyleBackColor = true;
            this.SaveExit_button.Click += new System.EventHandler(this.SaveExit_button_Click);
            // 
            // FillingDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 348);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AvailableWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.WordSearch);
            this.Controls.Add(this.DeleteConcept_button);
            this.Controls.Add(this.SaveExit_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FillingDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование словаря";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AddDefinition_textBox;
        private System.Windows.Forms.TextBox AddWord_textBox;
        private System.Windows.Forms.Button AddConcept_button;
        private System.Windows.Forms.ListBox AvailableWords;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox WordSearch;
        private System.Windows.Forms.Button DeleteConcept_button;
        private System.Windows.Forms.Button SaveExit_button;
    }
}