using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pruebaKonecta.Models;

namespace pruebaKonecta.Controllers
{
    public class SaleController : Controller
    {
        private readonly PruebaKonectaContext _context;
        public SaleController(PruebaKonectaContext context)
        {
            _context = context;
        }

        // Http Get Index
        public IActionResult Index()
        {
            ViewData["Productos"] = new SelectList(_context.Products, "Id", "Nombre");
            return View();
        }

        // Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.Find(sale.ProductId);

                if (product == null) return NotFound();

                if (product.Stock == 0)
                {
                    TempData["msg"] = "Hay cero unidades en stock, no es posible realizar la venta!";
                    return RedirectToAction("Index");
                }

                if ((product.Stock - sale.Cantidad) < 0)
                {
                    TempData["msg"] = "No hay suficiente stock! venda menos";
                    return RedirectToAction("Index");
                }

                product.Stock -= sale.Cantidad;
                _context.Products.Update(product);
                _context.Sales.Add(sale);

                _context.SaveChanges();

                TempData["msg"] = "Venta Realizada";
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Historial() => View(_context.Sales.ToList());
    }
}
