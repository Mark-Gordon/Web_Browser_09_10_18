using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Web_Browser
{
    public partial class Browser : Form
    {



        public Browser()
        {
            InitializeComponent();
            initNewTab(null);
            populateHistory();
            populateFavourites();
        }

        public void changeTabName(string name)
        {
            if (name.Length > 10)
                name = name.Substring(0, 10) + "...";
            tabControl.SelectedTab.Text = name;

        }

        //create a new tab which loads the homepage if url == null
        private void initNewTab(string url)
        {
            TabPage tab = new TabPage();
            Web page = new Web(this);

            //subscribes to Event in Web Class - allows for the method(s) the Web class calls - on Event - from this class to change
            //without having to recompile the Web class
            page.FaveEvent += OnFaveEvent;
            page.LoadHTML += OnLoadHTMLEvent;

            //adds the page to the tab
            tab.Controls.Add(page);
            //adds the tab to the browser
            tabControl.Controls.Add(tab);

            //if no url provided then load homepage
            if (url == null)
                url = Homepage.getHomepageURL();

            tab.Text = url;


            page.loadHTML(url);

        }


        public void OnLoadHTMLEvent(object source, EventArgs args)
        {
            populateHistory(); 
        }

        public void OnFaveEvent(object source, EventArgs args)
        {
            populateFavourites();
        }


        public void populateFavourites()
        {
            favesMenu.DropDownItems.Clear();

            // reads lines from fave file
            string[] faveText = Favourites.getFaves();
   

            int index = 0;
            //loops from last index as we want to display the last entered favourite first
            for (int i= faveText.Length-1; i >= 0; i--)
            {
                //a space character indicates the beginning of the user assigned name and the end of the url (seeing a url can't contain spaces)
                string[] result = faveText[i].Split(' ');

                favesMenu.DropDownItems.Add(result[1]);
                //On tab strip item click, init tab with the url value assigned to that item
                ToolStripItem newFaveItem = favesMenu.DropDownItems[index];
                newFaveItem.Click += (a, e) => {
                    initNewTab(result[0]);
                };
                index++;
                //keeps favourites drop down list to a count of 10
                if (index > 9)
                    return;
            }
        }

        public void populateHistory()
        {
            historyMenu.DropDownItems.Clear();
            // Open the file to read from.
            string[] historyText = History.getHistory();


            int index = 0;
            for (int i = historyText.Length - 1; i >= 0; i--)
            {
                historyMenu.DropDownItems.Add(historyText[i]);
                //On tab strip item click, init tab with the url value assigned to that item
                ToolStripItem it = historyMenu.DropDownItems[index];
                it.Click += (a, e) => {
                    initNewTab(it.Text);
                };
                index++;
                //keeps history drop down list to a count of 10
                if (index > 9)
                    return;
            }
        }

        private void newTabMenu_Click(object sender, EventArgs e)
        {
            initNewTab(null);
        }

        private void clearHistoryMenu_Click(object sender, EventArgs e)
        {
            historyMenu.DropDownItems.Clear();
            History.clearHistory();
        }

        private void removeTabMenu_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Remove(tabControl.SelectedTab);
        }

        private void editFaveMenu_Click(object sender, EventArgs e)
        {
            ModifyFaves fave = new ModifyFaves(this);
            fave.Show();
        }

        private void clearFavouritesMenu_Click(object sender, EventArgs e)
        {
            favesMenu.DropDownItems.Clear();
            Favourites.clearFavouritesFile();
        }

        private void allHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHistory histView = new ViewHistory(this);

            histView.Show();
        }

    }
}
