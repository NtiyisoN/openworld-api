using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using norwold.model;
using System.Data.Common;
using System.Data.SqlClient;
using NHibernate;
using DataModel.libHosting;


namespace norwold.forms
{
    public partial class frmSelectPlayers : Form
    {

        /**
         * Create, Pass List into player
         * Show Form
         * Read players as the result
         * Dispose
         * 
         * */


        public frmSelectPlayers()
        {
            InitializeComponent();
            _players = new List<hostChar>();

        }

        private IList<hostChar> _players;

        public IList<hostChar> Players { 
            get { return this._players; } 
            set { this._players = value; } 
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this._players.Clear();
            foreach(hostChar c in chklboxPlayers.CheckedItems) {
                this._players.Add(c);
            }
            Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._players.Clear();
            Close();
        }

        private void frmPlayers_Load(object sender, EventArgs e)
        {

        }

        private void frmSelectPlayers_Load(object sender, EventArgs e)
        {
            Debug.Print("Calling Load with a starting list of:"+this._players.Count().ToString());
            foreach (hostChar c in this._players)
            {
                chklboxPlayers.Items.Add(c);
            }
        }

        
    }
}
