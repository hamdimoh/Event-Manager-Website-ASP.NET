using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;
using System.Diagnostics;

namespace Organisationstool.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<Veranstaltungen> objVeranstaltungenList = _unitOfWork.Veranstaltungen.GetAll().ToList();
            return View(objVeranstaltungenList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Veranstaltungen> objOrganisatorList = _unitOfWork.Veranstaltungen.GetAll().ToList();
            return Json(new { data = objOrganisatorList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Veranstaltungen.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Organisator erfolgreich gelöscht" });
        }

        #endregion

    }
}