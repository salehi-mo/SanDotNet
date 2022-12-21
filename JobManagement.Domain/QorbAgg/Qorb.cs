using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using JobManagement.Domain.PersonAgg;
using JobManagement.Domain.QorbMoasAgg;

namespace JobManagement.Domain.QorbAgg
{
    public class Qorb : EntityBase
    {
        public long QorbId_sana { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public List<QorbMoas> QorbMoass { get; private set; }
        public List<Person> Persons { get; private set; }
        public Qorb()
        {
            QorbMoass = new List<QorbMoas>();
            Persons = new List<Person>();
        }

        public Qorb(long qorbId_sana, string name,string slug)
        {
            QorbId_sana = qorbId_sana;
            Name = name;
            Slug = slug;
        }
        public void Edit(long qorbId_sana, string name,string slug)
        {
            QorbId_sana = qorbId_sana;
            Name = name;
            Slug = slug;
        }
    }
   


}
