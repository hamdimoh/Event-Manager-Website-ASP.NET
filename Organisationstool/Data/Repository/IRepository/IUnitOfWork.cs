namespace Organisationstool.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVeranstaltungenRepository Veranstaltungen { get; }
        IOrganisatorRepository Organisator { get; }
        IMitwirkenderRepository Mitwirkender { get; }
        IGastRepository Gast { get; }
        IApplicationUserRepository ApplicationUser { get; }

        IBuchungenRepository Buchungen { get; }
      IProductRepository Products { get; }

        //IMitwirkenderAufgabenRepository MitwirkenderAufgaben { get; }

        void Save();
    }
}
