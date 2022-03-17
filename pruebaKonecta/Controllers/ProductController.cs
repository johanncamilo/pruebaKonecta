using Microsoft.AspNetCore.Mvc;
using pruebaKonecta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using pruebaKonecta.Models.ViewModels;

namespace pruebaKonecta.Controllers
{
    public class ProductController : Controller
    {
        private readonly PruebaKonectaContext _context;

        
        public ProductController(PruebaKonectaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var producto = new Product()
                {
                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    Peso = model.Peso,
                    Categoria = model.Categoria,
                    Stock = model.Stock
                };
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
                
        // Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var product = _context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }

        // Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                TempData["msg"] = "Producto actualizdo con éxito";
                return RedirectToAction("Index");
            }

            return View();
        }        
        
        public async Task<IActionResult> DeleteProduct_Old(int? id)
        {
            Product producto = _context.Products.Find(id);

            if (producto == null) return NotFound();

            _context.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        // Http Get Delete
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var product = _context.Products.Find(id);

            if (product == null) return NotFound();

            _context.Remove(product);
            _context.SaveChanges();

            TempData["msg"] = "Producto eliminado con éxito";
            return RedirectToAction("Index");
        }

    }
}
