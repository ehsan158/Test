using DomainModel.Entity.Cart;

namespace Repository.Repository.Write.Interfaces
{
    public interface IOrderRepositoryWrite
    {
        public void AddOrderInDb(Order order);
    }
}
