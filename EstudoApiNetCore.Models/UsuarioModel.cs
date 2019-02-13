using SHA3.Net;
using System;
using System.Text;

namespace EstudoApiNetCore.Models
{
    public class UsuarioModel
    {
        private byte[] _senha;
        private readonly string _salt = "Rp:]|e.}P0&OT$<OrXdLGjOiKL,q%;@<e9[dE%WTgDj1(g&b3Km9t1J4$:Ms.;qR";
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string HashSenha {
            get
            {
                return BitConverter
                    .ToString(_senha)
                    .Replace("-", string.Empty)
                    .ToLower();
            }
            set { }
        }
        
        public UsuarioModel(string primeiroNome, string ultimoNome, string nomeUsuario, string email, string endereco, int numero, string telefone, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            NomeUsuario = nomeUsuario;
            Email = email;
            Endereco = endereco;
            Numero = numero;
            Telefone = telefone;
            _senha = Sha3.Sha3512().ComputeHash(Encoding.UTF8.GetBytes(string.Concat(senha, _salt)));
        }
    }
}
