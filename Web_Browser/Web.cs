using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace Web_Browser
{

    public partial class Web : UserControl
    {

        private BackgroundWorker worker = new BackgroundWorker();
        private string workerURL = null;

        private Browser browse = null;
        private TabPage tab = null;


        public Web(Browser browse, TabPage tab)
        {
            InitializeComponent();
            this.browse = browse;
            this.tab = tab;
            
        }


        private void goBtn_Click(object sender, EventArgs e)
        {
            loadHTML(addressTextBox.Text);
        }

        public delegate void LoadHTMLEventhandler(object source, EventArgs args);
        public event LoadHTMLEventhandler LoadHTML;

        //called when backgroundworker is completed and will call methods subscribed to LoadHTMLEventhandler delegate
        protected virtual void OnLoadHTML()
        {
            if (LoadHTML != null)
            {
                LoadHTML(this, EventArgs.Empty);
            }
        }

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
                browse.changeTabName(url, tab);
                addressTextBox.Text = url;
                //start process on worker thread
                backgroundWorker1.RunWorkerAsync(url);
            }
        }


        //changes clickable status of buttons based off if there is 'Next' or 'Previous' history
        private void toggleButtons()
        {
            forwardBtn.Enabled = History.canGoToNext();
            backBtn.Enabled = History.canGoToPrevious();

        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {   //ensures users can't make empty searches
            if (e.KeyCode == Keys.Enter && (addressTextBox.Text.Length > 0))
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

        //called when backgroundworker is completed and will call methods subscribed to FaveEventhandler delegate
        protected virtual void OnFave()
        {
            if (FaveEvent != null)
            {
                FaveEvent(this, EventArgs.Empty);
            }
        }

        private void faveBtn_Click(object sender, EventArgs e)
        {
            string prompt = "Please enter the name you would like to assign to the web address " + addressTextBox.Text;

            string faveName = Microsoft.VisualBasic.Interaction.InputBox(prompt, "Favourite", "Enter Name", -1, -1);

            if(faveName.Length < 1) { return; };



            Favourites.addToFavouritesFile(addressTextBox.Text, faveName);

            OnFave();
        }


        private void homeBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Set " + addressTextBox.Text + " as homepage?", "Set Homepage", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Homepage.setNewHomepage(addressTextBox.Text);

        }

    }
}
