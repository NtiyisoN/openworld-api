using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;

namespace DataModel.libData
{
    //Implementations


    public class sysTreeRuleSet : nwdbTree
    {
        public sysTreeRuleSet()
            : base()
        {
            RuleSets = new List<sysBaseRuleset>();

        }

        public sysTreeRuleSet(string n, int v)
            : this()
        {

            this.Name = n;
        }

        public virtual IList<sysBaseRuleset> RuleSets { get; set; }

        public static sysTreeRuleSet SeedTreeData()
        {
            sysTreeRuleSet stRoot;
            stRoot = new sysTreeRuleSet(nwdbConst.sysTreeNameRuleSet, -1);
            stRoot.AddChild(new sysTreeRuleSet("Fantasy", -1));
            stRoot.AddChild(new sysTreeRuleSet("Sci Fi", -1));
            stRoot.AddChild(new sysTreeRuleSet("Western", -1));
            stRoot.AddChild(new sysTreeRuleSet("Other", -1));
            return stRoot;
        }


    }

    public class sysTreeItemType : nwdbTree
    {
        public sysTreeItemType()
            : base()
        {
            Items = new List<sysItemType>();
            this.LeafNodes = Items as IList<nwdbDataType>;
            StackingTypes = new List<sysStatisticStackingType>();
        }
        public sysTreeItemType(string n, int v)
            : this()
        {

            this.Name = n;
        }

        public virtual IList<sysItemType> Items { get; set; }
        public virtual IList<sysStatisticStackingType> StackingTypes { get; set; }


        public static sysTreeItemType SeedTreeData(IList<sysDamageRoll> dmgrolls)
        {
            sysTreeItemType mTree = new sysTreeItemType(nwdbConst.sysTreeNameItemType, -1);

            sysTreeItemType siFamily = new sysTreeItemType("Equipment", 0);
            sysTreeItemType siFamily2 = new sysTreeItemType("Resources", 0);
            sysTreeItemType siClass = new sysTreeItemType("Weapons", 0);
            sysTreeItemType siClass2 = new sysTreeItemType("Armour", 0);
            sysTreeItemType siClass3 = new sysTreeItemType("Jewellry", 0);
            sysTreeItemType siSubClass1 = new sysTreeItemType("Polearms", 0);
            sysTreeItemType siSubClass2 = new sysTreeItemType("Bows", 0);
            sysTreeItemType siSubClass3 = new sysTreeItemType("Staffs,Rods,Wands", 0);

            mTree.AddChild(siFamily);
            mTree.AddChild(siFamily2);

            siFamily.AddChild(siClass);
            siFamily.AddChild(siClass2);
            siFamily.AddChild(siClass3);
            siClass.AddChild(siSubClass2);
            siClass.AddChild(siSubClass1);
            siClass.AddChild(siSubClass3);

            siSubClass1.Items.Add(new sysItemType("Halberd", "Halberd", siSubClass1, 10, "8x1", dmgrolls.First(x => x.LongName == "1d12+0")));
            siSubClass1.Items.Add(new sysItemType("Spear", "Spear", siSubClass1, 8, "8x1", dmgrolls.First(x => x.LongName == "1d6+0")));
            siSubClass2.Items.Add(new sysItemType("LongBow", "LongBow", siSubClass2, 8, "5x1", dmgrolls.First(x => x.LongName == "1d6+0")));
            siSubClass2.Items.Add(new sysItemType("CompBow", "Composite Bow", siSubClass2, 8, "5x1", dmgrolls.First(x => x.LongName == "1d6+0")));

            return mTree;
        }
    }

    public class sysTreeCombatStat : nwdbTree
    {
        public sysTreeCombatStat()
            : base()
        {
            CombatStats = new List<sysBaseCombatStat>();
            this.LeafNodes = CombatStats as IList<nwdbDataType>;
        }
        
        public sysTreeCombatStat(string n, int v)
            : base(n, v)
        {
            this.Name = n;
            CombatStats = new List<sysBaseCombatStat>();
        }
        
        public virtual IList<sysBaseCombatStat> CombatStats { get; set; }

        public static sysTreeCombatStat SeedTreeData(IList<sysBaseCombatStat> stats) {

            sysTreeCombatStat stRoot, stCombat, stLevel;
            stRoot = new sysTreeCombatStat(nwdbConst.sysTreeNameStatistic, -1);
            stCombat = new sysTreeCombatStat("Combat", -1);
            stLevel = new sysTreeCombatStat("Level Based", -1);
            
            

            
            stats.Add(new sysBaseCombatStat("HP", "Hit Points", -10, 4000000, 10, stCombat));
            stats.Add(new sysBaseCombatStat("AC", "Armour Class", -10, 10, 10, stCombat));
            stats.Add(new sysBaseCombatStat("ACB", "Armour Class - Back", -10, 10, 10, stCombat));
            stats.Add(new sysBaseCombatStat("ACT", "Armour Class - Touch", -10, 10, 10, stCombat));
            stats.Add(new sysBaseCombatStat("THACO", "To Hit AC 10", 0, 20, 20, stCombat));
            stats.Add(new sysBaseCombatStat("THB", "To Hit Bonus", -10, 50, 0, stCombat));
            stats.Add(new sysBaseCombatStat("DB", "Damage Bonus", -10, 50, 10, stCombat));
            stats.Add(new sysBaseCombatStat("INIT", "Initiative", -10, 10, 10, stCombat));
            stats.Add(new sysBaseCombatStat("WEIGHT", "Weight", 0, 5000, 0, stCombat));
            stats.Add(new sysBaseCombatStat("SUP", "Surprised Percentage", 0, 100, 17, stCombat));
            stats.Add(new sysBaseCombatStat("ATKS", "Attacks per Round", 0, 100, 17, stCombat));
            stats.Add(new sysBaseCombatStat("SPELLS", "Spells per Round", 0, 100, 17, stCombat));
            
            //Add Level based
            stats.Add(new sysBaseCombatStat("HITDIE", "Hit Die", 0, 500, 0, stLevel));
            stats.Add(new sysBaseCombatStat("CL", "Casting Level", 0, 500, 0, stLevel));
            stats.Add(new sysBaseCombatStat("LVL", "Level", 0, 500, 0, stLevel));
            

            stRoot.AddChild(stCombat);
            return stRoot;
        }
    }

    public class sysTreeStatistic : nwdbTree
    {
        public sysTreeStatistic()
            : base()
        {
            Statistics = new List<sysBaseStatistic>();
            this.LeafNodes = Statistics as IList<nwdbDataType>;
        }
        public sysTreeStatistic(string n, int v)
            : base(n, v)
        {
            Statistics = new List<sysBaseStatistic>();
            this.LeafNodes = Statistics as IList<nwdbDataType>;
        }
        public virtual bool isCalculated { get; set; }
        public virtual IList<sysBaseStatistic> Statistics { get; set; }

        public static sysTreeStatistic SeedTreeData(IList<sysBaseStatistic> stats)
        {
            sysTreeStatistic stRoot, stBase, stDomain, stCombat, stLevels;
            //Stat Tree#
            stRoot = new sysTreeStatistic(nwdbConst.sysTreeNameStatistic, -1);

            stBase = new sysTreeStatistic("Base Stats", 0);
            stDomain = new sysTreeStatistic("Domain Stats", 0);
            stCombat = new sysTreeStatistic("Combat Stats", 0);
            stLevels = new sysTreeStatistic("Level Stats", 0);

            //Seed Statistics
            stats.Add(new sysBaseStatistic("STR", "Strength", stBase));
            stats.Add(new sysBaseStatistic("INT", "Intelligence", stBase));
            stats.Add(new sysBaseStatistic("WIS", "Wisdom", stBase));
            stats.Add(new sysBaseStatistic("CON", "Constitution", stBase));
            stats.Add(new sysBaseStatistic("DEX", "Dexterity", stBase));
            stats.Add(new sysBaseStatistic("CHA", "Charisma", stBase));

            stats.Add(new sysBaseStatistic("POL", "Politics", stDomain));
            stats.Add(new sysBaseStatistic("WAR", "Warfare", stDomain));
            stats.Add(new sysBaseStatistic("TRA", "Trade", stDomain));
            stats.Add(new sysBaseStatistic("SPY", "Espionage", stDomain));
            stats.Add(new sysBaseStatistic("SCI", "Science", stDomain));
            stats.Add(new sysBaseStatistic("LAW", "Lawmaking", stDomain));

           

            stRoot.AddChild(stBase);
            stRoot.AddChild(stDomain);
            //stRoot.AddChild(stCombat);
            return stRoot;
        }
    }

    public class sysTreeDevelopment : nwdbTree
    {
        public sysTreeDevelopment()
            : base()
        {
            Paths = new List<sysDevelopment>();
            this.LeafNodes = Paths as IList<nwdbDataType>;

        }
        public sysTreeDevelopment(string n, int v)
            : base(n, v)
        {
            Paths = new List<sysDevelopment>();
            this.LeafNodes = Paths as IList<nwdbDataType>;
        }
        public virtual IList<sysDevelopment> Paths { get; set; }


        public static sysTreeDevelopment SeedTreeData(IList<sysDevelopment> sysDev)
        {
            sysTreeDevelopment sdpRoot, sdpClass, sdpRace, sdpProf, sdpHobby, sdpFight, sdpMagic, sdpCleric, sdpRogue, sdpHuman, sdpElven, sdpStunty, sdpPlanar, sdpMonster, sdpOpen, sdpClosed;

            //sysDevelopment Paths
            sdpRoot = new sysTreeDevelopment(nwdbConst.sysTreeNameDevelopment, -1);

            sdpClass = new sysTreeDevelopment("Class", 0);
            sdpRace = new sysTreeDevelopment("Race", 1);
            sdpProf = new sysTreeDevelopment("Profession", 2);
            sdpHobby = new sysTreeDevelopment("Hobby", 3);


            sdpRoot.AddChild(sdpClass);
            sdpRoot.AddChild(sdpRace);
            sdpRoot.AddChild(sdpProf);
            sdpRoot.AddChild(sdpHobby);


            sdpFight = new sysTreeDevelopment("Combat", 0);
            sdpClass.AddChild(sdpFight);
            sdpMagic = new sysTreeDevelopment("Magical", 0);
            sdpClass.AddChild(sdpMagic);
            sdpCleric = new sysTreeDevelopment("Spiritual", 0);
            sdpClass.AddChild(sdpCleric);
            sdpRogue = new sysTreeDevelopment("Rogue", 0);
            sdpClass.AddChild(sdpRogue);

            sdpHuman = new sysTreeDevelopment("Humanoid", 0);
            sdpRace.AddChild(sdpHuman);
            sdpElven = new sysTreeDevelopment("Elven", 0);
            sdpRace.AddChild(sdpElven);
            sdpStunty = new sysTreeDevelopment("Stunty", 0);
            sdpRace.AddChild(sdpStunty);
            sdpMonster = new sysTreeDevelopment("Undead", 0);
            sdpRace.AddChild(sdpMonster);
            sdpPlanar = new sysTreeDevelopment("Planar", 0);
            sdpRace.AddChild(sdpPlanar);

            sdpOpen = new sysTreeDevelopment("Open", 0);
            sdpProf.AddChild(sdpOpen);
            sdpClosed = new sysTreeDevelopment("Closed", 0);
            sdpProf.AddChild(sdpClosed);

            //sysDevelopment Paths

            //Classes
            sysDev.Add(new sysDevelopment("WAR", "Warrior", sdpFight));
            sysDev.Add(new sysDevelopment("RNG", "Ranger", sdpFight));
            sysDev.Add(new sysDevelopment("PAL", "Paladin", sdpFight));
            sysDev.Add(new sysDevelopment("BAR", "Barbarian", sdpFight));
            sysDev.Add(new sysDevelopment("CAV", "Cavalier", sdpFight));
            sysDev.Add(new sysDevelopment("MAG", "Magician", sdpMagic));
            sysDev.Add(new sysDevelopment("ILL", "Illusionist", sdpMagic));
            sysDev.Add(new sysDevelopment("CLR", "Cleric", sdpCleric));
            sysDev.Add(new sysDevelopment("DRU", "Druid", sdpCleric));
            sysDev.Add(new sysDevelopment("THF", "Thief", sdpRogue));
            sysDev.Add(new sysDevelopment("ASS", "Assassin", sdpRogue));
            sysDev.Add(new sysDevelopment("BRD", "Bard", sdpRogue));

            //Races
            sysDev.Add(new sysDevelopment("Human", "Human", sdpHuman));
            sysDev.Add(new sysDevelopment("Elf-Wood", "Wood Elf", sdpElven));
            sysDev.Add(new sysDevelopment("Elf-High", "High Elf", sdpElven));
            sysDev.Add(new sysDevelopment("Elf-Half", "Half Elf", sdpElven));
            sysDev.Add(new sysDevelopment("Elf-Light", "Spriacqwe", sdpElven));
            sysDev.Add(new sysDevelopment("Elf-Drow", "Drowe", sdpElven));
            //sysDev.Add(new sysDevelopment("Elf-Wood", "Wood Elf", sdpElven));
            sysDev.Add(new sysDevelopment("Dwarf", "Dwarf", sdpStunty));
            sysDev.Add(new sysDevelopment("Gnome", "Gnome", sdpStunty));
            sysDev.Add(new sysDevelopment("Wraith", "Wraith", sdpMonster));
            sysDev.Add(new sysDevelopment("Zombie", "Zombie", sdpMonster));
            sysDev.Add(new sysDevelopment("Ghoul", "Ghoul", sdpMonster));
            sysDev.Add(new sysDevelopment("Avatar", "Avatar", sdpMonster));

            //Professions
            sysDev.Add(new sysDevelopment("SORC", "Sorceror", sdpOpen));
            sysDev.Add(new sysDevelopment("LOYTRO", "Warrior of Loytro", sdpClosed));

            return sdpRoot;

        }

    }
}
