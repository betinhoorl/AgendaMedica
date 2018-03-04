using AgendaMedicaDomain.Dto;
using AgendaMedicaDomain.Entidades;
using AgendaMedicaRules.Validacao;

namespace AgendaMedicaRules.Regras
{
    public class AgendamentoRegras : RouleFactory<AgendamentoRegras>
    {
        public AgendamentoRegras() {}

        public Agendamento Add(AgendamentoDto dto)
        {
            return new Agendamento
            {
                DataHora = ValidarDataHora.CreateInstance.JoinDataHora(dto.Data, dto.Hora),
                IdMedico = ValidarId.CreateInstance.SetId("Código Médico", dto.IdMedico),
                IdPaciente = ValidarId.CreateInstance.SetId("Código Paciente", dto.IdPaciente)
            };
        }

        public Agendamento Edit(AgendamentoDto dto)
        {
            return new Agendamento
            {
                IdAgendamento = ValidarId.CreateInstance.SetId("Código Agendamento", dto.IdAgendamento),
                DataHora = ValidarDataHora.CreateInstance.JoinDataHora(dto.Data, dto.Hora),
                IdMedico = ValidarId.CreateInstance.SetId("Código Médico", dto.IdMedico),
                IdPaciente = ValidarId.CreateInstance.SetId("Código Paciente", dto.IdPaciente)
            };
        }

        public int Delete(int idAgendamento)
        {
            return ValidarId.CreateInstance.SetId("Código Agendamento", idAgendamento);
        }
    }
}
