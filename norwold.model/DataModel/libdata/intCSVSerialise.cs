using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using norwold.model;
using System.IO;
using NHibernate;
using DataModel.libDB;


namespace DataModel.libData
{
    public interface intCSVSerialise {
        string WriteCSVHeader();                      //writes the header
        string WriteCSVRow(nwdbDataType s);            //writes the row
        bool ReadCSVHeader(string s);                 //reads the header, true if valid
        bool ReadCSVRow(string s);                    //reads the row
        IList<nwdbDataType> GetList();
    }

    public class CSVSerializer
    {
        protected FileStream fs;
        public string CSVFileName { get; set; }     //filename
        public string CSVFolder { get; set; }       //folder
        public bool bStrict { get; set; }           //fail if error and do nothing, otherwise pass exceptions
        protected FileStream file;

        public int DryRun(intCSVSerialise intface)
        {
            //doit Dry and return failed records
            return 0;

        }
        public int GoLiveWrite(List<string> Exceptions, string ExceptionFile, intCSVSerialise intface, ISession sess)
        {

            string thisstr;
            int eCount = 0;
            ; // doit, return exceptions and optionally write to file
            this.CSVFileName = intface.GetType().ToString();
            fs = new FileStream(this.CSVFolder+ "\\"+this.CSVFileName, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
               sw.WriteLine(intface.WriteCSVHeader());
                foreach (nwdbDataType sd in intface.GetList())
                {
                    try
                    {
                        thisstr = intface.WriteCSVRow(sd);
                        sw.WriteLine(thisstr);
                    }
                    catch (Exception e)
                    {
                        
                        Exceptions.Add(e.ToString());
                        eCount++;
                    }
                }
                return eCount;
            }

        }

        public CSVSerializer()
        {
            this.CSVFolder = "c:\\data\\csv";
            this.bStrict = false;

        }

    }


}
