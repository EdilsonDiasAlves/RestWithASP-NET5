﻿using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO personVO);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO personVO);
        void Delete(long id);
    }
}
