using CaseStudy_Quitq.Models;

namespace CaseStudy_Quitq.Repository
{
    public interface ICartRepository
    {
        public Cart GetCartByCustomerId(int customerId);
        public string AddToCart(int customerId, int productId, int quantity);
        public string RemoveFromCart(int customerId, int productId);
        public string ClearCart(int customerId);
    }
}
