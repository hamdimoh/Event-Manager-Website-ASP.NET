using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;
using System.Linq.Expressions;

namespace Organisationstool.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDB _db;
        public ProductRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    

    }
}