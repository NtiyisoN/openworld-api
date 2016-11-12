using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using norwold.model;
using DataModel.libMapping;
using DataModel.libDB;

namespace norwold.forms
{
    public partial class FrmMapDesigner : norwold.forms.frm_nwBase
    {
        public FrmMapDesigner()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitData();
            owTree.Session = this.sess;
            lboxMapMenu.Items.AddRange(mapConst.TreeNames);
            
        }

        private void btnMDChangePath_Click(object sender, EventArgs e)
        {

        }

        private void lblMasterPath_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.bs_mapDetail.DataSource = sess.QueryOver<mapTreeTerrain>().List();
            owTree.TreeBindingSource = this.bs_mapDetail; 
            
            //mapTreeTerrain nt = sess.QueryOver<mapTreeTerrain>().Where(x => x.Parent == null).SingleOrDefault<mapTreeTerrain>();
            //owTree.nwdbTree = nt;
            //openwTreeView1.nwdbTree = sess.QueryOver<sysTreeStatistic>(x => x.Parent == null).First;
            //bs_sysStatistic.DataSource = sess.QueryOver<sysTreeStatistic>();


        }

        private void picPOI_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picTerrain_Click(object sender, EventArgs e)
        {

        }

        private void openwTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mapTreeTerrain st = owTree.SelectedNode.Tag as mapTreeTerrain;
            
            //bs_mapTerrainType.DataSource = st.GetLeafNodes();
            //lblMasterPath.Text = st.Path(" \\ ");
            //this.BindingSource.Position = cEditor.BindingSource.IndexOf(st);

            //how to set BindingSource;
        }

        private void bs_mapTreeTerrain_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            owTree.TreeEditName = this.tboxBranchName;
            owTree.TreeEditValue = this.tboxTerrainTypeValue;
            owTree.TreeEditMode = true;
        }

        private void owTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            owTree.defEventTreeAfterSelect(sender, e);
        }

        private void lboxMapMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxMapMenu.SelectedIndex != -1) { owTree.LoadByTreeName(lboxMapMenu.Text); }
        }

        
    }
}
