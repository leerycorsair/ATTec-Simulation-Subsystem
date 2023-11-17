namespace VisualEditor
{
    partial class Images
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Images));
            this.heightImage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.widthImage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pathImage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nameImage = new System.Windows.Forms.TextBox();
            this.addImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heightImage
            // 
            this.heightImage.Location = new System.Drawing.Point(141, 97);
            this.heightImage.Name = "heightImage";
            this.heightImage.Size = new System.Drawing.Size(157, 20);
            this.heightImage.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Высота";
            // 
            // widthImage
            // 
            this.widthImage.Location = new System.Drawing.Point(141, 72);
            this.widthImage.Name = "widthImage";
            this.widthImage.Size = new System.Drawing.Size(157, 20);
            this.widthImage.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 146;
            this.label4.Text = "Ширина";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 144;
            this.label15.Text = "Имя изображения";
            // 
            // pathImage
            // 
            this.pathImage.Location = new System.Drawing.Point(141, 45);
            this.pathImage.Multiline = true;
            this.pathImage.Name = "pathImage";
            this.pathImage.Size = new System.Drawing.Size(157, 20);
            this.pathImage.TabIndex = 139;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 138;
            this.label12.Text = "Путь к изображению";
            // 
            // nameImage
            // 
            this.nameImage.Location = new System.Drawing.Point(141, 20);
            this.nameImage.Multiline = true;
            this.nameImage.Name = "nameImage";
            this.nameImage.Size = new System.Drawing.Size(157, 20);
            this.nameImage.TabIndex = 137;
            // 
            // addImage
            // 
            this.addImage.Location = new System.Drawing.Point(135, 128);
            this.addImage.Name = "addImage";
            this.addImage.Size = new System.Drawing.Size(86, 27);
            this.addImage.TabIndex = 149;
            this.addImage.Text = "OK";
            this.addImage.UseVisualStyleBackColor = true;
            this.addImage.Click += new System.EventHandler(this.addImage_Click);
            // 
            // Images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 170);
            this.Controls.Add(this.addImage);
            this.Controls.Add(this.heightImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pathImage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nameImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Images";
            this.Text = "Изображение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox widthImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox pathImage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nameImage;
        private System.Windows.Forms.Button addImage;
    }
}