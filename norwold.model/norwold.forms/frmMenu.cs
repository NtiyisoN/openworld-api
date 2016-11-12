using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel.libHosting;

namespace norwold.forms
{
    public partial class frmMenu : Form
    {


        
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnSystemDesigner_Click(object sender, EventArgs e)
        {
            frmRuleSetDesigner frmSysDesign = new frmRuleSetDesigner();
            frmSysDesign.InitData();
            frmSysDesign.ShowDialog(this);
            frmSysDesign.Dispose();

        }

        private void btnCharacters_Click(object sender, EventArgs e)
        {
            frmCharacters frmChar = new frmCharacters();
            frmChar.initData();
            frmChar.ShowDialog(this);
            frmChar.Dispose();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUserManager frmUser = new frmUserManager();
            frmUser.ShowDialog(this);
            frmUser.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogon frmLogon = new FrmLogon();
            frmLogon.initFB();
            frmLogon.ShowDialog(this);
            frmLogon.Dispose();
        }

        private void btnCampaign_Click(object sender, EventArgs e)
        {
            frmCampaign frmCamp = new frmCampaign();
            frmCamp.ShowDialog(this);
            frmCamp.Dispose();
        }

        private void btnWorldDesigner_Click(object sender, EventArgs e)
        {
            FrmMapDesigner frmMap = new FrmMapDesigner();
            frmMap.InitData();
            frmMap.ShowDialog(this);
            frmMap.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDevelopment frmDev = new FrmDevelopment();
            frmDev.InitData();
            frmDev.ShowDialog(this);
            frmDev.Dispose();
        }
    }
}
