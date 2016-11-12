using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libCampaign.maps
{
    public class campXPSpentMap : ClassMap<campXPSpent>
    {
        public campXPSpentMap()
        {
            Table("camp_xp_spent");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
        
            Map(x => x.XPspent).Column("XPspent");
            Map(x => x.Goldspent).Column("Goldspent");
            Map(x => x.GMApproved).Column("GMApproved");

            References(x => x.Character).Column("hostChar_id");
            References(x => x.Class).Column("sysDevelopment_id");
        }
    }
}
