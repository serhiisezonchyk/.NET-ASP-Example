using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    abstract public class DAOFactory
    {
        public abstract IRankDAO getRankDAO();
        public abstract IDepartmentDAO getDepartmentDAO();
        public abstract ISexDAO getSexDAO();
        public abstract IPolicemanDAO getPolicemanDAO();
        public abstract IIntruderDAO getIntruderDAO();
    }
}
