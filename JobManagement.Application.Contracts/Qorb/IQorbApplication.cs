using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonOzvNoa;

namespace JobManagement.Application.Contracts.Qorb
{
    public interface IQorbApplication
    {
        OperationResult Create(CreateQorb command);
        OperationResult Edit(EditQorb command);
        EditQorb GetDetails(long id);
        List<QorbViewModel> GetQorbs();
        List<QorbViewModel> Search(QorbSearchModel SearchModel);
    }
}
