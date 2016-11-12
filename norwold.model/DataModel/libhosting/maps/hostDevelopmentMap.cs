using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;


namespace DataModel.libHosting.maps {
    
    
    public class hostDevelopmentMap : ClassMap<hostDevelopment> {

        public hostDevelopmentMap()
        {
			Table("host_devtasks");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Type).Column("Type").Length(1);
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("hostUserType_LongName");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
			Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
			Map(x => x.Created).Column("Created");
			Map(x => x.Version).Column("Version");
			Map(x => x.Closed).Column("Closed");
        }
    }
}
