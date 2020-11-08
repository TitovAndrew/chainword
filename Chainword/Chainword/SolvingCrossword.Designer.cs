namespace Chainword
{
    partial class SolvingCrossword
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
            this.QWERTY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QWERTY
            // 
            this.QWERTY.Location = new System.Drawing.Point(337, 194);
            this.QWERTY.Name = "QWERTY";
            this.QWERTY.Size = new System.Drawing.Size(100, 20);
            this.QWERTY.TabIndex = 0;
            this.QWERTY.TextChanged += new System.EventHandler(this.QWERTY_TextChanged);
            // 
            // SolvingCrossword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 286);
            this.Controls.Add(this.QWERTY);
            this.Name = "SolvingCrossword";
            this.Text = "SolvingCrossword";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SolvingCrossword_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QWERTY;
    }
}