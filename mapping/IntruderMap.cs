using FluentHibernateTest.domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.mapping
{
    public class IntruderMap:ClassMap<Intruder>
    {
        public IntruderMap() {
            Table("Intruder");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName)
                .Length(50)
                .Not.Nullable();

            Map(x => x.LastName)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Age)
                .Not.Nullable();

            References(x => x.Sex, "SexId")
                .Not.Nullable();

            Map(x => x.Description)
                .Length(200);

            Map(x => x.Phone)
                .Length(12)
                .Not.Nullable();

            References(x => x.Policeman, "PolicemanId")
                .Not.Nullable();
        }
    }
}
