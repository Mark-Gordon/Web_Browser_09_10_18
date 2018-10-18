using System;
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

        //populates listbox with history from file
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

        //selected favourite from listbox will be deleted from file
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            XmlNodeList historyNodes = History.getHistory();

            try
            {   //get specific history url as identicated by selected index
                historyNodes[0].ParentNode.RemoveChild(historyNodes[(historyNodes.Count - 1) - historyDisplay.SelectedIndex]);
            }
            catch (Exception noHistoryToDelete)
            {
                return;
            }

            History.saveHistoryFile();

            historyDisplay.Items.RemoveAt(historyDisplay.SelectedIndex);

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateHistory();
        }

        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            History.clearHistoryFile();
            History.saveHistoryFile();
            browse.populateHistory();
            historyDisplay.Items.Clear();
        }

        //Will load the page of the selected URL from list in a new tab, closing this View
        private void LoadPage_Click(object sender, EventArgs e)
        {
            XmlNodeList historyNodes = History.getHistory();

            try
            {
                browse.initNewTab(historyNodes[(historyNodes.Count - 1) - historyDisplay.SelectedIndex].InnerText);
                browse.changeTab(browse.getTabCount()-1);
                Close();
            }
            catch (Exception noHistoryToLoad)
            {
                MessageBox.Show("Please select one of the histories from the list to load.");
                return;
            }
        }
    }
}
