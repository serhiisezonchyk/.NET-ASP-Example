using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.domain
{
    public class Policeman:EntityBase
    {
        private IList<Intruder> intrudersList = new List<Intruder>();
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Department Department { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual IList<Intruder> IntrudersList
        {
            get { return intrudersList; }
            set { intrudersList = value; }
        }
    }
}
