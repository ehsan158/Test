using ApplicationServices.Command;

namespace ApplicationServices.Services.Interfaces
{
    public interface IAccountServices
    {
        public bool LoginUser(LoginCammand loginCammand);
    }
}
