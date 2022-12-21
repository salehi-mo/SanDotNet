using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.QorbMoasPorKar;

namespace JobManagement.Domain.QorbMoasPorKarAgg
{
    public interface IQorbMoasPorKarRepository : IRepository<long, QorbMoasPorKar>
    {
        List<QorbMoasPorKarViewModel> GetQorbMoasPorKars();
        EditQorbMoasPorKar GetDetails(long id);
        List<QorbMoasPorKarViewModel> Search(QorbMoasPorKarSearchModel SearchModel);
        List<QorbMoasPorKarViewModel> GetQorbMoasPorKarsWithQorbMoasPor(long id);
    }
}
