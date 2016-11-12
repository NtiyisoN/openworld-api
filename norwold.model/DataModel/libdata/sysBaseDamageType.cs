using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysBaseDamageType : nwdbDataType
    {
        public sysBaseDamageType() : base() { }
        public sysBaseDamageType(string n, string nl) : base(n, nl) { }
        
        
        //Properties
        public virtual sysBaseRuleset RuleSet { get; set; }
        


        public static void SeedListData(IList<sysBaseDamageType> dmgs)
        {
            dmgs.Add(new sysBaseDamageType("PHYS", "Physical Damage"));
            dmgs.Add(new sysBaseDamageType("MAGIC", "Magical Damage"));
            dmgs.Add(new sysBaseDamageType("FIRE", "Fire Damage"));
            dmgs.Add(new sysBaseDamageType("COLD", "Cold Damage"));
            dmgs.Add(new sysBaseDamageType("AIR", "Electrical Damage"));
            dmgs.Add(new sysBaseDamageType("EARTH", "Earth Damage"));
            dmgs.Add(new sysBaseDamageType("HOLY", "Holy Damage"));
            dmgs.Add(new sysBaseDamageType("SORC", "Sorcorial Damage"));
            dmgs.Add(new sysBaseDamageType("DRAG", "Draconian Damage"));
            dmgs.Add(new sysBaseDamageType("UNHO", "Unholy Damage"));
            dmgs.Add(new sysBaseDamageType("POIS", "Poison Damage"));
            dmgs.Add(new sysBaseDamageType("DIS", "Disease Damage"));
        }
    
    }

    
}
