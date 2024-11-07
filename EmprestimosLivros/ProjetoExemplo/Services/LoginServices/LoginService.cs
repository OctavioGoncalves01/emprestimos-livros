using ProjetoExemplo.Data;
using ProjetoExemplo.DTO;
using ProjetoExemplo.Models;
using ProjetoExemplo.Services.SenhaService;
using ProjetoExemplo.Services.SessaoService;

namespace ProjetoExemplo.Services.LoginServices
{
    public class LoginService : ILoginInterface
    {
        private readonly AplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly ISessaoInterface _sessaoInterface;


        public LoginService(AplicationDbContext context, 
                            ISenhaInterface senhaInterface,
                            ISessaoInterface sessaoInterface
                            ){
            _context = context;
            _senhaInterface = senhaInterface;
            _sessaoInterface = sessaoInterface;
        }


        public async Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = _context.Usuarios.FirstOrDefault
                (
                    x => x.Email == usuarioLoginDTO.Email
                );

                if (usuario == null)
                {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                if (!_senhaInterface.VerificaSenha(usuarioLoginDTO.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                _sessaoInterface.CriarSessao(usuario);

                response.Mensagem = "Usuário logado";
                response.Status = true;
                return response;
            }
            catch (System.Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }



        public async Task<ResponseModel<UsuarioModel>>  RegistrarUsuario(UsuarioRegisterDTO usuarioRegisterDTO){
       
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

           try
           {
                if(VerificaSeEmailExite(usuarioRegisterDTO)){
                    response.Mensagem = "Email já cadastrado";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDTO.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel(){
                    Nome = usuarioRegisterDTO.Nome,
                    Sobrenome = usuarioRegisterDTO.Sobrenome,
                    Email = usuarioRegisterDTO.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return response;

           }
           catch (Exception ex)
           {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
           }
        }
    
        private bool VerificaSeEmailExite(UsuarioRegisterDTO usuarioRegisterDTO){

            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDTO.Email);

            if (usuario == null)
                return false;

            return true;
        }

    }

}