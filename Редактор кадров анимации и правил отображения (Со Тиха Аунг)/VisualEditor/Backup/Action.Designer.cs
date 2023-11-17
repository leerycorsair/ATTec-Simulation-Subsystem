namespace VisualEditor
{
    partial class Action
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Action));
            this.sImage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.snameKadre = new System.Windows.Forms.ComboBox();
            this.xCoor = new System.Windows.Forms.TextBox();
            this.yCoor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yChangedValue = new System.Windows.Forms.TextBox();
            this.yChangedType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.yCorEnd = new System.Windows.Forms.TextBox();
            this.yCorStart = new System.Windows.Forms.TextBox();
            this.xChangedValue = new System.Windows.Forms.TextBox();
            this.xChangeType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dImage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.xCorEnd = new System.Windows.Forms.TextBox();
            this.dnameKadre = new System.Windows.Forms.ComboBox();
            this.xCorStart = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sImage
            // 
            this.sImage.FormattingEnabled = true;
            this.sImage.ItemHeight = 13;
            this.sImage.Location = new System.Drawing.Point(155, 60);
            this.sImage.Name = "sImage";
            this.sImage.Size = new System.Drawing.Size(148, 21);
            this.sImage.TabIndex = 0;
            this.sImage.SelectedIndexChanged += new System.EventHandler(this.sImage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбрать_изображение/коментарий";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя_кадра";
            // 
            // snameKadre
            // 
            this.snameKadre.FormattingEnabled = true;
            this.snameKadre.Location = new System.Drawing.Point(155, 26);
            this.snameKadre.Name = "snameKadre";
            this.snameKadre.Size = new System.Drawing.Size(148, 21);
            this.snameKadre.TabIndex = 5;
            this.snameKadre.SelectedIndexChanged += new System.EventHandler(this.snameKadre_SelectedIndexChanged);
            // 
            // xCoor
            // 
            this.xCoor.Location = new System.Drawing.Point(154, 88);
            this.xCoor.Multiline = true;
            this.xCoor.Name = "xCoor";
            this.xCoor.Size = new System.Drawing.Size(149, 24);
            this.xCoor.TabIndex = 7;
            // 
            // yCoor
            // 
            this.yCoor.Location = new System.Drawing.Point(154, 118);
            this.yCoor.Multiline = true;
            this.yCoor.Name = "yCoor";
            this.yCoor.Size = new System.Drawing.Size(149, 24);
            this.yCoor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "X-координат";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y-координат";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.yCoor);
            this.groupBox1.Controls.Add(this.snameKadre);
            this.groupBox1.Controls.Add(this.xCoor);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(367, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Статические";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yChangedValue);
            this.groupBox2.Controls.Add(this.yChangedType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.yCorEnd);
            this.groupBox2.Controls.Add(this.yCorStart);
            this.groupBox2.Controls.Add(this.xChangedValue);
            this.groupBox2.Controls.Add(this.xChangeType);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dImage);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.xCorEnd);
            this.groupBox2.Controls.Add(this.dnameKadre);
            this.groupBox2.Controls.Add(this.xCorStart);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 333);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Динамические";
            // 
            // yChangedValue
            // 
            this.yChangedValue.Location = new System.Drawing.Point(165, 294);
            this.yChangedValue.Multiline = true;
            this.yChangedValue.Name = "yChangedValue";
            this.yChangedValue.Size = new System.Drawing.Size(142, 24);
            this.yChangedValue.TabIndex = 23;
            // 
            // yChangedType
            // 
            this.yChangedType.FormattingEnabled = true;
            this.yChangedType.Items.AddRange(new object[] {
            "Increase",
            "Decrease",
            "Null"});
            this.yChangedType.Location = new System.Drawing.Point(166, 267);
            this.yChangedType.Name = "yChangedType";
            this.yChangedType.Size = new System.Drawing.Size(141, 21);
            this.yChangedType.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(17, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Значение_изменения_y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(15, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Тип_изменения";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(17, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 19;
            this.label13.Text = "Y-конец";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(17, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 15);
            this.label14.TabIndex = 18;
            this.label14.Text = "Y-начало";
            // 
            // yCorEnd
            // 
            this.yCorEnd.Location = new System.Drawing.Point(166, 237);
            this.yCorEnd.Multiline = true;
            this.yCorEnd.Name = "yCorEnd";
            this.yCorEnd.Size = new System.Drawing.Size(141, 24);
            this.yCorEnd.TabIndex = 17;
            // 
            // yCorStart
            // 
            this.yCorStart.Location = new System.Drawing.Point(166, 207);
            this.yCorStart.Multiline = true;
            this.yCorStart.Name = "yCorStart";
            this.yCorStart.Size = new System.Drawing.Size(141, 24);
            this.yCorStart.TabIndex = 16;
            // 
            // xChangedValue
            // 
            this.xChangedValue.Location = new System.Drawing.Point(165, 177);
            this.xChangedValue.Multiline = true;
            this.xChangedValue.Name = "xChangedValue";
            this.xChangedValue.Size = new System.Drawing.Size(141, 24);
            this.xChangedValue.TabIndex = 15;
            // 
            // xChangeType
            // 
            this.xChangeType.FormattingEnabled = true;
            this.xChangeType.Items.AddRange(new object[] {
            "Increase",
            "Decrease",
            "Null"});
            this.xChangeType.Location = new System.Drawing.Point(166, 150);
            this.xChangeType.Name = "xChangeType";
            this.xChangeType.Size = new System.Drawing.Size(141, 21);
            this.xChangeType.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(16, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Значение_изменения_x";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(14, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Тип_изменения";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(16, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "X-конец";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Имя_кадра";
            // 
            // dImage
            // 
            this.dImage.FormattingEnabled = true;
            this.dImage.ItemHeight = 13;
            this.dImage.Location = new System.Drawing.Point(165, 59);
            this.dImage.Name = "dImage";
            this.dImage.Size = new System.Drawing.Size(142, 21);
            this.dImage.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(16, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "X-начало";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(16, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 35);
            this.label8.TabIndex = 1;
            this.label8.Text = "Выбрать_изображение";
            // 
            // xCorEnd
            // 
            this.xCorEnd.Location = new System.Drawing.Point(166, 120);
            this.xCorEnd.Multiline = true;
            this.xCorEnd.Name = "xCorEnd";
            this.xCorEnd.Size = new System.Drawing.Size(141, 24);
            this.xCorEnd.TabIndex = 8;
            // 
            // dnameKadre
            // 
            this.dnameKadre.FormattingEnabled = true;
            this.dnameKadre.Location = new System.Drawing.Point(165, 26);
            this.dnameKadre.Name = "dnameKadre";
            this.dnameKadre.Size = new System.Drawing.Size(142, 21);
            this.dnameKadre.TabIndex = 5;
            this.dnameKadre.SelectedIndexChanged += new System.EventHandler(this.dnameKadre_SelectedIndexChanged);
            // 
            // xCorStart
            // 
            this.xCorStart.Location = new System.Drawing.Point(166, 90);
            this.xCorStart.Multiline = true;
            this.xCorStart.Name = "xCorStart";
            this.xCorStart.Size = new System.Drawing.Size(141, 24);
            this.xCorStart.TabIndex = 7;
            // 
            // Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Action";
            this.Text = "Действие";
            this.Load += new System.EventHandler(this.Action_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox sImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox snameKadre;
        private System.Windows.Forms.TextBox xCoor;
        private System.Windows.Forms.TextBox yCoor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox xCorEnd;
        private System.Windows.Forms.ComboBox dnameKadre;
        private System.Windows.Forms.TextBox xCorStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox yChangedValue;
        private System.Windows.Forms.ComboBox yChangedType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox yCorEnd;
        private System.Windows.Forms.TextBox yCorStart;
        private System.Windows.Forms.TextBox xChangedValue;
        private System.Windows.Forms.ComboBox xChangeType;
    }
}