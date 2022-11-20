using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class NHibernateDAOFactory:DAOFactory
    {
        protected ISession session = null;
        public NHibernateDAOFactory(ISession session)
        {
            this.session = session;
        }
        public override ISexDAO getSexDAO()
        {
            return new SexDAO(session);
        }
        public override IDepartmentDAO getDepartmentDAO()
        {
            return new DepartmentDAO(session);
        }
        public override IRankDAO getRankDAO()
        {
            return new RankDAO(session);
        }
        public override IPolicemanDAO getPolicemanDAO()
        {
            return new PolicemanDAO(session);
        }
        public override IIntruderDAO getIntruderDAO()
        {
            return new IntruderDAO(session);
        }
    }
}
