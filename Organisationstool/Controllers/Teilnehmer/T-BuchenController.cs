using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Organisationstool.Data.Repository.IRepository;
using Nest;
using Microsoft.AspNetCore.Identity;
using NuGet.Packaging;
using Octokit;
using Organisationstool.Data.Repository;

namespace Organisationstool.Models.Controllers
{
    
    public class T_BuchenController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IUnitOfWork _unitOfWork;

        public T_BuchenController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? id)
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
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                veranstaltungfromDb.CurrentTeilnehmerName = (user as ApplicationUser)?.Name;

            }
            return View(veranstaltungfromDb);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuchung(int? id)
        {
            Veranstaltungen? veranstaltungenFromDb = null;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                veranstaltungenFromDb = _unitOfWork.Veranstaltungen.Get(u => u.Id == id);
                var buchungen = _unitOfWork.Buchungen.GetAll(_ => _.UserId == user.Id && _.VeranstaltungId == id);
                if (!buchungen.Any())
                {
                    _unitOfWork.Buchungen.Add(new Buchungen
                    {
                        VeranstaltungId = id.Value,
                        Datum = DateTime.Now,
                        UserId = user.Id,
                    });
                    _unitOfWork.Save();
                    TempData["success"] = "Buchung wurde erfolgreich abgeschlossen";

                }
                else
                {
                    TempData["error"] = "Buchung wurde ein mal gebucht";
                }
                return RedirectToAction("Index", new { id = id });
            }

            return View(veranstaltungenFromDb);
        }

        [HttpGet]
        public async Task<IActionResult> List(int? id)
        {
            List<Buchungen> buchungen = new List<Buchungen>();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                buchungen.AddRange(_unitOfWork.Buchungen.GetAll(u => u.UserId == user.Id));

               
                foreach (var buchung in buchungen)
                {
                    var veranstaltung = _unitOfWork.Veranstaltungen.Get(v => v.Id == buchung.VeranstaltungId);
                    buchung.Veranstaltung = veranstaltung;
                }
            }
            return View(buchungen);
        }

    }

}

