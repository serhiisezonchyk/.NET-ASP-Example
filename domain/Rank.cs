using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.domain
{
    public class Rank:EntityBase
    {
        private IList<Policeman> policemenList = new List<Policeman>();
        public virtual string Name { get; set; }

        public virtual IList<Policeman> PolicemenList
        {
            get { return policemenList; }
            set { policemenList = value; }
        }

    }
}
