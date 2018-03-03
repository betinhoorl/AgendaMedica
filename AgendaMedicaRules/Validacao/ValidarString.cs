using AgendaMedicaCommon.Auxiliares;

namespace AgendaMedicaRules.Validacao
{
    public class ValidarString : RouleFactory<ValidarString>
    {
        public ValidarString() { }

        public string SetString(string valor, string campo)
        {
            Guard.ForNullOrEmptyDefaultMessage(valor, campo);
            return valor;
        }
    }
}
