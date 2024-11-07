using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjetoExemplo.Views.Shared
{
    public class _LayoutDeslogado : PageModel
    {
        private readonly ILogger<_LayoutDeslogado> _logger;

        public _LayoutDeslogado(ILogger<_LayoutDeslogado> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}