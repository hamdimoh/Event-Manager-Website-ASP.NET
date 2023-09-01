using Organisationstool.Models;
namespace Organisationstool.Data.Repository.IRepository
{
    public interface IMitwirkenderRepository: IRepository<Mitwirkende>
    {
         void Update(Mitwirkende obj);
   }
}
