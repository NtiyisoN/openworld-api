using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DataModel.libHosting;
using norwold.model;
using DataModel.libDB;

namespace norwold.forms
{
    public partial class FrmDevelopment : norwold.forms.frm_nwBase
    {
        public FrmDevelopment()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            bool bClosed = chkClosed.Checked;
            string bFiltered = lboxFilter.Text;
            
            switch (bFiltered)
            {
                case "ALL": case "":
                    if (!bClosed) {
                        bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Closed == false).OrderBy(x => x.Version).Asc.List();
;
                    } else {
                        bs_Development.DataSource = sess.QueryOver<hostDevelopment>().OrderBy(x => x.Version).Asc.List();
                    }
                break;

                case "Features":
                if (!bClosed)
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Closed == false).And(x => x.Type == hostConstants.devtypeFeature).OrderBy(x => x.Version).Asc.List();
                }
                else
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Type == hostConstants.devtypeFeature).OrderBy(x => x.Version).Asc.List();
                }
                break;

                case "Bugs":
                if (!bClosed)
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Closed == false).And(x => x.Type == hostConstants.devtypeBugs).OrderBy(x => x.Version).Asc.List();
                }
                else
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Type == hostConstants.devtypeBugs).OrderBy(x => x.Version).Asc.List();
                }
                break;

                case "RoadMap":
                if (!bClosed)
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Closed == false).And(x => x.Type == hostConstants.devtypeRoadMap).OrderBy(x => x.Version).Asc.List();
                }
                else
                {
                    bs_Development.DataSource = sess.QueryOver<hostDevelopment>().Where(x => x.Type == hostConstants.devtypeRoadMap).OrderBy(x => x.Version).Asc.List();
                }
                break;
               default:
                SetMessage("Error in switch");
                   break;
            }

            bs_UserEvents.DataSource = sess.QueryOver<hostUserEvent>().OrderBy(x => x.DateOccured).Desc.Take(200).List();
            dataGridView2.Refresh();



        }

        private void DumptoDesktop(string fn)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView1.SelectAll();
            // Copy (set clipboard)
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
            // Paste (get the clipboard and serialize it to a file)
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\openworld_devlist.csv", Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
        }

        private void FrmDevelopment_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bs_Development.SuspendBinding();
            //save dev stuff
            foreach (hostDevelopment hd in bs_Development.List)
            {
                if (hd.LongName == null && hd.LongName == null || hd.Version == null) { Debug.Print("Null Record in Grid, skipping");  return; }
                this.Repository.Save(hd);
                SetMessage("Saving " + hd.LongName);
            }
            bs_Development.ResumeBinding();
            LoadData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnSave_Click(this,null);
            LoadData();
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridViewRow oDGVR = this.dataGridView1.Rows[e.RowIndex];
                hostDevelopment hd = oDGVR.DataBoundItem as hostDevelopment;

                if (oDGVR.Cells[1].Value == null || oDGVR.Cells[1].Value.ToString() == "")
                {
                    Debug.Print("Type is Not Letter!!!");
                    oDGVR.Cells[1].Value = hostConstants.devtypeBugs;
                }
                else
                {
                    if (oDGVR.Cells[1].Value.ToString() != hostConstants.devtypeBugs && oDGVR.Cells[1].Value.ToString() != hostConstants.devtypeFeature && oDGVR.Cells[1].Value.ToString() != hostConstants.devtypeRoadMap)
                    {
                        //force to BUG
                        Debug.Print("Type is not Release ,Bug ,Feature!!! - Setting to BUG");
                        oDGVR.Cells[1].Value = hostConstants.devtypeBugs;
                    }
                }
                if (hd == null) { return; }
                if (hd.Created == DateTime.MinValue) { hd.Created = DateTime.Now; }
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                SetMessage("Failed to validate, caught exception:"+ex.ToString());
                e.Cancel = true;
            }
        }

        private void lboxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bs_Development_AddingNew(object sender, AddingNewEventArgs e)
        {
            // Handles the Create Empty, click off, create 2nd blank behaviour
            if (dataGridView1.Rows.Count == bs_Development.Count)
            {
                bs_Development.RemoveAt(bs_Development.Count - 1);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DumptoDesktop("");
            SetMessage("Exported current List to Desktop as Openworld_devlist");
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            hostDevelopment hd = e.Row.DataBoundItem as hostDevelopment;
            if (hd != null)
            {
                bs_Development.Remove(hd);
                sess.Delete(hd);
            }

        }
    }
}
