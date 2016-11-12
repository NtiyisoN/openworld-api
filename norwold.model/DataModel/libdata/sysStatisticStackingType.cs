using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysStatisticStackingType : nwdbDataType
    {
        public sysStatisticStackingType() : base() { }
        public sysStatisticStackingType(string n, string nl) : this() {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG, nl.Length));
        }

        public sysStatisticStackingType(string n, string nl, sysBaseStatistic st) : base(n, nl) {
            this.Statistic = st;        
        }

        public virtual sysBaseStatistic Statistic { get; set; }
        public virtual sysTreeItemType ItemType { get; set; }
        // to stack multiples, have multiple records //public virtual int maxNum { get; set; }
    }
}
