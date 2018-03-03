using AgendaMedicaDomain.Entidades;
using System;

namespace AgendaMedicaRules.Regras
{
    public class TokenRegras : RouleFactory<TokenRegras>
    {
        public TokenRegras() {}

        public Token RegistrarToken(int idUsuario)
        {
            return new Token
            {
                NumeroToken = GerarNovoToken(),
                IdUsuario = idUsuario,
                DataInclusao = DateTime.Now,
            };
        }

        public Guid GerarNovoToken()
        {
            return Guid.NewGuid();
        }
    }
}
