using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;

namespace Organisationstool.Data.Repository
{
    public class GastRepository : Repository<Gast>, IGastRepository
    {
        private ApplicationDB _db;
        public GastRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }



        public void Update(Gast obj)
        {
            var objFromDb = _db.Gäste.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Essen = obj.Essen;
                objFromDb.Allergien = obj.Allergien;
                objFromDb.Veranstaltung = obj.Veranstaltung;
                objFromDb.VeranstaltungId = obj.VeranstaltungId;
                objFromDb.Name = obj.Name;
                objFromDb.Email = obj.Email;


            }
        }
    }
}
