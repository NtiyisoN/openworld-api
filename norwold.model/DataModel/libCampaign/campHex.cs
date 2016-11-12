using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libMapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libCampaign
{
    [Serializable()]
    public class campHex : nwdbDataType
    {
        
        public campHex() : base() { }
        public campHex(string n, string nl) : base(n, nl) { this.Milestones = new List<campMilestone>(); }

        public virtual int X { get; set; }
        public  virtual int Y { get; set; }
        public virtual string Description { get; set; }
        public virtual mapTerrainType TerrainType { get; set; }
        public virtual char CharValue { get; set; }
        public virtual IList<campMilestone> Milestones { get; set; }
        public virtual campTreeLocation Location { get; set; }
        
    }

    
}
