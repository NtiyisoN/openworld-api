using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using norwold.model;
using DataModel.libCampaign;

namespace norwold.forms
{
    public partial class frmReportViewer : norwold.forms.frm_nwBase
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            bs_nwAdventure.Clear();
            var query = sess.CreateCriteria(typeof(campAdventure));
            //query.SetFetchMode("Campaign", NHibernate.FetchMode.Eager);
            query.SetFetchMode("Rewards", NHibernate.FetchMode.Eager);
            query.SetResultTransformer(NHibernate.Transform.Transformers.DistinctRootEntity);
            bs_nwAdventure.DataSource =query.List<campAdventure>();
            
            
            //bs_nwAdventure.DataSource = sess.QueryOver<campAdventure>().List();

            this.rptViewer1.RefreshReport();
        }

        private void lboxSelections_SelectedIndexChanged(object sender, EventArgs e)
        {
            campAdventure nwa;
            nwa = bs_nwAdventure.Current as campAdventure;
            if (nwa == null) { return; }
            bsrep_nwAdventure.Clear();
            bsrep_nwAdventure.List.Add(nwa);
            bsrep_Campaign.Clear();
            bsrep_Campaign.List.Add(nwa.Campaign);
            //bsrep_nwXPGained.Clear();
            //bsrep_nwXPGained.DataSource = nwa.Rewards;

        }

        private void gboxReportSelect_Enter(object sender, EventArgs e)
        {

        }

        private void bs_nwAdventure_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            this.rptViewer1.RefreshReport();
        }

        private void bs_nwAdventure_CurrentChanged_1(object sender, EventArgs e)
        {
            campAdventure nwa;
            nwa = bs_nwAdventure.Current as campAdventure;
            if (nwa == null) { return; }

            bsrep_nwXPGained.DataSource = nwa.Rewards;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void rptViewer1_Load(object sender, EventArgs e)
        {

        }

        private void bsrep_nwXPGained_CurrentChanged(object sender, EventArgs e)
        {
 
        }

        private void bsrep_nwChar_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void nwAdventureBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
