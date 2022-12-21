using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonEshtegVaz;

namespace JobManagement.Application.Contracts.PersonOzvNoa
{
    public interface IPersonOzvNoaApplication
    {
        OperationResult Create(CreatePersonOzvNoa command);
        OperationResult Edit(EditPersonOzvNoa command);
        EditPersonOzvNoa GetDetails(long id);
        List<PersonOzvNoaViewModel> GetPersonOzvNoas();
        List<PersonOzvNoaViewModel> Search(PersonOzvNoaSearchModel SearchModel);
    }
}
