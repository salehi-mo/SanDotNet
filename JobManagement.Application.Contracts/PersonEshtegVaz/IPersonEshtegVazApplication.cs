using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace JobManagement.Application.Contracts.PersonEshtegVaz
{
    public interface IPersonEshtegVazApplication
    {
        OperationResult Create(CreatePersonEshtegVaz command);
        OperationResult Edit(EditPersonEshtegVaz command);
        EditPersonEshtegVaz GetDetails(long id);
        List<PersonEshtegVazViewModel> GetPersonEshtegVazs();
        List<PersonEshtegVazViewModel> Search(PersonEshtegVazSearchModel SearchModel);
    }
}
