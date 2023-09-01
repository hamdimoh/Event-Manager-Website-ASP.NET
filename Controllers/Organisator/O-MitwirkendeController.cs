using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Organisationstool.Models;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Organisationstool.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organisationstool.Models.ViewModels;

namespace Organisationstool.Controllers.Admin
{
    
    public class O_MitwirkendeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public O_MitwirkendeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Mitwirkende> objMitwirkenderList = _unitOfWork.Mitwirkender.GetAll(includeProperties: "Veranstaltung").ToList();

            return View(objMitwirkenderList);
        }
        public IActionResult Upsert(int? id)
        {

            MitwirkenderVM MitwirkenderVM = new()
            {

                VeranstaltungList = _unitOfWork.Veranstaltungen.GetAll().Select(u => new SelectListItem
                {
                    Text = u.NamederVeranstaltung,
                    Value = u.Id.ToString()
                }),
                Mitwirkende = new Mitwirkende()
            };
            if (id == null || id == 0)
            {
                //create
                return View(MitwirkenderVM);
            }
            else
            {
                //update
                MitwirkenderVM.Mitwirkende = _unitOfWork.Mitwirkender.Get(u => u.Id == id);
                return View(MitwirkenderVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(MitwirkenderVM MitwirkenderVM)
        {

            if (ModelState.IsValid)
            {
                if (MitwirkenderVM.Mitwirkende.Id == 0)
                {

                    if (MitwirkenderVM.Mitwirkende.VeranstaltungId == 0)
                    {
                        TempData["error"] = "Veranstaltung muss gefüllt sein";
                        return View(MitwirkenderVM);
                    }
                    else
                    {
                        _unitOfWork.Mitwirkender.Add(MitwirkenderVM.Mitwirkende);
                        TempData["success"] = "Mitwirkende erfolgreich hinzugefügt";
                    }

                }
                else
                {
                    if (MitwirkenderVM.Mitwirkende.VeranstaltungId == 0)
                    {
                        TempData["error"] = "Veranstaltung muss gefüllt sein";
                        return View(MitwirkenderVM);
                    }
                    else
                    {
                        _unitOfWork.Mitwirkender.Update(MitwirkenderVM.Mitwirkende);
                        TempData["success"] = "Mitwirkende erfolgreich bearbeitet";
                    }

                }


                _unitOfWork.Save();


                return RedirectToAction("Index");

            }

            return View(MitwirkenderVM);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Mitwirkende> objMitwirkenderList = _unitOfWork.Mitwirkender.GetAll(includeProperties: "Veranstaltung").ToList();
            return Json(new { data = objMitwirkenderList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var MitwirkenderToBeDeleted = _unitOfWork.Mitwirkender.Get(u => u.Id == id);
            if (MitwirkenderToBeDeleted == null)
            {
                return Json(new { success = false, message = "Fehler beim löschen" });
            }

            _unitOfWork.Mitwirkender.Remove(MitwirkenderToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Mitwirkende erfolgreich gelöscht" });
        }

        #endregion

    }
}