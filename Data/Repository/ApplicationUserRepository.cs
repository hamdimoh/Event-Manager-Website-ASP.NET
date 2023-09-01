using Octokit;
using Organisationstool.Models;
using Organisationstool.Data.Repository.IRepository;
using Nest;
using Organisationstool.Data;


namespace Organisationstool.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDB _db;
        public ApplicationUserRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUser.Update(applicationUser);
        }
    }
    }
