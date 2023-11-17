namespace VisualEditor
{
    partial class ChoiceKadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceKadre));
            this.Choice = new System.Windows.Forms.Button();
            this.listKadre = new System.Windows.Forms.ComboBox();
            this.Выбрать = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Choice
            // 
            this.Choice.Location = new System.Drawing.Point(104, 63);
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(75, 23);
            this.Choice.TabIndex = 0;
            this.Choice.Text = "OK";
            this.Choice.UseVisualStyleBackColor = true;
            this.Choice.Click += new System.EventHandler(this.Choice_Click);
            // 
            // listKadre
            // 
            this.listKadre.FormattingEnabled = true;
            this.listKadre.Location = new System.Drawing.Point(114, 26);
            this.listKadre.Name = "listKadre";
            this.listKadre.Size = new System.Drawing.Size(141, 21);
            this.listKadre.TabIndex = 1;
            // 
            // Выбрать
            // 
            this.Выбрать.AutoSize = true;
            this.Выбрать.Location = new System.Drawing.Point(23, 29);
            this.Выбрать.Name = "Выбрать";
            this.Выбрать.Size = new System.Drawing.Size(78, 13);
            this.Выбрать.TabIndex = 2;
            this.Выбрать.Text = "Выбрать кадр";
            // 
            // ChoiceKadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 107);
            this.Controls.Add(this.Выбрать);
            this.Controls.Add(this.listKadre);
            this.Controls.Add(this.Choice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoiceKadre";
            this.Text = "Выбор кадра";
            this.Load += new System.EventHandler(this.ChoiceKadre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Choice;
        private System.Windows.Forms.ComboBox listKadre;
        private System.Windows.Forms.Label Выбрать;
    }
}