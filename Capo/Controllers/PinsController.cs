using Capo.Models;
using Capo.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace Capo.Controllers
{
    public class PinsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserStore<ApplicationUser> _userStoreContext;

        public PinsController()
        {
            _userStoreContext = new UserStore<ApplicationUser>(new ApplicationDbContext());
            _applicationDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _applicationDbContext.Dispose();
        }

        // GET: Home/GetPins
        [HttpGet]
        public JsonResult GetPins()
        {
            return Json(_applicationDbContext.Pins.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult New()
        {
            var viewModel = new PinFormViewModel();
            var currentUserId = User.Identity.GetUserId();
            viewModel.ApplicationUserId = _userStoreContext.Users.FirstOrDefault(u => u.Id == currentUserId)?.Id;

            return PartialView("_PinForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pin pin)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("New", "Pins");

            if (pin.Id == 0)
            {
                _applicationDbContext.Pins.Add(pin);
            }

            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index", "Map");
        }
    }
}