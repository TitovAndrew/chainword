namespace Chainword
{
    partial class MenuAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CrossWord_listBox = new System.Windows.Forms.ListBox();
            this.Createcross_button = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Dictionary_listBox = new System.Windows.Forms.ListBox();
            this.Create_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 366);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CrossWord_listBox);
            this.tabPage2.Controls.Add(this.Createcross_button);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(630, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кроссворды";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CrossWord_listBox
            // 
            this.CrossWord_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CrossWord_listBox.FormattingEnabled = true;
            this.CrossWord_listBox.ItemHeight = 20;
            this.CrossWord_listBox.Location = new System.Drawing.Point(0, 34);
            this.CrossWord_listBox.Name = "CrossWord_listBox";
            this.CrossWord_listBox.Size = new System.Drawing.Size(630, 304);
            this.CrossWord_listBox.TabIndex = 27;
            this.CrossWord_listBox.SelectedIndexChanged += new System.EventHandler(this.CrossWord_listBox_SelectedIndexChanged);
            // 
            // Createcross_button
            // 
            this.Createcross_button.Location = new System.Drawing.Point(5, 5);
            this.Createcross_button.Name = "Createcross_button";
            this.Createcross_button.Size = new System.Drawing.Size(75, 23);
            this.Createcross_button.TabIndex = 26;
            this.Createcross_button.Text = "Создать";
            this.Createcross_button.UseVisualStyleBackColor = true;
            this.Createcross_button.Click += new System.EventHandler(this.Createcross_button_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Dictionary_listBox);
            this.tabPage1.Controls.Add(this.Create_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(630, 340);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Словари";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Dictionary_listBox
            // 
            this.Dictionary_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Dictionary_listBox.FormattingEnabled = true;
            this.Dictionary_listBox.HorizontalScrollbar = true;
            this.Dictionary_listBox.ItemHeight = 20;
            this.Dictionary_listBox.Location = new System.Drawing.Point(0, 34);
            this.Dictionary_listBox.Name = "Dictionary_listBox";
            this.Dictionary_listBox.Size = new System.Drawing.Size(630, 304);
            this.Dictionary_listBox.TabIndex = 28;
            this.Dictionary_listBox.SelectedIndexChanged += new System.EventHandler(this.Dictionary_listBox_SelectedIndexChanged);
            // 
            // Create_button
            // 
            this.Create_button.Location = new System.Drawing.Point(5, 5);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(75, 23);
            this.Create_button.TabIndex = 27;
            this.Create_button.Text = "Создать";
            this.Create_button.UseVisualStyleBackColor = true;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click_1);
            // 
            // Edit_button
            // 
            this.Edit_button.Location = new System.Drawing.Point(412, 373);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(110, 30);
            this.Edit_button.TabIndex = 30;
            this.Edit_button.Text = "Редактировать";
            this.Edit_button.UseVisualStyleBackColor = true;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(528, 373);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(110, 30);
            this.Delete_button.TabIndex = 31;
            this.Delete_button.Text = "Удалить";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 407);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Edit_button);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню администратора";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Createcross_button;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox Dictionary_listBox;
        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.ListBox CrossWord_listBox;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.Button Delete_button;
    }
}