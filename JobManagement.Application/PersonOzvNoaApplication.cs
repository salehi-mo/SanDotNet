using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.PersonOzvNoa;
using JobManagement.Domain.PersonOzvNoaAgg;

namespace JobManagement.Application
{
    public class PersonOzvNoaApplication : IPersonOzvNoaApplication
    {
        private readonly IPersonOzvNoaRepository _personOzvNoaRepository;

        public PersonOzvNoaApplication(IPersonOzvNoaRepository personOzvNoaRepository)
        {
            _personOzvNoaRepository = personOzvNoaRepository;
        }

        public OperationResult Create(CreatePersonOzvNoa command)
        {
            var operation = new OperationResult();
            if (_personOzvNoaRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var personOzvNoa = new PersonOzvNoa(command.PersonOzvNoaId, command.Name, slug);
            _personOzvNoaRepository.Create(personOzvNoa);
            _personOzvNoaRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditPersonOzvNoa command)
        {
            var operation = new OperationResult();
            var personOzvNoa = _personOzvNoaRepository.Get(command.Id);
            if (personOzvNoa == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personOzvNoaRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            personOzvNoa.Edit(command.PersonOzvNoaId, command.Name, slug);
            _personOzvNoaRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditPersonOzvNoa GetDetails(long id)
        {
            return _personOzvNoaRepository.GetDetails(id);
        }

        public List<PersonOzvNoaViewModel> GetPersonOzvNoas()
        {
            return _personOzvNoaRepository.GetPersonOzvNoas();
        }

        public List<PersonOzvNoaViewModel> Search(PersonOzvNoaSearchModel SearchModel)
        {
            return _personOzvNoaRepository.Search(SearchModel);
        }
    }
}
