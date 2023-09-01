using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;

namespace Organisationstool.Data.Repository
{
    public class VeranstaltungenRepository : Repository<Veranstaltungen>, IVeranstaltungenRepository
    {
        private ApplicationDB _db;
        public VeranstaltungenRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }



        public void Update(Veranstaltungen obj)
        {
            var objFromDb = _db.Veranstaltungen.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Adresse = obj.Adresse;
                objFromDb.Datum=obj.Datum;
                objFromDb.Bemerkung = obj.Bemerkung;
                objFromDb.Nrgäste = obj.Nrgäste;
                objFromDb.NrMit = obj.NrMit;
                objFromDb.Budget = obj.Budget;
                objFromDb.Essen = obj.Essen;
                objFromDb.NamederVeranstaltung=obj.NamederVeranstaltung;
                objFromDb.Bild=obj.Bild;
                objFromDb.Aufgaben = obj.Aufgaben;

            }
        }
    }
    
}
