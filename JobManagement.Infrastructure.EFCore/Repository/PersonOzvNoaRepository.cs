using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Domain.PersonOzvNoaAgg;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class PersonOzvNoaRepository : RepositoryBase<long, PersonOzvNoa>, IPersonOzvNoaRepository
    {
        private readonly JobContext _context;

        public PersonOzvNoaRepository(JobContext context) : base(context)
        {
            _context = context;
        }

        public EditPersonOzvNoa GetDetails(long id)
        {
            return _context.PersonOzvNoas.Select(x => new EditPersonOzvNoa()
            {
                Id = x.Id,
                PersonOzvNoaId = x.PersonOzvNoaId,
                Name = x.Name,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PersonOzvNoaViewModel> GetPersonOzvNoas()
        {
            return _context.PersonOzvNoas.Select(x => new PersonOzvNoaViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<PersonOzvNoaViewModel> Search(PersonOzvNoaSearchModel SearchModel)
        {
            var query = _context.PersonOzvNoas.Select(x => new PersonOzvNoaViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PersonOzvNoaId = x.PersonOzvNoaId,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
