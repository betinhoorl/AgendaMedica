﻿using System;

namespace AgendaMedicaDomain.Entidades
{
    public class Agendamento
    {
        public int IdAgendamento { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Data { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }

        public Agendamento() { }
    }
}
