using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DataModel.libHosting;
using NHibernate;
using Microsoft.VisualBasic;
using norwold.model;
using System.Diagnostics;
using DataModel.libDB;
using DataModel.libCampaign;


namespace norwold.forms
{
    public partial class frm_nwBase : Form
    {

        //private bool isAdmin;
        private hostUser _logon;

        public hostUser Logon { get { return this._logon; } set { SetVisibility(Logon); } }
        public hostChar Character { get; set; }
        public campAdventure Adventure { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }

        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager treeman;
        
        public frm_nwBase()
        {
            InitializeComponent();
        }

        protected virtual void SetMessage(string msg)
        {
            tboxMsg.Text = msg;
            Debug.Print(msg);
        }

        public virtual void SetVisibility(hostUser hu)
        {
            //[[TODO]]
            SetMessage("Setting visibility for " + hu.LongName + " Type" + hu.UserType.LongName);
            this._logon = hu;
        }

        public virtual void InitData()
        {
            //Create&Drop
            if (this.Database == null) { this.Database = new nwdbConnection(); }
            sessionFactory = this.Database.Factory;
            if (this.Repository == null) { this.Repository = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = this.Repository.GetSession();
            treeman = new sysTreeManager();
        }

        private void frm_nwBase_Load(object sender, EventArgs e)
        {

        }
    }
}
