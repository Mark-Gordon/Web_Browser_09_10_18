namespace Web_Browser
{
    partial class Browser
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFavouritesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editFaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.allHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.favesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.historyMenu,
            this.favesMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.clearFavouritesMenu,
            this.clearHistoryMenu,
            this.editFaveMenu,
            this.allHistoryToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "FIle";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTabToolStripMenuItem.Text = "New tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.newTabMenu_Click);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearHistoryToolStripMenuItem.Text = "Close Tab";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.removeTabMenu_Click);
            // 
            // clearFavouritesMenu
            // 
            this.clearFavouritesMenu.Name = "clearFavouritesMenu";
            this.clearFavouritesMenu.Size = new System.Drawing.Size(180, 22);
            this.clearFavouritesMenu.Text = "Clear Favourites";
            this.clearFavouritesMenu.Click += new System.EventHandler(this.clearFavouritesMenu_Click);
            // 
            // clearHistoryMenu
            // 
            this.clearHistoryMenu.Name = "clearHistoryMenu";
            this.clearHistoryMenu.Size = new System.Drawing.Size(180, 22);
            this.clearHistoryMenu.Text = "Clear History";
            this.clearHistoryMenu.Click += new System.EventHandler(this.clearHistoryMenu_Click);
            // 
            // editFaveMenu
            // 
            this.editFaveMenu.Name = "editFaveMenu";
            this.editFaveMenu.Size = new System.Drawing.Size(180, 22);
            this.editFaveMenu.Text = "All Favourites";
            this.editFaveMenu.Click += new System.EventHandler(this.editFaveMenu_Click);
            // 
            // allHistoryToolStripMenuItem
            // 
            this.allHistoryToolStripMenuItem.Name = "allHistoryToolStripMenuItem";
            this.allHistoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allHistoryToolStripMenuItem.Text = "All History";
            this.allHistoryToolStripMenuItem.Click += new System.EventHandler(this.allHistoryToolStripMenuItem_Click);
            // 
            // historyMenu
            // 
            this.historyMenu.Name = "historyMenu";
            this.historyMenu.Size = new System.Drawing.Size(57, 20);
            this.historyMenu.Text = "History";
            // 
            // favesMenu
            // 
            this.favesMenu.Name = "favesMenu";
            this.favesMenu.Size = new System.Drawing.Size(73, 20);
            this.favesMenu.Text = "Favourites";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(869, 607);
            this.tabControl.TabIndex = 1;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 631);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.Text = "Web Browser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFavouritesMenu;
        private System.Windows.Forms.ToolStripMenuItem historyMenu;
        private System.Windows.Forms.ToolStripMenuItem favesMenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryMenu;
        private System.Windows.Forms.ToolStripMenuItem editFaveMenu;
        private System.Windows.Forms.ToolStripMenuItem allHistoryToolStripMenuItem;
    }
}

