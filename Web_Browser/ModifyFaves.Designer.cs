namespace Web_Browser
{
    partial class ModifyFaves
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
            this.favesDisplay = new System.Windows.Forms.ListBox();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favesDisplay
            // 
            this.favesDisplay.FormattingEnabled = true;
            this.favesDisplay.Location = new System.Drawing.Point(91, 22);
            this.favesDisplay.Name = "favesDisplay";
            this.favesDisplay.Size = new System.Drawing.Size(397, 225);
            this.favesDisplay.TabIndex = 0;
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(10, 34);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyBtn.TabIndex = 1;
            this.modifyBtn.Text = "Modify Name";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(10, 81);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(10, 224);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // ModifyFaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 285);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.favesDisplay);
            this.Name = "ModifyFaves";
            this.Text = "ModifyFaves";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox favesDisplay;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button modifyBtn;
    }
}