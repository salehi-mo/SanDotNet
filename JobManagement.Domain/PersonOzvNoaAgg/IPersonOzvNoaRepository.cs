using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Application.Contracts.PersonOzvNoa;


namespace JobManagement.Domain.PersonOzvNoaAgg
{
    public interface IPersonOzvNoaRepository : IRepository<long, PersonOzvNoa>
    {
        List<PersonOzvNoaViewModel> GetPersonOzvNoas();
        EditPersonOzvNoa GetDetails(long id);
        List<PersonOzvNoaViewModel> Search(PersonOzvNoaSearchModel SearchModel);

    }
}
