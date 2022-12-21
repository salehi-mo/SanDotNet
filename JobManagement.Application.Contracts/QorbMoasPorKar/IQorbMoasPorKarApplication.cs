using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.QorbMoasPor;

namespace JobManagement.Application.Contracts.QorbMoasPorKar
{
    public interface IQorbMoasPorKarApplication
    {
        OperationResult Create(CreateQorbMoasPorKar command);
        OperationResult Edit(EditQorbMoasPorKar command);
        EditQorbMoasPorKar GetDetails(long id);
        List<QorbMoasPorKarViewModel> GetQorbMoasPorKars();
        List<QorbMoasPorKarViewModel> GetQorbMoasPorKarsWithQorbMoasPor(long id);
        List<QorbMoasPorKarViewModel> Search(QorbMoasPorKarSearchModel SearchModel);
    }
}
