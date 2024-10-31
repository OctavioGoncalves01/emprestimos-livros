using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjetoExemplo.Views.Emprestimo
{
    public class Excluir : PageModel
    {
        private readonly ILogger<Excluir> _logger;

        public Excluir(ILogger<Excluir> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}