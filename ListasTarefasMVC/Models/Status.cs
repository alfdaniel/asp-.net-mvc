using System.ComponentModel.DataAnnotations;

namespace ListasTarefasMVC.Models
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        public string Nome { get; set; }
    }
}
