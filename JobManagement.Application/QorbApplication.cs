using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.Qorb;
using JobManagement.Domain.QorbAgg;

namespace JobManagement.Application
{
    public class QorbApplication : IQorbApplication

    {
        private readonly IQorbRepository _qorbRepository;

        public QorbApplication(IQorbRepository qorbRepository)
        {
            _qorbRepository = qorbRepository;
        }

        public OperationResult Create(CreateQorb command)
        {
            var operation = new OperationResult();
            if (_qorbRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var qorb = new Qorb(command.QorbId_sana, command.Name, slug);
            _qorbRepository.Create(qorb);
            _qorbRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditQorb command)
        {
            var operation = new OperationResult();
            var qorb = _qorbRepository.Get(command.Id);
            if (qorb == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_qorbRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            qorb.Edit(command.QorbId_sana, command.Name, slug);
            _qorbRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditQorb GetDetails(long id)
        {
            return _qorbRepository.GetDetails(id);
        }

        public List<QorbViewModel> GetQorbs()
        {
            return _qorbRepository.GetQorbs();
        }

        public List<QorbViewModel> Search(QorbSearchModel SearchModel)
        {
            return _qorbRepository.Search(SearchModel);
        }
    }
}
