using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Domain.PersonEshtegVazAgg;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class PersonEshtegVazRepository : RepositoryBase<long, PersonEshtegVaz>, IPersonEshtegVazRepository
    {
        private readonly JobContext _context;
        public PersonEshtegVazRepository( JobContext context) : base(context)
        {
            _context = context;
        }
        public EditPersonEshtegVaz GetDetails(long id)
        {
            return _context.PersonEshtegVazs.Select(x => new EditPersonEshtegVaz()
            {
                Id = x.Id,
                PersonEshtegVazId = x.PersonEshtegVazId,
                Name = x.Name,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PersonEshtegVazViewModel> GetPersonEshtegVazs()
        {
            return _context.PersonEshtegVazs.Select(x => new PersonEshtegVazViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<PersonEshtegVazViewModel> Search(PersonEshtegVazSearchModel SearchModel)
        {
            var query = _context.PersonEshtegVazs.Select(x => new PersonEshtegVazViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PersonEshtegVazId = x.PersonEshtegVazId,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        
    }
}
