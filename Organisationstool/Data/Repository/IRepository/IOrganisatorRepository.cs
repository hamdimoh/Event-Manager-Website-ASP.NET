using Organisationstool.Models;
namespace Organisationstool.Data.Repository.IRepository
{
    public interface IOrganisatorRepository : IRepository<Organisator>
    {
        void Update(Organisator obj);
    }
}
