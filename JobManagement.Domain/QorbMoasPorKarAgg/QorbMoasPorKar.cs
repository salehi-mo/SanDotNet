using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.QorbMoasPorAgg;

namespace JobManagement.Domain.QorbMoasPorKarAgg
{
    public class QorbMoasPorKar : EntityBase
    {
        public long QorbMoasPorKarId_sana { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public long QorbMoasPorId { get; private set; }
        public QorbMoasPor QorbMoasPor { get; private set; }
        public List<Person> Persons { get; private set; }

        public QorbMoasPorKar()
        {
            Persons = new List<Person>();
        }
        public QorbMoasPorKar(long qorbMoasPorKarId_sana, string name,string slug, long qorbMoasPorId)
        {
            QorbMoasPorKarId_sana = qorbMoasPorKarId_sana;
            Name = name;
            Slug = slug;
            QorbMoasPorId = qorbMoasPorId;
        }
        public void Edit(long qorbMoasPorKarId_sana, string name,string slug, long qorbMoasPorId)
        {
            QorbMoasPorKarId_sana = qorbMoasPorKarId_sana;
            Name = name;
            Slug = slug;
            QorbMoasPorId = qorbMoasPorId;
        }
    }
}
