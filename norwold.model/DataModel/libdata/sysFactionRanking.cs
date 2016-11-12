using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.libDB;


namespace DataModel.libData
{
    public class sysFactionRanking : nwdbDataType
    {
        public sysFactionRanking() : base() { }
        public sysFactionRanking(string n, string nl) : base(n, nl) { }

        public sysFactionRanking(string n, string nl,string effects, int points) : this(n, nl) {
            this.Effects = effects;
            this.FactionPoints = points;
       
        }

        public virtual string Effects { get; set; }  // description of benefits @level
        public virtual int FactionPoints { get; set; } // num points required to reach @level

        public static void SeedListData(IList<sysFactionRanking> franks)
        {
            franks.Add(new sysFactionRanking("Hostile", "Hostile", "Open warfare", -4000));
            franks.Add(new sysFactionRanking("Hated", "Hated", "hated", -2000));
            franks.Add(new sysFactionRanking("Disliked", "Disliked", "Disliked", -1000));
            franks.Add(new sysFactionRanking("Untrusted", "Untrusted", "Untrusted", -200));
            franks.Add(new sysFactionRanking("Neutral", "Neutral", "Neutral", 0));
            franks.Add(new sysFactionRanking("Trusted", "Trusted", "Trusted", 200));
            franks.Add(new sysFactionRanking("Liked", "Liked", "Liked", 1000));
            franks.Add(new sysFactionRanking("Loved", "Loved", "Loved", 2000));
            franks.Add(new sysFactionRanking("Fanatical", "Fanatical", "Fanatical", 4000));
        }

    }

    
}
