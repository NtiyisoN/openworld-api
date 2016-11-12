using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataModel.libMapping;
using DataModel.libCampaign;
using DataModel.libDB;




namespace DataModel.libData
{
    /**
     * Class to Persist a terrain / block of hexes
     * 
     * TerrainMaps are of a certain type (think level/depth) and can have parents and children
     * Maps can have children & hexes can have children as well (subMaps)
     * POIs can have Maps (essentially submaps) as well
     * We only track parentMaps & Hexes, subMaps are children of the Hex itself (campHex)
     * Childmaps will  be determined by Region (currently pointless in a rectagonal only implication 
     * (see v0.1 notes).
     * 
     * v0.1 
     * 
     * uses character based string arrays for hexdefinition to be compatible with PGNapoleonics
     * submaps default to 32x32 for compatibility with Hex3D
     * currently only handles rectangular maps again for compatibility, move to sparse rectangles
     * 
     * */

    public class nwTerrainMap : nwdbDataType
    {
        //locals
        protected int curr_x, curr_y;

        //properties 
        protected virtual string[] curr_board { get; set; }
        public virtual sysTerrainMapType MapType { get; set; }
        public virtual mapTerrainMapHeader header { get; set; }
        public virtual IList<campHex> HexList { get; set; }

        /**
         * Parent Hexes are used for subhex maps (dominions) or POIMaps
         * Parent Maps are used for referring back to previous parent
         * Note child maps are based upon regions within the parent TODO
         * */
        public virtual campHex ParentHex { get; set; }
        public virtual nwTerrainMap ParentMap { get; set; }


        //constructors
        public nwTerrainMap()
        {
            header = new mapTerrainMapHeader();
            HexList = new List<campHex>();
        }

        public nwTerrainMap(string n, string nl): base(n,nl)
        {
            header = new mapTerrainMapHeader();
            HexList = new List<campHex>();
        }

        //methods
        public string[] GetBoard(out int x, out int y) {
            x= header.Width;
            y = header.Height;
            int ctotal = 0;
            int curr_x = curr_y = 0;
    
            if (HexList.Count != (x * y))
            {
                throw new ApplicationException("Error in GetBoard wanted"+(x*y)+" hexes and hexList is only"+HexList.Count);
            }

            string[,] Array2D = new string[y, x];
                while (curr_x < x)
                {
                    y = 0;
                    while (curr_y < y)
                    {
                        Array2D[curr_y, curr_x] = HexList[ctotal].Name;
                        ctotal++;
                        curr_y++;
                    }
                    x++;
                }
            return curr_board;
            }           
 
    }



}
