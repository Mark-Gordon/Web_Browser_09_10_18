namespace Web_Browser
{
    partial class Web
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Web));
            this.backBtn = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.htmlTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.faveBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.goHomeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backBtn.Enabled = false;
            this.backBtn.Location = new System.Drawing.Point(96, 17);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(283, 20);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(423, 20);
            this.addressTextBox.TabIndex = 2;
            this.addressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.address_KeyDown);
            // 
            // htmlTextBox
            // 
            this.htmlTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.htmlTextBox.Location = new System.Drawing.Point(0, 76);
            this.htmlTextBox.Multiline = true;
            this.htmlTextBox.Name = "htmlTextBox";
            this.htmlTextBox.ReadOnly = true;
            this.htmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlTextBox.Size = new System.Drawing.Size(845, 479);
            this.htmlTextBox.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Enabled = false;
            this.forwardBtn.Location = new System.Drawing.Point(188, 17);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(75, 23);
            this.forwardBtn.TabIndex = 5;
            this.forwardBtn.Text = "Forward";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            // 
            // faveBtn
            // 
            this.faveBtn.Location = new System.Drawing.Point(746, 17);
            this.faveBtn.Name = "faveBtn";
            this.faveBtn.Size = new System.Drawing.Size(75, 23);
            this.faveBtn.TabIndex = 6;
            this.faveBtn.Text = "Favourite";
            this.faveBtn.UseVisualStyleBackColor = true;
            this.faveBtn.Click += new System.EventHandler(this.faveBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeBtn.BackgroundImage")));
            this.homeBtn.Location = new System.Drawing.Point(746, 47);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(75, 23);
            this.homeBtn.TabIndex = 7;
            this.homeBtn.Text = "Set Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // goHomeBtn
            // 
            this.goHomeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("goHomeBtn.BackgroundImage")));
            this.goHomeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goHomeBtn.Location = new System.Drawing.Point(12, 18);
            this.goHomeBtn.Name = "goHomeBtn";
            this.goHomeBtn.Size = new System.Drawing.Size(33, 23);
            this.goHomeBtn.TabIndex = 8;
            this.goHomeBtn.UseVisualStyleBackColor = true;
            this.goHomeBtn.Click += new System.EventHandler(this.goHomeBtn_Click);
            // 
            // Web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goHomeBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.faveBtn);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.htmlTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.backBtn);
            this.Name = "Web";
            this.Size = new System.Drawing.Size(845, 555);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox htmlTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button faveBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button goHomeBtn;
    }
}
