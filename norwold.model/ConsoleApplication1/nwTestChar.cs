using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using norwold.model;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using DataModel.libDB;
using DataModel.libHosting;
using DataModel.libData;



namespace norwold.tests
{
    

    
    [TestFixture]
    public class nwTestChar : nwTestBase
    {
        [SetUp]
        public void SetupBlank()
        {
            Debug.Print("Ugg");

        }
        
        /**
 [SetUp]
 public void InitVariables() {
     nw = new nwdbConnection(true);
     sessionFactory = nw.Factory;
     repo = new nwSystemRepository(sessionFactory.OpenSession());
     Assert.IsNotNull(repo);
     Debug.Print("Initialisation complete");
 }
 **/






            public nwTestChar() : base()
            {
            //Initialize here
            //InitVariables();
            }

       [Test]
       public void nwChar_DeleteIfExistsWhenExists()
        {
            hostChar c = new hostChar("Brian", "Brian Walter", null);
            Debug.Print("Creating char record");
            repo.Add(c);
            bool res = repo.DeleteByLongName(typeof(hostChar), "Brian Walter");
            Assert.AreEqual(res, false);
        }

        [Test]
       public void nwChar_DeleteIfExistsWhenNotExists()
        {
            Debug.Print("DeleteIfExists - When doesnt exists");
            bool res = repo.DeleteByLongName(typeof(hostChar), "gibberish2-030");
            Assert.AreEqual(res,false);
        }

        [Test]
        public void nwChar_AddAndFindByID()
        {
            hostChar c = new hostChar("Brian", "Brian Walter",null);
            Debug.Print("Creating char record");
            repo.Add(c);
            Assert.Greater(repo.FindIDByLongName(typeof(hostChar),"Brian Walter"), 0);

            //Now delete
            repo.Delete(c);
        }
        


        [Test]
        public void nwChar_AddAndFindThenDelete()
        {
            Debug.Print("Creating char record");
            repo.Add(new hostChar("Barry", "Barry Manilow", null));
            
            //Find Record
            Debug.Print("Calling Find Char created");
            var Character = repo.Find(typeof(hostChar), "Barry Manilow");
            Assert.AreEqual(Character.LongName, "Barry Manilow");

            //Now delete
            repo.Delete(Character);


            //Ensure not Found
            Assert.AreEqual(repo.FindIDByLongName(typeof(hostChar), "Barry Manilow"), 0);
        }



        [Test]
        public void nwChar_FindOrCreateWhenExists()
        {
            hostChar c = new hostChar("Barry", "Barry Manilow", null);
            Debug.Print("Creating char record");
            repo.Add(c);

            //Find Record
            Debug.Print("Calling Find or Create on Char created");
            var Character = repo.FindOrCreate(typeof(hostChar), "Barry","Barry Manilow");
            Assert.AreEqual(Character.LongName, "Barry Manilow");

            //Now delete
            repo.Delete( Character);
        }

        [Test]
        public void nwChar_FindOrCreateWhenNotExists()
        {
            
            //Find Record
            Debug.Print("Calling Find or Create on Char on nonexistant character");
            var Character = repo.FindOrCreate(typeof(hostChar), "Barry", "Barry Manilow");
            Assert.AreEqual(Character.LongName, "Barry Manilow");
            //Now delete
            repo.Delete(Character);

        }

        [Test]
        public void nwSystemRepository_SeedMockData()
        {
            bool res = repo.SeedMockData();
            Assert.AreEqual(res, true);
        }

        [Test]
        public void nwChar_CreateTwoRecordsAndList()
        {
            Debug.Print("Calling Add x 2");
            hostChar c1 = new hostChar("Steve", "Steve Dangerfield", null);
            hostChar c2 = new hostChar("Gary", "Gary Barlow", null);

            repo.Add(c1);
            Assert.Greater(repo.FindIDByLongName(typeof(hostChar), "Steve Dangerfield"), 0);
            repo.Add(c2);
            Assert.Greater(repo.FindIDByLongName(typeof(hostChar), "Gary Barlow"), 0);
            Debug.Print("Calling List of hostChar");
            IList<nwdbDataType> il = repo.asList(typeof(hostChar));
                foreach (nwdbDataType item in il) {
                    Debug.Print(item.ToString());
                }
            Assert.Greater(il.Count,1);

            //Now delete
            repo.Delete( c1);
            repo.Delete( c2);
        }
        /**
        protected void CreateDuplicateChar() {

            repo.Add(typeof(hostChar), new hostChar("Steve", "Steve Dangerfield", "wanker@wabkjer.com"));
            repo.Add(typeof(hostChar), new hostChar("Steve", "Steve Dangerfield", "wanker@wabkjer.com"));
        }

        [Test]
        public void nwChar_CreateDuplicate()
        {
            Assert.Throws(NUnit.Framework.Is.InstanceOf(typeof(NHibernate.Exceptions.GenericADOException)), new TestDelegate(CreateDuplicateChar));
            repo.DeleteByLongName(typeof(hostChar), "Steve Dangerfield");
        }
        **/

        [Test]
        public void nwChar_CreateOwnedItem()
        {
            hostChar c = new hostChar("God", "God is a DJ", null);
            nwItem i1 = new nwItem("+1 dagger", "+1 Dagger");
            nwItem i2 = new nwItem("+1 dagger", "+4 LongBow");
            i2.Description = "This is a mega bow created by the elven lords";
            c.Items.Add(i1);
            c.Items.Add(i2);
            repo.Add(c);


            //now delete
            repo.Delete( c);
        }

        [Test]
        public void nwDB_CreateDatabase()
        {
            bool res;
            nwdbConnection nw2 = new nwdbConnection();
            res = nw2.CreateDatabase("norwold-ui");
            Assert.AreEqual(res, true);
        }

        static void Main() { Debug.Print("Goodbye World null static main in test fixture"); }

        [Test]
        public void nwDB_SeedRepo()
        {
            nwdbConnection nw2 = new nwdbConnection(true);
            sessionFactory = nw.Factory;
            repo = new nwdbRepository(sessionFactory.OpenSession());
            repo.SeedMockData();
        }

    }
}
