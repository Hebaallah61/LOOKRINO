using Microsoft.AspNetCore.Mvc;

namespace RINO.Controllers.ContactController
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
