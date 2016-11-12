using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using norwold.model;
using Brandy.Grapes.FluentNHibernate;
using Brandy.Grapes;
using DataModel.libCampaign;
using DataModel.libDB;



namespace DataModel.libMapping
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

    public abstract class mapTree : TreeEntry<mapTree>, IComparable
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual int Value { get; set; }
            //public virtual int OrderDisplay { get; set; }
            //public virtual int OrderPrint { get; set; }
            
            public virtual int CompareTo(object obj)
            {
                if (obj == null) return 1;
                mapTree otherSysTree = obj as mapTree;
                if (otherSysTree != null)
                {
                    return Id.CompareTo(otherSysTree.Id);
                }
                else
                    throw new ApplicationException("Compare to called on" + this.GetType() + "ID=" + this.Id + " Comparing to non nwdbTree");
            }


            public mapTree()
            {
                
            }

            public mapTree(string n, int v)
            {
                this.Name = n;
                this.Value = v;
            }

  
 

       }

    //Implementations
    public class mapTreeTerrain : nwdbTree
    {
        public mapTreeTerrain()
            : base()
        {
            
            TerrainTypes = new List<mapTerrainType>();
            this.LeafNodes = this.TerrainTypes.ToList<nwdbDataType>(); 
            Debug.Print("Set LeafNodes to " + this.TerrainTypes.Count + " elements leafnodes is :"+this.LeafNodes.Count);
        }
        public mapTreeTerrain(string n, int v)
            : this()
        {
            this.Name = n;
        }

        public virtual IList<mapTerrainType> TerrainTypes { get; set; }

        public virtual IList<nwdbDataType> GetLeafNodes()
        {
            return this.TerrainTypes.ToList<nwdbDataType>();
        }
        
    }

    //Implementations
    public class mapTreePOI : nwdbTree
    {
        public mapTreePOI()
            : base()
        {
            this.POITypes = new List<mapPOIType>();
        }
        public mapTreePOI(string n, int v)
            : this()
        {
            this.Name = n;
        }

        public virtual IList<mapPOIType> POITypes { get; set; }

 
    }

        /**
         * 
         * Keeping the override AddChild() for future examples
         * 
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
            if (ch.MilestoneType == null) { ch.MilestoneType = this.MilestoneType;}
        }
        **/
   
   
 

   

   
}

