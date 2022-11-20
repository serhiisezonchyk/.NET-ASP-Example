using FluentHibernateTest.domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class DepartmentDAO : GenericDAO<Department>, IDepartmentDAO
    {
        public DepartmentDAO(ISession session) : base(session) { }
        public IList<Policeman> getAllPolicemanOfDepartment(long Id)
        {
            var list = session.CreateSQLQuery(
                " SELECT Policeman.* FROM Policeman " +
                " WHERE Policeman.DepartmentId='" + Id+ "'")
                .AddEntity("Policeman", typeof(Policeman))
                .List<Policeman>();
            return list;
        }
    }
}
