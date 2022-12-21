using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.Qorb;

namespace JobManagement.Application.Contracts.QorbMoas
{
    public interface IQorbMoasApplication
    {
        OperationResult Create(CreateQorbMoas command);
        OperationResult Edit(EditQorbMoas command);
        EditQorbMoas GetDetails(long id);
        List<QorbMoasViewModel> GetQorbMoass();
        List<QorbMoasViewModel> GetQorbMoassWithQorb(long id);
        List<QorbMoasViewModel> Search(QorbMoasSearchModel SearchModel);
    }
}
