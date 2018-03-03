using AgendaMedicaCommon.Auxiliares;
using System;

namespace AgendaMedicaRules.Validacao
{
    public class ValidarToken : RouleFactory<ValidarToken>
    {
        public ValidarToken() { }

        public Guid SetToken(Guid token)
        {
            Guard.ForValidId(token, "Token");
            return token;
        }
    }
}
