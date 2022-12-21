using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonEshtegVaz;

namespace JobManagement.Application.Contracts.Person
{
   public interface IPersonApplication
    {
        OperationResult Create(CreatePerson command);
        OperationResult Edit(EditPerson command);
        EditPerson GetDetails(long id);
        List<PersonViewModel> GetPersons();
        List<PersonViewModel> Search(PersonSearchModel SearchModel);
    }
}
