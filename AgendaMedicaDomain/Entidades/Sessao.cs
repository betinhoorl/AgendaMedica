using System;

namespace AgendaMedicaDomain.Entidades
{
    public class Sessao
    {
        public int IdSessao { get; set; }
        public int IdUsuario { get; set; }
        public bool EstaLogado { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataEncerramento { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Sessao() { }
    }
}
