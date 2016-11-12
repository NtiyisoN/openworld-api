using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libHosting;
using DataModel.libData;
using DataModel.libDB;


namespace DataModel.libCampaign
{
    [Serializable()]
    public class campXPSpent : nwdbDataType
    {
        public campXPSpent() : base() { }
        public campXPSpent(string n, string nl) : base(n, nl) { }

        public virtual sysDevelopment Class { get; set; }
        public virtual hostChar Character { get; set; }
        public virtual int XPspent { get; set; }
        public virtual int Goldspent { get; set; }
        public virtual bool GMApproved { get; set; }

        //sysDevelopmentAbilityList
    }
}
