using Capo.Models;
using System.Web.Mvc;

namespace Capo.Controllers
{
    public class PinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PinsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            return View("PinForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pin pin)
        {
            if (!ModelState.IsValid)
                return View("PinForm", pin);

            if (pin.Id == 0)
            {
                _context.Pins.Add(pin);
            }

            _context.SaveChanges();

            return RedirectToAction("New", "Pins");
        }
    }
}