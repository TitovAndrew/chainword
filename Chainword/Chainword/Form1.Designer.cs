namespace Chainword
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.register_button = new System.Windows.Forms.Button();
            this.info_button = new System.Windows.Forms.Button();
            this.entry_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register_button
            // 
            this.register_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.register_button.Location = new System.Drawing.Point(142, 206);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(168, 40);
            this.register_button.TabIndex = 55;
            this.register_button.Text = "Регистрация";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // info_button
            // 
            this.info_button.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_button.Location = new System.Drawing.Point(316, 157);
            this.info_button.Name = "info_button";
            this.info_button.Size = new System.Drawing.Size(40, 40);
            this.info_button.TabIndex = 54;
            this.info_button.Text = "i";
            this.info_button.UseVisualStyleBackColor = true;
            // 
            // entry_button
            // 
            this.entry_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.entry_button.Location = new System.Drawing.Point(142, 157);
            this.entry_button.Name = "entry_button";
            this.entry_button.Size = new System.Drawing.Size(168, 40);
            this.entry_button.TabIndex = 53;
            this.entry_button.Text = "Войти";
            this.entry_button.UseVisualStyleBackColor = true;
            this.entry_button.Click += new System.EventHandler(this.entry_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 29);
            this.label2.TabIndex = 51;
            this.label2.Text = "Логин:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(133, 117);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(300, 30);
            this.password.TabIndex = 50;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(133, 60);
            this.login.Multiline = true;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(300, 30);
            this.login.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(175, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 49);
            this.label1.TabIndex = 48;
            this.label1.Text = "Вход";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 254);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.info_button);
            this.Controls.Add(this.entry_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Button info_button;
        private System.Windows.Forms.Button entry_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label1;
    }
}

