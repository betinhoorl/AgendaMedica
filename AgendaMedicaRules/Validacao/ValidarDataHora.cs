using System;

namespace AgendaMedicaRules.Validacao
{
    public class ValidarDataHora : RouleFactory<ValidarDataHora>
    {
        public ValidarDataHora() {}

        public DateTime JoinDataHora(string data, string hora)
        {
            DateTime dateTime;
            if(!DateTime.TryParseExact(hora, "hh:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                throw new Exception("Erro de conversão de string/hora");
            }

            if (!DateTime.TryParseExact(data, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                throw new Exception("Erro de conversão de string/data");
            }

            return dateTime;
        }
    }
}
