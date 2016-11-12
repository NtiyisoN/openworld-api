using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using norwold.model;
using DataModel.libDB;



namespace DataModel.libCampaign
{

    public class campXPGained : nwdbDataType
    {
        public campXPGained() : base() { }
        public campXPGained(string n, string nl) : base(n,nl) { }

        public campXPGained(string n, string nl,campAdventure adv, hostChar ch,int xp, int gold, bool approved) : base(n, nl) { 

            this.Adventure = adv;
            this.Character = ch;
            this.XP = xp;
            this.Gold = gold;
            this.GMApproved = approved;
        }
        
        public virtual string PlayerDescription { get; set; }
        public virtual campAdventure Adventure { get; set; }
        public virtual hostChar Character { get; set; }
        public virtual int XP { get; set; }
        public virtual int Gold { get; set; }
        public virtual bool GMApproved { get; set; }


    }
}
