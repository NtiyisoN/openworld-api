using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace norwold.model
{

 
    public class ConstSysSchool : nwSystemType
    {
        //Copy Constructor;
        public ConstSysSchool() : base() { }
        public ConstSysSchool(string n, string nl) : base(n, nl) { }
    }

    
 


    public class ConstSysRange : nwSystemType
    {
        public virtual int range_base { get; set; }
        public virtual string range_units { get; set; }
        public virtual int range_per { get; set; }
        public virtual string range_perName { get; set; }
        public virtual float range_perdivide { get; set; }

        public ConstSysRange()
            : base()
        {
            this.range_base = 0;
            this.range_units = "ft";
            this.range_per = 0;
            this.range_perName = "lvl";
            this.range_perdivide = 1;
        }
        public ConstSysRange(string n, string nl) : base(n, nl) { }

        protected override string toStringImpl()
        {
            return "Range ID " + this.id.ToString() + " Name:" + this.Name + " LongName:" + this.LongName +
                   " Base:" + this.range_base as string + " Units:" + this.range_units + " Per:" + this.range_per as string +
                   " PerName" + this.range_perName + "perDiv:" + this.range_perdivide as string;
        }
    }

    public class ConstSysCheckResult : nwSystemType
    {
        public virtual int? ResultDamage { get; set; }
        public virtual int? ResultDuration { get; set; }
        public virtual int? ResultModifier { get; set; }

        public ConstSysCheckResult()
            : base()
        {
            this.ResultDamage = 100;
            this.ResultDuration = 100;
            this.ResultModifier = 100;
        }
        public ConstSysCheckResult(string n, string nl) : base(n, nl) { }

        public new virtual string toString()
        {
            return "CheckResult ID " + this.id.ToString() + " Name:" + this.Name + " LongName:" + this.LongName +
                   " Dmg%:" + this.ResultDamage as string + " Duration%:" + this.ResultDuration as string + " Modifer%:" + this.ResultModifier as string;
        }

    }

    public class ConstSysFrequency : nwSystemType
    {
        public virtual int gametime_seconds { get; set; }


        public ConstSysFrequency()
            : base()
        {
            this.gametime_seconds = 0;

        }
        public ConstSysFrequency(string n, string nl) : base(n, nl) { }


        protected override string toStringImpl()
        {
            return "FreqID " + this.id.ToString() + " Name:" + this.Name + " LongName:" + this.LongName + "Secs:" + this.gametime_seconds;
        }

    }


 }
