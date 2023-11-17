namespace VisualEditor
{
    partial class FreeText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeText));
            this.foreTextColor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.yCorText = new System.Windows.Forms.TextBox();
            this.xCorText = new System.Windows.Forms.TextBox();
            this.heightText = new System.Windows.Forms.TextBox();
            this.widthText = new System.Windows.Forms.TextBox();
            this.desText = new System.Windows.Forms.TextBox();
            this.backTextColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // foreTextColor
            // 
            this.foreTextColor.FormattingEnabled = true;
            this.foreTextColor.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Grey"});
            this.foreTextColor.Location = new System.Drawing.Point(113, 93);
            this.foreTextColor.Name = "foreTextColor";
            this.foreTextColor.Size = new System.Drawing.Size(150, 21);
            this.foreTextColor.TabIndex = 182;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 179;
            this.label6.Text = "Цвет фона";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 180;
            this.label17.Text = "Цвет шрифта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 178;
            this.label2.Text = "Описание текста";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 175;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 173;
            this.label18.Text = "Ширина";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 174;
            this.label19.Text = "Высота";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 175);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 171;
            this.label23.Text = "X-координат";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 201);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 172;
            this.label24.Text = "Y-координат";
            // 
            // yCorText
            // 
            this.yCorText.Location = new System.Drawing.Point(113, 201);
            this.yCorText.Name = "yCorText";
            this.yCorText.Size = new System.Drawing.Size(150, 20);
            this.yCorText.TabIndex = 170;
            // 
            // xCorText
            // 
            this.xCorText.Location = new System.Drawing.Point(113, 175);
            this.xCorText.Name = "xCorText";
            this.xCorText.Size = new System.Drawing.Size(150, 20);
            this.xCorText.TabIndex = 169;
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(113, 149);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(150, 20);
            this.heightText.TabIndex = 168;
            // 
            // widthText
            // 
            this.widthText.Location = new System.Drawing.Point(113, 123);
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(150, 20);
            this.widthText.TabIndex = 167;
            // 
            // desText
            // 
            this.desText.Location = new System.Drawing.Point(113, 19);
            this.desText.Multiline = true;
            this.desText.Name = "desText";
            this.desText.Size = new System.Drawing.Size(150, 41);
            this.desText.TabIndex = 183;
            // 
            // backTextColor
            // 
            this.backTextColor.FormattingEnabled = true;
            this.backTextColor.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Grey"});
            this.backTextColor.Location = new System.Drawing.Point(113, 66);
            this.backTextColor.Name = "backTextColor";
            this.backTextColor.Size = new System.Drawing.Size(150, 21);
            this.backTextColor.TabIndex = 184;
            // 
            // FreeText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 272);
            this.Controls.Add(this.backTextColor);
            this.Controls.Add(this.desText);
            this.Controls.Add(this.foreTextColor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.yCorText);
            this.Controls.Add(this.xCorText);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.widthText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FreeText";
            this.Text = "Свободный текст";
            this.Load += new System.EventHandler(this.FreeText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox foreTextColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox yCorText;
        private System.Windows.Forms.TextBox xCorText;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.TextBox widthText;
        private System.Windows.Forms.TextBox desText;
        private System.Windows.Forms.ComboBox backTextColor;
    }
}