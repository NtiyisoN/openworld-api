using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysBaseStatistic : nwdbDataType
    {
        public sysBaseStatistic() : base() {
            if (this.min == 0) { this.min = 3; }
            if (this.max == 0) { this.max = 25; }
            if (this.defvalue == 0) { this.defvalue = 10; }
            RollModifers = new List<sysDamageRoll>();
            StackingTypes = new List<sysStatisticStackingType>();
             
        }

       //default values are handled by the dbschema (incl null)
        public sysBaseStatistic(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
            bUseShort = true;
        }

        public sysBaseStatistic(string n, string nl,sysTreeStatistic sg)
            : this(n, nl)
        {
            this.StatisticGroup = sg;
            sg.Statistics.Add(this);
        }

        public sysBaseStatistic(string n, string nl, int vmin, int vmax, int vdefault, sysTreeStatistic sg)
           : this(n, nl,sg)
       {
           this.min = vmin;
           this.max = vmax;
           this.defvalue = vdefault;
           bUseShort = true;
       }

        public virtual int min { get; set; }
        public virtual int max { get; set; }
        public virtual int defvalue { get; set; }
        public virtual string Description { get; set; }
        public virtual sysTreeStatistic StatisticGroup { get; set; }
        public virtual IList<sysDamageRoll> RollModifers { get; set; }
        public virtual IList<sysStatisticStackingType> StackingTypes { get; set; }
        public virtual sysBaseRuleset RuleSet { get; set;  }
    }
}
