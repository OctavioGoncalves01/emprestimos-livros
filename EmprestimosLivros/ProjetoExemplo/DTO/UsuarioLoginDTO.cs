using System.ComponentModel.DataAnnotations;

namespace ProjetoExemplo.DTO
{
    public class UsuarioLoginDTO
    {

        [Required(ErrorMessage ="Digite o Email")]
        public string Email {get; set;}  

        [Required(ErrorMessage ="Digite a senha")]
        public string Senha {get; set;}        
    }
}