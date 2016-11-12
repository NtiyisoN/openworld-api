using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using DataModel.libData;
using DataModel.libDB;


namespace DataModel.libCampaign
{

    public class campMilestone : nwdbDataType
    {
        public campMilestone() : base() {
            if (this.Occured == DateTime.MinValue || this.Occured == null) { this.Occured = nwdbConst.minSQLDate; }
        }
        public campMilestone(string n, string nl) : base(n, nl) { }

        //Mandatories
        public virtual hostChar SourceCharacter { get; set; }
        public virtual campTreeMileStone Type { get; set; }
        public virtual campAdventure Adventure { get; set; }  //can be adventure or turnsheet
        public virtual DateTime Occured { get; set; }

        //Optionals
        public virtual hostChar TargetCharacter { get; set; }
        public virtual campFaction TargetFaction { get; set; }
        public virtual campHex TargetHex { get; set; }
        public virtual nwItem TargetItem { get; set; }
        public virtual sysDevelopment TargetDevPath { get; set; }
        public virtual sysLanguage TargetLanguage { get; set; }


        
        //public virtual nwPOI LocationPOI { get; set; }

    }

    
}
