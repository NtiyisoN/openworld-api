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
using DataModel.libMapping.interfaces;
using DataModel.libCampaign;
using DataModel.libDB;



namespace DataModel.libMapping
{
    public class mapDataTypeDraw : nwdbDataType, IfaceMapDraw
    {
        /**
         * sysDataTypeDraw is the core hextype class for terrain, place of interest and terrain mods
         * 
         * 
         *
         **/
        
        
        
        //locals        
        private Color _bgColor;
        protected int _elevation;
        protected int _height;
        protected int _stepcost;
        

        //unmapped properties
        public virtual SolidBrush brBackground { get; set; }
        public virtual TextureBrush brForeground { get; set; }


        //mapped properties
        public virtual int Elevation { get; set; }
        public virtual int HeightTerrain { get; set; }
        public virtual int StepCost { get; set; }
        public virtual int LayerPriority { get; set; }
        public virtual Bitmap Tile { get; set; } // holds the fullsize image, provides (scaled) texturebrushes via getBrush

        public virtual string ResourceName { get; set; }
        public virtual string ImportName { get; set; }

 
        public virtual Color bgColor
        {
            get { return this._bgColor; }
            set
            {
                if (this.brBackground != null) { this.brBackground.Dispose(); this.brBackground = null; }
                this._bgColor = value;
                if (value != null && value != Color.Empty)
                {
                    this.brBackground = new SolidBrush(this._bgColor);
                }
            }
        }

        //Referenced properties
        public virtual IList<campHex> Hexes { get; set; }
        public virtual bool isTransparent { get; set;}

        //constructors
        public mapDataTypeDraw() : base() { this.Hexes = new List<campHex>(); }
        public mapDataTypeDraw(string n, string nl) : base(n,nl) { this.Hexes = new List<campHex>(); }

        public mapDataTypeDraw(string n, string nl, string resname, string importname, bool isTrans,  int elev, int height, int stepc,Color bg, int Priority)
            : base(n, nl)
        {
            ResourceManager rm = new ResourceManager("DataModel.Properties.Resources",typeof(mapTerrainType).Assembly);
            this.Tile = (Bitmap)rm.GetObject(resname);
            this.SetBrush(Tile.Size, false);
            this.ResourceName = resname;
            this.isTransparent = isTrans;
            this.ImportName = importname;
            this.bgColor = bg;
            this._elevation = elev;
            this._height = height;
            this._stepcost = stepc;
            this.LayerPriority = Priority;
            //this.PGHexType = pgtype;
            this.Hexes = new List<campHex>();

            Debug.Print("Loaded DrawType" + nl + " using resource" + resname + " Resultant Bitmap width:" + this.Tile.Size.Width + "height" + this.Tile.Size.Height);
         }




         //methods
        public virtual void SetBrush(Size s, bool transposed) {
            Bitmap working;

            //Allow dynamic Load of resource on Call as Resources not stored in db and could be proxied
            if (Tile == null)
            {
                ResourceManager rm = new ResourceManager("DataModel.Properties.Resources", typeof(mapTerrainType).Assembly);
                this.Tile = (Bitmap)rm.GetObject(this.ResourceName);
            }



            working = new Bitmap(Tile);
            if (transposed) working = RotateImage(working);
            if (Math.Max(s.Width, s.Height) != Math.Max(Tile.Size.Width, Tile.Size.Height) && Math.Min(s.Width, s.Height) != Math.Min(Tile.Size.Width, Tile.Size.Height))
            {
                Debug.Print("RESIZE TileSize:  " + Tile.Size.ToString() + "RequestedSize: " + s.ToString() + "Transposed" + transposed.ToString());
                working = ResizeImage(working,s);
            }
            if (working == null) throw new Exception("Null Pointer in Graphics classes");
            if (this.brForeground != null) { this.brForeground.Dispose(); }
            this.brForeground = new TextureBrush(working);
            working.Dispose();
        }

        public static Bitmap RotateImage(Bitmap imgToRotate)
        {
            try
            {
                using (Image img = (Image)imgToRotate)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return new Bitmap(img);
                }

            }
            catch { return null; }
        }

        public virtual void PrintHex(Size s, Graphics g)
        {
            //Prints a Hex onto a square canvas
            //Create DrawPaths
            //Size s = new Size(Canvas.Width, Canvas.Height);
            Size GridSize = new Size ( (int)(s.Width * 0.5),(int)(s.Height* 0.5));


            GraphicsPath HexGridPath = new GraphicsPath();
            
            /*
            HexGridPath.AddLines(new Point[] {
                new Point(s.Width*2/4   ,           0), 
                new Point(s.Width*4/4   ,s.Height*1/4),
                new Point(s.Width*4/4   ,s.Height*3/4),
                new Point(s.Width*2/4   ,s.Height*4/4),
                new Point(0             ,s.Height*3/4),
                new Point(0             ,s.Height*2/4),
                new Point(s.Width*2/4   ,           0)
            });
            */
            HexGridPath.AddLines(new Point[] {
	                    new Point(s.Width*2/4   ,           0),
	                    new Point(s.Width*4/4-1   ,s.Height*1/4),
	                    new Point(s.Width*4/4-1   ,s.Height*3/4),
	                    new Point(s.Width*2/4   ,s.Height*4/4),
	                    new Point(0             ,s.Height*3/4),
	                    new Point(0             ,s.Height*1/4),
	                    new Point(s.Width*2/4   ,           0)
	                });
            GraphicsPath HexgridRect = new GraphicsPath();
            HexgridRect.AddRectangle(new Rectangle(0, s.Height*1/4, GridSize.Width, GridSize.Height*2/4));
            

            using (g)
            {
                //Draw Black outline
                g.DrawPath(Pens.Black, HexGridPath);
                //Fill with Background
                if (this.brBackground != null) { g.FillPath(this.brBackground, HexGridPath); } else { Debug.Print("Background Empty for" + this.LongName); }
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //g.DrawImage(this.Tile, b, 0, b.Width, b.Height);
                
                
                
                //if (this.brForeground == null) this.SetBrush(GridSize,false);
                //g.FillPath(this.brForeground, HexgridRect);
            }
        }


        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            try
            {
                Bitmap b = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage((Image)b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return b;
            }
            catch { return null; }
        }


    }


}
