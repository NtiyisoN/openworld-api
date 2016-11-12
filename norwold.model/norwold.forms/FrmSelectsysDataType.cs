using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using norwold.model;
using DataModel.libDB;

namespace norwold.forms
{
    public partial class FrmSelectsysDataType : Form
    {
        private IList<nwdbDataType> _list;
        public IList<nwdbDataType> List
        { 
            get { return this._list; } 
            set { this._list = value; } 
        }

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

         public FrmSelectsysDataType()
        {
            InitializeComponent();
            _list = new List<nwdbDataType>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSelectnwSystemType_Load(object sender, EventArgs e)
        {
            foreach (nwdbDataType data in _list)
            {
                chklboxData.Items.Add(data);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this._list.Clear();
            foreach (nwdbDataType data in chklboxData.CheckedItems)
            {
                this._list.Add(data);
            }
            Close();
        }

        public static IList<nwdbDataType> Select (IList<nwdbDataType> i, string caption,Form sender )
        {
            FrmSelectsysDataType frmSelect = new FrmSelectsysDataType();
            frmSelect.List = i;
            frmSelect.Title = caption;
            frmSelect.ShowDialog(sender);
            i = frmSelect.List;
            frmSelect.Dispose();
            return i;
        }
    }
}
