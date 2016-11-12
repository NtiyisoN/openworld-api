using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataModel.libDB;


namespace DataModel.libData
{
    /**
     * Types or Levels of terrainMap
     * Global, continent, country, region, subhex, POI
     * Default to region with optional 32x32 subhexes & 32x32 POI maps
     * */

    public class sysTerrainMapType : nwdbDataType
    {
        //properties
        protected virtual bool isContainer { get; set; }
        
        public sysTerrainMapType() { }
        public sysTerrainMapType(string n, string nl) :base(n,nl) { }
        public sysTerrainMapType(string n, string nl,bool container) : base(n, nl) {
            this.isContainer = container;
        }


    public static IList<sysTerrainMapType> GetTerrains() {
        IList<sysTerrainMapType> res = new List<sysTerrainMapType>();
        res.Add(new sysTerrainMapType("Global", "Global Map",true));
        res.Add(new sysTerrainMapType("Continent", "Continent Map",true));
        res.Add(new sysTerrainMapType("Country", "Country Map",true));
        res.Add(new sysTerrainMapType("Region", "Regional Map",true));
        res.Add(new sysTerrainMapType("SubHexes", "Subhexes Map",false));
        res.Add(new sysTerrainMapType("POI", "POI Map",false));
        return res;

    
    }

}

}
