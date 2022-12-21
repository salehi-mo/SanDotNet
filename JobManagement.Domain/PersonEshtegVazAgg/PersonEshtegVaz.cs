using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonAgg;

namespace JobManagement.Domain.PersonEshtegVazAgg
{
    public class PersonEshtegVaz : EntityBase
    {
        public long PersonEshtegVazId { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }

        public List<Person> Persons { get; private set; }

        public PersonEshtegVaz()
        {
            Persons = new List<Person>();
        }
        public PersonEshtegVaz(long personEshtegVazId, string name,string slug)
        {
            PersonEshtegVazId = personEshtegVazId;
            Name = name;
            Slug = slug;
        }
        public void Edit(long personEshtegVazId, string name, string slug)
        {
            PersonEshtegVazId = personEshtegVazId;
            Name = name;
            Slug = slug;
        }
    }
}
