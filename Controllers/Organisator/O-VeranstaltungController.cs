using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Organisationstool.Models;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Organisationstool.Data.Repository.IRepository;
using Octokit;

namespace Organisationstool.Models.Controllers.Admin
{
    [Authorize(Roles = SD.Role_Org)]
    public class O_VeranstaltungController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public O_VeranstaltungController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Index()
        {
            List<Veranstaltungen> objVeranstaltungList = _unitOfWork.Veranstaltungen.GetAll().ToList();
            return View(objVeranstaltungList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Veranstaltungen());
            }
            else
            {
                //update
                Veranstaltungen? veranstaltungfromDb = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
                if (veranstaltungfromDb == null)
                {
                    return NotFound();
                }
                return View(veranstaltungfromDb);

            }
        }
        [HttpPost]
        public IActionResult Upsert(Veranstaltungen obj)
        {

            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    SaveBild(obj);
                    _unitOfWork.Veranstaltungen.Add(obj);
                    TempData["success"] = "Veranstaltung erfolgreich erstellt";
                }
                else
                {

                    _unitOfWork.Veranstaltungen.Update(obj);
                    TempData["success"] = "Veranstaltung erfolgreich bearbeitet";
                }
                SaveBild(obj);
                _unitOfWork.Save();
               
                return RedirectToAction("Index");
            }
            else
            {

                return View(obj);
            }
        }
        private void SaveBild(Veranstaltungen obj)
        {
            if (obj.BildStream != null && obj.BildStream.Length > 0)
            {
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                var filename = obj.BildStream.FileName;
                var filePath = Path.Combine(uploadFolder, filename);
                using (var stream = new FileStream(filePath, System.IO.FileMode.Create))
                {
                    obj.BildStream.CopyTo(stream);
                }
            }
        }
        public IActionResult Deletehaupt(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Veranstaltungen? veranstaltungfromDb = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
            if (veranstaltungfromDb == null)
            {
                return NotFound();
            }
            return View(veranstaltungfromDb);
        }
        [HttpPost, ActionName("Deletehaupt")]
        public IActionResult DeletePOST(int? id)
        {
            Veranstaltungen? obj = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.Veranstaltungen.Remove(obj!);
            _unitOfWork.Save();
            TempData["success"] = "Veranstaltung erfolgreich gelöscht";
            return RedirectToAction("Index");

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Veranstaltungen> objVeranstaltungList = _unitOfWork.Veranstaltungen.GetAll().ToList();
            return Json(new { data = objVeranstaltungList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var VeranstaltungenToBeDeleted = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
            if (VeranstaltungenToBeDeleted == null)
            {
                return Json(new { success = false, message = "Fehler beim löschen" });
            }

            _unitOfWork.Veranstaltungen.Remove(VeranstaltungenToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Veranstaltung erfolgreich gelöscht" });
        }

        #endregion

    }
}
