using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.QorbMoasPor;

namespace JobManagement.Domain.QorbMoasPorAgg
{
    public interface IQorbMoasPorRepository : IRepository<long,QorbMoasPor>
    {
        List<QorbMoasPorViewModel> GetQorbMoasPors();
        EditQorbMoasPor GetDetails(long id);
        List<QorbMoasPorViewModel> Search(QorbMoasPorSearchModel SearchModel);
        List<QorbMoasPorViewModel> GetQorbMoasPorsWithQorbMoas(long id);
    }
}
