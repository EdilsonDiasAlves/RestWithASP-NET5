using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO personVO);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO personVO);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
