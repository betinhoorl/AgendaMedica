using AgendaMedicaDomain.ObjetoValor;
using System.Collections.Generic;

namespace AgendaMedicaDomain.Entidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        public Paciente()
        {
            Agendamentos = new List<Agendamento>();
        }
    }
}
