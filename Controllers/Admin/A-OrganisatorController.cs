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
    public class AOrganisatorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AOrganisatorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Organisator> objOrganisatorList = _unitOfWork.Organisator.GetAll().ToList();
            return View(objOrganisatorList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Organisator());
            }
            else
            {
                //update
                Organisator objOrganisator = _unitOfWork.Organisator.Get(u => u.Id == id);
                return View(objOrganisator);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Organisator obj)
        {

            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Organisator.Add(obj);
                    TempData["success"] = "Organisator erfolgreich hinzugefügt";
                }
                else
                {
                    _unitOfWork.Organisator.Update(obj);
                    TempData["success"] = "Organisator erfolgreich bearbeitet";
                }

                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            else
            {

                return View(obj);
            }
        }
       
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Organisator> objOrganisatorList = _unitOfWork.Organisator.GetAll().ToList();
            return Json(new { data = objOrganisatorList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var OrganisatorToBeDeleted = _unitOfWork.Organisator.Get(u => u.Id == id);
            if (OrganisatorToBeDeleted == null)
            {
                return Json(new { success = false, message = "Fehler beim löschen" });
            }

            _unitOfWork.Organisator.Remove(OrganisatorToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Organisator erfolgreich gelöscht" });
        }

        #endregion

    }

}
