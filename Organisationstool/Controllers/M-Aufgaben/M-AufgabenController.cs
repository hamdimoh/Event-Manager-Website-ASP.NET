using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Organisationstool.Data.Repository;
using Organisationstool.Data.Repository.IRepository;
using Organisationstool.Models;

public class M_AufgabenController : Controller
{
    private readonly ApplicationDB _db;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public M_AufgabenController(ApplicationDB db, UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
    {
        _db = db;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Veranstaltungen> objVeranstaltungenList = _db.Veranstaltungen.ToList();
        return View(objVeranstaltungenList);
    }
    public IActionResult CreateTask()
    {
        return View();
    }
   
    [HttpGet]
    public async Task<IActionResult> Annehmen(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var veranstaltung = _unitOfWork.Veranstaltungen.Get(_ => _.Id == id);
            var mitwirkender = _unitOfWork.Mitwirkender.Get(_ => _.Email == user.Email);
            if (mitwirkender != null && veranstaltung != null)
            {
                var newObj = new MitwirkendeAufgaben
                {
                    VeranstaltungId = id,
                    MitwirkendeId = mitwirkender.Id
                };
                _db.MitwirkendeAufgaben.Add(newObj);
                mitwirkender.Aufgaben = veranstaltung.Aufgaben;
                mitwirkender.Uhrzeitab = veranstaltung.Datum;
                mitwirkender.Uhrzeitbis = veranstaltung.Datum;

                mitwirkender.VeranstaltungId = id;

                _db.Mitwirkenden.Update(mitwirkender);
                _db.SaveChanges();
                TempData["success"] = "Die Aufgabe erfolgreich angenommen";
            }

            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        M_Aufgaben? veranstaltungfromDb = _db.MitwirkendenAufgaben.Find(id);
        if (veranstaltungfromDb == null)
        {
            return NotFound();
        }
        return View(veranstaltungfromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        M_Aufgaben? obj = _db.MitwirkendenAufgaben.Find(id);
        if (id == null || id == 0)
        {
            return NotFound();
        }
        _db.MitwirkendenAufgaben.Remove(obj!);
        _db.SaveChanges();
        TempData["success"] = "Die Aufgabe erfolgreich gelöscht";
        return RedirectToAction("Index");

    }
}



