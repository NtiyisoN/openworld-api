using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using DataModel.libHosting;
using norwold.model;
using NHibernate;
using DataModel.libDB;


namespace norwold.forms
{
    public partial class frmUserManager : Form
    {

        
        protected nwdbConnection nw;
        protected ISessionFactory sessionFactory;
        protected nwdbRepository repo;
        protected ISession sess;
        protected sysTreeManager stm;

        public frmUserManager()
        {
            InitializeComponent();
            nw = new nwdbConnection();

            //Update
            //nw = new nwdbConnection();


            sessionFactory = nw.Factory;
            repo = new nwdbRepository(sessionFactory.OpenSession());
            sess = repo.GetSession();
            stm = new sysTreeManager();
            bs_hostUser.DataSource = sess.QueryOver<hostUser>().List();
            bs_userType.DataSource = sess.QueryOver<hostUserType>().List();

        }
        protected virtual void SetMessage(string msg)
        {
            tboxMsg.Text = msg;
            Debug.Print(msg);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUserManager_Load(object sender, EventArgs e)
        {

        }

        private void hostUserBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_hostUser.Current == null) { return; }
            hostUser user = bs_hostUser.Current as hostUser;
            
            this.bs_chars.DataSource = user.Characters;
            this.bs_campaigns.DataSource = user.GMCampaigns;
            if (user.UserType == null)
            {
                lboxUserType.SelectedIndex = -1;
            }
            else
            {
                lboxUserType.SelectedIndex = lboxUserType.Items.IndexOf(user.UserType);
            }
            if (user == null) { return; }
            SetMessage("Set User to" + user.LongName + " Charactercount:" + user.Characters.Count().ToString() + " campaigns" + user.GMCampaigns.Count().ToString());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetMessage("Starting User Save");
            foreach (hostUser user in bs_hostUser.List)
            {
                    repo.Save(user);
                    SetMessage("Saved " + user.LongName);
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bs_hostUser.AddNew();
        }

        private void lboxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bs_hostUser.Current == null || lboxUserType.SelectedItem == null) { return; }
            hostUser user = bs_hostUser.Current as hostUser;
            if (user.UserType == null) { return; }
            string c =lboxUserType.SelectedItem.ToString();
            if (user.UserType.LongName != c )
            {
                SetMessage("UserType has changed Utype" + user.UserType.LongName + " selvalue:" + c);
                user.UserType = bs_userType.Current as hostUserType;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNewCampaign_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        

    }
}
