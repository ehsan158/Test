using System;
using System.Collections.Generic;
using System.Linq;
using Infrostructure.Exeption;

namespace DomainModel.Entity.user
{
    public class User
    {
        public Guid Id { get;private set; }
        public string Name{ get; private set; }
        public string UserName { get;private set; }
        public string Password { get;private set; }
        public string Email { get;private set; }
        public string Address{ get; private set; }
        public IEnumerable<Guid> OrdersId { get; private set; } = new List<Guid>();
        public User(string name,string username,string password,string email,string address)
        {
            ValidateForUserDetails(name, username, password, email, address);

            Id = Guid.NewGuid();
            Name = name;
            UserName = username;
            Password = password;
            Email = email;
            Address = address;
        }
        public void AddOrder(Guid orderId)
        {
            ValidateForOrderId(orderId);

            var temp = OrdersId.ToList();
            temp.Add(orderId);
            OrdersId = temp;
        }

        //Validations
        private void ValidateForUserDetails(string name,string userName,string password,string email,string address)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(address))
                throw new InvalidUserDetailsExeption();
        }

        private void ValidateForOrderId(Guid orderId)
        {
            if (Guid.Empty == orderId)
                throw new InvalidOrderIdExeption();
        }
    }
}
