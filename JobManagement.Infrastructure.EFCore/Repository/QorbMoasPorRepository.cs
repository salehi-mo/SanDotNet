using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Domain.QorbMoasPorAgg;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class QorbMoasPorRepository : RepositoryBase<long, QorbMoasPor>, IQorbMoasPorRepository
    {
        private readonly JobContext _context;
        public QorbMoasPorRepository(JobContext context) : base(context)
        {
            _context = context;
        }
        public EditQorbMoasPor GetDetails(long id)
        {
            return _context.QorbMoasPors.Include(x => x.QorbMoas)
                .ThenInclude(x => x.Qorb)
                .Select(x => new EditQorbMoasPor()
            {
                Id = x.Id,
                QorbMoasPorId_sana = x.QorbMoasPorId_sana,
                Name = x.Name,
                Slug = x.Slug,
                QorbMoasId = x.QorbMoasId,
                QorbId = x.QorbMoas.Qorb.Id
                
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<QorbMoasPorViewModel> GetQorbMoasPors()
        {
            return _context.QorbMoasPors.Select(x => new QorbMoasPorViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<QorbMoasPorViewModel> GetQorbMoasPorsWithQorbMoas(long id)
        {
            return _context.QorbMoasPors
                .Where(x => x.QorbMoasId == id)
                .Select(x => new QorbMoasPorViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        public List<QorbMoasPorViewModel> Search(QorbMoasPorSearchModel SearchModel)
        {
            var query =
                _context.QorbMoasPors.Include(x => x.QorbMoas)
                    .ThenInclude(x=> x.Qorb)
                    .Select(x => new QorbMoasPorViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                QorbMoasPorId_sana = x.QorbMoasPorId_sana,
                QorbMoasId = x.QorbMoasId,
                QorbMoas = x.QorbMoas.Name,
                QorbId =  x.QorbMoas.Qorb.Id,
                Qorb = x.QorbMoas.Qorb.Name,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));

            if (SearchModel.QorbId != 0)
                query = query.Where(x => x.QorbId == SearchModel.QorbId);

            if (SearchModel.QorbMoasId != 0)
                query = query.Where(x => x.QorbMoasId == SearchModel.QorbMoasId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
