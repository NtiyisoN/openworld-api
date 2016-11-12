using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentNHibernate;
using NHibernate;
using DataModel.libHosting;
using DataModel.libDB;
using DataModel.libCampaign;
using DataModel.libData;


namespace norwold.forms
{
    public partial class frmCharacters : Form
    {
        private bool isAdmin;

        public hostUser Logon { get; set; }
        public hostChar Character { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }
        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager stm;

        public frmCharacters()
        {
            //bool CreateAndDrop = false;
            
            InitializeComponent();
           

           
        }




        private void LoadCharacters()
        {
            //lboxCharacters.Items.Clear();

            
            
            //bs_nwCharStat.DataSource = sess.QueryOver<hostCharStat>().List();
            //nwCharBindingSource


            SetMessage("Loaded " + lboxCharacters.Items.Count + " characters");
            /**
            foreach (nwdbDataType item in il)
            {
                lboxCharacters.Items.Add(item.LongName);
            }
            **/

            //SetMessage("Array Loaded with " + nwCharBindingSource.Count() + " Characters");
        }

        protected virtual void SetMessage(string msg)
        {
            tboxMsg.Text = msg;
            Debug.Print(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs_nwChar.AddNew();
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

            bs_sysAlignment.DataSource = sess.QueryOver<sysBaseAlignment>().List();

            if (this.Logon != null)
            {
                isAdmin = (this.Logon.UserType.LongName == "Administrator");
                SetMessage("isAdmin calulated" + isAdmin.ToString() + " for Logon" + this.Logon.LongName);
            }

            if (this.Character != null)
            {
                bs_nwChar.List.Clear();
                bs_nwChar.List.Add(Character);
                
                lboxLogon.Visible = false;
                lboxCharacters.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = false;
                nwCharBindingSource_CurrentChanged(this, null);
                return;

            }

            if (this.Logon == null || isAdmin)
            {
                bs_logons.DataSource = sess.QueryOver<hostUser>().List();
            }
            else
            {
                bs_logons.DataSource = sess.QueryOver<hostUser>().Where(tx => tx.id == this.Logon.id).List();
            }
            LoadCharacters();
            bs_sysTreeStatistic.DataSource = sess.QueryOver<sysTreeStatistic>().List();
            stm.FillTreeNodeCollection<sysTreeStatistic>(sess, treeStatistic.Nodes);
            //catch late binding controls
            nwCharBindingSource_CurrentChanged(this, null);
        }

        private void frmCharacters_Load(object sender, EventArgs e)
        {
            SetMessage("LOAD CALLED");
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (hostChar ch in bs_nwChar.List)
            {
                using (sess.BeginTransaction())
                {
                    sess.SaveOrUpdate(ch);
                    sess.Transaction.Commit();
                    SetMessage("Saved " + ch.LongName);
                }
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void nwCharBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            hostChar n = bs_nwChar.Current as hostChar;
            if (n == null) { return; }
            bs_nwItem.DataSource = n.Items;
            bs_nwCharStat.DataSource = n.CharStats;
            bs_nwCharCampaign.DataSource = n.Campaigns;
            lboxAlignment.SelectedItem = n.Alignment;
            SetMessage("Set Items to " + n.LongName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            hostChar ch = bs_nwChar.Current as hostChar;

            //Flush Pending changes
            SetMessage("Delete called on " + ch.LongName);
            btnSave_Click(null, null);

            SetMessage("Deleting:" + ch.LongName);
            using (sess.BeginTransaction())
            {
                sess.Delete(ch);
                sess.Transaction.Commit();
                SetMessage("Deleted " + ch.LongName);
            }

            
            SetMessage("Reloading List");
            LoadCharacters();
        }

        private void btnItemRemove_Click(object sender, EventArgs e)
        {
            nwItem i = bs_nwItem.Current as nwItem;
            bs_nwItem.Remove(i);
        }

        private void btnItemNew_Click(object sender, EventArgs e)
        {
            bs_nwItem.AddNew();
        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void bs_sysAlignment_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void lboxAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bs_sysAlignment.Current == null) { return; }
            if (bs_nwChar.Current == null) { return; }
            hostChar c = bs_nwChar.Current as hostChar;

            if (c.Alignment == null) { return; }
            if (c.Alignment != bs_sysAlignment.Current)
            {
                SetMessage("Alignments dont match");
                c.Alignment = bs_sysAlignment.Current as sysBaseAlignment;
            }
            else
            {
                SetMessage("Alignment matches:"+c.Alignment.Name);
            }
        }

        private void tboxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSetItem_Click(object sender, EventArgs e)
        {
            string typedesc;
            nwItem item = bs_nwItem.Current as nwItem;
            if (item.ItemType == null)
            {
                typedesc = "NULL";
            } else {
                typedesc = item.ItemType.Path("\\");
            }
            
            SetMessage("Calling Set Item for item:"+item.Name+" Current: Type"+typedesc);
            sysTreeItemType selected = stm.Select<sysTreeItemType>(sess, item.ItemType) as sysTreeItemType;
            if (selected != item.ItemType) { item.ItemType = selected; }
            UpdateItemPath();

        }
        protected virtual void UpdateItemPath() {
            nwItem item = bs_nwItem.Current as nwItem;
            if (item.ItemType == null) {
                lblItemType.Text = "UNASSIGNED";
            }
            else
            {
                lblItemType.Text = item.ItemType.Path(" \\ ");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0) { UpdateItemPath(); }
 
        }

        private void bs_logons_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_logons.Current == null)
            {
                bs_nwChar.DataSource = sess.QueryOver<hostChar>().List();
            }
            else
            {
                hostUser user = bs_logons.Current as hostUser;
                bs_nwChar.DataSource = user.Characters;
            }
        }

        private void lboxLogon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bs_campaigns_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void bs_nwChar_DataMemberChanged(object sender, EventArgs e)
        {
            SetMessage("Char data Changed" + sender.ToString());
            SetMessage("Sender" + sender.ToString());
            SetMessage("Events" + e.ToString());
        }

        private void nwCharCampaignBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            campCharCampaign camp = bs_nwCharCampaign.Current as campCharCampaign;
            if (camp != null) { bs_hostCampaign.DataSource = camp.Campaign; }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            bool bExists;
            hostChar me = bs_nwChar.Current as hostChar;
            if (me == null) { return;}

            IList<nwdbDataType> campaigns = sess.QueryOver<campCampaign>().List<nwdbDataType>();
            campaigns = FrmSelectsysDataType.Select(campaigns, "Select campaign", this);
            foreach (campCampaign camp in campaigns)
            {
                Debug.Print("Selected" + camp.ToString());
                bExists = false;
                foreach (campCharCampaign c in bs_nwCharCampaign.List)
                {
                    if (c.Campaign == camp)
                    {
                        SetMessage("Skipping " + campaigns.ToString() + "Already a participant");
                        bExists = true;
                    }
                }
                
                if (!bExists) {

                    // add as doesnt exists
                    campCharCampaign newc = new campCharCampaign(camp,me,false);
                    camp.Characters.Add(newc);
                    SetMessage("Applied to join :"+camp.ToString());
                }    

                   
                
            }
        }

        private void bs_nwCharStat_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bs_sysTreeStatistic_CurrentChanged(object sender, EventArgs e)
        {
            sysTreeStatistic n = bs_sysTreeStatistic.Current as sysTreeStatistic;
            hostChar nw = bs_nwChar.Current as hostChar;
            IList<hostCharStat> filtered = new List<hostCharStat>();
            foreach (hostCharStat c in bs_nwCharStat.List)
            {
                if (c.stat.StatisticGroup == n)
                {
                    filtered.Add(c);
                    Debug.Print("Filtered in" + c.ToString());
                }
                else
                {
                    Debug.Print("Filtered out" + c.ToString());
                }
            }
            dataGridView1.DataSource = filtered;

            //bs_sysStatistic.DataSource = n.Statistics;
            //bs_nwCharStat.DataSource = sess.QueryOver<hostCharStat>( )
            //                            .WithSubquery.WhereExists(QueryOver.Of<sysStatistic>()
            //                                    .Where(tx => tx.StatisticGroup = n ))
            //                            .And(x => x.character == nw)
            //                            .List();
        }

        private void treeStatistic_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nwdbTree st = treeStatistic.SelectedNode.Tag as nwdbTree;
            bs_sysTreeStatistic.Position = bs_sysTreeStatistic.IndexOf(st);
        }

      
    }

}     
               
    

