using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using norwold.model;
using System.Data.Common;
using System.Data.SqlClient;
using NHibernate;
using DataModel.libDB;

namespace norwold.forms
{
    public partial class frmSelectTree : Form
    {
        public frmSelectTree()
        {
            InitializeComponent();
            

        }
        public TreeNodeCollection GetTreeNodes() { return treeSelect.Nodes; }
        public nwdbTree Selected { get; set; }
        public ISession Session { get; set; }
        public sysTreeManager TreeManager { get; set; }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            this.Selected = treeSelect.SelectedNode.Tag as nwdbTree; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Selected = null;
        }

        private void frmTreeSelect_Load(object sender, EventArgs e)
        {
            this.treeSelect.ExpandAll();
            if (Selected != null)
            {
                TreeNode[] cNodes = treeSelect.Nodes.Find(Selected.Name, true);
                if (cNodes.GetLength(0) > 0)
                {
                    treeSelect.SelectedNode = cNodes[0];
                }
            }
        }

        private void treeSelect_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nwdbTree st = treeSelect.SelectedNode.Tag as nwdbTree;
            lblPath.Text = st.Path("\\");
        }

        private void treeSelect_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // only leafs are selectable not branches
            if (e.Node.Nodes.Count > 0)
            {
                e.Cancel = true;
            }
        }
    }
}
