using ProjetoExemplo.DTO;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Services.LoginServices
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDTO usuarioRegisterDTO);
        Task<ResponseModel<UsuarioModel>> Login (UsuarioLoginDTO usuarioLoginDTO);
        
    }
}