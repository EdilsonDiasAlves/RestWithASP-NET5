﻿using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using RestWithASP_NET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Business.Impl
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
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