using Microsoft.AspNetCore.Mvc;
using Organisationstool.Data;
using Organisationstool.Models;
using Microsoft.AspNetCore.Authorization;
using Organisationstool.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organisationstool.Data.Repository.IRepository;
using Microsoft.Extensions.Hosting.Internal;

namespace Organisationstool.Models.Controllers.Admin
{

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Index()
        {
            List<Product> objVeranstaltungenList = _unitOfWork.Products.GetAll().ToList();
            return View(objVeranstaltungenList);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? veranstaltungfromDb = _unitOfWork.Products.Get(u => u.Id == id);
            if (veranstaltungfromDb == null)
            {
                return NotFound();
            }
            return View(veranstaltungfromDb);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                SaveBild(obj);
                _unitOfWork.Products.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Produkt erfolgreich erstellt";
                return RedirectToAction("Index");
            }
            return View();
        }
        private void SaveBild(Product obj)
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
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                EditProductPriceCart(obj);
                SaveBild(obj);
                _unitOfWork.Products.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Produkt erfolgreich bearbeitet";
                return RedirectToAction("Index");
            }
            return View();
        }

        private void EditProductPriceCart(Product obj)
        {
            Cart cart = GetCartFromSession();
            var products = cart.Products.Where(_ => _.Id == obj.Id);
            foreach (var product in products)
            {
                product.Price = obj.Price;
            }
            SaveCartToSession(cart);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? veranstaltungfromDb = _unitOfWork.Products.Get(u => u.Id == id);
            if (veranstaltungfromDb == null)
            {
                return NotFound();
            }
            return View(veranstaltungfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Products.Get(u => u.Id == id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            RemoveProductCart(obj!);
            _unitOfWork.Products.Remove(obj!);
            _unitOfWork.Save();
            TempData["success"] = "Produkt erfolgreich gelöscht";
            return RedirectToAction("Index");

        }

        private void RemoveProductCart(Product obj)
        {
            Cart cart = GetCartFromSession();
            var productsToRemove = cart.Products.Where(_ => _.Id == obj.Id).ToList();
            foreach (var productToRemove in productsToRemove)
            {
                cart.Products.Remove(productToRemove);
            }

            SaveCartToSession(cart);
        }

        public IActionResult AddToCart(int id)
        {
            Product product = _unitOfWork.Products.Get(u => u.Id == id);
            if (product != null)
            {
                Cart cart = GetCartFromSession();
                cart.Products.Add(product);
                SaveCartToSession(cart);
            }
            TempData["success"] = "Zum Einkaufswagen hinzugefügt";
            return RedirectToAction("Index");
        }

        // Aktion zum Anzeigen des Einkaufswagens
        public IActionResult Cart()
        {
            Cart cart = GetCartFromSession();
            var veranstaltungen = _unitOfWork.Veranstaltungen.GetAll().ToList();
            cart.VeranstaltungenListItems = veranstaltungen.Select(_ => new SelectListItem { Value = _.Id.ToString(), Text = _.NamederVeranstaltung }).ToList();
            return View(cart);
        }

        public IActionResult BudgetBerechnen(int VeranstaltungId)
        {
            Cart cart = GetCartFromSession();
            var veranstaltung = _unitOfWork.Veranstaltungen.Get(_ => _.Id == VeranstaltungId);
            cart.Budget = veranstaltung?.Budget;
            cart.VeranstaltungId = VeranstaltungId;
            SaveCartToSession(cart);
            return RedirectToAction("Cart", cart);
        }

        public IActionResult DeleteFromCart(int id)
        {
            Cart cart = GetCartFromSession();
            var product = cart.Products.Find(_ => _.Id == id);
            TempData["success"] = "Produkt erfolgreich gelöscht";
            cart.Products.Remove(product);
            SaveCartToSession(cart);
            return RedirectToAction("Cart", cart);
        }

        private Cart GetCartFromSession()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                SaveCartToSession(cart);
            }
            return cart;
        }

        private void SaveCartToSession(Cart cart)
        {
            HttpContext.Session.SetObject("Cart", cart);
        }
    }
}






