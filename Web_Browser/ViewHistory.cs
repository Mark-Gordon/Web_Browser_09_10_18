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
            // read lines from fave file
            string[] historyArray = History.getHistory();
            for(int i = historyArray.Length-1; i >= 0; i--)
            {
                historyDisplay.Items.Add(historyArray[i]);
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            List<string> readText = History.getHistory().ToList();

            try
            {
                readText.RemoveAt((readText.Count - 1) - historyDisplay.SelectedIndex);
            }catch(Exception noHistoryToDelete)
            {
                return;
            }

            History.clearHistory();
            History.updateHistoryFile(readText);

            historyDisplay.Items.RemoveAt(historyDisplay.SelectedIndex);

            //potentially delegate??? Seemed useless at time as I couldn't imagine ever adding more functionality to this event
            browse.populateHistory();
        }

        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            History.clearHistory();
            browse.populateHistory();
            historyDisplay.Items.Clear();
        }
    }
}
