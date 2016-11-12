using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

using NHibernate;
using Microsoft.VisualBasic;
using DataModel.libHosting;
using DataModel.libMapping;
using DataModel.libCampaign;
using DataModel.libDB;
using DataModel.libData;

namespace norwold.forms
{
    public partial class frmRuleSetDesigner : Form
    {
        //private bool isAdmin;
        private hostUser _logon;

        public hostUser Logon { get { return this._logon;}  set { SetVisibility(Logon); } }
        public hostChar Character { get; set; }
        public campAdventure Adventure { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }
        public mapTileSetManager TerrainManager { get; set; }

        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager treeman;

        protected GraphicsPath HexGridPath;
        protected GraphicsPath HexGridRect;

        protected GroupBox[] gBoxes;

        private const string strAlign = "Alignments";
        private const string strDamage = "Damage Types";
        private const string strAOE = "AOE Types";
        private const string strStatGroup = "Statistics";
        private const string strItemType = "Item Types";
        private const string strDevType = "Development Types";
        private const string strMilestoneTypes = "Milestone Types";
        private const string strSysItems = "System Items";
        private const string strSysStats = "Stats";
        private const string strDevPaths = "Classes";
        private const string strDmgRolls = "Rolls";
        private const string strDurationType = "Duration Type";
        private const string strMilestones = "Milestones";
        private const string strItemTree = "Tree: Itemtypes";
        private const string strStatTree = "Tree: StatisticTypes";
        private const string strMilestoneTree = "Tree: Milestones";
        private const string strFactionRanks = "Faction Ranks";
        private const string strTerrainTypes = "Terrain Types";
        private const string mapTerrainTypes = "Terrain Types(M)";
        private const string strFactions = "Factions";
        private const string strFactionTree = "Tree: Factions";
        private const string strLocations = "Locations";
        private const string strLocationTree = "Tree: Locations";
        private const string strTerrainTree = "Tree: Terrains";

        private const string strPOIType = "Places of Interest (POI) Types";
        private const string strLanguage = "Languages";



        private const int isTable = 0;
        private const int isTree = 1;
        private const int isMasterDetail = 2;
        private EditOptions cEditor;
        
        
        private IList<EditOptions> Editors;
        private static Point TableLocation = new Point(436, 96);


        private class EditOptions
        {
            public EditOptions(int tab, string d, object o, BindingSource bs, EditOptions detail)
            {
                tabType = tab;
                Description = d;
                EmptyType = o;
                SetBinding(bs);
                Detail = detail;
            }
            public EditOptions(int tab, string d, object o, BindingSource bs, EditOptions detail, TabPage custom, bool camptable)
                : this(tab, d, o, bs, detail)
            {
                tabControl = custom;
                //Fixup leftisms;
                //if (gBox != null) { gBox.Left = TableLocation.X; gBox.Top = TableLocation.Y; }
                isCampignTable = camptable;
            }

            public int tabType { get; set; }
            public string Description { get; set; }
            public object EmptyType { get; set; }
            public BindingSource BindingSource { get; private set; }
            public Binding bindID { get; private set; }
            public Binding bindName { get; private set; }
            public Binding bindLongName { get; private set; }
            public TabPage tabControl { get; private set; }
            public EditOptions Detail { get; private set; }
            public bool isCampignTable { get; private set; }
            public bool canCreate { get; private set; }
            public bool canDelete { get; private set; }

            
            
            public void SetBinding(BindingSource bs)
            {
                BindingSource = bs;
                bindID = new Binding("Text", bs, "ID");
                bindLongName = new Binding("Text", bs, "LongName");
                bindName = new Binding("Text", bs, "Name");
            }
            public override string ToString()
            {
                return Description;
            }
        }

        public frmRuleSetDesigner()
        {
            InitializeComponent();
            Editors = new List<EditOptions>();
            this.TerrainManager = new mapTileSetManager();
            HexGridPath = new GraphicsPath();
            HexGridRect = new GraphicsPath();
            //Init();

        }
        
        public void SetVisibility(hostUser hu) {
            //[[TODO]]
            SetMessage("Setting visibility for " + hu.LongName + " Type" + hu.UserType.LongName);
            LoadEditors(hu.UserType.LongName);
            this._logon = hu;
        }


        public void InitData()
        {
            //Create&Drop
            if (this.Database == null) { this.Database = new nwdbConnection(); }
            sessionFactory = this.Database.Factory;
            if (this.Repository == null) { this.Repository = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = this.Repository.GetSession();
            treeman = new sysTreeManager();
            //repo.SeedMockData();
            Init();
            
        }

        protected void LoadEditors(string role)
        {
            this.lboxSystemTables.Items.Clear();
            foreach(EditOptions opt in Editors) {
                switch (role)
                {
                    case hostConstants.usrSysAdmin:
                        lboxSystemTables.Items.Add(opt);
                        break;
                    case hostConstants.usrRulesetAdmin:
                        if (!opt.isCampignTable) { lboxSystemTables.Items.Add(opt); }
                        break;
                    case hostConstants.usrPlayer:
                        if (opt.isCampignTable) { lboxSystemTables.Items.Add(opt); }
                        break;

                }
      }



        }

           //[BEGIN]]
        protected void Init()
        {
            




            refreshBindings();
            //Create EditOptions
            Editors.Add(new EditOptions(isTable,strAlign, new sysBaseAlignment(),bs_sysAlignment, null));
            Editors.Add(new EditOptions(isTable, strLanguage, new sysLanguage(), bs_sysLanguage, null));
            Editors.Add(new EditOptions(isTable, strDamage, new sysBaseDamageType(), bs_sysDamageType, null));
            Editors.Add(new EditOptions(isTable, strAOE, new sysAOEType(), bs_sysAOE, null, tbAOE, false));
            Editors.Add(new EditOptions(isTable, strDmgRolls, new sysDamageRoll(), bs_sysDmgRoll, null, tbRolls, false));
            Editors.Add(new EditOptions(isTable, strDurationType, new sysBaseDurationType(), bs_Duration, null, tbDuration, false));
            Editors.Add(new EditOptions(isTable, strFactionRanks, new sysFactionRanking(), bs_sysFactionRanking, null, tbRanks, false));
            Editors.Add(new EditOptions(isTable, strPOIType, new mapPOIType(), bs_sysPOI, null, tbPOI, false));
            Editors.Add(new EditOptions(isTable, strMilestoneTypes, new sysMilestoneType(), bs_sysMilestoneType, null, tbMilestoneTypes, false));
            Editors.Add(new EditOptions(isMasterDetail, strStatGroup, new sysTreeStatistic(), bs_sysTreeStatistic, new EditOptions(isTable,strSysStats,new sysBaseStatistic(),bs_sysStatistic,null,tbStatistics,false),null,false));
            Editors.Add(new EditOptions(isMasterDetail, strItemType, new sysTreeItemType(), bs_sysTreeItemType, new EditOptions(isTable, strSysItems, new sysItemType(), bs_sysItemType, null,tbItemDetail,false), null, false));
            Editors.Add(new EditOptions(isMasterDetail, mapTerrainTypes, new mapTreeTerrain(), bs_maptreeTerrain, new EditOptions(isTable, strTerrainTypes, new sysTerrainMapType(), bs_sysTerrainType, null, tbTerrain, false), null, false));

            
            //Campaign Tables (editable by a GM rather than rulsetAdmin)
            Editors.Add(new EditOptions(isMasterDetail, strMilestones, new campTreeMileStone(), bs_nwTreeMilestone, new EditOptions(isTable, strMilestones, new campMilestone(), bs_nwMilestone, null), null, true));
            
            //[TODO - Change to NWPOI]
            Editors.Add(new EditOptions(isMasterDetail, strFactions, new campTreeFaction(), bs_nwTreeFaction, new EditOptions(isTable, strFactions, new campFaction(), bs_nwFaction, null,tbFactions,false), null, true));
            Editors.Add(new EditOptions(isMasterDetail, strLocations, new campTreeLocation(), bs_nwTreeLocation, new EditOptions(isTable, strLocations, new campHex(), bs_nwHex, null), null, true));
            Editors.Add(new EditOptions(isMasterDetail, strDevType, new sysTreeDevelopment(), bs_sysTreeDevelopment, new EditOptions(isTable, strDevPaths, new sysDevelopment(), bs_sysDevelopment, null), tbPaths, false));
           
            //Campaign trees
            Editors.Add(new EditOptions(isTree, strMilestoneTree, new campTreeMileStone(), bs_nwTreeMilestone, null, tbMilestones, true));
            Editors.Add(new EditOptions(isTree, strLocationTree, new campTreeLocation(), bs_nwTreeLocation, null, null, true));
            Editors.Add(new EditOptions(isTree, strStatTree, new sysTreeItemType(), bs_sysTreeStatistic, null, null, false));
            Editors.Add(new EditOptions(isTree, strItemTree, new sysTreeStatistic(), bs_sysTreeItemType, null, null, false));
            Editors.Add(new EditOptions(isTree, strFactionTree, new campTreeFaction(), bs_nwTreeFaction, null, null, false));
            Editors.Add(new EditOptions(isTree, strTerrainTree, new mapTreeTerrain(), bs_maptreeTerrain, null, null, false));
            this.LoadEditors(hostConstants.usrSysAdmin);
        }

        protected void refreshBindings() {
            //Bind Sources
            bs_sysAlignment.DataSource = sess.QueryOver<sysBaseAlignment>().List();
            bs_sysDamageType.DataSource = sess.QueryOver<sysBaseDamageType>().List();
            bs_sysTreeStatistic.DataSource = sess.QueryOver<sysTreeStatistic>().List();
            bs_nwTreeFaction.DataSource = sess.QueryOver<campTreeFaction>().List();
            bs_nwTreeLocation.DataSource = sess.QueryOver<campTreeLocation>().List();
            bs_sysTreeItemType.DataSource = sess.QueryOver<sysTreeItemType>().List();
            bs_maptreeTerrain.DataSource = sess.QueryOver<mapTreeTerrain>().List();
            //bs_sysTerrainType.DataSource = sess.QueryOver<sysTerrainType>().List();
            bs_sysAOE.DataSource = sess.QueryOver<sysAOEType>().List();
            bs_sysMilestoneType.DataSource = sess.QueryOver<sysMilestoneType>().List();
            bs_sysTreeDevelopment.DataSource = sess.QueryOver<sysTreeDevelopment>().List();
            bs_sysFactionRanking.DataSource = sess.QueryOver<sysFactionRanking>().List();
            bs_nwTreeMilestone.DataSource = sess.QueryOver<campTreeMileStone>().List();
            bs_sysDmgRoll.DataSource = sess.QueryOver<sysDamageRoll>().List();
            bs_hostUser.DataSource = sess.QueryOver<hostUserType>().List();
            // [[TODO: Change Where Clause]]
            bs_DamageRoll_PerLevel.DataSource = sess.QueryOver<sysBaseStatistic>().Where(tx => tx.StatisticGroup.Id == 79).List();
            bs_Duration.DataSource = sess.QueryOver<sysBaseDurationType>().List();
            bs_sysMilestoneTypeFKey.DataSource = sess.QueryOver<sysMilestoneType>().List();
            bs_sysPOI.DataSource = sess.QueryOver<mapPOIType>().List();
            bs_sysLanguage.DataSource = sess.QueryOver<sysLanguage>().List();
        }

        protected void PaintTree()
        {
            tboxTreeName.Text = "";
            lblTreeID.Text = "";
            refreshBindings();
            tabData.SelectedTab = tbTree;
            switch (cEditor.Description)
            {
                case strStatTree:
                    treeman.FillTreeNodeCollection<sysTreeStatistic>(sess, treeData.Nodes);
                    break;
                case strItemTree:
                    treeman.FillTreeNodeCollection<sysTreeItemType>(sess, treeData.Nodes);
                    break;
                case strDevType:
                    treeman.FillTreeNodeCollection<sysTreeDevelopment>(sess, treeData.Nodes);
                    break;
                case strMilestoneTree:
                    treeman.FillTreeNodeCollection<campTreeMileStone>(sess, treeData.Nodes);
                    break;
                case strFactionTree:
                    treeman.FillTreeNodeCollection<campTreeFaction>(sess, treeData.Nodes);
                    break;
                case strLocationTree:
                    treeman.FillTreeNodeCollection<campTreeLocation>(sess, treeData.Nodes);
                    break;
                case strTerrainTree:
                    treeman.FillTreeNodeCollection<mapTreeTerrain>(sess, treeData.Nodes);
                    break;
                default:
                    break;
            }
            
            tboxTreeName.DataBindings.Clear();
            tboxTreeName.DataBindings.Add(cEditor.bindName);
            lblTreeID.DataBindings.Clear();
            lblTreeID.DataBindings.Add(cEditor.bindID);
            treeData.ExpandAll();
            if (cEditor.tabControl != null)
            {
                tabTree.Enabled = true;
                tabTree.Visible = true;
                tabTree.SelectedTab = cEditor.tabControl;
            }
            else
            {
                tabTree.Enabled = false;
                tabTree.Visible = false;
            }

        }

        protected void PaintMasterDetail()
        {
            tabData.SelectedTab = tbMasterDetail;
            bool isTree = true;

            switch (cEditor.Description)
            {
                case strStatGroup:
                    treeman.FillTreeNodeCollection<sysTreeStatistic>(sess, treeMasterDetail.Nodes);
                    break;
                case strDevType:
                    treeman.FillTreeNodeCollection<sysTreeDevelopment>(sess, treeMasterDetail.Nodes);
                    break;
                case strItemType:
                    treeman.FillTreeNodeCollection<sysTreeItemType>(sess, treeMasterDetail.Nodes);
                    break;
                case strMilestones:
                    treeman.FillTreeNodeCollection<campTreeMileStone>(sess, treeMasterDetail.Nodes);
                    break;
                case strFactions:
                    treeman.FillTreeNodeCollection<campTreeFaction>(sess, treeMasterDetail.Nodes);
                    break;
                case strLocations:
                    treeman.FillTreeNodeCollection<campTreeLocation>(sess, treeMasterDetail.Nodes);
                    break;
                case mapTerrainTypes:
                    treeman.FillTreeNodeCollection<mapTreeTerrain>(sess, treeMasterDetail.Nodes);
                    break;
                default:
                    //This is the not treeman use case - i.e a master detail controlled by binding source current changed
                    lboxMaster.DataSource = cEditor.BindingSource;
                    lboxMaster.BringToFront();
                    isTree = false;
                    break;
            }
            //For tree mode, birng to front, else let lbox be in front
            if (isTree) { treeMasterDetail.BringToFront(); }

            lboxMDDetails.DataSource = cEditor.Detail.BindingSource;
            tboxMasterDetailLongName.DataBindings.Clear();
            tboxMasterDetailLongName.DataBindings.Add(cEditor.Detail.bindLongName);
            tboxMasterDetailName.DataBindings.Clear();
            tboxMasterDetailName.DataBindings.Add(cEditor.Detail.bindName);
            lblMasterDetailID.DataBindings.Clear();
            lblMasterDetailID.DataBindings.Add(cEditor.Detail.bindID);
            if (cEditor.Detail.tabControl != null)
            {
                tabMDGboxes.Enabled = true;
                tabMDGboxes.Visible = true;
                tabMDGboxes.SelectedTab = cEditor.Detail.tabControl;
            }
            else
            {
                tabMDGboxes.Enabled = false;
                tabMDGboxes.Visible = false;
            }
            UpdateMasterDetailPath();

        }

        protected void PaintTable() {
            //refreshBindings();

            lblDetailID.Text = "";
            tboxDetailLongName.Text="";
            tboxDetailName.Text = "";
            
            
            tabData.SelectedTab = tbDetail;
            lboxDetailOnly.DataSource = cEditor.BindingSource;
            
            tboxDetailLongName.DataBindings.Clear();
            tboxDetailLongName.DataBindings.Add(cEditor.bindLongName);

            tboxDetailName.DataBindings.Clear();
            tboxDetailName.DataBindings.Add(cEditor.bindName);
            lblDetailID.DataBindings.Clear();
            lblDetailID.DataBindings.Add(cEditor.bindID);
            tbDetail.Refresh();
            if (cEditor.tabControl != null)
            {
                tabDetail.Enabled = true;
                tabDetail.Visible = true;
                tabDetail.SelectedTab = cEditor.tabControl;
                            }
            else
            {
                tabDetail.Enabled = false;
                tabDetail.Visible = false;
            }
            tbDetail.Refresh();
        }

        protected virtual void SetMessage(string msg)
        {
            tboxMsg.Text = msg;
            Debug.Print(msg);
        }

        protected void LoadEditor()
        {
            if (lboxSystemTables.SelectedIndex == -1) { return; }
            //Hide current editor
       
            cEditor = lboxSystemTables.Items[lboxSystemTables.SelectedIndex] as EditOptions;
            switch (cEditor.tabType)
            {
                case isTable:
                    SetMessage("Set Table");
                    PaintTable();

                    break;
                case isTree:
                    SetMessage("Set tree");
                    PaintTree();
                    
                    break;
                case isMasterDetail:
                    SetMessage("Set MasterDetail");
                    PaintMasterDetail();
                    break;
                default:
                    SetMessage("TAB Type Error for"+cEditor.Description);
                    break;
            }
            
            switch (cEditor.Description)
            {
                case strAlign:
                    SetMessage("Load Alignments");
                    break;
                case strDevType:
                    SetMessage("Load DevTypes");
                    break;
                 


            }
        }

        private void frmSysDesigner_Load(object sender, EventArgs e)
        {
            tabDetail.Visible = false;
            Bitmap bg = new Bitmap(picTerrain.Width, picTerrain.Height);
            using (Graphics g = Graphics.FromImage(bg))
            {
                g.FillRectangle(Brushes.White, 0, 0, bg.Width, bg.Height);
            }
            picTerrain.ClientSize = new Size(bg.Width, bg.Height);
            picTerrain.Image = (Image)bg;

            Size s = new Size(picTerrain.Width, picTerrain.Height);
            

            HexGridPath.AddLines(new Point[] {
	                    new Point(s.Width*2/4   ,           0),
	                    new Point(s.Width*4/4-1   ,s.Height*1/4),
	                    new Point(s.Width*4/4-1   ,s.Height*3/4),
	                    new Point(s.Width*2/4   ,s.Height*4/4),
	                    new Point(0             ,s.Height*3/4),
	                    new Point(0             ,s.Height*1/4),
	                    new Point(s.Width*2/4   ,           0)
	                });

            HexGridRect.AddRectangle(new Rectangle(0, 0, (int)s.Width, (int)s.Height));
        }

        private void btnMasterRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnInitData_Click(object sender, EventArgs e)
        {
            //Repository.SeedMockData();

            DialogResult result = MessageBox.Show(
                "Confirm Complete Data Refresh?",
                "You are about to recreate all records, only do so if databae has been deleted , OK to proceed?",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) { Repository.SeedMockData(); }
        }

        private void btnGlobalQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lboxSystemTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEditor();

        }

        private void lblDetailID_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cEditor.BindingSource.AddNew();
        }

        private void btnDetailRemove_Click(object sender, EventArgs e)
        {
            nwdbDataType nwRecord = cEditor.BindingSource.Current as nwdbDataType;
            if (nwRecord == null) { return; }
            DialogResult result = MessageBox.Show(
                "Confirm Master Record Deletion?", 
                "You are about to delete"+nwRecord.LongName+" this will delete all child records, OK to proceed?",
                MessageBoxButtons.OKCancel);

            if ( result == DialogResult.OK)
                {
                    Repository.Delete(nwRecord);
                    refreshBindings(); //force cascades to load
                    LoadEditor();
                }
        }

        private void btnDetailSave_Click(object sender, EventArgs e)
        {
            // Scan through whole table
            foreach (nwdbDataType nw in cEditor.BindingSource.List)
            {
                SetMessage("Saving" + nw.ToString());
                Repository.Save(nw);
            }
        }

        private void treeData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nwdbTree st = treeData.SelectedNode.Tag as nwdbTree;
            lblTreePath.Text = st.Path(" \\ ");
            cEditor.BindingSource.Position = cEditor.BindingSource.IndexOf(st);
        }

        private void lblTreePath_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMasterAdd_Click(object sender, EventArgs e)
        {
            nwdbTree nodeparent;
            string nodename;
            nwdbTree node;
            TreeNode tn;

            nodename = Microsoft.VisualBasic.Interaction.InputBox("Create Node", "Enter name of node to create under current selected", "Name", 200,400);

            // dont refresh whole list, just add in and select
            //Create new record and node
            tn = new TreeNode(nodename);

            //prevent firing updates
            cEditor.BindingSource.SuspendBinding();
            node = cEditor.BindingSource.AddNew() as nwdbTree;
            tn.Tag = node;
            node.Name = nodename;

            //determine if root add (Parent ==null, or no selected), or subnode add
            if (treeData.SelectedNode != null)
            {
                nodeparent = treeData.SelectedNode.Tag as nwdbTree;
                treeData.SelectedNode.Nodes.Add(tn);
            }
            else
            {
                nodeparent = null;
                treeData.Nodes.Add(tn);
            }
            node.Parent = nodeparent;
            cEditor.BindingSource.ResumeBinding();
            treeData.SelectedNode = tn;

        }

        private void bs_sysItemType_CurrentItemChanged(object sender, EventArgs e)
        {
            sysTreeItemType it;
            TreeNode tn;
            tn = treeData.SelectedNode;
            it = bs_sysTreeItemType.Current as sysTreeItemType;

            //Check for edits in the etxtbox and upate the specific node if changed
            if (tn != null && it != null) {
                if (tn.Text != it.Name) {
                    SetMessage("ERROR Node + BindingSource dont match!!!! NodeName:" + tn.Text + "  bsName:" + it.Name);
                    tn.Text = it.Name;
                }
                else {  SetMessage("FINE Node + BindingSource match" );}
            }
        }

        private void btnMasterSave_Click(object sender, EventArgs e)
        {

        }

        private void btnGlobalSave_Click(object sender, EventArgs e)
        {
            foreach (object nw in cEditor.BindingSource.List)
            {
                SetMessage("Saving" + nw.ToString());
                if (nw.GetType() == typeof(nwdbDataType))
                {
                    Repository.Save(nw as nwdbDataType);
                }
                else
                {
                    sess.SaveOrUpdate(nw);
                }
            }
            sess.Flush();

            
        }

        private void btnTreeRemove_Click(object sender, EventArgs e)
        {
            nwdbTree it;
            nwdbTree parent;
            TreeNode tn;

            tn = treeData.SelectedNode;
            it = cEditor.BindingSource.Current as nwdbTree;
            
            
            //Delete from parent
            parent = it.Parent ;
            if (parent != null)
            {
                parent.RemoveChild(it);
            }

            if (tn == null || it == null) { SetMessage("Error in remove non selected or current"); return; }
            //bs_sysItemType.Remove(it);
            //sess.Delete(it);
            cEditor.BindingSource.SuspendBinding();
            using (ITransaction transaction = sess.BeginTransaction())
            {
                sess.Delete(it);
                transaction.Commit();
            }
            //cascade in node
            foreach(TreeNode n in tn.Nodes) {
                        it = n.Tag as nwdbTree;
                        Debug.Print("Removing:" + it.Name);
                        cEditor.BindingSource.Remove(it);
                        //sess.Delete(it);
                
                    }
                    it = tn.Tag as nwdbTree;
                    Debug.Print("Removing:" + it.Name);
                    cEditor.BindingSource.Remove(it);
                    
            
            treeData.Nodes.Remove(tn);
            treeData.SelectedNode = null;
            tboxTreeName.Text = "";
            lblTreeID.Text = "";
            cEditor.BindingSource.ResumeBinding();
            //repaint
            //PaintTree();
        }

        private void treeData_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetMessage("Called control removed Sender" + sender.ToString() + "args:" + e.ToString());
        }

        private void tbDetail_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bs_sysTreeDevelopment_CurrentChanged(object sender, EventArgs e)
        {
            
            sysTreeDevelopment n = bs_sysTreeDevelopment.Current as sysTreeDevelopment;
            if (n != null )
            {
                bs_sysDevelopment.DataSource = n.Paths;
            }
        }

        private void treeMasterDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nwdbTree st = treeMasterDetail.SelectedNode.Tag as nwdbTree;
            lblMasterPath.Text = st.Path(" \\ ");
            cEditor.BindingSource.Position = cEditor.BindingSource.IndexOf(st);
            UpdateMasterDetailPath();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add 1;

        }

        private void lboxDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxMDDetails.SelectedIndex != -1 && treeMasterDetail.SelectedNode != null)
            {
                UpdateMasterDetailPath();

            }
        }

        private void UpdateMasterDetailPath()
        {
            nwdbTree cat;
            switch (cEditor.Description)
            {
                
                case strDevType:
                    if (bs_sysDevelopment.Current != null)
                    {
                        sysDevelopment sd = bs_sysDevelopment.Current as sysDevelopment;
                        cat = sd.DevelopmentGroup;
                        lblMasterPath.Text = cat.Path("\\") + "\\" + sd.Name;
                    }
                    break;
                case strStatGroup:
                    if (bs_sysStatistic.Current != null) 
                    { 
                        sysBaseStatistic st = bs_sysStatistic.Current as sysBaseStatistic;
                        cat = st.StatisticGroup;
                        lblMasterPath.Text = cat.Path("\\") + "\\" + st.Name;
                    }
                    break;
                case strMilestoneTree:
                    if (bs_nwMilestone.Current != null) 
                    {
                        campMilestone sm = bs_nwMilestone.Current as campMilestone;
                        cat = sm.Type;
                        lblMasterPath.Text = cat.Path("\\") + "\\" + sm.Name;
                    }
                    break;
            }
            //;
        }

        private void bs_sysStat_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_sysStatistic.Current == null) { return; }
            sysBaseStatistic st = bs_sysStatistic.Current as sysBaseStatistic;
            bs_statStacking.DataSource = st.StackingTypes;
            }

        private void bs_sysTreeStatistic_CurrentChanged(object sender, EventArgs e)
        {
            sysTreeStatistic n = bs_sysTreeStatistic.Current as sysTreeStatistic;
            bs_sysStatistic.DataSource = n.Statistics;
            Debug.Print("Set Statistics for:" + n.Name + " to" + n.Statistics.Count.ToString());
        }
        

        private void bs_sysStat_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnMDChangePath_Click(object sender, EventArgs e)
        {
            
            switch (cEditor.Description)
            {

                case strDevType:
                    sysDevelopment sd = bs_sysDevelopment.Current as sysDevelopment;
                    sysTreeDevelopment selected = treeman.Select<sysTreeDevelopment>(sess, sd.DevelopmentGroup) as sysTreeDevelopment;
                    sysTreeDevelopment original = sd.DevelopmentGroup;
                    if (selected != sd.DevelopmentGroup) { 
                        sd.DevelopmentGroup = selected;
                        //Repository.Save(sd);
                        //UpdateMasterDetailPath();
                        original.Paths.Remove(sd);
                        selected.Paths.Add(sd);
                        treeMasterDetail.SelectedNode = treeMasterDetail.Nodes[treeMasterDetail.Nodes.IndexOfKey(selected.Name)];
                        lboxMDDetails.SelectedIndex = lboxMDDetails.FindStringExact(sd.LongName);
                        //PaintMasterDetail();
                    }
                    break;
                case strStatGroup:
                    sysBaseStatistic st = bs_sysStatistic.Current as sysBaseStatistic;
                    sysTreeStatistic sel = treeman.Select<sysTreeStatistic>(sess, st.StatisticGroup) as sysTreeStatistic;
                    sysTreeStatistic orig = st.StatisticGroup; 
                    if (sel != st.StatisticGroup)
                    {
                        st.StatisticGroup = sel;
                        //Repository.Save(st);
                        //UpdateMasterDetailPath();
                        //refreshBindings();
                       
                        orig.Statistics.Remove(st);
                        sel.Statistics.Add(st);
                        treeMasterDetail.SelectedNode = treeMasterDetail.Nodes[treeMasterDetail.Nodes.IndexOfKey(sel.Name)];
                        lboxMDDetails.SelectedIndex = lboxMDDetails.FindStringExact(st.LongName);
                        //PaintMasterDetail();

                    }
                    break;
            }
        }

        private void bs_sysTreeItemType_CurrentChanged(object sender, EventArgs e)
        {
            sysTreeItemType n = bs_sysTreeItemType.Current as sysTreeItemType;
            bs_sysItemType.DataSource = n.Items;
        }

       

        private void lboxDetailOnly_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bs_nwTreeMilestoneType_CurrentChanged(object sender, EventArgs e)
        {
            campTreeMileStone n = bs_nwTreeMilestone.Current as campTreeMileStone;

            if (n != null)
            {
                bs_nwMilestone.DataSource = n.Milestones;
            }
        }

        private void bs_nwTreeFaction_CurrentChanged(object sender, EventArgs e)
        {
            campTreeFaction n = bs_nwTreeFaction.Current as campTreeFaction;
            bs_nwFaction.DataSource = n.Factions;
        }

        private void bs_nwTreeLocation_CurrentChanged(object sender, EventArgs e)
        {
            campTreeLocation n = bs_nwTreeLocation.Current as campTreeLocation;
            bs_nwFaction.DataSource = n.Hexes;
        }

        private void lboxImpersonate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxImpersonate.SelectedIndex == -1) { return; }
            LoadEditors(lboxImpersonate.Text);
        }

        private void btnMDRemove_Click(object sender, EventArgs e)
        {
            nwdbDataType sd;
            if (lboxMDDetails.SelectedIndex == -1)
            {
                SetMessage("Nothing Selected");
            }
            else
            {
                sd = lboxMDDetails.SelectedItem as nwdbDataType;
                cEditor.Detail.BindingSource.Remove(sd);
                SetMessage("Deleted "+sd.ToString());
            }
        }

        private void btnMDAdd_Click(object sender, EventArgs e)
        {
            switch (cEditor.Description)
            {
                case strDevType:
                    sysTreeDevelopment sd = bs_sysTreeDevelopment.Current as sysTreeDevelopment;
                    if (sd != null)
                    {
                        sysDevelopment newdev = new sysDevelopment("", "", sd);
                        bs_sysTreeDevelopment_CurrentChanged(this,null);
                        bs_sysDevelopment.ResetBindings(false);
                        bs_sysDevelopment.Position = bs_sysDevelopment.IndexOf(newdev);
                    }
                break;
                case strStatGroup:
                sysTreeStatistic st = bs_sysTreeStatistic.Current as sysTreeStatistic;
                    if (st != null)
                    {
                        sysBaseStatistic newstat = new sysBaseStatistic("", "",st);
                        bs_sysTreeStatistic_CurrentChanged(this, null);
                        bs_sysStatistic.ResetBindings(false);
                        bs_sysStatistic.Position = bs_sysStatistic.IndexOf(newstat);
                    }
                break;

            }
        }

        private void bs_DamageRoll_PerLevel_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            //Repository.CreateTerrains();
            //Repository.CreatePOIs();
            //Repository.CreateLanguages();
            //Repository.CreateTreeMap();
        }

        private void gboxterrain_Enter(object sender, EventArgs e)
        {

        }

        private void SetTerrainImage(mapTerrainType s)
        {
            //if (this.picTerrain.Image != null) this.picTerrain.Dispose();
            //if (s == null) { return; }
            //Bitmap newImage = new Bitmap(picTerrain.Width,picTerrain.Height);
            //s.PrintHex(newImage);
            //this.picTerrain.Image = (Image)newImage;
            //this.picTerrain.Refresh();
            this.picTerrain.Invalidate();




        }

        private void bs_sysTerrainType_CurrentChanged(object sender, EventArgs e)
        {
            mapTerrainType s = bs_sysTerrainType.Current as mapTerrainType;
            SetTerrainImage(s);
        }

        private void btnMDSaveDetail_Click(object sender, EventArgs e)
        {
            switch (cEditor.Description)
            {
                case strDevType:
                    sysDevelopment sd = bs_sysDevelopment.Current as sysDevelopment;
                    if (sd != null) { this.Repository.Save(sd); }
                    break;
                case strStatGroup:
                    sysBaseStatistic st = bs_sysStatistic.Current as sysBaseStatistic;
                    if (st != null) { this.Repository.Save(st); }
                    break;
            }
        }

        private void picTerrain_Paint(object sender, PaintEventArgs e)
        {
            mapTerrainType st = bs_sysTerrainType.Current as mapTerrainType;
            if (st == null) { return; }
            st.SetBrush(new Size((int)e.ClipRectangle.Width, (int)e.ClipRectangle.Height), false);


            e.Graphics.DrawPath(Pens.Black, HexGridPath);
            if (st.brBackground == null)
            {
                Debug.Print("No background for Terrain" + st.LongName);
            }
            else
            {
                e.Graphics.FillPath(st.brBackground, HexGridPath);
            }
            if (st.brForeground == null)
            {
                Debug.Print("No Foreground for Terrain" + st.LongName);
            }
            else
            {
                e.Graphics.FillPath(st.brForeground, HexGridRect);
            }
        }

        private void picTerrain_Click(object sender, EventArgs e)
        {

        }

        private void picPOI_Paint(object sender, PaintEventArgs e)
        {
            mapPOIType sp = bs_sysPOI.Current as mapPOIType;
            if (sp == null) { return; }
            sp.SetBrush(new Size((int)e.ClipRectangle.Width, (int)e.ClipRectangle.Height), false);


            e.Graphics.DrawPath(Pens.Black, HexGridPath);
            if (sp.brForeground == null)
            {
                Debug.Print("No Foreground for Terrain" + sp.LongName);
            }
            else
            {
                e.Graphics.FillPath(sp.brForeground, HexGridRect);
            }
        }

        private void bs_sysPOI_CurrentChanged(object sender, EventArgs e)
        {
            picPOI.Invalidate();
        }

        private void chkMandatoryChar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bs_maptreeTerrain_CurrentChanged(object sender, EventArgs e)
        {
            mapTreeTerrain n = bs_maptreeTerrain.Current as mapTreeTerrain;
            bs_sysTerrainType.DataSource = n.TerrainTypes;
        }

        private void bs_nwFaction_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
