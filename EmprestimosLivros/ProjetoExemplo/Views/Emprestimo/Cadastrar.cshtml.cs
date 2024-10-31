using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjetoExemplo.Views.Emprestimo
{
    public class Cadastrar : PageModel
    {
        private readonly ILogger<Cadastrar> _logger;

        public Cadastrar(ILogger<Cadastrar> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}