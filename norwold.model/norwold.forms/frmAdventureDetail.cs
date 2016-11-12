using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using NHibernate;
using norwold.model;
using DataModel.libHosting;
using DataModel.libDB;
using DataModel.libCampaign;



namespace norwold.forms
{
    public partial class frmAdventureDetail : Form
    {
        //private bool isAdmin;

        public hostUser Logon { get; set; }
        public hostChar Character { get; set; }
        public campAdventure Adventure { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }

        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager stm;

        public frmAdventureDetail()
        {
            InitializeComponent();
        }
            

        public void initData()
        {
            //Create&Drop
            if (this.Database == null) { this.Database = new nwdbConnection(); }
            sessionFactory = this.Database.Factory;
            if (this.Repository == null) { this.Repository = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = this.Repository.GetSession();
            stm = new sysTreeManager();
            //repo.SeedMockData();
            if (this.Adventure != null)
            {
                bs_nwAdventure.List.Clear();
                bs_nwAdventure.List.Add(Adventure);
            }
            else
            {
                SetMessage("initData Failed no Adventure set");
            }
            bs_sysMileStoneType.DataSource = sess.QueryOver<DataModel.libData.sysMilestoneType>().List();
        }
        

        private void frmAdventureDetails_Load(object sender, EventArgs e)
        {
            bs_nwAdventure_CurrentChanged(null, null);
        }
        private void SetMessage(string msg)
        {
            Debug.Print(msg);
            tboxMsg.Text = msg;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlayerSelect_Click(object sender, EventArgs e)
        {
            bool bExists;
            
            //health check
            campAdventure nw = bs_nwAdventure.Current as campAdventure;
            if (nw == null) { SetMessage("No Current Adventure"); return; }
            campCampaign camp = nw.Campaign;
            if (camp == null) { SetMessage("No Campaign for Adventure:"+nw.LongName); return; }
            
            //create Campaign Characters List
            IList<hostChar> plist = new List<hostChar>();
            foreach (campCharCampaign c in camp.Characters)
            {
                if (c.Character.isNPC == false && c.Approved) {
                    // Remove if already rewarded / in Adventure
                    bExists = false;
                    foreach(campXPGained xp in nw.Rewards) {
                        if (xp.Character == c.Character) {
                            bExists = true;
                            SetMessage("Skipping " + c.Character.LongName + " exists already");
                        }
                   
                    }
                    //doesnt exist, isnt NPC, is approved
                    if (!bExists) { plist.Add(c.Character); }
                }
            }
            SetMessage("Loaded" + plist.Count().ToString() + " Campaign Characters");

            frmSelectPlayers frmPlayers = new frmSelectPlayers();
                frmPlayers.Players = plist;
                frmPlayers.ShowDialog(this);
                plist = frmPlayers.Players;
                frmPlayers.Dispose();
            SetMessage("Select returned" + plist.Count().ToString() + " Campaign Characters");
            
            //Create new records for new players
            foreach(hostChar c in plist) {
                campXPGained xp = new campXPGained("", "", nw, c, 0, 0, false);
                nw.Rewards.Add(xp);
            }
            //refresh charlist binding
            bs_nwAdventure_CurrentChanged(null, null);
        }

        private void bs_nwAdventure_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_nwAdventure.Current == null) { return; }
            campAdventure nwa = bs_nwAdventure.Current as campAdventure;
            bs_nwXPGained.DataSource = nwa.Rewards;
            bs_nwMilestone.DataSource = nwa.Milestones;
            bs_nwChar.DataSource = nwa.GetPlayers();
            chklboxPlayers.Items.Clear();
            foreach (hostChar p in nwa.GetPlayers())
            {
                chklboxPlayers.Items.Add(p);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bs_nwAdventure.Current == null) { return; }
            campAdventure nwa = bs_nwAdventure.Current as campAdventure;
            Repository.Save(nwa);
            SetMessage("Saved Adventure:" + nwa.LongName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
