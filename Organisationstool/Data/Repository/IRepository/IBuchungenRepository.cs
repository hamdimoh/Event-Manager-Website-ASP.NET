using Organisationstool.Models;
using System.Linq.Expressions;

namespace Organisationstool.Data.Repository.IRepository
{
    public interface IBuchungenRepository : IRepository<Buchungen>
    {
        void Update(Buchungen obj);
    }
}
