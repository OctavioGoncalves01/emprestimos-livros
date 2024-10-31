using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoExemplo.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome de quem irá receber o livro")]
        public required string Receber { get; set; }
        
        [Required(ErrorMessage = "Digite o nome de quem irá fornecer o livro")]
        public required string  Fornecedor { get; set; }
        
        [Required(ErrorMessage = "Digite o nome da obra")]
        public required string LivroEmprestado { get; set; }
        
        public DateTime dataUltimaAtualiacao { get; set; } = DateTime.Now;

    }
}
