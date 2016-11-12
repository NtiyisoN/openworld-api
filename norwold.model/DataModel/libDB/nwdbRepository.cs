using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Data.SqlClient;
using DataModel.libHosting;
using DataModel.libCampaign;
using DataModel.libMapping;
using DataModel.libData;



namespace DataModel.libDB
{
    public class nwdbRepository
    {
        private ISession i;
        public nwdbRepository(ISession sess) { this.i = sess; }

        public virtual nwdbDataType FindbyID(Type t, int id)
        {
            return i.Get<nwdbDataType>(id);
        }

        public virtual nwdbDataType Find(Type t, string nl)
        {
            int r = FindIDByLongName(t, nl);
            return i.Get(t, r) as nwdbDataType;
        }

        public virtual nwdbDataType FindOrCreate(Type t, string nshort, string nl)
        {
            Object o;

            int r = FindIDByLongName(t, nl);
            if (r == 0)
            {
                ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(string), typeof(string) });
                o = ci.Invoke(new object[] { nshort, nl }) as nwdbDataType;
                Add(o as nwdbDataType);
                return o as nwdbDataType;
            }
            else
            {
                return i.Get(t, r) as nwdbDataType;
            }
        }

        public virtual bool SeedMockData()
        {
           //NEW FEDERATED Initialisations

            //libMapping Create Base;
            this.CreateLibMapping();

            //libHosting Create Base
            this.CreateLibHosting();

            //libRuleSet Create Base
            this.CreateLibRuleset();

            //libRuleSet Create Base
            this.CreateLibCampaign();


            try
            {
                //Seed Characters
                hostUser steve = this.Find((typeof(hostUser)), "unclemessy") as hostUser;
                hostUser lewis = this.Find((typeof(hostUser)), "lewis") as hostUser;
                hostUser matt = this.Find((typeof(hostUser)), "matsly") as hostUser;

                if (FindIDByLongName(typeof(hostChar), "Messy da Anti Hero") == 0)
                {
                    hostChar c = new hostChar("Messy", "Messy da Anti Hero", steve);
                    c.RefreshCharacterStats(i);

                    //Chuck in some items
                    nwItem i1 = new nwItem("+1 Dagger", "+1 Dagger");
                    i1.Owner = c;
                    c.Items.Add(i1);
                    nwItem i2 = new nwItem("+4 LongBow", "+4 LongBow");
                    i2.Description = "This is a mega bow created by the elven lords";
                    i2.Owner = c;
                    c.Items.Add(i2);
                    Add(c);

                    //i.SaveOrUpdate(new campCharCampaign(traitPBEM, c, false));
                    //traitPBEM.Characters.Add(c);
                    //i.SaveOrUpdate(c);
                }
                if (FindIDByLongName(typeof(hostChar), "Sabbath") == 0)
                {
                    hostChar c = new hostChar("Sabbath", "Sabbath", matt);
                    c.RefreshCharacterStats(i);

                    //Chuck in some items
                    nwItem i1 = new nwItem("+5 Vorpal", "+5 Vorpal Sword");
                    i1.Owner = c;
                    c.Items.Add(i1);
                    Add(c);
                }

                if (FindIDByLongName(typeof(hostChar), "Muttley") == 0)
                {
                    hostChar c = new hostChar("Muttley", "Muttley", lewis);
                    c.RefreshCharacterStats(i);
                    this.Add(c);
                    //i.SaveOrUpdate(new campCharCampaign(traitPBEM, c, false));
                    //i.SaveOrUpdate(c);
                }


                this.Save(steve);
                this.Save(matt);
                //this.Save(traitPBEM);


                return true;
            }
            catch (GenericADOException ex)
            {
                var sql = ex.InnerException as SqlException;
                if (sql != null)
                {
                    Debug.Print("Caught GenericADO:" + ex.ToString());
                    Debug.Print("Caught Inner:" + sql.ToString());
                    Debug.Print("SQL ErrorNumber:" + sql.Number.ToString());
                    throw;
                }
                return false;
            }

        }



        public virtual int FindIDByLongName(Type t, string n)
        {
            //Debug.Print(t.Name);
            var r = i.CreateCriteria(t.Name)
                  .Add(Restrictions.Eq("LongName", n))
                  .UniqueResult<nwdbDataType>();
            if (r == null)
            {
                return 0;
            }
            else
            {
                return r.id;
            }

        }

        public virtual bool DeleteByLongName(Type t, string n)
        {
            nwdbDataType nw = Find(t, n);
            if (nw == null)
            {
                // Not Found
                return false;
            }
            else
            {
                Delete(nw);
                return false;
            }
        }

        public void Delete(nwdbDataType nw)
        {
            Debug.Print("Delete called on:" + nw.GetType() + "param:" + nw);
            if (nw == null) { return; };
            using (ITransaction transaction = i.BeginTransaction())
            {
                i.Delete(nw);
                transaction.Commit();
            };
        }
        public void Add2(nwdbDataType nw)
        {

        }

        public void Add(nwdbDataType nw)
        {
            Debug.Print("Add called on:" + nw.GetType() + "params:" + nw.ToString());
            using (ITransaction transaction = i.BeginTransaction())
            {
                i.SaveOrUpdate(nw);
                transaction.Commit();
            }

        }


        public void Save(nwdbDataType nw)
        {
            Debug.Print("Save called on:" + nw.GetType() + "params:" + nw.ToString());
            using (ITransaction transaction = i.BeginTransaction())
            {
                i.SaveOrUpdate(nw);
                transaction.Commit();
            }

        }
        public virtual string GetTableName(Type t)
        {
            var u = i.SessionFactory.GetClassMetadata(t.Name) as NHibernate.Persister.Entity.AbstractEntityPersister;
            return u.TableName;
        }

        public ISession GetSession()
        {
            return i;
        }

        public virtual IList<nwdbDataType> asList(Type t)
        {

            return i.CreateCriteria(t.Name)
                    .List<nwdbDataType>();
        }


        public virtual void CreateLibRuleset()
        {
            //Creates initial data for the Ruleset
            
            
            //SysDamageRolls
            IList<sysDamageRoll> dmgrolls = new List<sysDamageRoll>();
            sysDamageRoll.SeedListData(dmgrolls);
            foreach (sysDamageRoll sd in dmgrolls) { this.Add(sd); }

            //sysLanguages
            IList<sysLanguage> currList = new List<sysLanguage>();
            sysLanguage.SeedListData(currList);
            foreach (sysLanguage l in currList) { this.Add(l); }
  

            //sysTreeItemType
            sysTreeItemType sysItemTree = sysTreeItemType.SeedTreeData(dmgrolls);
            i.SaveOrUpdate(sysItemTree);

            //sysDevelopment & sysTreeDevelopment
            IList<sysDevelopment> sysDev = new List<sysDevelopment>();
            sysTreeDevelopment sysdevTree = sysTreeDevelopment.SeedTreeData(sysDev);
            i.SaveOrUpdate(sysdevTree);
            foreach (sysDevelopment sdev in sysDev) { this.Add(sdev); }
            
            //Remap children
            i.Flush();

            //Statistics
            IList<sysBaseStatistic> stats = new List<sysBaseStatistic>();
            sysTreeStatistic statTree = sysTreeStatistic.SeedTreeData(stats);
            i.SaveOrUpdate(statTree);
            foreach (sysBaseStatistic st in stats) { this.Add(st); }

            //sysAOETypes
            IList<sysAOEType> aoetypes = new List<sysAOEType>();
            sysAOEType.SeedListData(aoetypes);
            foreach (sysAOEType aoe in aoetypes) { this.Add(aoe); }

            //sysDurations
            IList<sysBaseDurationType> sdtypes = new List<sysBaseDurationType>();
            sysBaseDurationType.SeedListData(sdtypes);
            foreach (sysBaseDurationType sd in sdtypes) { this.Add(sd); }

            //sysAlignments
            IList<sysBaseAlignment> altypes = new List<sysBaseAlignment>();
            sysBaseAlignment.SeedListData(altypes);
            foreach (sysBaseAlignment a in altypes) { this.Add(a); }

            //sysDmgTypes
            IList<sysBaseDamageType> dmgtypes = new List<sysBaseDamageType>();
            sysBaseDamageType.SeedListData(dmgtypes);
            foreach (sysBaseDamageType d in dmgtypes) { this.Add(d); }

            //sysFactionRanks
            IList<sysFactionRanking> facranks = new List<sysFactionRanking>();
            sysFactionRanking.SeedListData(facranks);
            foreach (sysFactionRanking fr in facranks) { this.Add(fr); }

            //sysMilestoneTypes
            IList<sysMilestoneType> smiletypes = new List<sysMilestoneType>();
            sysMilestoneType.SeedListData(smiletypes);
            foreach (sysMilestoneType smt in smiletypes) { this.Add(smt); }


        }


        public virtual void CreateHostUsers(IList<hostUserType> usertypelist)
        {

            hostUser steve, matt, lewis;
            hostUserType players, gms, admins;
            admins = usertypelist.Where(x => x.LongName == hostConstants.usrSysAdmin).First();
            gms = usertypelist.Where(x => x.LongName == hostConstants.usrRulesetAdmin).First();
            players = usertypelist.Where(x => x.LongName == hostConstants.usrPlayer).First();


            //seed users
            steve = new hostUser("unclemessy", "unclemessy", "stephen_dangerfield@yahoo.co.uk", "muppet");
            steve.fbID = "10152572366130895";
            steve.fbAccessToken = "CAANSyHyJq9gBAFYZB2qpnJkZAEsicsnF0kYa7qPIoUZARqGZBhgXpNAZCRN9MplrL6ZCRXRMAUi5AV54NTi8CA9TI6aamXb7HvZAyqMv8Uw4mSNPt6Xtg6TIY3X3YqlvJeYHZC1laqeJUfvSFgZCuuECTmZCv3b2OefSOZBwl1xJC69H5s1Baj9lNMIWwPBbxFt1S2i36jTnUsBQwAm2fM9K0wJ";
            steve.fbGender = "male";
            steve.fbFirstName = "Steve";
            steve.fbSurname = "Dangerfield";
            //steve.CreateCampaign("Legends", "Land of Legends", "dangerfield.stephen@yahoo.com.au", "A Dark and nasty underworld Land plagued by the Mists of Krondell and the spawns of Chortos");


            matt = new hostUser("matsly", "matsly", "matsilvester@hotmail.co.uk", "muppet");
            matt.fbID = "10152966328743429";
            matt.fbAccessToken = "CAANSyHyJq9gBAL332yEjJrLTZA1GH2rAAn9ZBTy9hXyIvaNkQJdNZBZCOe6y6pZCMeQ0VW0ARq0awxbFsla23lVKdZCpte4CvAR3690Y6X8UDcQJmhF25swYdJmeOUQvfFUEomAVWVcDYXrieywtFzRhrw3MdZAHjQXeKCuZCAH84MGfvU0Qo6pgbylvk09E6W3RnFWdhF45gtc1cFAIMgmI";
            matt.fbGender = "male";
            matt.fbFirstName = "Matthew";
            matt.fbSurname = "Silvester";
            //matt.CreateCampaign("traitPBEM", "Traits Play by Email", "dangerfield.stephen@yahoo.com.au", "This is a PBEM game for the Drowe Underworld");

            lewis = new hostUser("lewis", "lewis", "lewis@hotmail.com", "muppet");

            //Add to correct host usertypelist after creation

            steve.UserType = admins;
            matt.UserType = gms;
            lewis.UserType = players;

            this.Save(steve);
            this.Save(matt);
            this.Save(lewis);

        }

        public virtual void CreateLibHosting()
        {

            //Creates initial data for libHosting

            //hostUserTypes
            this.Add(new hostUserType("Admin", hostConstants.usrSysAdmin));
            this.Add(new hostUserType("Player", hostConstants.usrPlayer));
            this.Add(new hostUserType("RuleAdmin", hostConstants.usrRulesetAdmin));
            this.Add(new hostUserType("Unreg", hostConstants.usrUnregistered));
            IList<hostUserType> huTypes = this.i.QueryOver<hostUserType>().List();
 
            CreateHostUsers(huTypes);
            //users are presisted by being added to their types.


        }

        public virtual void CreateLibCampaign()
        {
            //Creates initial data for the defalt d20 Campaign
            //need Milestonetypes for Campaign Milestone tree
            IList<sysMilestoneType> sysMileStoneTypes = i.QueryOver<sysMilestoneType>().List();

            //nwMileStoneTree
            campTreeMileStone milestoneTree = campTreeMileStone.SeedTreeData(sysMileStoneTypes);
            i.SaveOrUpdate(milestoneTree);
            
            //campTreeFaction
            campTreeFaction factionTree = campTreeFaction.SeedTreeData();
            i.SaveOrUpdate(factionTree);

            //campTreeFaction
            campTreeLocation locationTree = campTreeLocation.SeedTreeData();
            i.SaveOrUpdate(locationTree);


        }

        public virtual void CreateLibMapping()
        {
            //Creates initial data for the default Medieaveal Mapset

            mapTreeTerrain mt = new mapTreeTerrain("Terrain Type Tree", 0);
            mapTileSetManager.InitmapTerrainTree(mt);
            i.Save(mt);

            //Create defaults using existing mTree
            mapTileSetManager ttm = new mapTileSetManager(i);
            ttm.Init(mt,null);

            foreach (mapTerrainType st in ttm.TerrainTypes) { this.Add(st); }
            foreach (mapPOIType sp in ttm.POITypes) { this.Add(sp); }

        }
    }

}
