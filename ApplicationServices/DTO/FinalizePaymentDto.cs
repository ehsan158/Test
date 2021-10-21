using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.PaymentProducts;

namespace ApplicationServices.DTO
{
    public class FinalizePaymentDto : IDto
    {
        public Amount Cash{ get; set; }
        public Amount PrePayment{ get; set; }

        public string Display()
        {
            if (Cash != null)
                return $"Order amount : {Cash.Value}";

            else if (PrePayment != null)
                return $"Pre payment amount: {PrePayment.Value}";

            else
            return "You have finalized the order.";
        }
    }
}
