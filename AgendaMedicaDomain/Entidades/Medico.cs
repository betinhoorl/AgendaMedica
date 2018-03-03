using System.Collections.Generic;

namespace AgendaMedicaDomain.Entidades
{
    public class Medico
    {
        public const int MaxLenghtMedico = 45;
        public const int MaxLenhgtlenghtCRM = 8;

        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        public Medico()
        {
            Agendamentos = new List<Agendamento>();
        }
    }
}
