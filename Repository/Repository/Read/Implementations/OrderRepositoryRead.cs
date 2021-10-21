using System;
using System.Linq;
using DomainModel.Entity.Cart;
using Repository.DataBases;
using Repository.Repository.Read.Interfaces;

namespace Repository.Repository.Read.Implementations
{
    public class OrderRepositoryRead : IOrderRepositoryRead
    {
        DataBase _dataBase;
        public OrderRepositoryRead()
        {
            _dataBase = DataBase.GetInstance();
        }
        public Order GetOrderById(Guid orderId)
        {
            return _dataBase.Orders.SingleOrDefault(c => c.Id == orderId);
        }
    }
}
