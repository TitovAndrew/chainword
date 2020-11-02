namespace Chainword
{
    partial class Info
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
            this.label1 = new System.Windows.Forms.Label();
            this.InfoSystem_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 160);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сведения о разработчиках\r\n\r\nНад проектом работали студенты группы 6415:\r\nТитов Ан" +
    "дрей Дмитриевич\r\nРыбакин Данила Иванович\r\nШевелев Александр Витальевич\r\n\r\nСамарс" +
    "кий университет, 02.11.2020\r\n";
            // 
            // InfoSystem_button
            // 
            this.InfoSystem_button.Location = new System.Drawing.Point(127, 172);
            this.InfoSystem_button.Name = "InfoSystem_button";
            this.InfoSystem_button.Size = new System.Drawing.Size(125, 23);
            this.InfoSystem_button.TabIndex = 1;
            this.InfoSystem_button.Text = "Сведения о системе";
            this.InfoSystem_button.UseVisualStyleBackColor = true;
            this.InfoSystem_button.Click += new System.EventHandler(this.InfoSystem_button_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 201);
            this.Controls.Add(this.InfoSystem_button);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InfoSystem_button;
    }
}