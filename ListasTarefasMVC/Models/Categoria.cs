using System.ComponentModel.DataAnnotations;

namespace ListasTarefasMVC.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
    }
}
