using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace AspDotNet2_l5
{
    public partial class Policedepartment : System.Web.UI.MasterPage
    {
        private ISessionFactory factory;
        private ISession session;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private ISession openSession(String host, int port, String database, String user, String passwd)
        {
            ISession session = null;
            Assembly mappingsAssemly = Assembly.GetExecutingAssembly();
            if (factory == null)
            {
                factory = Fluently.Configure()
                .Database(PostgreSQLConfiguration
                .PostgreSQL82.ConnectionString(c => c
                .Host(host)
                .Port(port)
                .Database(database)
                .Username(user)
                .Password(passwd)))
                .Mappings(m => m.FluentMappings
                .AddFromAssembly(mappingsAssemly))
                .BuildSessionFactory();
            }
            session = factory.OpenSession();
            return session;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            session = openSession("localhost", 5432,
            "policedepartment", WebConfigurationManager.AppSettings["login"] , WebConfigurationManager.AppSettings["pass"]);
            Session["hbmsession"] = session;
        }
    }
}