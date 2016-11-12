using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;
 

namespace DataModel.libCampaign.maps {
    
    
    public class campCampaignMap : ClassMap<campCampaign> {

        public campCampaignMap()
        {
			Table("camp_campaign");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
			Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("campCampaign_UK_LongName");
			Map(x => x.Email).Column("Email");
			Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.DateStarted);
            Map(x => x.DateFinished);

            //HasMany(x => x.Characters).Cascade.All();
            HasMany(x => x.Adventures).Cascade.All();
            References(x => x.GM).Column("hostUser_id");



        }
    }
}
