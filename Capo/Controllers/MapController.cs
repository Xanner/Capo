using System.Web.Mvc;

namespace Capo.Controllers
{
    public class MapController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}