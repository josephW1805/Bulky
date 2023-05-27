using Bulky.Models;

namespace Bulky.DataAccess.Data.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
        int IncrementCount(ShoppingCart cart, int count);
        int DecrementCount(ShoppingCart cart, int count);
    }
}
