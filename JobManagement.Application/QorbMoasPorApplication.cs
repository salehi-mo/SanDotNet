using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.QorbMoasPor;
using JobManagement.Domain.QorbMoasPorAgg;

namespace JobManagement.Application
{
    public class QorbMoasPorApplication : IQorbMoasPorApplication
    {
        private readonly IQorbMoasPorRepository _qorbMoasPorRepository;

        public QorbMoasPorApplication(IQorbMoasPorRepository qorbMoasPorRepository)
        {
            _qorbMoasPorRepository = qorbMoasPorRepository;
        }

        public OperationResult Create(CreateQorbMoasPor command)
        {
            var operation = new OperationResult();
            if (_qorbMoasPorRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var qorbMoasPor = new QorbMoasPor(command.QorbMoasPorId_sana, command.Name, slug, command.QorbMoasId);
            _qorbMoasPorRepository.Create(qorbMoasPor);
            _qorbMoasPorRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditQorbMoasPor command)
        {
            var operation = new OperationResult();
            var qorbMoasPor = _qorbMoasPorRepository.Get(command.Id);
            if (qorbMoasPor == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_qorbMoasPorRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            qorbMoasPor.Edit(command.QorbMoasPorId_sana, command.Name, slug, command.QorbMoasId);
            _qorbMoasPorRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditQorbMoasPor GetDetails(long id)
        {
            return _qorbMoasPorRepository.GetDetails(id);
        }

        public List<QorbMoasPorViewModel> GetQorbMoasPors()
        {
            return _qorbMoasPorRepository.GetQorbMoasPors();
        }

        public List<QorbMoasPorViewModel> GetQorbMoasPorsWithQorbMoas(long id)
        {
            return _qorbMoasPorRepository.GetQorbMoasPorsWithQorbMoas(id);
        }

        public List<QorbMoasPorViewModel> Search(QorbMoasPorSearchModel SearchModel)
        {
            return _qorbMoasPorRepository.Search(SearchModel);
        }
    }
}
