using ApplicationServices.Command;
using ApplicationServices.Services.Interfaces;
using Infrostructure;
using Repository.Repository.Read.Interfaces;

namespace ApplicationServices.Services.Implementations
{
    public class AccountService : IAccountServices
    {
        #region Constructor
        readonly IUserRepositoryRead _userRepositoryRead;

        public AccountService(IUserRepositoryRead userRepositoryRead)
        {
            _userRepositoryRead = userRepositoryRead;
        }
        #endregion

        #region Login
        public bool LoginUser(LoginCammand loginCammand)
        {
            var user = _userRepositoryRead.GetUserByUserNameAndPassword(loginCammand.UserName, loginCammand.Password);
            if (user != null)
            {
                AuthenticationInformation.SetLoginInformation(user.Id, user.UserName);
                return true;
            }
            return false;
        }
        #endregion
    }
}
