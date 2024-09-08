using ListasTarefasMVC.Data;
using ListasTarefasMVC.Models;

namespace ListasTarefasMVC.Controllers
{
    public class HomeController : Controller
    {

        public readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult Index(string filtro)
        {

            var filtros = new Filtros(filtro);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Vencimento = Filtros.VencimentoValoresFiltro;


            IQueryable<Tarefa> consulta = _context.Tarefas.Include(c => c.Categorias).Include(s => s.Status);

            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaNome == filtros.CategoriaNome);
            }

            if (filtros.TemStatus)
            {
                consulta = consulta.Where(t => t.StatusNome == filtros.StatusNome);
            }

            if (filtros.TemVencimento)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(t => t.DataVencimento < hoje);
                }


                if (filtros.EFuturo)
                {
                    consulta = consulta.Where(t => t.DataVencimento > hoje);
                }


                if (filtros.EHoje)
                {
                    consulta = consulta.Where(t => t.DataVencimento == hoje);
                }
            }

            var tarefas = consulta.OrderBy(t => t.DataVencimento).ToList();

            return View(tarefas);
        }

    }
}
