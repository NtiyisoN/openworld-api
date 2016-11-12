using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libHosting.maps {
    
    
    public class hostUserEventMap : ClassMap<hostUserEvent> {

        public hostUserEventMap()
        {
			Table("host_userevents");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG);
			Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.Viewed);
            Map(x => x.Sent);
            Map(x => x.DateOccured);

            References(x => x.Character).Column("hostChar_id");
            References(x => x.Campaign).Column("campCampaign_id");
            References(x => x.User).Column("hostUser_id");


        }
    }
}
