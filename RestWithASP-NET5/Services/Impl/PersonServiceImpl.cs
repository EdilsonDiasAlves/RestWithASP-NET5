using RestWithASP_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RestWithASP_NET5.Model.Context;

namespace RestWithASP_NET5.Services.Impl
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Address = "São Paulo - SP - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
