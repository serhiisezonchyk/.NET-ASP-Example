using FluentHibernateTest.domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class PolicemanDAO : GenericDAO<Policeman>, IPolicemanDAO
    {
        public PolicemanDAO(ISession session) : base(session) { }
        public IList<Intruder> getAllIntruderOfPoliceman(long Id)
        {
            var list = session.CreateSQLQuery(
            "SELECT Intruder.* FROM Intruder " +
            " WHERE Intruder.PolicemanId='" + Id + "'")
            .AddEntity("Intruder", typeof(Intruder))
            .List<Intruder>();
            return list;
        }

        public Policeman getPolicemanByFirstNameAndLastName(string FirstName, string LastName)
        {
            var list = session.CreateSQLQuery(
            "SELECT Policeman.* FROM Policeman " +
            " WHERE Policeman.FirstName='" + FirstName + "'" +
            " and Policeman.LastName='" + LastName + "'")
            .AddEntity("Policeman", typeof(Policeman))
            .List<Policeman>();
            Policeman policeman = list[0];
            return policeman;
        }
    }
}
