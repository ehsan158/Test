using System;
using DomainModel.Entity.user;

namespace Repository.Repository.Read.Interfaces
{
    public interface IUserRepositoryRead
    {
        public User GetUserByUserNameAndPassword(string userName, string password);
        public User GetUserById(Guid userId);
    }
}
