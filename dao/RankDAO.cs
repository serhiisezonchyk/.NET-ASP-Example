using FluentHibernateTest.domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class RankDAO : GenericDAO<Rank>, IRankDAO
    {
        public RankDAO(ISession session) : base(session) { }
        public IList<Policeman> getAllPolicemanOfRank(string name)
        {
            var list = session.CreateSQLQuery(
            " SELECT Policeman.* FROM Policeman JOIN Rank" +
            " ON Policeman.RankId = Rank.Id" +
            " WHERE Rank.Name='" + name + "'")
            .AddEntity("Policeman", typeof(Policeman))
            .List<Policeman>();
            return list;
        }
    }
}
