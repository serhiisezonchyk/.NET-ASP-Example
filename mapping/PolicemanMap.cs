using FluentHibernateTest.domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.mapping
{
    public class PolicemanMap:ClassMap<Policeman>
    {
        public PolicemanMap()
        {
            Table("Policeman");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName)
                .Length(100)
                .Not.Nullable();

            Map(x => x.LastName)
                .Length(100)
                .Not.Nullable();

            Map(x => x.Age)
                .Not.Nullable();

            References(x => x.Sex, "SexId")
                .Not.Nullable();

            References(x => x.Department, "DepartmentId")
                .Not.Nullable();
            References(x => x.Rank, "RankId")
                .Not.Nullable();
        }
    }
}
