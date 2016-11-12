using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using norwold.model;
using Brandy.Grapes.FluentNHibernate;
using Brandy.Grapes;
using DataModel.libDB;
using DataModel.libData;



namespace DataModel.libCampaign
{
    /**
     * Core Tabling structure, rather than traditional linked groups/categories, this is linked trees
     * The core branches of the tree are the traditional groups, then (optional) subgroups and (optional) subsubgroups
     * branches by definition are XTypes of X (foreign keys)
     * 
     * Deleting tree branches is bad and can have massive effect on database (e.g. delete everythinig that depends on them)
     * Changing trees (swapping) is almost as bad with same implications.
     * 
     * Implicit in this is the linked subclass where the tree is the master(menu) structure and the subclass the detail
     * For this we use the following nomenclature
     * 
     * Tier       Name            ItemTypeExample
     * Root       Root            ItemTypes <<not part of tree>>
     * Branch1:   Class           Equipment, Resources
     * Branch2:   SubClass        Weapons, Minerals
     * Branch3:   TertiaryClass   Polearms , <<resources are 2 tiers hence branch3 ==ItemType for resources>>
     * Branch4:   Quartary        <<not implemented yet, branch4 i== ItemType for Equipment>>
     * 
     * In the actual linkedClass [nwSystemGroupedType] - this reference to the heirachy is called the Category
     * */

    public abstract class campTree : TreeEntry<campTree>, IComparable
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual int Value { get; set; }
            //public virtual int OrderDisplay { get; set; }
            //public virtual int OrderPrint { get; set; }
            
            public virtual int CompareTo(object obj)
            {
                if (obj == null) return 1;
                campTree otherSysTree = obj as campTree;
                if (otherSysTree != null)
                {
                    return Id.CompareTo(otherSysTree.Id);
                }
                else
                    throw new ApplicationException("Compare to called on" + this.GetType() + "ID=" + this.Id + " Comparing to non nwdbTree");
            }


            public campTree()
            {
                
            }

            public campTree(string n, int v)
            {
                this.Name = n;
                this.Value = v;
            }

  
 

       }

    //Implementations
    //Implementations


    public class campTreeMileStone : nwdbTree
    {
        public campTreeMileStone()
            : base()
        {
            Milestones = new List<campMilestone>();
        }
        public campTreeMileStone(string n, int v)
            : this()
        {
            this.Name = n;
        }

        public campTreeMileStone(string n, sysMilestoneType sType)
            : this()
        {
            this.Name = n;
            this.MilestoneType = sType;
        }

        public virtual IList<campMilestone> Milestones { get; set; }
        public virtual sysMilestoneType MilestoneType { get; set; }

        public override void AddChild(nwdbTree child)
        {
            campTreeMileStone ch = child as campTreeMileStone;
            base.AddChild(child);
            if (ch.MilestoneType == null) { ch.MilestoneType = this.MilestoneType; }
        }

        public static campTreeMileStone SeedTreeData(IList<sysMilestoneType> mTypes)
        {
            sysMilestoneType mPeople, mPlace, mSkill, mFaction, mItem;
            campTreeMileStone msCharacter, msDungeon, msItem, msSkill;

            mPeople = mTypes.Where(x => x.Name == "People").First();
            mPlace = mTypes.Where(x => x.Name == "Place").First();
            mSkill = mTypes.Where(x => x.Name == "Skill").First();
            mFaction = mTypes.Where(x => x.Name == "Faction").First();
            mItem = mTypes.Where(x => x.Name == "Equipment").First();

            campTreeMileStone mTree = new campTreeMileStone(campConst.campTreeNameMilestone, 0);
            
            //nwMileStroneTree
            msCharacter = new campTreeMileStone("Character & Faction", mPeople);
            msDungeon = new campTreeMileStone("Dungeon & Places", mPlace);
            msItem = new campTreeMileStone("Items & Equipment", mItem);
            msSkill = new campTreeMileStone("Skills & Lore", mSkill);

            //Add sub Milestones
            msCharacter.AddChild(new campTreeMileStone("Killed", 6));
            msCharacter.AddChild(new campTreeMileStone("Met", 6));
            msCharacter.AddChild(new campTreeMileStone("Made friend", 6));
            msCharacter.AddChild(new campTreeMileStone("Made Enemy", 6));
            msDungeon.AddChild(new campTreeMileStone("Discovered", 6));
            msDungeon.AddChild(new campTreeMileStone("Completed", 6));
            msDungeon.AddChild(new campTreeMileStone("Conquered", 6));
            msDungeon.AddChild(new campTreeMileStone("Destroyed", 6));
            msItem.AddChild(new campTreeMileStone("Gained", 6));
            msItem.AddChild(new campTreeMileStone("Lost", 6));
            msItem.AddChild(new campTreeMileStone("Used", 6));
            msSkill.AddChild(new campTreeMileStone("Learnt Skill", 6));
            msSkill.AddChild(new campTreeMileStone("Gained Language", 6));
            msSkill.AddChild(new campTreeMileStone("Used Stat Lore Book", 6));


            mTree.AddChild(msCharacter);
            mTree.AddChild(msDungeon);
            mTree.AddChild(msItem);
            mTree.AddChild(msSkill);


            return mTree;
        }

    }

    public class campTreeFaction : nwdbTree
    {
        public campTreeFaction()
            : base()
        {
            Factions = new List<campFaction>();
        }
        public campTreeFaction(string n, int v)
            : this()
        {
            this.Name = n;
        }
        public virtual IList<campFaction> Factions { get; set; }

        public static campTreeFaction SeedTreeData()
        {
            campTreeFaction facRoot,facRacial, facAlignment, facProf, facTrade, facNation, subFacHuman, subFacEvil, subFacMartial;
            facRoot = new campTreeFaction(campConst.campTreeNameFaction, 0);

            facRacial = new campTreeFaction("Racial", 0);
            facNation = new campTreeFaction("Nations", 0);
            facAlignment = new campTreeFaction("Alignment", 0);
            facProf = new campTreeFaction("Profession", 0);
            facTrade = new campTreeFaction("Trade", 0);

            subFacHuman = new campTreeFaction("Human", 0);
            facRacial.AddChild(subFacHuman);
            facRacial.AddChild(new campTreeFaction("Elven", 0));
            facRacial.AddChild(new campTreeFaction("Stunty", 0));
            facRacial.AddChild(new campTreeFaction("Dragon", 0));
            facRacial.AddChild(new campTreeFaction("Demonic", 0));
            facRacial.AddChild(new campTreeFaction("Humanoid", 0));
            subFacHuman.Factions.Add(new campFaction("A Human", "A Human Faction"));

            subFacEvil = new campTreeFaction("Evil", 0);
            facAlignment.AddChild(subFacEvil);
            facAlignment.AddChild(new campTreeFaction("Neutral", 0));
            facAlignment.AddChild(new campTreeFaction("Good", 0));
            facAlignment.AddChild(new campTreeFaction("Lawful", 0));
            facAlignment.AddChild(new campTreeFaction("Chaotic", 0));
            subFacEvil.Factions.Add(new campFaction("Evil", "An Evil Faction"));


            subFacMartial = new campTreeFaction("Martial", 0);
            facProf.AddChild(subFacMartial);
            facProf.AddChild(new campTreeFaction("Magical", 0));
            subFacEvil.Factions.Add(new campFaction("Loytro", "Warriors of Loytro"));
            facNation.Factions.Add(new campFaction("Alphatia", "Alphatia"));
            facNation.Factions.Add(new campFaction("Thyatia", "Thyatia"));
            facNation.Factions.Add(new campFaction("Oceansend", "Oceansend"));


            facRoot.AddChild(facRacial);
            facRoot.AddChild(facNation);
            facRoot.AddChild(facAlignment);
            facRoot.AddChild(facProf);
            facRoot.AddChild(facTrade);

            return facRoot;

        }

    }


    public class campTreeLocation : nwdbTree
    {
        public campTreeLocation()
            : base()
        {
            Hexes = new List<campHex>();
        }
        public campTreeLocation(string n, int v)
            : this()
        {
            this.Name = n;
        }
        public virtual IList<campHex> Hexes { get; set; }

        public static campTreeLocation SeedTreeData()
        {
            campTreeLocation locRoot,locContinent, locNorwold, locAlphatia, locThyatia;
            locRoot = new campTreeLocation(campConst.campTreeNameLocation, 0);

            //campTreeLocation
            locContinent = new campTreeLocation("Continents", 0);
            locNorwold = new campTreeLocation("Norwold", 0);
            locAlphatia = new campTreeLocation("Alphatia", 0);
            locThyatia = new campTreeLocation("Thyatia", 0);
            locContinent.AddChild(locAlphatia);
            locContinent.AddChild(locNorwold);
            locContinent.AddChild(locThyatia);
            locNorwold.AddChild(new campTreeLocation("Northern Wastes", 0));
            locNorwold.AddChild(new campTreeLocation("Southern Lands", 0));
            locNorwold.AddChild(new campTreeLocation("Arc of Fire", 0));
            locNorwold.AddChild(new campTreeLocation("Eastern Seaboard", 0));
            locNorwold.AddChild(new campTreeLocation("Capital Territory", 0));
            locNorwold.AddChild(new campTreeLocation("Middle Realm", 0));
            
            locRoot.AddChild(locContinent);
            return locRoot;
        }
    }
}

