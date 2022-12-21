using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.QorbAgg;
using JobManagement.Domain.QorbMoasPorAgg;

namespace JobManagement.Domain.QorbMoasAgg
{
    public class QorbMoas : EntityBase
    {
        public long QorbMoasId_sana { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public long QorbId { get; private set; }
        public Qorb Qorb { get; private set; }
        public List<QorbMoasPor> QorbMoasPors { get; private set; }
        public List<Person> Persons { get; private set; }

        public QorbMoas()
        {
            QorbMoasPors = new List<QorbMoasPor>();
            Persons = new List<Person>();
        }

        public QorbMoas(long qorbMoasId_sana, string name,string slug, long qorbId)
        {
            QorbMoasId_sana = qorbMoasId_sana;
            Name = name;
            Slug = slug;
            QorbId = qorbId;
        }
        public void Edit(long qorbMoasId_sana, string name,string slug, long qorbId)
        {
            QorbMoasId_sana = qorbMoasId_sana;
            Name = name;
            Slug = slug;
            QorbId = qorbId;
        }
    }
}
