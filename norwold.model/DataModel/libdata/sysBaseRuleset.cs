using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;

namespace DataModel.libData
{

    /**
     * Class for the Base RuleSet Types
     * 
     * Every Campaign uses a sysRuleSet which must be a child of the BaseRule set
     * Rules for ChildRulesets:
     *      i) Must use the same sysStatistics & sysBaseCombatStats
     *      ii) Must use the same Currency and XPMethod
     *      iii) Must use the same Alignments,DamageTypes,Durations
     * 
     * The following tables are inheritable from the base or overridden (override can copy into the sysRuleSet)
     *      sysItemType
     *      
     **/


    public class sysBaseRuleset : nwdbDataType
    {
    

        public sysBaseRuleset() : base() {

            if (this.GPDescription == null) { this.GPDescription = "Gold"; }
            if (this.HPDescription == null) { this.HPDescription = "Hit Points"; }
            if (this.XPDescription == null) { this.XPDescription = "XP"; }
            if (this.Version == 0) { this.Version = 1; }

            this.Alignments= new List<sysBaseAlignment>();
            this.CombatStats = new List<sysBaseCombatStat>();
            this.DamageTypes = new List<sysBaseDamageType>();
            this.Durations = new List<sysBaseDurationType>();
     
        }

        public sysBaseRuleset(string n,string nl):this ()
        {
            this.Name = n.Substring(0, Math.Min(nwdbConst.LEN_SHORT , n.Length ));
            this.LongName = nl.Substring(0, Math.Min(nwdbConst.LEN_LONG , nl.Length ));
        }

        //Properties
        public virtual float Version { get; set; }
        public virtual string GPDescription { get; set; }  //The description for GP (i.e. Currency)
        public virtual string XPDescription { get; set; }  //The description for XP (i.e. Experience/development)
        public virtual string HPDescription { get; set; }  //The description for Life (i.e. Hit Points)
        public virtual float StatMinimum { get; set; }     //Default minimum statistic value
        public virtual float StatMaximum { get; set; }     //Default Maximum statistic value


        //PropertyTables
        public virtual IList<sysBaseAlignment> Alignments { get; set; }
        public virtual IList<sysBaseCombatStat> CombatStats { get; set; }
        public virtual IList<sysBaseDamageType> DamageTypes { get; set; }
        public virtual IList<sysBaseDurationType> Durations { get; set; }



    }

}
