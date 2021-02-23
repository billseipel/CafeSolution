using Cafe.Core.Domain.Order;

namespace Cafe.Services.Checkout
{
    public interface ICheckoutService
    {
        //decimal CalculateTotal(Order order);

        //decimal CalculateServiceCharge(Order order);

        //decimal CalculateSubTotal(Order order);

        void CalculateAll(Order order);
    }
}
