using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.QorbMoas;
using JobManagement.Domain.QorbMoasAgg;


namespace JobManagement.Application
{
    public class QorbMoasApplication : IQorbMoasApplication
    {
        private readonly IQorbMoasRepository _qorbMoasRepository;

        public QorbMoasApplication(IQorbMoasRepository qorbMoasRepository)
        {
            _qorbMoasRepository = qorbMoasRepository;
        }

        public OperationResult Create(CreateQorbMoas command)
        {
            var operation = new OperationResult();
            if (_qorbMoasRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var qorbMoas = new QorbMoas(command.QorbMoasId_sana, command.Name, slug,command.QorbId);
            _qorbMoasRepository.Create(qorbMoas);
            _qorbMoasRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditQorbMoas command)
        {
            var operation = new OperationResult();
            var qorbMoas = _qorbMoasRepository.Get(command.Id);
            if (qorbMoas == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_qorbMoasRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            qorbMoas.Edit(command.QorbMoasId_sana, command.Name, slug,command.QorbId);
            _qorbMoasRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditQorbMoas GetDetails(long id)
        {
            return _qorbMoasRepository.GetDetails(id);
        }

        public List<QorbMoasViewModel> GetQorbMoass()
        {
            return _qorbMoasRepository.GetQorbMoass();
        }

        public List<QorbMoasViewModel> GetQorbMoassWithQorb(long id)
        {
            return _qorbMoasRepository.GetQorbMoassWithQorb(id);
        }

        public List<QorbMoasViewModel> Search(QorbMoasSearchModel SearchModel)
        {
            return _qorbMoasRepository.Search(SearchModel);
        }
    }
}
