using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Resources;
using System.Diagnostics;
using norwold.model;
using DataModel.libDB;





namespace DataModel.libMapping
{
    /**
     * MapTileType
     * 
     * 
     * Defines if it mapTiles are:
     *      isHex               True = Hex map tiles, else assumed square tiles
     *      is2D                True = 2d (flat) map tiles, false = 3D (tiered) map tiles
     *      isPublic            True = Approve for Public use
     *      isProgessable       True = POITypes are progressable (assume type = mapPOIProgressableType), otherwise POIs dont progress up levels
     *      
     *      Description         Describe it e.g. 2D hex medieval & fantasy     
     *      Author              Reference to hostUserGM who created
     * */


    public class mapTileType : nwdbDataType
    {
        //constants
        //public static Color ColUnderdarkSolid = Color.FromArgb(unchecked((int)0xFF787878));


        //mapped properties
        public virtual bool isHex { get; set; }
        public virtual bool is2D { get; set; }
        public virtual bool isProgressable { get; set; }
        public virtual bool isPublic { get; set; }

        public virtual string Description { get; set; }
        public virtual string AuthorName { get; set; }
  
        //Referenced properties


        //constructors
        //constructors
        public mapTileType() : base() {  }
        public mapTileType(string n,string nl) : base(n,nl) {  }

        public mapTileType(string n, string nl, bool Hex, bool TwoD, bool Progress,string Desc, string author) : base(n, nl) { 
    
            this.isHex = Hex;
            this.is2D = TwoD;
            this.isProgressable = Progress;
            this.Description = Desc;
            this.AuthorName = author;

            //this.Public = false  [TODO]
        
        }

        public static void SeedListData(IList<mapTileType> tiles)
        {

            tiles.Add(new mapTileType("2D Hex Med", "2D Hex Medieval Fantasy", true, true, false, "Traditional 2D Hex map", "Stephen Dangerfield"));

        }


     }


}
