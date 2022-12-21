using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.Qorb;

namespace JobManagement.Domain.QorbAgg
{
    public interface IQorbRepository : IRepository<long,Qorb>
    {
        List<QorbViewModel> GetQorbs();
        EditQorb GetDetails(long id);
        List<QorbViewModel> Search(QorbSearchModel SearchModel);

    }
}
