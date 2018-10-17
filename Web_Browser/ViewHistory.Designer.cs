namespace Web_Browser
{
    partial class ViewHistory
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
            this.historyDisplay = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.deleteAllBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.LoadPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyDisplay
            // 
            this.historyDisplay.FormattingEnabled = true;
            this.historyDisplay.Location = new System.Drawing.Point(91, 22);
            this.historyDisplay.Name = "historyDisplay";
            this.historyDisplay.Size = new System.Drawing.Size(397, 225);
            this.historyDisplay.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(12, 116);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(73, 23);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // deleteAllBtn
            // 
            this.deleteAllBtn.Location = new System.Drawing.Point(12, 145);
            this.deleteAllBtn.Name = "deleteAllBtn";
            this.deleteAllBtn.Size = new System.Drawing.Size(73, 23);
            this.deleteAllBtn.TabIndex = 2;
            this.deleteAllBtn.Text = "Delete All";
            this.deleteAllBtn.UseVisualStyleBackColor = true;
            this.deleteAllBtn.Click += new System.EventHandler(this.deleteAllBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 250);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(73, 23);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // LoadPage
            // 
            this.LoadPage.Location = new System.Drawing.Point(12, 34);
            this.LoadPage.Name = "LoadPage";
            this.LoadPage.Size = new System.Drawing.Size(73, 23);
            this.LoadPage.TabIndex = 4;
            this.LoadPage.Text = "Load Page";
            this.LoadPage.UseVisualStyleBackColor = true;
            this.LoadPage.Click += new System.EventHandler(this.LoadPage_Click);
            // 
            // ViewHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 285);
            this.Controls.Add(this.LoadPage);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.deleteAllBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.historyDisplay);
            this.Name = "ViewHistory";
            this.Text = "Modify History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox historyDisplay;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button deleteAllBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button LoadPage;
    }
}