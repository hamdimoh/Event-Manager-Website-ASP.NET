using Organisationstool.Models;
namespace Organisationstool.Data.Repository.IRepository
{
    public interface IVeranstaltungenRepository : IRepository<Veranstaltungen>
    {
        void Update(Veranstaltungen obj);
    }
}
