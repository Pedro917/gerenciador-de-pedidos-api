using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDePedidos.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
