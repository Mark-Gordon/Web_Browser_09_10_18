using System;
using System.Windows.Forms;
using System.Xml;

namespace Web_Browser
{
    public partial class ModifyFaves : Form
    {
        private Browser browse = null;

        public ModifyFaves(Browser browse)
        {
            InitializeComponent();
            displayFaves();
            this.browse = browse;

        }

        //populates listbox with favourites from file
        private void displayFaves()
        {
            XmlNodeList favouriteNodes = Favourites.getFaves();

            for (int i = favouriteNodes.Count - 1; i >= 0; i--)
            {   //poor use of '\t\t\t', requires proper formatting
                favesDisplay.Items.Add(favouriteNodes[i].Attributes["name"].Value + "\t\t\t" + favouriteNodes[i].InnerText);
            }

        }

        //Will load the page of the selected URL from list in a new tab, closing this View
        private void loadPage_Click(object sender, EventArgs e)
        {
            XmlNodeList favouriteNodes = Favourites.getFaves();

            try
            {
                browse.initNewTab(favouriteNodes[(favouriteNodes.Count - 1) - favesDisplay.SelectedIndex].InnerText);
                browse.changeTab(browse.getTabCount() - 1);
                Close();
            }
            catch (Exception noFaveToLoad)
            {
                MessageBox.Show("Please select a favourite from the list to load.");
                return;
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        //selected favourite from listbox will be deleted from file
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            XmlNodeList favouriteNodes = Favourites.getFaves();

            try
            {   //get specific favourite as identicated by selected index
                favouriteNodes[0].ParentNode.RemoveChild(favouriteNodes[(favouriteNodes.Count - 1) - favesDisplay.SelectedIndex]);
            }catch(Exception noFaveToDelete)
            {
                return;
            }

            Favourites.saveFavouritesFile();

            favesDisplay.Items.RemoveAt(favesDisplay.SelectedIndex);

            //potentially delegate??? Seemed pointless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateFavourites();

        }

        //used to update the name associated with the current favourited url
        private void modifyBtn_Click(object sender, EventArgs e)
        {


            XmlNodeList favouriteNodes = Favourites.getFaves();

            //get specific favourite as identicated by selected index
            XmlNode faveNode = favouriteNodes[(favouriteNodes.Count - 1) - favesDisplay.SelectedIndex];


            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a new name for the address " + faveNode.InnerText, "New name", faveNode.Attributes["name"].Value, -1, -1);

            if (input.Length < 1) { return; }


            faveNode.Attributes["name"].Value = input;

            Favourites.saveFavouritesFile();

            favesDisplay.Items[favesDisplay.SelectedIndex] = faveNode.Attributes["name"].Value + " " + faveNode.InnerText + " ";

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateFavourites();

        }

        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            Favourites.clearFavouritesFile();
            Favourites.saveFavouritesFile();
            browse.populateFavourites();
            favesDisplay.Items.Clear();
        }
    }
}
