using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Domain.QorbMoasAgg;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class QorbMoasRepository : RepositoryBase<long, QorbMoas>, IQorbMoasRepository
    {
        private readonly JobContext _context;
        public QorbMoasRepository(JobContext context) : base(context)
        {
            _context = context;
        }
        public EditQorbMoas GetDetails(long id)
        {
            return _context.QorbMoass.Select(x => new EditQorbMoas()
            {
                Id = x.Id,
                QorbMoasId_sana = x.QorbMoasId_sana,
                Name = x.Name,
                Slug = x.Slug,
                QorbId = x.QorbId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<QorbMoasViewModel> GetQorbMoass()
        {
            return _context.QorbMoass.Select(x => new QorbMoasViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<QorbMoasViewModel> GetQorbMoassWithQorb(long id)
        {
            return _context.QorbMoass            
                .Where(x=> x.QorbId  == id)                
                .Select(x => new QorbMoasViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<QorbMoasViewModel> Search(QorbMoasSearchModel SearchModel)
        {
            var query =
                _context.QorbMoass.Include(x => x.Qorb)
                    .Select(x => new QorbMoasViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Qorb = x.Qorb.Name,
                QorbMoasId_sana = x.QorbMoasId_sana,
                QorbId = x.QorbId,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));
            
            if (SearchModel.QorbId != 0)
                query = query.Where(x => x.QorbId == SearchModel.QorbId);
            
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
