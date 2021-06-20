using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Impl
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
