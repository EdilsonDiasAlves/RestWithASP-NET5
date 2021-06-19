using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Impl
{
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImpl(IBookRepository repository)
        {
            _repository = repository;
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
