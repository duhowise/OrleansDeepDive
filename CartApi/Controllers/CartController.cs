

using Microsoft.AspNetCore.Mvc;

namespace CartApi.Controllers
{
    public class CartController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}