using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using JobManagement.Application.Contracts.Person;
using JobManagement.Domain.PersonAgg;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Infrastructure.EFCore.Repository
{
    public class PersonRepository : RepositoryBase<long, Person>, IPersonRepository
    {
        private readonly JobContext _context;
        public PersonRepository(JobContext context) : base(context)
        {
            _context = context;
        }
        public EditPerson GetDetails(long id)
        {
            return _context.Persons.Include(x => x.QorbMoasPorKar)
                .Include(x => x.QorbMoasPor)
                .Include(x => x.QorbMoas)
                .Include(x => x.Qorb)
                .Include(x => x.PersonEshtegVaz)
                .Include(x => x.PersonOzvNoa)
                .Select(x => new EditPerson()
            {
                Id = x.Id,
                PerId = x.PerId,
                Nam = x.Nam,
                Fam = x.Fam,
                NamPed = x.NamPed,
                NoShe = x.NoShe,
                CodMelli = x.CodMelli,
                PersonEshtegVazId = x.PersonEshtegVazId,
                PersonOzvNoaId = x.PersonOzvNoaId,
                QorbId = x.QorbId,
                QorbMoasId = x.QorbMoasId,
                QorbMoasPorId = x.QorbMoasPorId,
                QorbMoasPorKarId = x.QorbMoasPorKarId,
                
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<PersonViewModel> GetPersons()
        {
            return _context.Persons.Select(x => new PersonViewModel()
            {
                Id = x.Id,
                Nam = x.Nam
            }).ToList();
        }

        public List<PersonViewModel> Search(PersonSearchModel SearchModel)
        {
            var query = _context.Persons.Include(x => x.QorbMoasPorKar)
                .Include(x => x.QorbMoasPor)
                .Include(x => x.QorbMoas)
                .Include(x => x.Qorb)
                .Include(x => x.PersonEshtegVaz)
                .Include(x => x.PersonOzvNoa)
                .Select(x => new PersonViewModel()
            {
                Id = x.Id,
                PerId = x.PerId,
                Nam = x.Nam,
                Fam = x.Fam,
                NamPed = x.NamPed,
                NoShe = x.NoShe,
                CodMelli = x.CodMelli,
                CreationDate = x.CreationDate.ToFarsi(),
                QorbId = x.Qorb.Id,
                Qorb = x.Qorb.Name,
                QorbMoasId = x.QorbMoas.Id,
                QorbMoas = x.QorbMoas.Name,
                QorbMoasPorId = x.QorbMoasPor.Id,
                QorbMoasPor = x.QorbMoasPor.Name,
                QorbMoasPorKarId = x.QorbMoasPorKar.Id,
                QorbMoasPorKar = x.QorbMoasPorKar.Name,
                PersonEshtegVazId = x.PersonEshtegVaz.Id,
                PersonEshtegVaz = x.PersonEshtegVaz.Name,
                PersonOzvNoaId = x.PersonOzvNoa.Id,
                PersonOzvNoa = x.PersonOzvNoa.Name
                });

            if (!string.IsNullOrWhiteSpace(SearchModel.Nam))
                query = query.Where(x => x.Nam.Contains(SearchModel.Nam));

            if (!string.IsNullOrWhiteSpace(SearchModel.Fam))
                query = query.Where(x => x.Fam.Contains(SearchModel.Fam));

            if (!string.IsNullOrWhiteSpace(SearchModel.NamPed))
                query = query.Where(x => x.NamPed.Contains(SearchModel.NamPed));

            if (!string.IsNullOrWhiteSpace(SearchModel.Noshe))
                query = query.Where(x => x.NoShe.Contains(SearchModel.Noshe));

            if (!string.IsNullOrWhiteSpace(SearchModel.CodMelli))
                query = query.Where(x => x.CodMelli.Contains(SearchModel.CodMelli));

            if ((SearchModel.QorbId != 0) & (SearchModel.QorbId != -1))
                query = query.Where(x => x.QorbId == SearchModel.QorbId);

            if ((SearchModel.QorbMoasId != 0) & (SearchModel.QorbMoasId != -1))
                query = query.Where(x => x.QorbMoasId == SearchModel.QorbMoasId);

            if ((SearchModel.QorbMoasPorId != 0) & (SearchModel.QorbMoasPorId != -1))
                query = query.Where(x => x.QorbMoasPorId == SearchModel.QorbMoasPorId);

            if ((SearchModel.QorbMoasPorKarId != 0) & (SearchModel.QorbMoasPorKarId != -1))
                query = query.Where(x => x.QorbMoasPorKarId == SearchModel.QorbMoasPorKarId);

            if ((SearchModel.PersonEshtegVazId != 0) & (SearchModel.PersonEshtegVazId != -1))
                query = query.Where(x => x.PersonEshtegVazId == SearchModel.PersonEshtegVazId);

            if ((SearchModel.PersonOzvNoaId != 0) & (SearchModel.PersonOzvNoaId != -1))
                query = query.Where(x => x.PersonOzvNoaId == SearchModel.PersonOzvNoaId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
