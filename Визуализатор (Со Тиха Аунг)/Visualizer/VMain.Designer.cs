namespace Visualizer
{
    partial class VMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VMain));
            this.showKadre = new System.Windows.Forms.Button();
            this.nameKadre = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pauseAnnimation = new System.Windows.Forms.Button();
            this.showChart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scanInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stopAnnimation = new System.Windows.Forms.Button();
            this.WorkSpace = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // showKadre
            // 
            this.showKadre.Location = new System.Drawing.Point(26, 170);
            this.showKadre.Name = "showKadre";
            this.showKadre.Size = new System.Drawing.Size(144, 31);
            this.showKadre.TabIndex = 0;
            this.showKadre.Text = "Запуск";
            this.showKadre.UseVisualStyleBackColor = true;
            this.showKadre.Click += new System.EventHandler(this.showKadre_Click);
            // 
            // nameKadre
            // 
            this.nameKadre.FormattingEnabled = true;
            this.nameKadre.Location = new System.Drawing.Point(26, 88);
            this.nameKadre.Name = "nameKadre";
            this.nameKadre.Size = new System.Drawing.Size(144, 21);
            this.nameKadre.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pauseAnnimation
            // 
            this.pauseAnnimation.Location = new System.Drawing.Point(26, 207);
            this.pauseAnnimation.Name = "pauseAnnimation";
            this.pauseAnnimation.Size = new System.Drawing.Size(144, 28);
            this.pauseAnnimation.TabIndex = 2;
            this.pauseAnnimation.Text = "Пауза";
            this.pauseAnnimation.UseVisualStyleBackColor = true;
            this.pauseAnnimation.Click += new System.EventHandler(this.pauseAnnimation_Click);
            // 
            // showChart
            // 
            this.showChart.Location = new System.Drawing.Point(26, 277);
            this.showChart.Name = "showChart";
            this.showChart.Size = new System.Drawing.Size(144, 31);
            this.showChart.TabIndex = 3;
            this.showChart.Text = "Графики";
            this.showChart.UseVisualStyleBackColor = true;
            this.showChart.Click += new System.EventHandler(this.showChart_Click);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(569, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 43);
            this.label2.TabIndex = 46;
            this.label2.Text = "(АТ-ТЕХНОЛОГИЯ)";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(437, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 43);
            this.label1.TabIndex = 45;
            this.label1.Text = "ВИЗУАЛИЗАТОР";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Выбрать кадр:";
            // 
            // scanInterval
            // 
            this.scanInterval.Location = new System.Drawing.Point(26, 140);
            this.scanInterval.Multiline = true;
            this.scanInterval.Name = "scanInterval";
            this.scanInterval.Size = new System.Drawing.Size(144, 24);
            this.scanInterval.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 49;
            this.label4.Text = "Интервал сканирования:";
            // 
            // stopAnnimation
            // 
            this.stopAnnimation.Location = new System.Drawing.Point(26, 241);
            this.stopAnnimation.Name = "stopAnnimation";
            this.stopAnnimation.Size = new System.Drawing.Size(144, 30);
            this.stopAnnimation.TabIndex = 51;
            this.stopAnnimation.Text = "Стоп";
            this.stopAnnimation.UseVisualStyleBackColor = true;
            this.stopAnnimation.Click += new System.EventHandler(this.stopAnnimation_Click);
            // 
            // WorkSpace
            // 
            this.WorkSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WorkSpace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WorkSpace.Location = new System.Drawing.Point(193, 88);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.Size = new System.Drawing.Size(800, 600);
            this.WorkSpace.TabIndex = 52;
            // 
            // VMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1181, 692);
            this.Controls.Add(this.WorkSpace);
            this.Controls.Add(this.stopAnnimation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scanInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showChart);
            this.Controls.Add(this.pauseAnnimation);
            this.Controls.Add(this.nameKadre);
            this.Controls.Add(this.showKadre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VMain";
            this.Text = "Главное окно";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button showKadre;
        private System.Windows.Forms.ComboBox nameKadre;
        private System.Windows.Forms.Button pauseAnnimation;
        private System.Windows.Forms.Button showChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scanInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopAnnimation;
        private System.Windows.Forms.Panel WorkSpace;
    }
}

