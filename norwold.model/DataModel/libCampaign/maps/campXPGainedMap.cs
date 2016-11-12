using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libCampaign.maps
{
    public class campXPGainedMap : ClassMap<campXPGained>
    {
        public campXPGainedMap()
        {
            Table("camp_xp_gains");
            LazyLoad();
            Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
            Map(x => x.XP).Column("XP");
            Map(x => x.Gold).Column("Gold");
            Map(x => x.GMApproved).Column("GMApproved");
            Map(x => x.PlayerDescription).Column("player_description").CustomType("StringClob").CustomSqlType("nvarchar(max)");

            References(x => x.Character).Column("hostChar_id").Not.LazyLoad();
            References(x => x.Adventure).Column("campAdventure_id");
        }
    }
}
