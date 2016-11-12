using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using DataModel.libDB;
using DataModel.libHosting;





namespace norwold.model 
{

	public class nwdbTest  {

		//private
		private IDbConnection _conn;
		private const String strConnection = "Server=STEVE-PC\\SQLEXPRESS;Database=norwold-run;User ID=nwlogin;Password=nwlogin;";
		//private IDbCommand _cmd;
		/**
		* Constructor
		* 
		* Example: 
		* Const_sys_dmgtype myConst_sys_dmgtype = new Const_sys_dmgtype();
		*/

		public nwdbTest() {
			//--
			Debug.Print("Calling nwdbConnection with paramater"+strConnection);
			this._conn = new SqlConnection(strConnection);
            Debug.Print("nwdbConnection created");
			_conn.Open();
            Debug.Print("nwdbConnection open");
		}

		/**
		* Properties
		*/
		public IDbConnection conn {
			get { return this._conn; }
			set { this._conn = value; }
		}



            static void Main() 	{
		

			var nw = new nwdbConnection ();
			var sessionFactory = nw.Factory;
            var repo = new nwdbRepository(sessionFactory.OpenSession());
            
            // retreive all dmgtypes and display them
			//var sorttypes = session.CreateCriteria(typeof(ConstSysStatisticSortGroup))
            //                .List<ConstSysStatisticSortGroup>();
            //campTree nwt;

            /*
            nwdbDataType nws;
            ConstSysItemFamily nwf;
            ConstSysItemClass nwc;
            nws = new ConstSysDmgType();
            WritePretty(nws.asList(session), "Damage Type");
            nws = new ConstSysAoeType();
            WritePretty(nws.asList(session), "Aoe Type");
            nws = new ConstSysCheckResult();
            WritePretty(nws.asList(session), "Check Result");
            nws = new ConstSysRange();
            WritePretty(nws.asList(session), "Ranges");
            nws = new ConstSysSchool();
            WritePretty(nws.asList(session), "Schools");
            nws = new ConstSysStatisticSortGroup();
            WritePretty(nws.asList(session), "Stat groups");
            nws = new ConstSysFrequency();
            WritePretty(nws.asList(session), "Frequency");
            
            Debug.WriteLine("Start" );
            nwf = repo.FindOrNew(typeof(ConstSysItemFamily), "Items", "General") as ConstSysItemFamily;

            Debug.WriteLine("Armor Family returned" + nwf.toString());
            nwf.LongName = "Armor + Shields";
            session.SaveOrUpdate(nwf);

           

            // WritePretty(nwf.asList(session), "Item Family");
            nwc = repo.FindOrNew(typeof(ConstSysItemClass), "Amulets", "Amulets, Necklaces") as ConstSysItemClass;


            var records = repo.asList(nwc);
            foreach (nwdbDataType r in records)
            {
                Debug.Print("Amulet Report:" + r.toString());
            }

            
            //WritePretty(nwc.asList(session), "Item Class");
            nwc.item_family = nwf;
            //int r = nwf.FindIDByName(session, "Armor");
            //Debug.WriteLine("Armor returned" + r as string);
            //Debug.WriteLine("Set ItemClass Family to" +nwc.item_family.toString());
            session.SaveOrUpdate(nwc);
             * */


            //add a dmttype
			//ConstSysDmgType c = new ConstSysDmgType("Piercing","Piercing Damage");
            //repo.Add(typeof(hostChar), new hostChar("Brian", "Brian Walter","brian@gibraltar.com"));

            //hostChar c = repo.FindbyID(typeof(hostChar), 1) as hostChar;
            //Debug.WriteLine(c.ToString());
                //session.SaveOrUpdate(c);
    		//transaction.Commit();
            //int did = repo.FindIDByLongName(typeof(hostChar), "Derek Willow2");
            //hostChar d = repo.FindbyID(typeof(hostChar), did) as hostChar;
            //Debug.WriteLine(d.ToString());

            Debug.Print("Calling List of hostChar");
            IList<nwdbDataType> il = repo.asList(typeof(hostChar));
                foreach (nwdbDataType item in il) {
                    Debug.Print(item.ToString());

                }
            }	
		
	}

}