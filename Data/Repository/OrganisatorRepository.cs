using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;

namespace Organisationstool.Data.Repository
{
    public class OrganisatorRepository : Repository<Organisator>, IOrganisatorRepository
    {
        private ApplicationDB _db;
        public OrganisatorRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }



        public void Update(Organisator obj)
        {
            _db.Organisatoren.Update(obj);
        }
    }
   
}
