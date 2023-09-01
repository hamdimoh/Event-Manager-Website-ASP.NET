using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Organisationstool.Data.Repository.IRepository;
using Nest;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organisationstool.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Data;

namespace Organisationstool.Models.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AGastController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
       
        public AGastController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Gast> objGastList = _unitOfWork.Gast.GetAll(includeProperties: "Veranstaltung").ToList();
           
            return View(objGastList);
        }
        public IActionResult Upsert(int? id)
        {
           
            GastVM GastVM = new()
            {
                 
                VeranstaltungList = _unitOfWork.Veranstaltungen.GetAll().Select(u => new SelectListItem
                {
                    Text = u.NamederVeranstaltung,
                    Value = u.Id.ToString()
                }),
              
                Gast = new Gast()
             
            };
          
            if (id == null || id == 0)
            {
               
                //create
                return View(GastVM);
            }
            else
            {
                //update
                GastVM.Gast = _unitOfWork.Gast.Get(u => u.Id == id);
                return View(GastVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(GastVM GastVM)
        {

            if (ModelState.IsValid)
            {

                if (GastVM.Gast.Id == 0)
                {

                    if (GastVM.Gast.VeranstaltungId == 0)
                    {
                        TempData["error"] = "Veranstaltung muss gefüllt sein";
                        return View(GastVM);
                    }
                    else
                    {
                        _unitOfWork.Gast.Add(GastVM.Gast);
                        TempData["success"] = "Gast erfolgreich hinzugefügt";
                    }

                }
                else
                {
                    if (GastVM.Gast.VeranstaltungId == 0)
                    {
                        TempData["error"] = "Veranstaltung muss gefüllt sein";
                        return View(GastVM);
                    }
                    else
                    {
                        _unitOfWork.Gast.Update(GastVM.Gast);
                        TempData["success"] = "Gast erfolgreich bearbeitet";
                    }
                }
                    _unitOfWork.Save();

              
                return RedirectToAction("Index");

            }
           
            return View(GastVM);
        }
       
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gast> objGastList = _unitOfWork.Gast.GetAll(includeProperties: "Veranstaltung").ToList();
            return Json(new { data = objGastList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var GastToBeDeleted = _unitOfWork.Gast.Get(u => u.Id == id);
            if (GastToBeDeleted == null)
            {
                return Json(new { success = false, message = "Fehler beim löschen" });
            }

            _unitOfWork.Gast.Remove(GastToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Gast erfolgreich gelöscht" });
        }

        #endregion

    }




}


