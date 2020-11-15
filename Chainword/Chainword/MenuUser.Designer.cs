namespace Chainword
{
    partial class MenuUser
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
            this.StartedCross_ListBox = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.NewCross_ListBox = new System.Windows.Forms.ListBox();
            this.Open_Button = new System.Windows.Forms.Button();
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
            this.tabControl1.Size = new System.Drawing.Size(638, 350);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.StartedCross_ListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(630, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Начатые";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // StartedCross_ListBox
            // 
            this.StartedCross_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartedCross_ListBox.FormattingEnabled = true;
            this.StartedCross_ListBox.ItemHeight = 26;
            this.StartedCross_ListBox.Location = new System.Drawing.Point(3, 4);
            this.StartedCross_ListBox.Margin = new System.Windows.Forms.Padding(2);
            this.StartedCross_ListBox.Name = "StartedCross_ListBox";
            this.StartedCross_ListBox.Size = new System.Drawing.Size(623, 316);
            this.StartedCross_ListBox.TabIndex = 25;
            this.StartedCross_ListBox.SelectedIndexChanged += new System.EventHandler(this.StartedCross_ListBox_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NewCross_ListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(630, 324);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Новые";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // NewCross_ListBox
            // 
            this.NewCross_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewCross_ListBox.FormattingEnabled = true;
            this.NewCross_ListBox.ItemHeight = 26;
            this.NewCross_ListBox.Location = new System.Drawing.Point(3, 4);
            this.NewCross_ListBox.Margin = new System.Windows.Forms.Padding(2);
            this.NewCross_ListBox.Name = "NewCross_ListBox";
            this.NewCross_ListBox.Size = new System.Drawing.Size(623, 316);
            this.NewCross_ListBox.TabIndex = 26;
            this.NewCross_ListBox.SelectedIndexChanged += new System.EventHandler(this.NewCross_ListBox_SelectedIndexChanged);
            // 
            // Open_Button
            // 
            this.Open_Button.Location = new System.Drawing.Point(528, 357);
            this.Open_Button.Name = "Open_Button";
            this.Open_Button.Size = new System.Drawing.Size(110, 30);
            this.Open_Button.TabIndex = 26;
            this.Open_Button.Text = "Открыть";
            this.Open_Button.UseVisualStyleBackColor = true;
            this.Open_Button.Click += new System.EventHandler(this.Open_Button_Click);
            // 
            // MenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 391);
            this.Controls.Add(this.Open_Button);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MenuUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню пользователя";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox StartedCross_ListBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Open_Button;
        private System.Windows.Forms.ListBox NewCross_ListBox;
    }
}