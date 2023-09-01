using Organisationstool.Models;



namespace Organisationstool.Data.Repository.IRepository
{
    public interface IGastRepository:IRepository<Gast>
    {
        void Update(Gast obj);
    }
}
