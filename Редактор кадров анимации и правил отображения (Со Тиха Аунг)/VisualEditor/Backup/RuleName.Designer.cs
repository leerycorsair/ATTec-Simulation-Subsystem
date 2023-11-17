namespace VisualEditor
{
    partial class RuleName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleName));
            this.addRule = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addRule
            // 
            this.addRule.Location = new System.Drawing.Point(120, 65);
            this.addRule.Name = "addRule";
            this.addRule.Size = new System.Drawing.Size(66, 23);
            this.addRule.TabIndex = 0;
            this.addRule.Text = "OK";
            this.addRule.UseVisualStyleBackColor = true;
            this.addRule.Click += new System.EventHandler(this.addRule_Click);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(103, 30);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(149, 20);
            this.nameText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя правила";
            // 
            // RuleName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 105);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.addRule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuleName";
            this.Text = "Имя правила";
            this.Load += new System.EventHandler(this.RuleName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addRule;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label label1;
    }
}