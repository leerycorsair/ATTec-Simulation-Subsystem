namespace VisualEditor
{
    partial class Parameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parameters));
            this.nameParameter = new System.Windows.Forms.ComboBox();
            this.widthParameter = new System.Windows.Forms.TextBox();
            this.heightParameter = new System.Windows.Forms.TextBox();
            this.xCorParamter = new System.Windows.Forms.TextBox();
            this.yCorParamerter = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameResource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.backTextColor = new System.Windows.Forms.ComboBox();
            this.foreTextColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameParameter
            // 
            this.nameParameter.FormattingEnabled = true;
            this.nameParameter.Location = new System.Drawing.Point(135, 53);
            this.nameParameter.Name = "nameParameter";
            this.nameParameter.Size = new System.Drawing.Size(127, 21);
            this.nameParameter.TabIndex = 0;
            // 
            // widthParameter
            // 
            this.widthParameter.Location = new System.Drawing.Point(135, 147);
            this.widthParameter.Name = "widthParameter";
            this.widthParameter.Size = new System.Drawing.Size(127, 20);
            this.widthParameter.TabIndex = 1;
            // 
            // heightParameter
            // 
            this.heightParameter.Location = new System.Drawing.Point(135, 173);
            this.heightParameter.Name = "heightParameter";
            this.heightParameter.Size = new System.Drawing.Size(127, 20);
            this.heightParameter.TabIndex = 2;
            // 
            // xCorParamter
            // 
            this.xCorParamter.Location = new System.Drawing.Point(135, 199);
            this.xCorParamter.Name = "xCorParamter";
            this.xCorParamter.Size = new System.Drawing.Size(127, 20);
            this.xCorParamter.TabIndex = 3;
            // 
            // yCorParamerter
            // 
            this.yCorParamerter.Location = new System.Drawing.Point(135, 225);
            this.yCorParamerter.Name = "yCorParamerter";
            this.yCorParamerter.Size = new System.Drawing.Size(127, 20);
            this.yCorParamerter.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 147);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 156;
            this.label18.Text = "Ширина";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 173);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 157;
            this.label19.Text = "Высота";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 199);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 13);
            this.label23.TabIndex = 154;
            this.label23.Text = "X-координат";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 225);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 13);
            this.label24.TabIndex = 155;
            this.label24.Text = "Y-координат";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 158;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "Имя параметра";
            // 
            // nameResource
            // 
            this.nameResource.FormattingEnabled = true;
            this.nameResource.Location = new System.Drawing.Point(135, 26);
            this.nameResource.Name = "nameResource";
            this.nameResource.Size = new System.Drawing.Size(127, 21);
            this.nameResource.TabIndex = 160;
            this.nameResource.SelectedIndexChanged += new System.EventHandler(this.nameResource_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Имя ресурса";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 162;
            this.label6.Text = "Цвет фона";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 163;
            this.label17.Text = "Цвет шрифта";
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
            this.backTextColor.Location = new System.Drawing.Point(135, 85);
            this.backTextColor.Name = "backTextColor";
            this.backTextColor.Size = new System.Drawing.Size(127, 21);
            this.backTextColor.TabIndex = 164;
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
            this.foreTextColor.Location = new System.Drawing.Point(135, 115);
            this.foreTextColor.Name = "foreTextColor";
            this.foreTextColor.Size = new System.Drawing.Size(127, 21);
            this.foreTextColor.TabIndex = 165;
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 304);
            this.Controls.Add(this.foreTextColor);
            this.Controls.Add(this.backTextColor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameResource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.yCorParamerter);
            this.Controls.Add(this.xCorParamter);
            this.Controls.Add(this.heightParameter);
            this.Controls.Add(this.widthParameter);
            this.Controls.Add(this.nameParameter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parameters";
            this.Text = "Параметр ресурса";
            this.Load += new System.EventHandler(this.Parameters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nameParameter;
        private System.Windows.Forms.TextBox widthParameter;
        private System.Windows.Forms.TextBox heightParameter;
        private System.Windows.Forms.TextBox xCorParamter;
        private System.Windows.Forms.TextBox yCorParamerter;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nameResource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox backTextColor;
        private System.Windows.Forms.ComboBox foreTextColor;
    }
}