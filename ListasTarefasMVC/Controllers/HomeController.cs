using ListasTarefasMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListasTarefasMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
