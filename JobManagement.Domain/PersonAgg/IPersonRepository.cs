using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.Person;

namespace JobManagement.Domain.PersonAgg
{
    public interface IPersonRepository : IRepository<long, Person>
    {
        List<PersonViewModel> GetPersons();
        EditPerson GetDetails(long id);
        List<PersonViewModel> Search(PersonSearchModel SearchModel);



    }
}
