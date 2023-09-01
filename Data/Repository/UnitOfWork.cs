using Organisationstool.Data.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Organisationstool.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDB _db;
       public IVeranstaltungenRepository Veranstaltungen { get; private set; }
        public IOrganisatorRepository Organisator { get; private set; }
        public IMitwirkenderRepository Mitwirkender { get; private set; }
        public IGastRepository Gast { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IBuchungenRepository Buchungen { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductRepository MitwirkenderAufgaben { get; private set; }

        public UnitOfWork(ApplicationDB db)
        {
            _db = db;
            Veranstaltungen = new VeranstaltungenRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Organisator = new OrganisatorRepository(_db);
            Gast = new GastRepository(_db);
          
            Mitwirkender=new MitwirkenderRepository(_db);
            Buchungen =new BuchungenRepository(_db);
           Products =new ProductRepository(_db);
            //MitwirkenderAufgaben = new MitwirkenderAufgabenRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
