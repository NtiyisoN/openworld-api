using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysItemType : nwdbDataType
    {
        public virtual string Description { get; set; }

        public sysItemType() : base() { }
        public sysItemType(string n, string nl) : base(n, nl) { }
        public sysItemType(string n, string nl,sysTreeItemType itype, int w8, string dimension,sysDamageRoll sysdmgroll) : base(n, nl) {

            this.Weight = w8;
            this.ItemType = itype;
            this.Dimensions = dimension;
            this.Damage = sysdmgroll;
        }

        public virtual sysTreeItemType ItemType { get; set; }
        public virtual int Weight  {get; set;}
        public virtual string Dimensions { get; set; }
        public virtual sysDamageRoll Damage { get; set; }
    }
}
