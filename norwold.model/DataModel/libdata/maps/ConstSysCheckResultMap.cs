using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using norwold.model; 

namespace norwold.model.maps {
    
    
    public class ConstSysCheckResultMap : ClassMap<ConstSysCheckResult> {
        
        public ConstSysCheckResultMap() {
			Table("const_sys_checkresult");
			LazyLoad();
			Id(x => x.id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name").Length(10);
			Map(x => x.ResultDamage).Column("ResultDamage");
			Map(x => x.ResultDuration).Column("ResultDuration");
			Map(x => x.ResultModifier).Column("ResultModifier");
            Map(x => x.LongName).Column("LongName").Length(42);
        }
    }
}
