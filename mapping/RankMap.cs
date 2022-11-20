using FluentHibernateTest.domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.mapping
{
    public class RankMap : ClassMap<Rank>
    {
        public RankMap()
        {
            Table("Rank");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name)
                .Length(30)
                .Not.Nullable();

            HasMany(x => x.PolicemenList)
            .Inverse()
            .Cascade.All()
            .KeyColumn("RankId");
        }
    }
}
