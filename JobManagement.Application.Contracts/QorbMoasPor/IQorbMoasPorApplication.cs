using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.QorbMoas;

namespace JobManagement.Application.Contracts.QorbMoasPor
{
    public interface IQorbMoasPorApplication
    {
        OperationResult Create(CreateQorbMoasPor command);
        OperationResult Edit(EditQorbMoasPor command);
        EditQorbMoasPor GetDetails(long id);
        List<QorbMoasPorViewModel> GetQorbMoasPors();
        List<QorbMoasPorViewModel> GetQorbMoasPorsWithQorbMoas(long id);
        List<QorbMoasPorViewModel> Search(QorbMoasPorSearchModel SearchModel);
    }
}
