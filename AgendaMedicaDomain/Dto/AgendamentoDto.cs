using System;

namespace AgendaMedicaDomain.Dto
{
    public class AgendamentoDto
    {
        public int IdAgendamento { get; set; }
        public string Hora { get; set; }
        public string Data { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
    }
}
