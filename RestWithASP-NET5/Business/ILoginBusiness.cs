using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
