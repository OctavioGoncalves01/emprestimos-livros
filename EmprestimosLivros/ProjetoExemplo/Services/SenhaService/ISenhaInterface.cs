using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoExemplo.Services.SenhaService
{
    public interface ISenhaInterface
    {
        
        void CriarSenhaHash(string senha,
                            out byte[] senhaHash,
                            out byte[] senhaSalt);  

        bool VerificaSenha(string senha,
                           byte[] senhaHash,
                           byte[] senhaSalt);       
    }
}