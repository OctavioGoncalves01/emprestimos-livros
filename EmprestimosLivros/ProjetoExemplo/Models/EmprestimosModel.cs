using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoExemplo.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }
        public string Receber { get; set; }
        public string Fornecedor { get; set; }
        public string LivroEmprestado { get; set; }
        public DateTime dataUltimaAtualiacao { get; set; } = DateTime.Now;
    }
}