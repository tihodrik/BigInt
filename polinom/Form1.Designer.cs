namespace polinom
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.K = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.R = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Mod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(12, 328);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(315, 23);
            this.button.TabIndex = 1;
            this.button.Text = "Рассчитать";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // K
            // 
            this.K.Location = new System.Drawing.Point(12, 50);
            this.K.Multiline = true;
            this.K.Name = "K";
            this.K.Size = new System.Drawing.Size(171, 272);
            this.K.TabIndex = 2;
            this.K.Text = "11024711\r\n20128731\r\n20200000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите коэффициенты";
            // 
            // R
            // 
            this.R.Location = new System.Drawing.Point(12, 412);
            this.R.Name = "R";
            this.R.ReadOnly = true;
            this.R.Size = new System.Drawing.Size(315, 20);
            this.R.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Результат";
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(201, 50);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(115, 20);
            this.B.TabIndex = 6;
            this.B.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Введите точку";
            // 
            // Mod
            // 
            this.Mod.Location = new System.Drawing.Point(201, 119);
            this.Mod.Name = "Mod";
            this.Mod.Size = new System.Drawing.Size(114, 20);
            this.Mod.TabIndex = 8;
            this.Mod.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Введите кольцо";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Mod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.R);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.K);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox K;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox R;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Mod;
        private System.Windows.Forms.Label label4;
    }
}

