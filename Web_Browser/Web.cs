using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Web_Browser
{

    public partial class Web : UserControl
    {

        private BackgroundWorker worker = new BackgroundWorker();
        private string workerURL = null;

        private Browser browse = null;


        public Web(Browser browse)
        {
            InitializeComponent();
            this.browse = browse;
            
        }


        private void goBtn_Click(object sender, EventArgs e)
        {
            loadHTML(addressTextBox.Text);
        }

        public delegate void LoadHTMLEventhandler(object source, EventArgs args);
        public event LoadHTMLEventhandler LoadHTML;

        //loads new page given an url
        public void loadHTML(string url)
        {

            History.addURL(url);
            toggleButtons();

            //If backgroundworker is busy, the latest url submitted will be remembered
            //so that it can carry out the load once the backgroundworker is finished its
            //current work
            if (backgroundWorker1.IsBusy)
            {
                workerURL = url;
            }
            else
            {
                browse.changeTabName(url);
                addressTextBox.Text = url;
                //start process on worker thread
                backgroundWorker1.RunWorkerAsync(url);

            }
        }

        //called when backgroundworker is completed and will call relevant methods from other classes such as updating history
        protected virtual void OnLoadHTML()
        {
            if (LoadHTML != null)
            {
                LoadHTML(this, EventArgs.Empty);
            }
        }

        private void toggleButtons()
        {
            forwardBtn.Enabled = History.canGoToNext();
            backBtn.Enabled = History.canGoToPrevious();

        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loadHTML(addressTextBox.Text);

        }


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Stores the raw html returned from the html request
            e.Result = WebManager.getHTML((string)e.Argument);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
  
            htmlTextBox.Text = ((string)e.Result);
            
            //If NOT null, then another request was made during running so loadHTML will be recalled
            //with the latest url request
            if (workerURL != null)
            {
                loadHTML((string)workerURL);
                workerURL = null;
            }
            OnLoadHTML();

        }

        private void goHomeBtn_Click(object sender, EventArgs e)
        {
            loadHTML(Homepage.getHomepageURL());
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loadHTML(History.goToPrevious());
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            loadHTML(History.goToNext());
        }

        public delegate void FaveEventhandler(object source, EventArgs args);
        public event FaveEventhandler FaveEvent;

        private void faveBtn_Click(object sender, EventArgs e)
        {
            string prompt = "Please enter the name you would like to assign to the web address " + addressTextBox.Text;
            string faveName = Microsoft.VisualBasic.Interaction.InputBox(prompt, "Favourite", "Enter Name", -1, -1);


            Favourites.addToFavouritesFile(addressTextBox.Text, faveName);

            OnFave();
        }

        protected virtual void OnFave()
        {
            if (FaveEvent != null)
            {
                FaveEvent(this, EventArgs.Empty);
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Set " + addressTextBox.Text + " as homepage?", "Set Homepage", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Homepage.setNewHomepage(addressTextBox.Text);

        }

    }
}
