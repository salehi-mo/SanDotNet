using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using JobManagement.Application.Contracts.QorbMoasPorKar;
using JobManagement.Domain.QorbMoasPorKarAgg;

namespace JobManagement.Application
{
    public class QorbMoasPorKarApplication : IQorbMoasPorKarApplication
    {
        private readonly IQorbMoasPorKarRepository _qorbMoasPorKarRepository;

        public QorbMoasPorKarApplication(IQorbMoasPorKarRepository qorbMoasPorKarRepository)
        {
            _qorbMoasPorKarRepository = qorbMoasPorKarRepository;
        }

        public OperationResult Create(CreateQorbMoasPorKar command)
        {
            var operation = new OperationResult();
            if (_qorbMoasPorKarRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var qorbMoasPorKar = new QorbMoasPorKar(command.QorbMoasPorKarId_sana, command.Name, slug, command.QorbMoasPorId);
            _qorbMoasPorKarRepository.Create(qorbMoasPorKar);
            _qorbMoasPorKarRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditQorbMoasPorKar command)
        {
            var operation = new OperationResult();
            var qorbMoasPorKar = _qorbMoasPorKarRepository.Get(command.Id);
            if (qorbMoasPorKar == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_qorbMoasPorKarRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            qorbMoasPorKar.Edit(command.QorbMoasPorKarId_sana, command.Name, slug, command.QorbMoasPorId);
            _qorbMoasPorKarRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditQorbMoasPorKar GetDetails(long id)
        {
            return _qorbMoasPorKarRepository.GetDetails(id);
        }

        public List<QorbMoasPorKarViewModel> GetQorbMoasPorKars()
        {
            return _qorbMoasPorKarRepository.GetQorbMoasPorKars();
        }

        public List<QorbMoasPorKarViewModel> GetQorbMoasPorKarsWithQorbMoasPor(long id)
        {
            return _qorbMoasPorKarRepository.GetQorbMoasPorKarsWithQorbMoasPor(id);
        }

        public List<QorbMoasPorKarViewModel> Search(QorbMoasPorKarSearchModel SearchModel)
        {
            return _qorbMoasPorKarRepository.Search(SearchModel);
        }
    }
}
