using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoExemplo.DTO;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Services.SessaoService
{
    public interface ISessaoInterface
    {
        UsuarioModel BuscarSessao();

        void CriarSessao(UsuarioModel usuarioModel);

        void RemoverSessao();
        
    }
}