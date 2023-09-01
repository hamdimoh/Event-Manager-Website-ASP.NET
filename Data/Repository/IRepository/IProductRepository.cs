using Organisationstool.Models;
using System.Linq.Expressions;

namespace Organisationstool.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}

