using FluentHibernateTest.domain;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class IntruderDAO : GenericDAO<Intruder>, IIntruderDAO
    {
        public IntruderDAO(ISession session) : base(session) { }
        public Intruder getIntruderByFirstNameAndLastName(string FirstName, string LastName)
        {
            Intruder intruder = new Intruder();
            intruder.FirstName = FirstName;
            intruder.LastName = LastName;
            ICriteria criteria = session.CreateCriteria(typeof(Intruder))
            .Add(Example.Create(intruder));
            IList<Intruder> list = criteria.List<Intruder>();
            intruder = list[0];
            return intruder;
        }
    }
}
