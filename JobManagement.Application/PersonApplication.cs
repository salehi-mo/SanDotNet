using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.Person;
using JobManagement.Domain.PersonAgg;

namespace JobManagement.Application
{
    public class PersonApplication : IPersonApplication
    {
        private readonly IPersonRepository _personRepository;

        public PersonApplication(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public OperationResult Create(CreatePerson command)
        {
            var operation = new OperationResult();
            if (_personRepository.Exists(x => x.CodMelli == command.CodMelli))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var person = new Person(command.PerId, command.Nam,command.Fam,command.NamPed,command.NoShe,command.CodMelli, (long)command.PersonOzvNoaId,
                (long)command.PersonEshtegVazId, (long)command.QorbId, (long)command.QorbMoasId, (long)command.QorbMoasPorId, (long)command.QorbMoasPorKarId, slug);
            _personRepository.Create(person);
            _personRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditPerson command)
        {
            var operation = new OperationResult();
            var person = _personRepository.Get(command.Id);
            if (person == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personRepository.Exists(x => x.CodMelli == command.CodMelli && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            person.Edit(command.PerId, command.Nam, command.Fam, command.NamPed, command.NoShe, command.CodMelli, (long)command.PersonOzvNoaId,
                (long)command.PersonEshtegVazId, (long)command.QorbId, (long)command.QorbMoasId, (long)command.QorbMoasPorId, (long)command.QorbMoasPorKarId, slug);
            _personRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditPerson GetDetails(long id)
        {
            return _personRepository.GetDetails(id);
        }

        public List<PersonViewModel> GetPersons()
        {
            return _personRepository.GetPersons();
        }

        public List<PersonViewModel> Search(PersonSearchModel SearchModel)
        {
            return _personRepository.Search(SearchModel);
        }
    }
}
