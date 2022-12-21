using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Domain.QorbAgg;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class QorbRepository : RepositoryBase<long, Qorb>, IQorbRepository
    {
        private readonly JobContext _context;
        public QorbRepository(JobContext context) : base(context)
        {
            _context = context;
        }
        public EditQorb GetDetails(long id)
        {
            return _context.Qorbs.Select(x => new EditQorb()
            {
                Id = x.Id,
                QorbId_sana = x.QorbId_sana,
                Name = x.Name,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<QorbViewModel> GetQorbs()
        {
            return _context.Qorbs.Select(x => new QorbViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<QorbViewModel> Search(QorbSearchModel SearchModel)
        {
            var query = _context.Qorbs.Select(x => new QorbViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                QorbId_sana = x.QorbId_sana,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
