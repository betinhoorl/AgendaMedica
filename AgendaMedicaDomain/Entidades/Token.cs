using System;

namespace AgendaMedicaDomain.Entidades
{
    public class Token
    {
        public int IdToken { get; set; }
        public int IdUsuario { get; set; }
        public Guid NumeroToken { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Token() { }
    }
}
