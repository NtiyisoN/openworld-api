using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model; 

namespace norwold.model.maps {
    
    
    public class ConstSysFrequencyMap : ClassMap<ConstSysFrequency> {
        
        public ConstSysFrequencyMap() {
			Table("const_sys_frequency");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
			Map(x => x.gametime_seconds).Column("gametime_seconds");
            Map(x => x.Name).Column("Name").Length(10);
            Map(x => x.LongName).Column("LongName").Length(42);
        }
    }
}
