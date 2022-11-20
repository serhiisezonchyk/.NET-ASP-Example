using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.domain
{
    public class Intruder : EntityBase
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual string Description { get; set; }
        public virtual string Phone { get; set; }
        public virtual Policeman Policeman { get; set; }
    }
}
