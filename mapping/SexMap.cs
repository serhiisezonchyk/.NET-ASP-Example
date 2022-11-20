using FluentHibernateTest.domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.mapping
{
    public class SexMap:ClassMap<Sex>
    {
        public SexMap()
        {
            Table("Sex");
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Name)
                .Not.Nullable();

            HasMany(x => x.IntrudersList)
             .Inverse()
             .Cascade.All()
             .KeyColumn("SexId");

            HasMany(x => x.PolicemenList)
             .Inverse()
             .Cascade.All()
             .KeyColumn("SexId");
        }
    }
}
