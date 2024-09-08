using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListasTarefasMVC.Models
{
    public class Tarefa
    {
        [Key]
        public Guid TarefaId { get; set; }
        [Required(ErrorMessage = "Preencha a descrição")]
        public  string Descicao { get; set; }
        [Required(ErrorMessage = "Preencha a Data de Vencimento")]
        public DateTime DataVencimento { get; set; }
        [Required(ErrorMessage = "Selecione uma Categoria")]
        public Guid CategoriaId { get; set; }
        [ValidateNever]
        public Categoria Catergoria { get; set; }
        [Required(ErrorMessage = "Selecione um Status")]
        public Guid StatusId { get; set; }
        [ValidateNever]
        public Status Status { get; set; }
        public bool Atarsado => Status.Nome == "Aberto" && DataVencimento < DateTime.Today;
    }
}
