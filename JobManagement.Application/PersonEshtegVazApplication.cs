using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonEshtegVaz;
using JobManagement.Domain.PersonEshtegVazAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application
{
    public class PersonEshtegVazApplication : IPersonEshtegVazApplication
    {
        private readonly IPersonEshtegVazRepository _personEshtegVazRepository;

        public PersonEshtegVazApplication(IPersonEshtegVazRepository personEshtegVazRepository)
        {
            _personEshtegVazRepository = personEshtegVazRepository;
        }

        public OperationResult Create(CreatePersonEshtegVaz command)
        {
            var operation = new OperationResult();
            if (_personEshtegVazRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var personEshtegVaz = new PersonEshtegVaz(command.PersonEshtegVazId, command.Name, slug);
            _personEshtegVazRepository.Create(personEshtegVaz);
            _personEshtegVazRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditPersonEshtegVaz command)
        {
            var operation = new OperationResult();
            var personEshtegVaz = _personEshtegVazRepository.Get(command.Id);
            if (personEshtegVaz == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personEshtegVazRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            personEshtegVaz.Edit(command.PersonEshtegVazId, command.Name, slug);
            _personEshtegVazRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditPersonEshtegVaz GetDetails(long id)
        {
            return _personEshtegVazRepository.GetDetails(id);
        }

        public List<PersonEshtegVazViewModel> GetPersonEshtegVazs()
        {
            return _personEshtegVazRepository.GetPersonEshtegVazs();
        }

        public List<PersonEshtegVazViewModel> Search(PersonEshtegVazSearchModel SearchModel)
        {
            return _personEshtegVazRepository.Search(SearchModel);
        }
    }
}
