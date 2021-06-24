using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO BookVO);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO BookVO);
        void Delete(long id);
    }
}
