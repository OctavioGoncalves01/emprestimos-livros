using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoExemplo.DTO
{
    public class UsuarioRegisterDTO
    {
        [Required(ErrorMessage ="Digite o nome: ")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage ="Digite o sobrenome: ")]
        public string? Sobrenome { get; set; }
        
        [Required(ErrorMessage ="Digite o Email: ")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Digite a Senha: ")]
        public string? Senha { get; set; }

        [Required(ErrorMessage ="Digite a confirmação da senha: "),
        Compare("Senha", ErrorMessage = "As senhas devem ser iguals")]
        public string? ConfirmaSenha { get; set; }
    }
}