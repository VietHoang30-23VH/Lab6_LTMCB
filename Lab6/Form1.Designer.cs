namespace Lab6
{
    partial class Form1
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
            this.Bai1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lab6 :Data Protection with C#";
            // 
            // Bai1
            // 
            this.Bai1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bai1.Location = new System.Drawing.Point(93, 88);
            this.Bai1.Name = "Bai1";
            this.Bai1.Size = new System.Drawing.Size(597, 62);
            this.Bai1.TabIndex = 1;
            this.Bai1.Text = "Bài 1: Viết chương trình cho phép mã hóa và giải mã dữ liệu theo phương pháp mã h" +
    "óa Ceasar\r\n";
            this.Bai1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bai1.UseVisualStyleBackColor = true;
            this.Bai1.Click += new System.EventHandler(this.Bai1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(93, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(597, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "Bài 2: Viết chương trình cho phép mã hóa và giải mã dữ liệu theo phương pháp mã h" +
    "óa Vigenère";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(93, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(597, 62);
            this.button3.TabIndex = 3;
            this.button3.Text = "Bài 3: Chương trình mã hóa - giải mã Client-Server\r\n";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 323);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Bai1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bai1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

