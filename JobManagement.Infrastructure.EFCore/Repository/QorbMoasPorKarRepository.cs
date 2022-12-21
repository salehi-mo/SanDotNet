using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using JobManagement.Domain.QorbMoasPorKarAgg;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class QorbMoasPorKarRepository : RepositoryBase<long, QorbMoasPorKar>, IQorbMoasPorKarRepository
    {
        private readonly JobContext _context;
        public QorbMoasPorKarRepository(JobContext context) : base(context)
        {
            _context = context;
        }
        public EditQorbMoasPorKar GetDetails(long id)
        {
            return _context.QorbMoasPorKars.Include(x => x.QorbMoasPor)
                .ThenInclude(x => x.QorbMoas)
                .ThenInclude(x => x.Qorb)
                .Select(x => new EditQorbMoasPorKar()
                {
                    Id = x.Id,
                    QorbMoasPorKarId_sana = x.QorbMoasPorKarId_sana,
                    Name = x.Name,
                    Slug = x.Slug,
                    QorbMoasPorId = x.QorbMoasPorId,
                    QorbMoasId = x.QorbMoasPor.QorbMoasId,
                    QorbId = x.QorbMoasPor.QorbMoas.QorbId

                }).FirstOrDefault(x => x.Id == id);
        }

        public List<QorbMoasPorKarViewModel> GetQorbMoasPorKars()
        {
            return _context.QorbMoasPorKars.Select(x => new QorbMoasPorKarViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<QorbMoasPorKarViewModel> GetQorbMoasPorKarsWithQorbMoasPor(long id)
        {
            return _context.QorbMoasPorKars
                .Where(x => x.QorbMoasPorId == id)
                .Select(x => new QorbMoasPorKarViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        public List<QorbMoasPorKarViewModel> Search(QorbMoasPorKarSearchModel SearchModel)
        {
            var query =
                _context.QorbMoasPorKars.Include(x => x.QorbMoasPor)
                    .ThenInclude(x => x.QorbMoas)
                    .ThenInclude(x => x.Qorb)
                    .Select(x => new QorbMoasPorKarViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        QorbMoasPorKarId_sana = x.QorbMoasPorKarId_sana,
                        QorbMoasPorId = x.QorbMoasPorId,
                        QorbMoasPor = x.QorbMoasPor.Name,
                        QorbMoasId = x.QorbMoasPor.QorbMoasId,
                        QorbMoas = x.QorbMoasPor.QorbMoas.Name,
                        QorbId = x.QorbMoasPor.QorbMoas.Qorb.Id,
                        Qorb = x.QorbMoasPor.QorbMoas.Qorb.Name,
                        CreationDate = x.CreationDate.ToFarsi()
                    });

            if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                query = query.Where(x => x.Name.Contains(SearchModel.Name));

            if (SearchModel.QorbId != 0)
                query = query.Where(x => x.QorbId == SearchModel.QorbId);

            if (SearchModel.QorbMoasId != 0)
                query = query.Where(x => x.QorbMoasId == SearchModel.QorbMoasId);

            if (SearchModel.QorbMoasPorId != 0)
                query = query.Where(x => x.QorbMoasPorId == SearchModel.QorbMoasPorId);

            return query.OrderByDescending(x => x.Id).ToList();




        }
    }
}
