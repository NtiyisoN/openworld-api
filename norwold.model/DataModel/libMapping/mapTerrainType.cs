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





namespace DataModel.libMapping
{
    public class mapTerrainType : mapDataTypeDraw
    {
        //constants
        public static Color ColForest = Color.FromArgb(unchecked((int)0xFF74A33A));
        public static Color ColJungle = Color.FromArgb(unchecked((int)0xFF4D8F5A));
        public static Color ColGrass = Color.FromArgb(unchecked((int)0xFFC8EE8C));
        public static Color ColMountain = Color.FromArgb(unchecked((int)0xFFCA8D00));
        public static Color ColCactus = Color.FromArgb(unchecked((int)0xFFCCCC00));

        public static Color ColRiver = Color.FromArgb(unchecked((int)0xFF99CCFF));
        public static Color ColOcean = Color.FromArgb(unchecked((int)0xFF003366));
        public static Color ColSea = Color.FromArgb(unchecked((int)0xFF003366));

        public static Color ColHill = Color.FromArgb(unchecked((int)0xFF86A233));
        public static Color ColDesert = Color.FromArgb(unchecked((int)0xFFFFFF99));
        public static Color ColLava = Color.FromArgb(unchecked((int)0xFFFF9900));
        public static Color ColSwamp = Color.FromArgb(unchecked((int)0xFFADDEA5));

        public static Color ColBadlands = Color.FromArgb(unchecked((int)0xFFA0A09A));
        public static Color ColUnderdark = Color.FromArgb(unchecked((int)0xFFA0A09A));
        public static Color ColUnderdarkSolid = Color.FromArgb(unchecked((int)0xFF787878));

        //mapped properties
        public virtual char Value { get; set; }

  
        //Referenced properties
        public virtual mapTreeTerrain TerrainType { get; set; }

        //constructors
        public mapTerrainType() : base() { }
        
       
        public mapTerrainType(char val, string n, string nl, string resname, string importname, bool isTrans, int elev, int height, int stepc, Color bg, mapTreeTerrain tbase)
            : base(n, nl, resname, importname, isTrans, elev, height, stepc, bg, 0)
        {
            this.Value = val;
            this.TerrainType = tbase;

            //this.PGHexType = pgtype;
            Debug.Print("Loaded TerrainType (via treeLoad) " + nl + " using resource" + resname + " Resultant Bitmap width:" + this.Tile.Size.Width + "height" + this.Tile.Size.Height);
        }


     }


}
