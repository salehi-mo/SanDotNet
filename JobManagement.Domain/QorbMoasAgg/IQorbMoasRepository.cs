using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Domain.QorbMoasAgg;

namespace JobManagement.Domain.QorbMoasAgg
{
    public interface IQorbMoasRepository : IRepository<long, QorbMoas>
    {
        List<QorbMoasViewModel> GetQorbMoass();
        List<QorbMoasViewModel> GetQorbMoassWithQorb(long id);
        EditQorbMoas GetDetails(long id);
        List<QorbMoasViewModel> Search(QorbMoasSearchModel SearchModel);
       
    }
}
