using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonAgg;

namespace JobManagement.Domain.PersonOzvNoaAgg
{
    public class PersonOzvNoa : EntityBase
    {
        public long PersonOzvNoaId { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        

        public List<Person> Persons { get; private set; }

        public PersonOzvNoa()
        {
            Persons = new List<Person>();
        }
        public PersonOzvNoa(long personOzvNoaId, string name,string slug)
        {
            PersonOzvNoaId = personOzvNoaId;
            Name = name;
            Slug = slug;
        }
        public void Edit(long personOzvNoaId, string name,string slug)
        {
            PersonOzvNoaId = personOzvNoaId;
            Name = name;
            Slug = slug;
        }
    }
}
