using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataModel.libData;

namespace DataModel.libMapping
{
    /**
     * Class to Persist terrain to a stream (file or db)#
     * Also can Import Hexographer definitions
     * */

    public class mapTerrainFiler
    {
        const string HEX_TRUE = "truecolumns";
        const string HEX_VERSION = "version";
        const string HEX_SHOWHIDE = "show/hide";
        const string HEX_T_LINE = "line_template";
        const string HEX_T_TERRAIN = "terrain_template";
        const string HEX_T_TEXT= "text_template";
        const string HEX_START = "hexes";
        const string HEX_POI = "feature";
        const string HEX_MKEY_START = "map-key";
        const string HEX_MKEY_END = "end-map-key";
        const string HEX_START_TEXT = "Text";
        const string HEX_START_LINE = "Line";


            public bool ReadMapHeader(string h,mapTerrainMapHeader hdr)
            {
                string[] split, subsplit;
 
                Debug.Print("Converting Header:" + h);

                try
                {
                    split = h.Split(',');
                    if ( split.Length != 5) { throw new Exception("invalid header format:" + h); }

                    //get grid dimensions
                    hdr.Width = Int32.Parse(split[0]);
                    hdr.Height = Int32.Parse(split[1]);

                    //get hex dimensions
                    subsplit = split[2].Split('x');
                    hdr.HexHeight = Int32.Parse(subsplit[0]);
                    hdr.HexWidth = Int32.Parse(subsplit[1]);

                    if (hdr.Height == 0 || hdr.Width == 0 || hdr.HexHeight == 0 || hdr.HexWidth == 0)
                    {
                        Debug.Print("Header failed to read coords");
                        throw new Exception("Header failed to read coords");
                    }

                    subsplit = split[3].Split(':');
                    hdr.Id = Int32.Parse(subsplit[1]);
                    hdr.bTrueColumns = split[4].Contains(HEX_TRUE);

                    int vloc = split[4].IndexOf(HEX_VERSION);
                        if (vloc > 0)
                        {
                            hdr.version = split[4].Substring(vloc+HEX_VERSION.Length,Math.Min(10,split[4].Length-(vloc+HEX_VERSION.Length)));
                        }

                    //srip out crap from URL;
                    hdr.URL = split[4];
                    if (hdr.version.Length>0) {
                        hdr.URL = hdr.URL.Replace(hdr.version,"");
                        hdr.URL = hdr.URL.Replace(HEX_VERSION, "");
                    }
                    if (hdr.bTrueColumns) {
                        hdr.URL = hdr.URL.Replace(HEX_TRUE,"");
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Debug.Print("Failed with exception" + e.ToString());
                    return false;
                }

            }

            public bool WriteMapHeader(out string h,mapTerrainMapHeader hdr)
            {
                string tmp;
                try
                {
                    tmp = hdr.Width + "," + hdr.Height + "," + hdr.HexWidth + "x" + hdr.HexHeight;
                    tmp = tmp + ",id:" + hdr.Id;
                    if (hdr.bTrueColumns)
                    {
                        tmp = tmp + HEX_TRUE;
                    }
                    tmp = tmp + " " + hdr.URL;
                    h = tmp;
                    return true;
                }
                catch (Exception e)
                {
                    Debug.Print("Write Header hit Exception" + e.ToString());
                    h = null;
                    return false;
                }
            }

            nwTerrainMap nwMap;
            public IList<string> TemplateLines;
            public IList<string> TemplateTerrain;
            public IList<string> TemplateText;
            public IList<string> ErrorList;

        public mapTerrainFiler()
        {
            nwMap = new nwTerrainMap();

            TemplateLines = new List<string>();
            TemplateTerrain = new List<string>();
            TemplateText = new List<string>();
            ErrorList = new List<string>();
        }

        protected bool ReadHex(string line)
        {
            //if terrain add Hex, else add POI to current hex
             string[] fields;
            fields = line.Split('\t');
            switch (fields[0])
            {
                case HEX_POI:

                    break;

                default:

                    break;
            }
            return true;
        }

        protected bool ReadLine(string line)
        {
            string[] fields;
            fields = line.Split('\t');
            switch (fields[0])
            {
                case HEX_T_LINE:
                    TemplateLines.Add(line);
                    break;
                case HEX_T_TERRAIN:
                    TemplateTerrain.Add(line);
                    break;
                case HEX_T_TEXT:
                    TemplateText.Add(line);
                    break;
                default:
                    return false;
            }
            return true;
        }


        public bool ReadMapFromString(string content)
        {
            int eCount = 0;
            bool bHexMode = false;
            bool bTextMode = false;
            bool bLineMode = false;

            try
            {
                using (var reader = new StringReader(content))
                {
                    string line;
                    line = reader.ReadLine();
                    if (!ReadMapHeader(line,nwMap.header)) { throw new Exception("Parseheader failed for line"+line);}


                    
                    while ((line = reader.ReadLine()) != null)
                    {

                        if (line.Substring(0, HEX_START.Length) == HEX_START)
                        {
                            Debug.Print("Found Hexes - starting read");
                            bHexMode = true;
                            bLineMode = false;
                            bTextMode = false;
                        }

                        if (line.Substring(0, HEX_START_TEXT.Length) == HEX_START_TEXT)
                        {
                            Debug.Print("Found Text - starting read");
                            bTextMode = true;
                            bHexMode = false;
                            bLineMode = false;
                        }

                        if (line.Substring(0, HEX_START_LINE.Length) == HEX_START_LINE)
                        {
                            Debug.Print("Found Text - starting read");
                            bLineMode = true;
                            bHexMode = false;
                            bTextMode = false;
                        }


                        if (bHexMode)
                        {
                            if (!this.ReadHex(line)) { eCount++; ErrorList.Add(line); }
                        } else {
                            if (!this.ReadLine(line)) { eCount++; ErrorList.Add(line); };
                        }
                    }
                }
                Debug.Print("Completed Reading String");
                Debug.Print("Header:" + nwMap.header.ToString());
                Debug.Print("Failure count" + eCount+"\n ErrorLines:");
                foreach (string err in ErrorList)
                {
                    Debug.Print(err);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.Print("Failed to read from Stream" + e.ToString());
                return false;
            }
        }



    public static void ReadFromResource() {

        
        string fileContent = Properties.Resources.hexo_181;
        
    }
    
    
    }



}
