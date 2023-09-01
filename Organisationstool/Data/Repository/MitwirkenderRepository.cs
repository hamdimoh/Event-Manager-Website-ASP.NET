using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;

namespace Organisationstool.Data.Repository
{
    public class MitwirkenderRepository : Repository<Mitwirkende>, IMitwirkenderRepository
    {
        private ApplicationDB _db;
        public MitwirkenderRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }



        public void Update(Mitwirkende obj)
        {
            _db.Mitwirkenden.Update(obj);
        }
    }
   
}
