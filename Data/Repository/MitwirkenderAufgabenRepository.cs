using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;
using System.Linq.Expressions;

namespace Organisationstool.Data.Repository
{
    //public class MitwirkenderAufgabenRepository : Repository<MitwirkendeAufgaben>, IMitwirkenderAufgabenRepository
    //{

    //    private ApplicationDB _db;
    //    public MitwirkenderAufgabenRepository(ApplicationDB db) : base(db)
    //    {
    //        _db = db;
    //    }



    //    public void Update(MitwirkendeAufgaben obj)
    //    {
    //        var objFromDb = _db.Veranstaltungen.FirstOrDefault(u => u.Id == obj.Id);
    //        if (objFromDb != null)
    //        {
    //            objFromDb.Adresse = obj.Adresse;
    //            objFromDb.Datum = obj.Datum;
    //            objFromDb.Details = obj.Details;
    //            objFromDb.NamederVeranstaltung = obj.NamederVeranstaltung;
    //            objFromDb.Bild = obj.Bild;
    //            objFromDb.Nrgäste = obj.Nrgäste;
    //            objFromDb.NrMit = obj.NrMit;
    //            objFromDb.Budget = obj.Budget;
    //            objFromDb.Aufgaben = obj.Aufgaben;
    //        }
    //    }

    //    public void Update(MitwirkendeAufgaben obj)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

