using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.QorbMoasAgg;
using JobManagement.Domain.QorbMoasPorKarAgg;

namespace JobManagement.Domain.QorbMoasPorAgg
{
    public class QorbMoasPor : EntityBase
    {
        public long QorbMoasPorId_sana { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public long QorbMoasId { get; private set; }
        public QorbMoas QorbMoas { get; private set; }
        public List<QorbMoasPorKar> QorbMoasPorKars { get; private set; }
        public List<Person> Persons { get; private set; }

        public QorbMoasPor()
        {
            QorbMoasPorKars = new List<QorbMoasPorKar>();
            Persons = new List<Person>();
        }

        public QorbMoasPor(long qorbMoasPorId_sana, string name,string slug, long qorbMoasId)
        {
            QorbMoasPorId_sana = qorbMoasPorId_sana;
            Name = name;
            Slug = slug;
            QorbMoasId = qorbMoasId;
        }
        public void Edit(long qorbMoasPorId_sana, string name,string slug, long qorbMoasId)
        {
            QorbMoasPorId_sana = qorbMoasPorId_sana;
            Name = name;
            Slug = slug;
            QorbMoasId = qorbMoasId;
        }
    }
}
