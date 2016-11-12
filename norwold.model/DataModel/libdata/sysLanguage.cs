using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libCampaign;
using DataModel.libDB;


namespace DataModel.libData
{
    [Serializable()]
    public class sysLanguage : nwdbDataType
    {
        public sysLanguage() : base() { Milestones = new List<campMilestone>(); }
        public sysLanguage(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        public virtual IList<campMilestone> Milestones { get; set; }

        public static void SeedListData(IList<sysLanguage> LangList) {

            LangList.Add(new sysLanguage("Common", "Common Tongue"));
            LangList.Add(new sysLanguage("Theives", "Theives Cant"));
            LangList.Add(new sysLanguage("UWorld", "Underworld"));
            LangList.Add(new sysLanguage("Human", "Human"));
            LangList.Add(new sysLanguage("Elvish", "Elvish"));
            LangList.Add(new sysLanguage("Dwrvish", "Dwarvish"));
            LangList.Add(new sysLanguage("Orcish", "Orcish"));
            LangList.Add(new sysLanguage("Death", "Death Tongue"));
            LangList.Add(new sysLanguage("Demon", "Demonic"));
            LangList.Add(new sysLanguage("Merchant", "Merchant's Cant"));



        }

    }
}