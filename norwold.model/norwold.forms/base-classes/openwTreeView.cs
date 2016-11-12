using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Brandy.Grapes;
using norwold.model;
using NHibernate;
using DataModel.libCampaign;
using DataModel.libMapping;
using DataModel.libDB;

namespace norwold.forms.base_classes
{

    /**
     * 
     * openwTreeView
     * 
     ******************************************
     *    Version Info                  *
     ******************************************
     * 0.1  SD      Initial draft
     * [TODO]
     * 0.2  SD      Add TreeListBoxSelect
     * 
      ******************************************
     *    Component Overview                  *
     ******************************************
     * This custom tree control works in 2 ways for basic tree load & Display
     * Control to provide a BrandyGrapes Tree for brnaches where the leaf nodes are an nwdbDataType
     * 
     * Utilises fixed string constants to determine tree root Name & Type (and crap switch logic for loading leafs [TODO])
     * see nwdbConst.TreeNames[], mapConst.TreeNames[], campConst.TreeNames
     * 
     * Created simply to encapsulate (and hide) the huge complexity in having 10 x Master/Detail linked BindingSources on Edit Forms
     * Also to handle the dynamic changing of the Bound Controls
     * (Need a ListBox version)
     * 
     * A)       Set SysTree Property to root of tree
     * B)       Set TreeBindingSource for tree nodes
     * 
     * Once tree is set , there are 3 Groups of optional controls:
     * 
     * *****************************************
     *    Behaviour Controls                   *
     * *****************************************
     * ListBoxTreeSelect    if set, then will capture the Listbox After Select event and load the tree based upon changes to the selection
     * _RootNode            Stores the fact that the Control has been set by a RootNode(Mode A) rather than TreeBindingSource(Mode B)
     * _currentTree         Holds the Constant Name fo the current Tree (also the root Node Name)
     * 
     * *****************************************
     *    Branch Editing Controls              *
     * *****************************************
     * TreeEditName         TextBox for editing the name of the tree branch
     * TreeEditValue        TextBox for editing the Value of the tree branch
     * TreeEditID           Label for Displaying the ID of the tree branch
     * TreeEditTreeName     Label for Displaying the Tree Name
     * 
     * *****************************************
     *    Detail/Leaf Editing Controls         *
     * *****************************************
     * DetailListBox        The control will manage a bindingsource to attach to the ListBox
     * DetailEditName       Textbox for nwdbDataType.Name of the DetailBindingSource
     * DetailEditLongName   Textbox for nwdbDataType.LongName of the DetailBindingSource
     * DetailEditID         Label for nwdbDataType.ID of the DetailBindingSource
     * DetailEditGroupBox   GroupBox for detail Editing, note that binding & creating is beyind scope of this control
     * 
     * *****************************************
     *  Managing the NHibernate Data LifeCycle *
     * *****************************************
     * Changes to bound controls are saved in cache automatically but whether they are flushed to db auto matically is handled below
     * 
     * AutoUpdateMode       Use carefully - this will flush changes to the NHibernate session automatically wheen tree is changed or disposed
     *                      Otherwise will only flush to the session if NHSaveTree Event is called (Saves Tree & Detail)
     * TreeEditMode         If True, then requires & enables (enabled = True) the Tree Edit ListBoxes 
     * 
     * DetailBindingSource  This exposes the Detail BindingSource for Add,Remove Functions & for capturing before/after validate
     * TreeBindingSoure     This exposes the Tree BindingSource for Add,Remove Functions & for capturing before/after validate
     * 
     * *****************************************
     *  Key Methods                            *
     * *****************************************
     * NHSaveTree           Flushes tree changes to the NHibernate Session
     * BindDetailControls   Allows rapid binding of DetailControls in one call
     * BindTreeControls     Allows rapid binding of TreeControls in one call
     * */


    public partial class openwTreeView : TreeView
    {
        //Locals
        private TreeEntry<nwdbTree> _sysTree;
        private ISession _sess;
        private String _currentTree;
        private TreeEntry<nwdbTree> _RootNode;

        private BindingSource _DetailBindingSource;
        private BindingSource _TreeBindingSource;
        private ListBox _DetailListBox;
        private ListBox _ListBoxTreeSelect;
        private bool _TreeEditMode;
        private bool _AutoUpdateMode = false;

        private TextBox _TreeEditName;
        //private TextBox _TreeEditValue;
        //private Label _TreeEditID;
        //private Label _TreeEditTreeName; 


        protected sysTreeManager treeman;

        //properties
        public TreeEntry<nwdbTree> nwdbTree { get { return this._sysTree; }  set { SetRootNode(value); } }
        public ISession Session { get { return this._sess; } set { this._sess = value; } }
        public String CurrentTree { get { return this._currentTree; } }

        public ListBox ListBoxTreeSelect { get { return this._ListBoxTreeSelect; } set { SetListBoxTreeSelect(value); } }
        public BindingSource DetailBindingSource { get { return this._DetailBindingSource; } set { SetDetailBindingSource(value); } }
        public BindingSource TreeBindingSource { get { return this._TreeBindingSource; } set { SetTreeBindingSource(value); } }

        public bool TreeEditMode { get { return this._TreeEditMode; } set { SetTreeEditMode(value); } }


        //Tree Properties
        public virtual TextBox TreeEditName { get { return this._TreeEditName; } set { this._TreeEditName = value; SyncTreeControls(); } }       // TextBox for editing the name of the tree branch
        public virtual TextBox TreeEditValue { get; set; }      // TextBox for editing the Valueof the tree branch
        public virtual Label TreeEditID { get; set; }           // Label for showing the ID of the tree branch
        public virtual Label TreeEditTreeName { get; set; }     // Label for showing the Name of the Tree

        //Detail Properties
        public virtual ListBox DetailListBox { get { return this._DetailListBox; } set { SetListBoxDetail(value); } }	    // The control will manage a bindingsource to attach to the ListBox
        public virtual TextBox DetailEditName { get; set; }	    // Textbox for binding Detail Name
        public virtual TextBox DetailEditLongName { get; set; }	// Textbox for binding Detail LongName
        public virtual Label DetailEditID { get; set; }		// Label for binding Detail ID
        public virtual GroupBox DetailGroupBox { get; set; }	// GroupBox for detail Editing, note that binding & creating is beyind scope of this control





        


        //ctors
        public openwTreeView()
        {
            InitializeComponent();
            this.treeman = new sysTreeManager();
            _currentTree = "";
        }

        public openwTreeView(ISession sess)
            : this()
        {
            this._sess = sess;
        }

        //GetterSetters
        protected void SetListBoxDetail(ListBox lbox)
        {
            this._DetailListBox = lbox;
            SyncDetailControls();
        }

        protected void SetListBoxTreeSelect(ListBox lboxTree)
        {
            this._ListBoxTreeSelect = lboxTree;
            //[TODO] Capture AfterSelect and set to LoadTreeByName;

        }


        //TODO Do we let this get Set??
        protected void SetDetailBindingSource(BindingSource detail)
        {
            if (this._DetailBindingSource == detail) { return; }
            this._DetailBindingSource = detail;

            SyncDetailControls();

        }

        protected void SetTreeEditMode(bool value)
        {
            this._TreeEditMode = value;
            SyncTreeControls();
        }

        protected void SetTreeBindingSource(BindingSource tree)
        {
            if (this._RootNode != null)
            {
                throw new ApplicationException("Error in TreControl:SetTreeBindingSource: use SetSystree or TreeBindingSource but not both");
            }
            
            if (this._TreeBindingSource == tree) { return; }
            this._TreeBindingSource = tree;
            TreeEntry<nwdbTree> t = tree.List.Cast<nwdbTree>().FirstOrDefault(n => n.Parent == null);
            this._sysTree = t;
            tree.CurrentChanged += defEventCurrentChanged;
            UpdateTree();
    
            //If DetailsListBox, SyncDetails
            if (this._DetailListBox != null) { SyncDetailControls(); }
        }

        protected void SetRootNode(TreeEntry<nwdbTree> t)
        {
            if (this._TreeBindingSource != null)
            {
                throw new ApplicationException("Error in Tree control:SetRootNode: use SetSystree or TreeBindingSource but not both");
            }

            this.Nodes.Clear();
            this._sysTree = t;
            this._RootNode = t;  //Captures that we are in SetBySysTreeMode , not BindingSource mode
            UpdateTree();
        }

        //methods

        protected virtual void BindTreeControls(TextBox tName, TextBox tValue, Label tID, Label tTreeName)
        {
            this.TreeEditName = tName;
            this.TreeEditValue = tValue;
            this.TreeEditID = tID;
            this.TreeEditTreeName = tTreeName;
            SyncTreeControls();
        }

        protected virtual void BindDetailControls(ListBox lDetail, TextBox tName, TextBox tLongName,Label lblID, GroupBox gDetail)
        {
            this.DetailListBox=lDetail;
            this.DetailEditName=tName;
            this.DetailEditLongName=tLongName;
            this.DetailEditID= lblID;
            this.DetailGroupBox = gDetail;
            SyncDetailControls();
                
        }

        protected virtual void SyncTreeControls()
        {
            if (this.TreeBindingSource != null)
            {
                if (this.TreeEditName != null) 
                {  if(this.TreeEditName.DataBindings.Count == 0 || this.TreeEditName.DataBindings[0].DataSource != this.TreeBindingSource)
                    {
                    this.TreeEditName.DataBindings.Clear();
                    this.TreeEditName.DataBindings.Add("Text", this.TreeBindingSource, "Name");
                    }
                }

                if (this.TreeEditValue != null) 
                {
                    if(this.TreeEditValue.DataBindings.Count == 0 || this.TreeEditValue.DataBindings[0].DataSource != this.TreeBindingSource)
                    {
                    this.TreeEditValue.DataBindings.Clear();
                    this.TreeEditValue.DataBindings.Add("Text", this.TreeBindingSource, "Value");
                    }
                }

                if (this.TreeEditID != null)
                {
                    if (this.TreeEditID.DataBindings.Count == 0 || this.TreeEditID.DataBindings[0].DataSource != this.TreeBindingSource)
                    {
                        this.TreeEditID.DataBindings.Clear();
                        this.TreeEditID.DataBindings.Add("Text", this.TreeBindingSource, "ID");
                    }
                }
            }

            //Set Tree Name
            if (this.TreeEditTreeName != null) { this.TreeEditTreeName.Text = this._currentTree; }
            

            //Set Enabled based upon EditMode
            if (this.TreeEditValue != null) { this.TreeEditValue.Enabled = this._TreeEditMode; }
            if (this.TreeEditID != null) { this.TreeEditID.Enabled = this._TreeEditMode; }
            if (this.TreeEditTreeName != null) { this.TreeEditTreeName.Enabled = this._TreeEditMode; }

        }

        protected virtual void SyncDetailControls()
        {
            if (this.DetailBindingSource != null)
            {
                if (this.DetailListBox != null)
                {
                    if (this.DetailListBox.DataSource != this.DetailBindingSource)
                    {
                        this.DetailListBox.DataSource = this.DetailBindingSource;
                        this.DetailListBox.DisplayMember = "LongName";
                        //this.DetailListBox.Tag = "ID";
                    }
                }

                if (this.DetailEditName != null)
                {
                    if (this.DetailEditName.DataBindings.Count == 0 || this.DetailEditName.DataBindings[0].DataSource != this.DetailBindingSource)
                    {
                        this.DetailEditName.DataBindings.Clear();
                        this.DetailEditName.DataBindings.Add("Text", this.DetailBindingSource, "Name");
                    }
                }


                if (this.DetailEditLongName != null)
                {
                    if (this.DetailEditLongName.DataBindings.Count == 0 || this.DetailEditLongName.DataBindings[0].DataSource != this.DetailBindingSource)
                    {
                        this.DetailEditLongName.DataBindings.Clear();
                        this.DetailEditLongName.DataBindings.Add("Text", this.DetailBindingSource, "LongName");
                    }
                }

                if (this.DetailEditID != null)
                {
                    if (this.DetailEditID.DataBindings.Count == 0 || this.DetailEditID.DataBindings[0].DataSource != this.DetailBindingSource)
                    {
                        this.DetailEditID.DataBindings.Clear();
                        this.DetailEditID.DataBindings.Add("Text", this.DetailBindingSource, "ID");
                    }
                }


                //CEditors & Hide & show [TODO]
                //this.DetailGroupBox = gDetail;

            }

        }

        public virtual void LoadByTreeName(String constTreeName)
        {
            
            String eMsg;
            if (this._sess == null) { throw new ApplicationException("Error in TreeControl:LoadbyTreeName: No Session"); }
            if (this._RootNode != null) { throw new ApplicationException("Error in TreeControl:LoadbyTreeName: Working in SetTreNodeMode"); }

            //Disposal
            if (this._currentTree != "")
            {
                if (this._AutoUpdateMode)
                {
                    try
                    {
                        this._sess.SaveOrUpdate(this._sysTree);
                    }
                    catch (Exception e)
                    {
                        eMsg = "Error Saving" + this._currentTree + " Caught Exception:" + e.Message;
                        Debug.Print(eMsg);
                        MessageBox.Show(eMsg);
                    }
                }
            }
            CreateBindings(constTreeName);
            
        }
        protected void CreateBindings(string constTreeName)
        {
            BindingSource bstree, bsdetail;
            switch (constTreeName)
            {
                case mapConst.mapTreeNamePOI:
                    bstree = new BindingSource();
                    bstree.DataSource = this._sess.QueryOver<mapTreePOI>().List();
                    //SetupDetail
                    bsdetail = new BindingSource();
                    bsdetail.DataSource = this._sess.QueryOver<mapPOIType>().List();
                    this._DetailBindingSource = bsdetail;
                    bstree.CurrentChanged += defEventCurrentChanged;
                    this.TreeBindingSource = bstree; //triggers the UpdateTree & detailChain
                    break;
                case mapConst.mapTreeNameTerrain:
                    bstree = new BindingSource();
                    bstree.DataSource = this._sess.QueryOver<mapTreeTerrain>().List();
                    //SetupDetail
                    bsdetail = new BindingSource();
                    bsdetail.DataSource = this._sess.QueryOver<mapTerrainType>().List();
                    bstree.CurrentChanged += defEventCurrentChanged;
                    this._DetailBindingSource = bsdetail;
                    this.TreeBindingSource = bstree; //triggers the UpdateTree & detailChain
                    break;
                case nwdbConst.sysTreeNameDevelopment:
                    //Do devStuff
                    break;
                case nwdbConst.sysTreeNameStatistic:
                    //Do StatStuff
                    break;
                case nwdbConst.sysTreeNameItemType:
                    //Do ItemStuff
                    break;
                case campConst.campTreeNameFaction:
                    //Do Faction Stuff
                    break;
                case campConst.campTreeNameLocation:
                    //Do LocationStuff
                    break;
                case campConst.campTreeNameMilestone:
                    //Do Milestone
                    break;
                default:
                    throw new ApplicationException("Error in TreeControl:LoadTreeByName:constTreeName is invalid:" + constTreeName);
            }
        }

        //Tree Loading
        protected void recurseAddChildren(nwdbTree t, TreeNode tn)
        {
            TreeNode child;
            foreach (nwdbTree leaf in t.Children)
            {
                child = new TreeNode(leaf.Name);
                child.Tag = leaf;
                child.Name = leaf.Name;
                Debug.Print("Adding Child: " + child.Name + "to leaf" + leaf.Name);
                recurseAddChildren(leaf, child);
                Debug.Print("Finished child: " + child.Name);
                tn.Nodes.Add(child);
            }
        }

 


        protected void UpdateTree()
        {
            TreeNode tn;
            nwdbTree nw;
            if (this._sysTree == null) { return; }
            //swap to simply adding by descendants,skip root so It can be deleted
            if (this._sysTree.Parent != null) { throw new ApplicationException("Error in TreeControl:UpdateTree, root is not root"); }

            //Update tree Name 
            nw = this._sysTree as nwdbTree;
            _currentTree = nw.Name;
            if (this.TreeEditTreeName != null) { this.TreeEditTreeName.Text = _currentTree; }


            //Load Tree
            foreach (nwdbTree branch in this._sysTree.Children)
            {
                tn = new TreeNode(branch.Name);
                tn.Tag = branch;
                tn.Name = branch.Name;
                recurseAddChildren(branch, tn);


                this.Nodes.Add(tn);
            }
            
            //Update Detail;
            SyncTreeControls();
            SyncDetailControls();

            //Make sure default eventhandler is in place
            this.AfterSelect -= this.defEventCurrentChanged;
            this.AfterSelect += this.defEventCurrentChanged;

        }

        //Events
        public virtual void defEventTreeAfterSelect(object sender, EventArgs e)
        {
            nwdbTree n = this.SelectedNode.Tag as nwdbTree;
            if (n != null)
            {
                if (this._TreeBindingSource != null)
                {
                    this._TreeBindingSource.Position = this._TreeBindingSource.IndexOf(n);
                }

            }
        }


        protected virtual void defEventCurrentChanged(object sender, EventArgs e)
        {
            switch (_currentTree)
            {
                case mapConst.mapTreeNamePOI:
                    mapTreePOI mP = this.TreeBindingSource.Current as mapTreePOI;
                    if (mP != null && this._DetailBindingSource != null) { this._DetailBindingSource.DataSource = mP.POITypes; } 
                    else { this._DetailBindingSource.List.Clear(); }
                    break;
                case mapConst.mapTreeNameTerrain:
                    mapTreeTerrain mT = this.TreeBindingSource.Current as mapTreeTerrain;
                    if (this._DetailBindingSource!=null) {
                       if  (mT != null) { this._DetailBindingSource.DataSource = mT.TerrainTypes; } 
                       else { this._DetailBindingSource.List.Clear(); }
                    }
                    break;
                case nwdbConst.sysTreeNameDevelopment:
                    //Do devStuff
                    break;
                case nwdbConst.sysTreeNameStatistic:
                    //Do StatStuff
                    break;
                case nwdbConst.sysTreeNameItemType:
                    //Do ItemStuff
                    break;
                case campConst.campTreeNameFaction:
                    //Do Faction Stuff
                    break;
                case campConst.campTreeNameLocation:
                    //Do LocationStuff
                    break;
                case campConst.campTreeNameMilestone:
                    //Do Milestone
                    break;
                case "":
                    Debug.Print("No tree Loaded");

                    break;
                default:
                    throw new ApplicationException("Error in TreeControl:defEventCurrentChanged:_currentTree is invalid:" + _currentTree);
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
