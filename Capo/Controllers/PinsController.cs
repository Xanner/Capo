using Capo.Models;
using Capo.ViewModels;
using System.Linq;
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

        // GET: Home/GetPins
        [HttpGet]
        public JsonResult GetPins()
        {
            return Json(_context.Pins.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var viewModel = new PinFormViewModel();

            return View("PinForm", viewModel);
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