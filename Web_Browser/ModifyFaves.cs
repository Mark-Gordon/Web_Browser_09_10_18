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
            // read lines from fave file
            string[] faveList = Favourites.getFaves();

            for(int i= faveList.Length-1; i >=0; i--)
            {
                favesDisplay.Items.Add(faveList[i]);
            }
  
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Potential for improvement, currently deletes by rewriting over entire favourite file
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            List<string> readText = Favourites.getFaves().ToList();

            try
            {
                readText.RemoveAt((readText.Count - 1) - favesDisplay.SelectedIndex);
            }catch(Exception noFaveToDelete)
            {
                return;
            }

            Favourites.clearFavouritesFile();
            Favourites.setFavouritesFile(readText);

            favesDisplay.Items.RemoveAt(favesDisplay.SelectedIndex);

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateFavourites();

        }

        //used to update the name associated with the current favourited url
        private void modifyBtn_Click(object sender, EventArgs e)
        {

            List<string> readText = Favourites.getFaves().ToList();

            //a space character indicates the beginning of the user assigned name and the end of the url (seeing a url can't contain spaces)
            string[] result=null;
            try
            {
                result = readText[(readText.Count - 1) - favesDisplay.SelectedIndex].Split(' ');
            }
            catch (Exception noFaveToModify)
            {
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a new name for the address " + result[0], "New name", result[1], -1, -1);

            if(input.Length < 1) { return; }

            string newLine = result[0] + " " + input;

            readText[(readText.Count -1) - favesDisplay.SelectedIndex] = newLine;

            Favourites.setFavouritesFile(readText);

            favesDisplay.Items[favesDisplay.SelectedIndex] = newLine;

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateFavourites();

        }
    }
}
