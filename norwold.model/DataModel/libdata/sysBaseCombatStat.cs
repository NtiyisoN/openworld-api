using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    /**
     * sysBaseCombatStat determines all the calculated metrics for the ruleset
     * e.g. To Hit Bonus , Hit Points etc etc
     * */

    public class sysBaseCombatStat: nwdbDataType
    {
        public sysBaseCombatStat() : base() {}

       //default values are handled by the dbschema (incl null)
        public sysBaseCombatStat(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }
        public sysBaseCombatStat(string n, string nl,sysTreeCombatStat stc)
            : this(n,nl)
        {
            this.StatisticGroup = stc;
            stc.CombatStats.Add(this);
        }


        public sysBaseCombatStat(string n, string nl, int vmin, int vmax, int vdefault, sysTreeCombatStat sg)
           : this(n, nl,sg)
       {
           this.min = vmin;
           this.max = vmax;
           this.defvalue = vdefault;
           bUseShort = true;
       }

        public virtual string Description { get; set; }  // Longer description
        public virtual int min { get; set; }
        public virtual int max { get; set; }
        public virtual int defvalue { get; set; }
        public virtual sysTreeCombatStat StatisticGroup { get; set; }
        public virtual sysBaseRuleset RuleSet { get; set; }
    }
}
