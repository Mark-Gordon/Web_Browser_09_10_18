using System;
using System.Windows.Forms;
using System.Xml;

namespace Web_Browser
{
    public partial class Browser : Form
    {

        public Browser()
        {
            InitializeComponent();
            Homepage.checkExists();
            populateHistory();
            populateFavourites();
            initNewTab(null);
        }

        public void changeTabName(string name, TabPage tab)
        {
            if (name.Length > 10)
                name = name.Substring(0, 10) + "...";

            tab.Text = name;

        }

        public void changeTab(int index)
        {
            tabControl.SelectedIndex = index;

        }



        //create a new tab which loads the homepage if url == null
        public void initNewTab(string url)
        {
            TabPage tab = new TabPage();
            Web page = new Web(this, tab);

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
            //ensures favourites file exists
            Favourites.checkExists();

            favesMenu.DropDownItems.Clear();

            //get favourites from file
            XmlNodeList favouriteNodes = Favourites.getFaves();
   

            int index = 0;
            for (int i= favouriteNodes.Count-1; i >= 0; i--)
            {
                string url = favouriteNodes[i].InnerText;

                Console.WriteLine(i);
                favesMenu.DropDownItems.Add(favouriteNodes[i].Attributes["name"].Value);
                //On tab strip item click, init tab with the url value assigned to that item
                ToolStripItem newFaveItem = favesMenu.DropDownItems[index];
                Console.WriteLine(favouriteNodes[0].InnerText + " -----");
                newFaveItem.Click += (a, e) => {
                    initNewTab(url);
                };
                index++;
                //keeps favourites drop down list to a count of 10
                if (index > 9)
                    return;
            }
        }

        public void populateHistory()
        {
            //ensures history file exists
            History.checkExists();

            historyMenu.DropDownItems.Clear();
            //get history from file
            XmlNodeList historyNodes = History.getHistory();


            int index = 0;
            for (int i = historyNodes.Count - 1; i >= 0; i--)
            {
                historyMenu.DropDownItems.Add(historyNodes[i].InnerText);
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
            History.clearHistoryFile();
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

        public int getTabCount()
        {
            return tabControl.TabCount;
        }

    }
}
