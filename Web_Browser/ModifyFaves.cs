using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        private void displayFaves()
        {
            XmlNodeList favouriteNodes = Favourites.getFaves();

            for (int i = favouriteNodes.Count - 1; i >= 0; i--)
            {
                favesDisplay.Items.Add(favouriteNodes[i].Attributes["name"].Value + " " + favouriteNodes[i].InnerText);
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Potential for improvement, currently deletes by rewriting over entire favourite file
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            XmlNodeList favouriteNodes = Favourites.getFaves();

            try
            {
                favouriteNodes[0].ParentNode.RemoveChild(favouriteNodes[(favouriteNodes.Count - 1) - favesDisplay.SelectedIndex]);
            }catch(Exception noFaveToDelete)
            {
                return;
            }

            Favourites.saveFavouritesFile();
            //Favourites.setFavouritesFile(favouriteNodes);

            favesDisplay.Items.RemoveAt(favesDisplay.SelectedIndex);

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
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
