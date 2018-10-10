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
    public partial class ViewHistory : Form
    {

        Browser browse = null;
        public ViewHistory(Browser browse)
        {
            InitializeComponent();
            this.browse = browse;
            displayHistory();
        }

        private void displayHistory()
        {

            XmlNodeList historyNodes = History.getHistory();

            for (int i = historyNodes.Count-1; i >= 0; i--)
            {
                historyDisplay.Items.Add(historyNodes[i].InnerText);
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            XmlNodeList historyNodes = History.getHistory();

            try
            {
                historyNodes[0].ParentNode.RemoveChild(historyNodes[(historyNodes.Count - 1) - historyDisplay.SelectedIndex]);
            }
            catch (Exception noHistoryToDelete)
            {
                return;
            }

            History.saveHistoryFile();
            //Favourites.setFavouritesFile(favouriteNodes);

            historyDisplay.Items.RemoveAt(historyDisplay.SelectedIndex);

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateFavourites();
        }

        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            History.clearHistoryFile();
            History.saveHistoryFile();
            browse.populateHistory();
            historyDisplay.Items.Clear();
        }
    }
}
