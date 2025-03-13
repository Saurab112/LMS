using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class DetailsController : Controller
    {
        //specific book details show garnu paro
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
