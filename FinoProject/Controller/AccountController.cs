using System;
using ApplicationServices.Command;
using ApplicationServices.Services.Interfaces;

namespace FinoProject.Controller
{
    public class AccountController
    {
        #region Constructor
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            this._accountServices = accountServices;
        }
        #endregion

        #region  Login
        public void Login()
        {
            var loginCommand = GetUserDetail();
            loginCommand.Validate();
            if (!_accountServices.LoginUser(loginCommand))
                Login();
        }
        #endregion

        #region View
        private LoginCammand GetUserDetail()
        {
            Console.WriteLine("hello");
            Console.WriteLine("Enter Your UserName :");
            string userName = Console.ReadLine();
            Console.WriteLine("\nEnter Your Password :");
            string password = Console.ReadLine();
            return new LoginCammand() { UserName = userName, Password = password };
        }
        #endregion
    }
}
