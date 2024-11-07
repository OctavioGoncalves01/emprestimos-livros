using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

namespace ProjetoExemplo.Services.SenhaService
{
    public class SenhaServices : ISenhaInterface
    {
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;  
                senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }

        public bool VerificaSenha(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512(senhaSalt))  
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return computeHash.SequenceEqual(senhaHash); 
            }
        }
    }
}
