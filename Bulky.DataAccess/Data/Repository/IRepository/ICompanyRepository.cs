using Bulky.Models;

namespace Bulky.DataAccess.Data.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
