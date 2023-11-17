namespace VisualEditor
{
    partial class Messages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messages));
            this.forecolorMessage = new System.Windows.Forms.ComboBox();
            this.bgcolorMessage = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.heightMessage = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.widthMessage = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.discriptionMessage = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nameMessage = new System.Windows.Forms.TextBox();
            this.addMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // forecolorMessage
            // 
            this.forecolorMessage.FormattingEnabled = true;
            this.forecolorMessage.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Grey"});
            this.forecolorMessage.Location = new System.Drawing.Point(120, 113);
            this.forecolorMessage.Name = "forecolorMessage";
            this.forecolorMessage.Size = new System.Drawing.Size(139, 21);
            this.forecolorMessage.TabIndex = 156;
            // 
            // bgcolorMessage
            // 
            this.bgcolorMessage.FormattingEnabled = true;
            this.bgcolorMessage.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "White",
            "Grey"});
            this.bgcolorMessage.Location = new System.Drawing.Point(120, 85);
            this.bgcolorMessage.Name = "bgcolorMessage";
            this.bgcolorMessage.Size = new System.Drawing.Size(139, 21);
            this.bgcolorMessage.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 154;
            this.label6.Text = "Цвет фона";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 155;
            this.label17.Text = "Цвет шрифта";
            // 
            // heightMessage
            // 
            this.heightMessage.Location = new System.Drawing.Point(121, 171);
            this.heightMessage.Name = "heightMessage";
            this.heightMessage.Size = new System.Drawing.Size(138, 20);
            this.heightMessage.TabIndex = 152;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 151;
            this.label18.Text = "Ширина";
            // 
            // widthMessage
            // 
            this.widthMessage.Location = new System.Drawing.Point(121, 142);
            this.widthMessage.Name = "widthMessage";
            this.widthMessage.Size = new System.Drawing.Size(138, 20);
            this.widthMessage.TabIndex = 150;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 175);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 153;
            this.label19.Text = "Высота";
            // 
            // discriptionMessage
            // 
            this.discriptionMessage.Location = new System.Drawing.Point(120, 46);
            this.discriptionMessage.Multiline = true;
            this.discriptionMessage.Name = "discriptionMessage";
            this.discriptionMessage.Size = new System.Drawing.Size(139, 32);
            this.discriptionMessage.TabIndex = 149;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 147;
            this.label21.Text = "Имя сообщения";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 148;
            this.label22.Text = "Описание";
            // 
            // nameMessage
            // 
            this.nameMessage.Location = new System.Drawing.Point(120, 21);
            this.nameMessage.Multiline = true;
            this.nameMessage.Name = "nameMessage";
            this.nameMessage.Size = new System.Drawing.Size(139, 20);
            this.nameMessage.TabIndex = 142;
            // 
            // addMessage
            // 
            this.addMessage.Location = new System.Drawing.Point(115, 207);
            this.addMessage.Name = "addMessage";
            this.addMessage.Size = new System.Drawing.Size(65, 23);
            this.addMessage.TabIndex = 159;
            this.addMessage.Text = "OK";
            this.addMessage.UseVisualStyleBackColor = true;
            this.addMessage.Click += new System.EventHandler(this.addMessage_Click);
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 246);
            this.Controls.Add(this.addMessage);
            this.Controls.Add(this.forecolorMessage);
            this.Controls.Add(this.bgcolorMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.heightMessage);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.widthMessage);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.discriptionMessage);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.nameMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Messages";
            this.Text = "Сообщение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox forecolorMessage;
        private System.Windows.Forms.ComboBox bgcolorMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox heightMessage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox widthMessage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox discriptionMessage;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox nameMessage;
        private System.Windows.Forms.Button addMessage;
    }
}