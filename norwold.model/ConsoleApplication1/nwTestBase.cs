using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernate.Automapping;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using NHibernate.Criterion;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NUnit.Framework;
using norwold.model;
using System.Diagnostics;
using DataModel.libDB;


namespace norwold.tests
{
    public class nwTestBase
    {
        protected nwdbConnection nw;
        protected ISessionFactory sessionFactory;
        protected nwdbRepository repo;


        protected void DropCreateDB(string dbname,string username,string password)
        {
            nw = new nwdbConnection(true,dbname,username,password);
            sessionFactory = nw.Factory;
            repo = new nwdbRepository(sessionFactory.OpenSession());
        }
       

        public nwTestBase()
        {
            DropCreateDB("norwold-test", "nwlogin", "nwlogin"); 
        }


    }
}
