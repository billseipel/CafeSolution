using Cafe.Core.Domain.Order;

namespace Cafe.Services.Checkout
{
    public interface ICheckoutService
    {
        void CalculateAll(Order order);
    }
}
