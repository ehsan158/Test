using System;
using DomainModel.Entity.Cart;

namespace Repository.Repository.Read.Interfaces
{
   public interface IOrderRepositoryRead
   {
       public Order GetOrderById(Guid orderId);
   }
}
