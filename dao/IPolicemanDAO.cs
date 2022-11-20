using FluentHibernateTest.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateTest.dao
{
    public interface IPolicemanDAO:IGenericDAO<Policeman>
    {
        Policeman getPolicemanByFirstNameAndLastName(string FirstName, string LastName);
        IList<Intruder> getAllIntruderOfPoliceman(long Id);
    }
}
