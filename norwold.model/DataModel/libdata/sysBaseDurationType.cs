using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysBaseDurationType : nwdbDataType
    {
        public sysBaseDurationType() : base() { }
        public sysBaseDurationType(string n, string nl) : base(n, nl) { }
        public sysBaseDurationType(string n, string nl, int s) : base(n, nl) {
            this.Seconds = s;
        }

        public virtual int Seconds { get; set; }
        public virtual sysBaseRuleset RuleSet { get; set; }


        public virtual Single GetMinutes()
        {
            return (Seconds / 60);

        }
        public virtual Single GetHours()
        {
            return (GetMinutes() / 60);
        }
        public virtual Single GetDays()
        {
            return (GetHours() / 24);
        }


        public static void SeedListData(IList<sysBaseDurationType> sysdurs)
        {
            //DurationTypes
            sysdurs.Add(new sysBaseDurationType("Round", "Round", 10));
            sysdurs.Add(new sysBaseDurationType("Turn", "Turn", 60));
            sysdurs.Add(new sysBaseDurationType("Second", "Seconds", 1));
            sysdurs.Add(new sysBaseDurationType("Minute", "Minutes", 60));
            sysdurs.Add(new sysBaseDurationType("Hour", "Hour", 3600));
            sysdurs.Add(new sysBaseDurationType("Day", "Day", 86400));
            sysdurs.Add(new sysBaseDurationType("Week", "Week", 604800));
        }
    }

    
}
