using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Resources;
using System.Diagnostics;

using norwold.model;
using DataModel.libDB;
using NHibernate;


namespace DataModel.libMapping
{
    public class mapTileSetManager     {
        
        // locals
        private Dictionary<char, mapTerrainType> dictByChar;
        private Dictionary<string, mapTerrainType> dictByName;
        private Dictionary<string, mapTerrainType> dictByImportName;
        private Dictionary<string, mapTreeTerrain> dictTreeTerrainByName;
        

        private Dictionary<string, mapPOIType> POIdictByImportName;
        private Dictionary<string, mapPOIType> POIdictByName;
        private Dictionary<string, mapTreePOI> dictTreePOIbyName;

        

        //properties
        public virtual IList<mapTerrainType> TerrainTypes { get; set; }
        public virtual IList<mapPOIType> POITypes { get; set; }
        public virtual mapTreeTerrain mTreeTerrain { get; set; }
        public virtual mapTreePOI mTreePOI { get; set; }
        //constructors

        public mapTileSetManager()
        {
            TerrainTypes = new List<mapTerrainType>();
            POITypes = new List<mapPOIType>();
            mTreeTerrain = new mapTreeTerrain();
            mTreePOI = new mapTreePOI();

            dictByChar= new Dictionary<char,mapTerrainType>();
            dictByName= new Dictionary<string,mapTerrainType>();
            dictByImportName = new Dictionary<string, mapTerrainType>();
            dictTreeTerrainByName = new Dictionary<string, mapTreeTerrain>();
            dictTreePOIbyName = new Dictionary<string, mapTreePOI>(); 
            
            POIdictByName = new Dictionary<string, mapPOIType>();
            POIdictByImportName = new Dictionary<string, mapPOIType>();
  
        }



        public mapTileSetManager(ISession sess): this()
        {
            
            //
            TerrainTypes = sess.QueryOver<mapTerrainType>().List();
            POITypes = sess.QueryOver<mapPOIType>().List();
            //mTreeTerrain = sess.QueryOver<mapTreeTerrain>().Future<mapTreeTerrain>;

        }

        public void Init(mapTreeTerrain mtree, mapTreePOI mPOI)
        {
            //Need mTreeTerrain to be possible to exist before creating other defaults
            if (mtree != null) { mTreeTerrain = mtree; }
            else { InitmapTerrainTree(mTreeTerrain); }
            
            foreach (mapTreeTerrain mt in mTreeTerrain.Descendants){
                Debug.Print("Adding Name" + mt.Name + " Count of Dict" + dictTreeTerrainByName.Count);
                dictTreeTerrainByName.Add(mt.Name, mt);
            }


            InitMapTerrains(TerrainTypes, dictTreeTerrainByName);
            //build dictionaries
            foreach (mapTerrainType t in TerrainTypes)
            {
                
                dictByChar.Add(t.Value, t);
                dictByName.Add(t.LongName, t);

                if (!t.ImportName.Contains("|")) { dictByImportName.Add(t.ImportName, t); }
                else  {
                    var split = t.ImportName.Split('|');
                    foreach (string s in split){ dictByImportName.Add(s, t); }
                }
            }

            if (mPOI != null) { mTreePOI = mPOI; }
            else  { mTreePOI = this.SeedTreeDataPOI();  }


            foreach (mapTreePOI mp in mTreePOI.Descendants)
            {
                Debug.Print("Adding Name" + mp.Name + " Count of Dict" + dictTreePOIbyName.Count);
                dictTreePOIbyName.Add(mp.Name, mp);
            }

            //InitPOITypes(POITypes);
            foreach (mapPOIType sp in POITypes)
            {
                POIdictByImportName.Add(sp.ImportName, sp);
                POIdictByName.Add(sp.LongName, sp);
            }
        }


        //methods
        public mapTerrainType FindTerrain(string nl)
        {

            if (this.dictByName.ContainsKey(nl)) { return dictByName[nl]; }
            else { return null; } 
         }

        public mapTerrainType FindTerrainbyChar(char v)
        {
            if (this.dictByChar.ContainsKey(v))  { return dictByChar[v];}
            else { return null;} 
        }

        public mapTerrainType FindTerrainbyImportName(string impname)
        {

            if (this.dictByImportName.ContainsKey(impname)) { return this.dictByImportName[impname]; }
            else { return this.dictByImportName["Empty"]; } 
        }

        public void SetBrushSize(Size s)
        {
            foreach (mapTerrainType t in TerrainTypes){ t.SetBrush(s,false);}
            //foreach (POIType p in POITypes) { p.SetBrush(s, false); }
        }

        public TextureBrush GetForegroundBrush(char v)
        {
            string msg;
            
            mapTerrainType t = this.FindTerrainbyChar(v);
            if (t == null)
            {
                Debug.Print("Failed to find Type for Value:" + v);
                throw new Exception("GetForeGroundBrush failed t foind terrain for character"+v);
            }
            else
            {
                msg = "Found for Value" + v;
                return t.brForeground; 
            }
        }

        public virtual mapTreeTerrain SeedTreeDataTerrain()
        {
            mapTreeTerrain mtRoot, mtEmpty, mtLand, mtWater;
            mtRoot = new mapTreeTerrain(mapConst.mapTreeNameTerrain, 0);


            mtEmpty = new mapTreeTerrain("Empty/Error", 0);
            mtLand = new mapTreeTerrain("Land Terrain", 0);
            mtWater = new mapTreeTerrain("Water Terrain", 0);

            mtEmpty.AddChild(new mapTreeTerrain("Empty", 0));

            mtLand.AddChild(new mapTreeTerrain("Grass", 0));
            mtLand.AddChild(new mapTreeTerrain("Desert", 0));
            mtLand.AddChild(new mapTreeTerrain("Mountain", 0));
            mtLand.AddChild(new mapTreeTerrain("Hill", 0));
            mtLand.AddChild(new mapTreeTerrain("Forest", 0));
            mtLand.AddChild(new mapTreeTerrain("Mixed", 0));
            mtLand.AddChild(new mapTreeTerrain("Evergreen", 0));
            mtLand.AddChild(new mapTreeTerrain("Jungle", 0));
            mtLand.AddChild(new mapTreeTerrain("Snow", 0));
            mtLand.AddChild(new mapTreeTerrain("Badland", 0));
            mtLand.AddChild(new mapTreeTerrain("Other", 0));

            mtWater.AddChild(new mapTreeTerrain("Water", 0));

            mtRoot.AddChild(mtEmpty);
            mtRoot.AddChild(mtWater);
            mtRoot.AddChild(mtLand);
            return mtRoot;
        }

        public virtual mapTreePOI SeedTreeDataPOI()
        {
            mapTreePOI mtRoot, mtResourceMod, mtPOI, mtTravelMod, mtEventMod;

            mtRoot = new mapTreePOI(mapConst.mapTreeNamePOI, 0);
            mtResourceMod = new mapTreePOI("Resource Modifiers", 0);
            mtTravelMod = new mapTreePOI("Travel Modifiers", 0);
            mtEventMod = new mapTreePOI("Event Modifiers", 0);
            mtPOI = new mapTreePOI("Places of Interest", 0);


            //Events
            mtEventMod.POITypes.Add(new mapPOIType("Battle", "Battle", "poi_battle", "Battle", 0, 1));
            mtEventMod.POITypes.Add(new mapPOIType("Fleet", "Fleet", "poi_fleet", "Sailship", 0, 1));
            mtEventMod.POITypes.Add(new mapPOIType("Wreck", "Ship Wreck", "poi_shipwreck", "Shipwreck", 0, 1));
            mtEventMod.POITypes.Add(new mapPOIType("Warcamp", "Warcamp", "poi_warcamp", "Primitive", 0, 1));
            mtEventMod.POITypes.Add(new mapPOIType("Lair", "Lair", "poi_lair", "Monster Lair", 0, 1));

            //Resources
            mtResourceMod.POITypes.Add(new mapPOIType("Oasis", "Oasis", "poi_oasis", "Oasis", 0, 1));
            mtResourceMod.POITypes.Add(new mapPOIType("Gold", "Gold", "poi_gold", "Resource", 0, 1));
            mtResourceMod.POITypes.Add(new mapPOIType("Windmill", "Windmill", "poi_windmill", "Windmill", 0, 1));
            mtResourceMod.POITypes.Add(new mapPOIType("Skull", "Skull", "poi_crossbones", "Bad Magic Source", 0, 1));
            mtResourceMod.POITypes.Add(new mapPOIType("Fish", "Fish", "poi_fish", "Fishing", 0, 1));

            //Travel
            mtTravelMod.POITypes.Add(new mapPOIType("Bridge", "Bridge", "poi_bridge", "Bridge", +2, 1));

            //POIs
            mtPOI.POITypes.Add(new mapPOIType("Mine", "Mine", "poi_mine", "Mines", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Village", "Village", "poi_village", "Village", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Port", "Port", "poi_port", "Port", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Castle", "Castle", "poi_castle", "Castle", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Tower", "Tower", "poi_tower", "Tower", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Keep", "Keep", "poi_keep", "Fort", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Camp", "Camp", "poi_camp", "Campsite", 0, 1));

            mtPOI.POITypes.Add(new mapPOIType("Tents", "Tents", "poi_tents", "Tee-pee", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Idol", "Idol", "poi_idol", "Totem", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Ruins", "Ruins", "poi_village_ruins", "Ruins", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Ruins-City", "Ruined City", "poi_town_ruins", "Ruined City", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Cave", "Cave", "poi_cave", "Cave", 0, 1));

            mtPOI.POITypes.Add(new mapPOIType("Monolith", "Monolith", "poi_obelisk", "Monolith", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Landmark", "Landmark", "poi_henge", "Landmark", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Pyramid", "Pyramid", "poi_pyramid", "Pyramid", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Shrine", "Shrine", "poi_shrine", "Shrine", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Palace", "Palace", "poi_palace", "Palace", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Temple", "Temple", "poi_temple", "Temple", 0, 1));
            mtPOI.POITypes.Add(new mapPOIType("Tomb", "Tombstone", "poi_tombstone", "Tombstone", 0, 1));

            mtRoot.AddChild(mtPOI);
            mtRoot.AddChild(mtResourceMod);
            mtRoot.AddChild(mtTravelMod);
            mtRoot.AddChild(mtEventMod);
            return mtRoot;
        }



        public static void InitmapTerrainTree(mapTreeTerrain mTree)
        {
            mapTreeTerrain mtEmpty, mtLand, mtWater;

 
            mtEmpty = new mapTreeTerrain("Empty/Error", 0);
            mtLand = new mapTreeTerrain("Land Terrain", 0);
            mtWater = new mapTreeTerrain("Water Terrain", 0);
            
            mtEmpty.AddChild(new mapTreeTerrain("Empty", 0));
            mtLand.AddChild(new mapTreeTerrain("Grass", 0));
            mtLand.AddChild(new mapTreeTerrain("Desert", 0));
            mtWater.AddChild(new mapTreeTerrain("Water", 0));
            mtLand.AddChild(new mapTreeTerrain("Mountain", 0));
            mtLand.AddChild(new mapTreeTerrain("Hill", 0));
            mtLand.AddChild(new mapTreeTerrain("Forest", 0));
            mtLand.AddChild(new mapTreeTerrain("Mixed", 0));
            mtLand.AddChild(new mapTreeTerrain("Evergreen", 0));
            mtLand.AddChild(new mapTreeTerrain("Jungle", 0));
            mtLand.AddChild(new mapTreeTerrain("Snow", 0));
            mtLand.AddChild(new mapTreeTerrain("Badland", 0));
            mtLand.AddChild(new mapTreeTerrain("Other", 0));

            mTree.AddChild(mtEmpty);
            mTree.AddChild(mtWater);
            mTree.AddChild(mtLand);
        }



        protected static void InitMapTerrains(IList<mapTerrainType> Types, IDictionary<string, mapTreeTerrain> dictTreeTerrainByName)
        {
 

            Types.Add(new mapTerrainType('E', "Empty", "Empty", "terrain_empty", "Empty|Blank", false, 4, 4, 5, Color.Red,dictTreeTerrainByName["Empty"]));
            Types.Add(new mapTerrainType('.', "Grass", "Grasslands", "terrain_grass", "Farmland|Grassland", false, 1, 1, 4, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType('H', "Hill", "Hills", "terrain_hill", "Hills|Moor", false, 3, 3, 6, mapTerrainType.ColHill, dictTreeTerrainByName["Hill"]));
            Types.Add(new mapTerrainType('D', "Desert", "Deserts", "terrain_desert", "Sandy Desert|Beach", false, 1, 2, 5, mapTerrainType.ColDesert, dictTreeTerrainByName["Desert"]));
            Types.Add(new mapTerrainType('d', "Dunes", "Dunes", "terrain_desert_dunes", "Sand Dunes", false, 1, 2, 5, mapTerrainType.ColDesert, dictTreeTerrainByName["Desert"]));
            Types.Add(new mapTerrainType('e', "Desert-C", "Coastal Desert", "terrain_desert_coastal", "Coastal Desert", false, 1, 2, 5, mapTerrainType.ColDesert, dictTreeTerrainByName["Desert"]));
            Types.Add(new mapTerrainType('c', "Desert-R", "Rocky Desert", "terrain_desert_rocky", "Rocky Desert", false, 1, 2, 5, mapTerrainType.ColDesert, dictTreeTerrainByName["Desert"]));
            Types.Add(new mapTerrainType('R', "River", "Rivers", "terrain_water_sea", "Sea|Kelp Forest|Kelp Forest Heavy|Reefs|Shoals", false, 1, 1, 5, mapTerrainType.ColRiver, dictTreeTerrainByName["Water"]));
            Types.Add(new mapTerrainType('S', "Sea", "Sea", "terrain_water_sea", "Ocean", false, 1, 1, 5, mapTerrainType.ColSea, dictTreeTerrainByName["Water"]));
            Types.Add(new mapTerrainType('O', "Ocean", "Ocean", "terrain_water_sea", "Deep Ocean|Deep Sea", false, 1, 1, 5, mapTerrainType.ColOcean, dictTreeTerrainByName["Water"]));

            //Mountains
            Types.Add(new mapTerrainType('M', "Mounts", "Mountains", "terrain_mountains", "Mountains|Full Mountains", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType('m', "Mount", "Mountain", "terrain_mountain", "Mountain", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType('n', "Mounts-S", "Snowy Mountains", "terrain_mountains_snowy", "Snowcapped Mountains", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType('o', "Mount-S", "Snowy Mountain", "terrain_mountain_snowy", "Snowcapped Mountain", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType('V', "Volcano-A", "Volcano", "terrain_volcano_active", "Volcano", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType('W', "Volcano-D", "Dormant Volcano", "terrain_volcano_dormant", "Dormant Volcano", false, 4, 4, 5, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));

            //Forest 
            Types.Add(new mapTerrainType('F', "Forest", "Forests", "terrain_forest", "Forest|Full Forest", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            Types.Add(new mapTerrainType('f', "Forest-L", "Light Forest", "terrain_forest_wood", "Light Forest", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            Types.Add(new mapTerrainType('g', "Forest-H", "Forest Hill", "terrain_forest_hill", "Forested Hills", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            Types.Add(new mapTerrainType('h', "Forest-M", "Forest Mountain", "terrain_forest_mountain", "Forested Mountain", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            Types.Add(new mapTerrainType('i', "Forest-MS", "Forest Mountains", "terrain_forest_mountains", "Forested Mountains", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            Types.Add(new mapTerrainType('j', "Forest-W", "Forest Wetlands", "terrain_forest_wetlands", "Forested Wetlands", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Forest"]));
            
            //Mixed Forest
            Types.Add(new mapTerrainType('Q', "Mixed", "Mixed Forests", "terrain_mixed", "Mixed Forest Heavy", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Mixed"]));
            Types.Add(new mapTerrainType('q', "Mixed-L", "Mixed Wood", "terrain_mixed_wood", "Mixed Forest", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Mixed"]));
            //Types.Add(new sysTerrainType('r', "Mixed-M", "Mixed Forest Mountain", "terrain_mixed_mountain", "Mixed Forest Mountain", false, 1, 2, 8, sysTerrainType.ColForest));
            //Types.Add(new sysTerrainType('s', "Mixed-MS", "Mixed Forest Mountains", "terrain_mixed_mountains", "Mixed Forest Mountains", false, 1, 2, 8, sysTerrainType.ColForest));

            //Jungle
            Types.Add(new mapTerrainType('J', "Jungle", "Jungle", "terrain_jungle", "Jungle  Forests", false, 1, 2, 8, mapTerrainType.ColJungle, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType('K', "Jungle-L", "Jungle Light", "terrain_jungle_wood", "Light Jungle|Jungle Wetlands", false, 1, 2, 8, mapTerrainType.ColJungle, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType('k', "Jungle-H", "Jungle Hill", "terrain_jungle_hill", "Jungle Hills", false, 1, 2, 8, mapTerrainType.ColJungle, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType('L', "Jungle-M", "Jungle Mountain", "terrain_jungle_mountain", "Jungle Mountain", false, 1, 2, 8, mapTerrainType.ColJungle, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType('l', "Jungle-MS", "Jungle Mountains", "terrain_jungle_mountains", "Jungle Mountains", false, 1, 2, 8, mapTerrainType.ColJungle, dictTreeTerrainByName["Jungle"]));

            //Evergreen
            Types.Add(new mapTerrainType('T', "EverGreen", "Heavy Evergreen", "terrain_evergreen", "Heavy Evergreen", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));
            Types.Add(new mapTerrainType('t', "EGreen-L", "Evergreen Light", "terrain_evergreen_wood", "Light Evergreen", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));
            Types.Add(new mapTerrainType('u', "EGreen-H", "Evergreen Hill", "terrain_evergreen_hill", "Evergreen Hills", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));
            Types.Add(new mapTerrainType('v', "EGreen-M", "Evergreen Mountain", "terrain_evergreen_mountain", "Evergreen Mountain", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));
            Types.Add(new mapTerrainType('w', "EGreen-MS", "Evergreen Mountains", "terrain_evergreen_mountains", "Evergreen Mountains", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));
            Types.Add(new mapTerrainType('x', "EGreen-W", "Evergreen Wetlands", "terrain_evergreen_wetlands", "Evergreen Wetlands", false, 1, 2, 8, mapTerrainType.ColForest, dictTreeTerrainByName["Evergreen"]));

            
            
            //use 35 45, 47-64 & 91 - 126 for rare ones
            // 46 reserved for grass 
            Types.Add(new mapTerrainType((char)35, "Badland", "Badlands", "terrain_badlands", "Badlands|Full Badlands", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)36, "Broken", "Brokenlands", "terrain_brokenlands", "Broken Lands", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            //37
            Types.Add(new mapTerrainType((char)38, "Cactus", "Cactus", "terrain_cactus", "Cactus", false, 4, 4, 5, mapTerrainType.ColGrass, dictTreeTerrainByName["Other"]));
            Types.Add(new mapTerrainType((char)39, "Cactus-H", "Cactus Heavy", "terrain_cactus_heavy", "Heavy Cactus", false, 4, 4, 5, mapTerrainType.ColCactus, dictTreeTerrainByName["Other"]));
            Types.Add(new mapTerrainType((char)40, "Culti", "Cultivated", "terrain_cultivated", "Cultivated Farmland|Full Wheatfields", false, 4, 4, 5, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            //41
            Types.Add(new mapTerrainType((char)42, "Dead-F", "Dead Forest", "terrain_dead_forest", "Dead Forest", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)43, "Dead-FH", "Dead Forest Hill", "terrain_dead_forest_hill", "Dead Forest Hills", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)44, "Dead-FM", "Dead Forest Mountain", "terrain_dead_forest_mountain", "Dead Forest Mountain", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)45, "Dead-FMS", "Dead Forest Mountains", "terrain_dead_forest_mountains", "Dead Forest Mountains", false, 4, 4, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            //Types.Add(new sysTerrainType((char)46, "Dead-G", "Dead Grassland", "terrain_dead_grass", "Erma", false, 1, 1, 5, sysTerrainType.ColBadlands));
            Types.Add(new mapTerrainType((char)47, "Dead-W", "Dead Wetland", "terrain_dead_wetlands", "Dead Forest Wetlands", false, 1, 1, 5, mapTerrainType.ColBadlands, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)48, "Moss", "Moss", "terrain_moss", "Moss", false, 1, 1, 6, mapTerrainType.ColSwamp, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType((char)49, "Mud", "Mud", "terrain_mud", "Mud", false, 1, 1, 7, mapTerrainType.ColMountain, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType((char)50, "Lava", "Lava", "terrain_lava", "Lave", false, 1, 1, 6, mapTerrainType.ColLava, dictTreeTerrainByName["Mountain"]));
            Types.Add(new mapTerrainType((char)51, "Fungal", "Fungal Forest", "terrain_fungal_forest", "Heavy Fungal Forest", false, 1, 1, 7, mapTerrainType.ColSwamp, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType((char)52, "Fungal-L", "Light Fungal Forest", "terrain_fungal_wood", "Fungal Forest", false, 1, 1, 6, mapTerrainType.ColSwamp, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType((char)53, "Grassland", "Grassland", "terrain_grassland", "Steppe|Grazing Land", false, 1, 1, 6, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)54, "Grass-H", "Grassland Hill", "terrain_grassland_hill", "Grassland Hills|Grassy Hills", false, 1, 1, 7, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)55, "Grass-P", "Grassland Poor", "terrain_grassland_poor", "Grassland Poor", false, 1, 1, 6, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)56, "Savanna", "Savana", "terrain_savanna", "Savana", false, 1, 1, 7, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)57, "Shrub", "Shrubland", "terrain_shrubland", "Shrubland", false, 1, 1, 6, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)58, "Shrub-H", "Shrubland Hill", "terrain_shrubland_hill", "Shrubland Hills", false, 1, 1, 6, mapTerrainType.ColGrass, dictTreeTerrainByName["Grass"]));
            Types.Add(new mapTerrainType((char)59, "Swamp", "Swamp", "terrain_swamp", "Swamp", false, 1, 1, 6, mapTerrainType.ColSwamp, dictTreeTerrainByName["Jungle"]));
            //60
            Types.Add(new mapTerrainType((char)61, "Marsh", "Marsh", "terrain_marsh", "Marsh", false, 1, 1, 6, mapTerrainType.ColSwamp, dictTreeTerrainByName["Jungle"]));
            Types.Add(new mapTerrainType((char)62, "Under", "Underdark", "terrain_underdark_open", "Open Underdark", false, 1, 1, 6, mapTerrainType.ColUnderdark, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)63, "Under-R", "Underdark - Solid Rock", "terrain_underdark_solidrock", "Solid Rock", false, 1, 1, 6, mapTerrainType.ColUnderdarkSolid, dictTreeTerrainByName["Badland"]));
            Types.Add(new mapTerrainType((char)64, "Under-B", "Underdark Brokenlands", "terrain_underdark_brokenlands", "Broken Lands Underdark", false, 4, 4, 5, mapTerrainType.ColUnderdark, dictTreeTerrainByName["Badland"]));


            Types.Add(new mapTerrainType((char)91, "Snow", "Snow", "terrain_water_ocean", "Snow Fields", false, 1, 1, 6, Color.GhostWhite, dictTreeTerrainByName["Snow"]));
            Types.Add(new mapTerrainType((char)92, "Snow-D", "Snowy Desert", "terrain_ice_desert", "Cold Desert", false, 1, 1, 6, Color.GhostWhite, dictTreeTerrainByName["Snow"]));
            Types.Add(new mapTerrainType((char)93, "Snow-H", "Snowy Hill", "terrain_ice_hill", "Unknown Snow", false, 1, 1, 6, Color.GhostWhite, dictTreeTerrainByName["Snow"]));
            Types.Add(new mapTerrainType((char)94, "Glacier", "Glacier", "terrain_ice_hill", "Glacier", false, 1, 1, 6, Color.GhostWhite, dictTreeTerrainByName["Snow"]));
        }


    }
    

}
