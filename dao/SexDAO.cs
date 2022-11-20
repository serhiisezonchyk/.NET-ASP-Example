using FluentHibernateTest.domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public class SexDAO : GenericDAO<Sex>, ISexDAO
    {
        public SexDAO(ISession session) : base(session) { }
    }
}
