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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Createcross_button = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Dictionary_listBox = new System.Windows.Forms.ListBox();
            this.Download_button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(9, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 450);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Createcross_button);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(842, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кроссворды";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Createcross_button
            // 
            this.Createcross_button.Location = new System.Drawing.Point(7, 6);
            this.Createcross_button.Margin = new System.Windows.Forms.Padding(4);
            this.Createcross_button.Name = "Createcross_button";
            this.Createcross_button.Size = new System.Drawing.Size(100, 28);
            this.Createcross_button.TabIndex = 26;
            this.Createcross_button.Text = "Создать";
            this.Createcross_button.UseVisualStyleBackColor = true;
            this.Createcross_button.Click += new System.EventHandler(this.Createcross_button_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Dictionary_listBox);
            this.tabPage1.Controls.Add(this.Download_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(842, 421);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Словари";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Dictionary_listBox
            // 
            this.Dictionary_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Dictionary_listBox.FormattingEnabled = true;
            this.Dictionary_listBox.HorizontalScrollbar = true;
            this.Dictionary_listBox.ItemHeight = 25;
            this.Dictionary_listBox.Items.AddRange(new object[] {
            "dfdfgfgfdg",
            "ssdfsdfsdf"});
            this.Dictionary_listBox.Location = new System.Drawing.Point(0, 42);
            this.Dictionary_listBox.Margin = new System.Windows.Forms.Padding(4);
            this.Dictionary_listBox.Name = "Dictionary_listBox";
            this.Dictionary_listBox.Size = new System.Drawing.Size(838, 379);
            this.Dictionary_listBox.TabIndex = 28;
            // 
            // Download_button
            // 
            this.Download_button.Location = new System.Drawing.Point(7, 6);
            this.Download_button.Margin = new System.Windows.Forms.Padding(4);
            this.Download_button.Name = "Download_button";
            this.Download_button.Size = new System.Drawing.Size(100, 28);
            this.Download_button.TabIndex = 27;
            this.Download_button.Text = "Добавить";
            this.Download_button.UseVisualStyleBackColor = true;
            this.Download_button.Click += new System.EventHandler(this.Download_button_Click);
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 466);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Createcross_button;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox Dictionary_listBox;
        private System.Windows.Forms.Button Download_button;
    }
}