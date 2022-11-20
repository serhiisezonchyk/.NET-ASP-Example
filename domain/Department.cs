using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.domain
{
    public class Department:EntityBase
    {
        private IList<Policeman> policemenList = new List<Policeman>();
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual IList<Policeman> PolicemenList
        {
            get { return policemenList; }
            set { policemenList = value; }
        }

    }
}
