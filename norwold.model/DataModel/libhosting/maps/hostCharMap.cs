using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model;
using DataModel.libDB;
 

namespace DataModel.libHosting.maps {
    
    
    public class hostCharMap : ClassMap<hostChar> {

        public hostCharMap()
        {
			Table("host_char");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(nwdbConst.LEN_SHORT);
			Map(x => x.isNPC).Column("isNPC").Default("0");
            Map(x => x.LongName).Column("LongName").Length(nwdbConst.LEN_LONG).UniqueKey("hostChar_UK_LongName");
			Map(x => x.Description).Column("description").CustomType("StringClob").CustomSqlType("nvarchar(max)");
            HasMany(x => x.Items).Cascade.All(); //deleting a character implicitly deletes his items...consider????
            HasMany(x => x.CharStats).Cascade.All();
            HasMany(x => x.XPGained).Inverse().Cascade.All();
            HasMany(x => x.XPSpent).Inverse().Cascade.All();
            HasMany(x => x.Campaigns).Cascade.All();
            HasMany(x => x.SourceMilestones).Cascade.All().KeyColumn("Sourcechar_id");
            HasMany(x => x.TargetMilestones).Cascade.All().KeyColumn("Targetchar_id");

            References(x => x.Alignment).Column("sysAlignment_id");
            //References(x => x.Logon).Column("hostUser_id");



;
        }
    }
}
