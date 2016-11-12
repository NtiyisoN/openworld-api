using System;
using System.Text;
using System.Collections.Generic;
using DataModel.libHosting;
using DataModel.libData;


namespace DataModel.libHosting
{
    [Serializable()]

    public class hostCharStat
    {

        public hostCharStat() {}

        public hostCharStat(sysBaseStatistic s, hostChar c, int v)
        {
            this.stat = s;
            if (v == 0) { v = s.defvalue; }
            this.value = v;
            character = c;
            if (this.value < s.min || this.value > s.max)
            {
                throw new ApplicationException("System Stat out of range," + s.LongName + " =" + v.ToString());
            }
        }

        public virtual sysBaseStatistic stat { get; set; }
        public virtual hostChar character { get; set; }
        public virtual int value { get; set; }
        public virtual int id { get; set; }

        //Calculated types
        public virtual string StatType { 
            get {

                if (stat == null || stat.StatisticGroup == null) {
                    return "";
                } else {
                    return stat.StatisticGroup.Path("\\");
                }
            }
       }

    }
}
