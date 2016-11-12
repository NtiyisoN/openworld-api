using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using norwold.model;
using DataModel.libHosting;
using NHibernate;
using DataModel.libDB;
using DataModel.libCampaign;

namespace norwold.forms
{
    public partial class frmCampaign : Form
    {
        private bool isAdmin;

        public hostUser Logon { get; set; }
        public hostChar Character { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }
        
        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager stm;
        protected hostEmail email;

        public frmCampaign()
        {
            InitializeComponent();
            email = new hostEmail();
        }

        private void initData()
        {
            //Create&Drop
            if (this.Database == null) { this.Database = new nwdbConnection(); }
            sessionFactory = this.Database.Factory;
            if (this.Repository == null) { this.Repository = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = this.Repository.GetSession();
            stm = new sysTreeManager();
            //repo.SeedMockData()
            if (this.Logon != null)
            {
                isAdmin = (this.Logon.UserType.LongName == "Administrator");
                SetMessage("isAdmin calulated" + isAdmin.ToString() + " for Logon" + this.Logon.LongName);
            }
            if (this.Logon == null || isAdmin)
            {
                bs_hostUser.DataSource = sess.QueryOver<hostUser>().List();
            }
            else
            {
                bs_hostUser.DataSource = sess.QueryOver<hostUser>().Where(tx => tx.id == this.Logon.id).List();
            }

        }

        private void frmCampaign_Load(object sender, EventArgs e)
        {
            initData();

        }

        private void LoadCampaigns()
        {
            bs_hostUser.DataSource = sess.QueryOver<hostUser>().List();
            bs_hostCampaign.DataSource = sess.QueryOver<campCampaign>().List();
        }

        private void LoadCharacters()
        {
            hostChar c;
            chkListBoxPlayers.Items.Clear();
            chkListBoxPlayersPending.Items.Clear();
            chkListBoxRejected.Items.Clear();
            

            foreach( campCharCampaign ch in bs_nwCharCampaign.List) {
                c = ch.Character;
                if (ch.Approved)
                {
                    chkListBoxPlayers.Items.Add(c);
                }
                else {
                    if (ch.RejectComment != null)
                    {
                        chkListBoxRejected.Items.Add(c);

                    }
                    else { chkListBoxPlayersPending.Items.Add(c); }
                     
                }
            }
        }


        private void bs_hostUser_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_hostUser.Current == null)
            {
                bs_hostCampaign.DataSource = sess.QueryOver<campCampaign>().List();
            }
            else
            {
                hostUser user = bs_hostUser.Current as hostUser;
                bs_hostCampaign.DataSource = user.GMCampaigns;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetMessage(string msg)
        {
            Debug.Print(msg);
            tboxMsg.Text = msg;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            campCampaign cm = bs_hostCampaign.Current as campCampaign;

            //Flush Pending changes
            SetMessage("Delete called on " + cm.LongName);
            btnSave_Click(null, null);

            SetMessage("Deleting:" + cm.LongName);
            using (sess.BeginTransaction())
            {
                sess.Delete(cm);
                sess.Transaction.Commit();
                SetMessage("Deleted " + cm.LongName+ "lets see whats happened to the characters");
            }


            SetMessage("Reloading List");
            LoadCampaigns();
        }

        private void bs_hostCampaign_CurrentChanged(object sender, EventArgs e)
        {
            campCampaign camp = bs_hostCampaign.Current as campCampaign;
           
            if (camp != null)
            {
                bs_nwCharCampaign.DataSource = sess.QueryOver<campCharCampaign>()
                    .Where(tx => tx.Campaign == camp)
                    .List();
                bs_nwAdventure.DataSource = sess.QueryOver<campAdventure>()
                    .Where(tx => tx.Campaign == camp)
                    .List();
                LoadCharacters();

            }
        }

        private void bs_nwChar_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (campCampaign camp in bs_hostCampaign.List)
            {
                this.Repository.Save(camp);
            }
            //email.SendMessage("dangerfield.stephen@yahoo.com.au", "Hello and Welcome", "Hello and welcome to Openworld");
        }

        private void btnLoadChar_Click(object sender, EventArgs e)
        {
            bs_hostCampaign.AddNew();
        }

       
        private void bs_nwCharCampaign_Queue_CurrentChanged(object sender, EventArgs e)
        {
            /**
            if (bs_nwCharCampaign_Queue.Current != null)
            {
                campCharCampaign current = bs_nwCharCampaign_Queue.Current as campCharCampaign;
                bs_nwChar_Queue.Clear();
                bs_nwChar_Queue.List.Add(current.Character);
            }
            **/
        }


        private void LoadSelectedChar(object sender, EventArgs e)
        {
            SetMessage("Sender" + sender.ToString());
            SetMessage("Events" + e.ToString());
            CheckedListBox clb = sender as CheckedListBox;
            hostChar c = clb.SelectedItem as hostChar;
            if (c != null)
            {
                SetMessage("loaded Character" + c.ToString());
                frmCharacters frmChar = new frmCharacters();
                frmChar.Character = c;
                frmChar.Database = this.Database;
                frmChar.Repository = this.Repository;
                frmChar.initData();
                frmChar.ShowDialog(this);
                frmChar.Dispose();
            }


        }
        private void chkListBoxRejected_DoubleClick(object sender, EventArgs e)
        {

        }

        private void chkListBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCharApprove_Click(object sender, EventArgs e)
        {
            bs_nwCharCampaign.SuspendBinding();
            foreach (hostChar c in chkListBoxPlayersPending.CheckedItems)
            {
                
                foreach(campCharCampaign nwc in bs_nwCharCampaign.List) {
                    if (nwc.Character == c) {
                        SetMessage("Approving"+c.LongName+ "for Campaign"+nwc.Campaign);
                        nwc.Approved = true;
                        break;
                    }
                }
            }
            bs_nwCharCampaign.ResumeBinding();
            LoadCharacters();
        }

        private void btnCampaignRemove_Click(object sender, EventArgs e)
        {
            bs_nwCharCampaign.SuspendBinding();
            foreach (hostChar c in chkListBoxPlayers.CheckedItems)
            {
                foreach (campCharCampaign nwc in bs_nwCharCampaign.List)
                {
                    if (nwc.Character == c)
                    {
                        SetMessage("Removing" + c.LongName + "for Campaign" + nwc.Campaign);
                        nwc.Approved = false;
                        nwc.RejectComment = "Removed from " + nwc.Campaign.LongName + " on " + DateTime.Now.ToString();
                        break;
                    }
                }
            }
            bs_nwCharCampaign.ResumeBinding();
            LoadCharacters();
        }

        private void btnCampaignReject_Click(object sender, EventArgs e)
        {
            bs_nwCharCampaign.SuspendBinding();
            foreach (hostChar c in chkListBoxPlayersPending.CheckedItems)
            {
                foreach (campCharCampaign nwc in bs_nwCharCampaign.List)
                {
                    if (nwc.Character == c)
                    {
                        SetMessage("Rejecting" + c.LongName + "for Campaign" + nwc.Campaign);
                        nwc.Approved = false;
                        nwc.RejectComment = "Declined Entry to " + nwc.Campaign.LongName + " on " + DateTime.Now.ToString();
                        break;
                    }
                }
            }
            bs_nwCharCampaign.ResumeBinding();
            LoadCharacters();
        }

        private void chkListBoxRejected_SelectedIndexChanged(object sender, EventArgs e)
        {
            hostChar c = chkListBoxRejected.SelectedItem as hostChar;
            if (c != null )
            {
                bs_nwCharCampaign.SuspendBinding();
                    foreach (campCharCampaign nwc in bs_nwCharCampaign.List)
                    {
                        if (nwc.Character == c)
                        {
                            tboxRejectText.Text = nwc.RejectComment;
                            break;
                        }
                    }
                
                bs_nwCharCampaign.ResumeBinding();
               
            }
            else { tboxRejectText.Text = ""; }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            hostChar c = chkListBoxRejected.SelectedItem as hostChar;
            if (c != null)
            {
                bs_nwCharCampaign.SuspendBinding();
                foreach (campCharCampaign nwc in bs_nwCharCampaign.List)
                {
                    if (nwc.Character == c)
                    {
                        nwc.RejectComment = null;
                        nwc.Approved = false;
                        tboxRejectText.Text = "";
                        break;
                    }
                }

                bs_nwCharCampaign.ResumeBinding();
                LoadCharacters();
            }
        }

        private void btnNewAdventure_Click(object sender, EventArgs e)
        {
            campCampaign camp = bs_hostCampaign.Current as campCampaign;
            if (camp == null)
            {
                SetMessage("Cannot Add Adventure - No Current campaign");
            }
            else
            {


                                
                campAdventure nwa = bs_nwAdventure.AddNew() as campAdventure;
                camp.Adventures.Add(nwa);
                nwa.Campaign = camp;
                tboxAdventureName.Focus();

            }


        }

        private void lboxAdventures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

            campAdventure nwa = bs_nwAdventure.Current as campAdventure;
            if (nwa == null)
            {
                SetMessage("No Current Adventure Selected");
                return;
            }
            else
            {
                if (nwa.LongName == "" || nwa.LongName == null || bs_hostCampaign.Current ==null)
                {
                    SetMessage("Cannot Save Adventure - No Adventure Name");
                }
                else
                {
                    //Save and load
                    this.Repository.Save(nwa);

                    frmAdventureDetail frmAdventure = new frmAdventureDetail();
                    frmAdventure.Adventure = nwa;
                    frmAdventure.Database = this.Database;
                    frmAdventure.Repository = this.Repository;
                    frmAdventure.initData();
                    frmAdventure.ShowDialog(this);
                    frmAdventure.Dispose();
                }
            }
        }
    }
}
