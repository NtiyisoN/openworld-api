using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;



namespace DataModel.libData
{
    public class sysDamageRoll : nwdbDataType
    {
        public sysDamageRoll() : base() { this.ItemsDamage = new List<sysItemType>(); }
        public sysDamageRoll(string n, string nl) : base(n, nl) { this.ItemsDamage = new List<sysItemType>(); }
        public sysDamageRoll(string n, string nl, int die , int number, int bonus, sysBaseStatistic per, int perdivide) : base() {

            this.Die = die;
            this.Number = number;
            this.Bonus = bonus;
            this.BonusPer = per;
            this.PerDivide = perdivide;
            this.LongName = toStringImpl();
            this.Name = LongName.Substring(0,Math.Min(nwdbConst.LEN_SHORT,LongName.Length));
            this.ItemsDamage = new List<sysItemType>();
        }

        public virtual int Die { get; set; }
        public virtual int Number { get; set; }
        public virtual int Bonus { get; set; }
        public virtual sysBaseStatistic BonusPer { get; set; }
        public virtual int PerDivide { get; set; }
        //public virtual IList<sysItemType> ItemsSmallDamage { get; set; }
        public virtual IList<sysItemType> ItemsDamage { get; set; }


        protected override String toStringImpl()
        {
            string build = "";
            string perbuild = "";
            if (BonusPer != null)
            {
                if (PerDivide > 1)
                {
                    perbuild = " per " + PerDivide.ToString() + BonusPer.Name + "(s)";
                }
                else
                {
                    perbuild = " per " + BonusPer.Name;
                }
            }
            build = Number + "d" + Die + "+" + Bonus + perbuild;
            return build;
        }


        public static void SeedListData(IList<sysDamageRoll> dmglist)
        {
            dmglist.Add(new sysDamageRoll("", "d4", 4, 1, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "d6", 6, 1, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "d8", 8, 1, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "d10", 10, 1, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "d12", 12, 1, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "2d4+1", 4, 2, 1, null, 0));
            dmglist.Add(new sysDamageRoll("", "2d6", 6, 2, 0, null, 0));
            dmglist.Add(new sysDamageRoll("", "2d8", 8, 2, 0, null, 0));
        }

    }
}

