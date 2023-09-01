using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;
using System.Linq.Expressions;

namespace Organisationstool.Data.Repository
{
    public class BuchungenRepository : Repository<Buchungen>, IBuchungenRepository
    {
        private ApplicationDB _db;
        public BuchungenRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Buchungen obj)
        {
            _db.Buchungen.Update(obj);
        }
    }
}
