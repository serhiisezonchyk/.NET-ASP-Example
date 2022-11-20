using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.domain
{
    public class Sex:EntityBase
    {
        private IList<Policeman> policemenList = new List<Policeman>();

        private IList<Intruder> intrudersList = new List<Intruder>();
        public virtual string Name { get; set; }
        public virtual IList<Policeman> PolicemenList
        {
            get { return policemenList; }
            set { policemenList = value; }
        }
        public virtual IList<Intruder> IntrudersList
        {
            get { return intrudersList; }
            set { intrudersList = value; }
        }
    }
}
