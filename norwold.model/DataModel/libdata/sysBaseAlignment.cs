using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using DataModel.libDB;


namespace DataModel.libData
{

    public class sysBaseAlignment : nwdbDataType
    {
        public sysBaseAlignment() : base() { Characters = new List<hostChar>(); }
        public sysBaseAlignment(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        public virtual IList<hostChar> Characters { get; set; }
        public virtual sysBaseRuleset RuleSet { get; set; }

        public static void SeedListData(IList<sysBaseAlignment> aligns)
        {
            aligns.Add(new sysBaseAlignment("LG", "Lawful Good"));
            aligns.Add(new sysBaseAlignment("NG", "Neutral Good"));
            aligns.Add(new sysBaseAlignment("CG", "Chaotic Good"));
            aligns.Add(new sysBaseAlignment("LN", "Lawful Neutral"));
            aligns.Add(new sysBaseAlignment("NN", "Neutral"));
            aligns.Add(new sysBaseAlignment("CN", "Chaotic Neutral"));
            aligns.Add(new sysBaseAlignment("LE", "Lawful Evil"));
            aligns.Add(new sysBaseAlignment("NE", "Neutral Evil"));
            aligns.Add(new sysBaseAlignment("CE", "Chaotic Evil"));
        }
    }
}