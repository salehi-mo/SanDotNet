using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.PersonEshtegVaz;


namespace JobManagement.Domain.PersonEshtegVazAgg
{
    public interface IPersonEshtegVazRepository : IRepository<long, PersonEshtegVaz>
    {
        List<PersonEshtegVazViewModel> GetPersonEshtegVazs();
        EditPersonEshtegVaz GetDetails(long id);
        List<PersonEshtegVazViewModel> Search(PersonEshtegVazSearchModel SearchModel);
    }
}
