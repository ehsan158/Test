using DomainModel.Entity.Cart;
using Repository.DataBases;
using Repository.Repository.Write.Interfaces;

namespace Repository.Repository.Write.Implementations
{
    public class OrderRepositoryWrite : IOrderRepositoryWrite
    {
        DataBase _dataBase;
        public OrderRepositoryWrite()
        {
            _dataBase = DataBase.GetInstance();
        }
        public void AddOrderInDb(Order order)
        {
            _dataBase.Orders.Add(order);  
        }
    }
}
