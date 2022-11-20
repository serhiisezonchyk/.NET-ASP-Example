using FluentHibernateTest.domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.mapping
{
    public class DepartmentMap:ClassMap<Department>
    {
        public DepartmentMap()
        {
            Table("Department");
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.Address)
                .Length(50)
                .Not.Nullable();

            Map(x => x.City)
                .Length(100)
                .Not.Nullable();

            HasMany(x => x.PolicemenList)
            .Inverse()
            .Cascade.All()
            .KeyColumn("DepartmentId");
        }
    }
}
