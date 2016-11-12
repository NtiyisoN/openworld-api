using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using norwold.model;

namespace DataModel.libMapping
{
    /**
     * Class to represent MapDimensions
     * Also can Import Hexographer definitions
     * 
     * Component Class
     * */

    public class mapTerrainMapHeader
    {
            public int Height;
            public int Width;
            public int HexHeight;
            public int HexWidth;

            public string version;
            public int Id;
            public bool bTrueColumns;
            public string URL;
            public mapTerrainMapHeader() { }

            public override string ToString()
            {
                string t;
                t = "Height:" + this.Height + ", Width" + this.Width;
                t = t + "HexSize:" + this.HexWidth + "x" + this.HexHeight;
                t = t + "ID:" + this.Id;
                t = t + "TrueHexes" + this.bTrueColumns;
                t = t + "URL" + this.URL;
                return t;
            }

   
    }
}
