using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using System.Threading.Tasks;
using Brandy.Grapes.FluentNHibernate;
using Brandy.Grapes;
using System.Windows.Forms;
using norwold.model;
using DataModel.libDB;


namespace norwold.forms
{
    public class sysTreeManager
    {
        
        public sysTreeManager()
        {
        }

        //GetRootBranches
        public IList<T> GetRootBranches<T>(ISession i) where T : class
        {
           return i.CreateCriteria<T>()
               .Add(Expression.IsNull("Parent"))
               .List<T>();
        }


        protected void recurseAddChildren(nwdbTree t, TreeNode tn)
        {
            TreeNode child; 
            foreach (nwdbTree leaf in t.Children)
            {
                child = new TreeNode(leaf.Name);
                child.Tag = leaf;
                child.Name = leaf.Name;
                Debug.Print("Adding Child: "+ child.Name + "to leaf"+leaf.Name);
                recurseAddChildren(leaf, child);
                Debug.Print("Finished child: " + child.Name);
                tn.Nodes.Add(child);
            }
        }
        
        protected void recurseDeleteChildren(nwdbTree t, TreeNode tn,TreeNodeCollection tnc ,BindingSource bs)
        {
            
        }

        public void FillTreeNodes<T>(BindingSource b, TreeNodeCollection tnc) where T : nwdbTree
        {
            TreeNode tn;
            IList<T> rootbranches = new List<T>();
            foreach(nwdbTree trec in b.List) {
                if (trec.Parent == null)
                { 
                //Add those nodes
                    tn = new TreeNode(trec.Name);
                    tn.Tag = trec;
                    tn.Name = trec.Name;
                    recurseAddChildren(trec, tn);
                }
            }

           

        }
        public void FillTreeNodeCollection<T>(ISession i, TreeNodeCollection tnc) where T : nwdbTree
        {
            TreeNode tn;
            
            IList<T> rootbranches;

            tnc.Clear();
            rootbranches = GetRootBranches<T>(i);
            foreach (nwdbTree branch in rootbranches)
            {
                tn = new TreeNode(branch.Name);
                tn.Tag = branch;
                tn.Name = branch.Name;
                recurseAddChildren(branch, tn);
                
                
                tnc.Add(tn);
            }
        }

        public nwdbTree Select<T>(ISession i, nwdbTree current) where T : nwdbTree
        {
            frmSelectTree frm = new frmSelectTree();
            frm.Selected = current;
            frm.Session = i;
            frm.TreeManager = this;
            this.FillTreeNodeCollection<T>(i, frm.GetTreeNodes());

            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.Selected;
            }
            else
            {
                return current;
            }
           
        }

    }
}
