using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.DTO;
using ProjetoExemplo.Services.LoginServices;
using ProjetoExemplo.Services.SessaoService;

namespace ProjetoExemplo.Controllers
{
    public class LoginController : Controller
    {
  

        private readonly ILoginInterface _loginInterface;
        private readonly ISessaoInterface _sessaoInterface;

        public LoginController(ILoginInterface loginInterface, ISessaoInterface sessaoInterface){

            _loginInterface = loginInterface;
            _sessaoInterface = sessaoInterface;
        }


        public IActionResult Index()
        {

            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario != null){
                return RedirectToAction("Login", "Index");
            }

            return View();
        }


        public IActionResult Logout(){
            _sessaoInterface.RemoverSessao();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View("Registrar");
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDTO usuarioRegisterDTO)
        {

            if(ModelState.IsValid){
                var usuario = await _loginInterface.RegistrarUsuario(usuarioRegisterDTO);

                if(usuario.Status){
                    TempData["MensagemSucesso"] = usuario.Mensagem;
                }else{
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View(usuarioRegisterDTO);
                }

                return RedirectToAction("Index");

            }else
            {
                return View(usuarioRegisterDTO);
            }

           
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO usuarioLoginDTO){
            if(ModelState.IsValid){
                var usuario = await _loginInterface.Login(usuarioLoginDTO);

                if(usuario.Status){
                    TempData["MensagemSucesso"] = usuario.Mensagem;
                    return RedirectToAction("Index", "Home");
                }else{
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View("Index", usuarioLoginDTO);
                }



            }else{
                return RedirectToAction("Index");
            }

        }
    }
}
