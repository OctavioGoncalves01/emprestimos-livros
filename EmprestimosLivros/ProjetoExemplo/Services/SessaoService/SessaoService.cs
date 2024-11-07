using Newtonsoft.Json;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Services.SessaoService
{
    public class SessaoService : ISessaoInterface
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessaoService(IHttpContextAccessor contextAccessor){
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            var sessaoUsuario = _contextAccessor?.HttpContext?.Session.GetString("sessaoUsuario");

            if(string.IsNullOrEmpty(sessaoUsuario)){
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessao(UsuarioModel usuarioModel)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuarioModel);
            _contextAccessor?.HttpContext?.Session.SetString("sessaoUsuario", usuarioJson);
        }

        public void RemoverSessao()
        {
            _contextAccessor?.HttpContext?.Session.Remove("sessaoUsuario");
        }
    }
}