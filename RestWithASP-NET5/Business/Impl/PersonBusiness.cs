using RestWithASP_NET5.Data.Converter.Impl;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Impl
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Create(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonVO Update(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        
    }
}
