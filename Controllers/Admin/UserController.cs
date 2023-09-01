using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Organisationstool.Models;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Organisationstool.Models.Controllers.Admin;
using Organisationstool.Data.Repository;
using Organisationstool.Data.Repository.IRepository;


namespace Organisationstool.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> objOrganisatorList = _unitOfWork.ApplicationUser.GetAll().ToList();
            return View(objOrganisatorList);
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objOrganisatorList = _unitOfWork.ApplicationUser.GetAll().ToList();
            return Json(new { data = objOrganisatorList });
        }

        #endregion

    }
}
