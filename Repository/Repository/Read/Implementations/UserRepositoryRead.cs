using System;
using System.Linq;
using DomainModel.Entity.user;
using Repository.DataBases;
using Repository.Repository.Read.Interfaces;

namespace Repository.Repository.Read.Implementations
{
    public class UserRepositoryRead : IUserRepositoryRead
    {
        DataBase _dataBase;
        public UserRepositoryRead()
        {
            _dataBase = DataBase.GetInstance();
        }

        public User GetUserById(Guid userId)
        {
            return _dataBase.Users.SingleOrDefault(c => c.Id == userId);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _dataBase.Users.SingleOrDefault(c => c.UserName == userName && c.Password == password);
        }
    }
}
