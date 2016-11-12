using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using norwold.model;
using DataModel.libHosting;
using NHibernate;
using DataModel.libDB;

namespace norwold.forms
{
    public class sysDocuments : System.Drawing.Printing.PrintDocument
    {
        public hostUser Logon { get; set; }
        public hostChar Character { get; set; }
        public nwdbRepository Repository { get; set; }
        public nwdbConnection Database { get; set; }

        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager stm;


        public sysDocuments(hostUser logon,hostChar ch,nwdbRepository repo, nwdbConnection nw)
        {
            this.Logon = logon;
            this.Character = ch;
            this.Repository = repo;
            this.Database = nw;
            initData();
        }

        public void initData(){
            //Create&Drop
            if (this.Database == null) { this.Database = new nwdbConnection(); }
            sessionFactory = this.Database.Factory;
            if (this.Repository == null) { this.Repository = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = this.Repository.GetSession();
            stm = new sysTreeManager();
            //repo.SeedMockData();
        }

        private void InitializeComponent()
        {

        }



    }
}
