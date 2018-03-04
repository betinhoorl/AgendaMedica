using AgendaMedicaDomain.Dto;
using AgendaMedicaDomain.Entidades;
using AgendaMedicaDomain.ObjetoValor;
using AgendaMedicaRules.Validacao;

namespace AgendaMedicaRules.Regras
{
    public class PacienteRegras : RouleFactory<PacienteRegras>
    {
        public PacienteRegras() { }

        public Paciente Add(PacienteDto dto)
        {
            return new Paciente
            {
                Nome = ValidarString.CreateInstance.SetString(dto.Nome, "Paciente"),
                Cpf = new Cpf(dto.Cpf)
            };
        }

        public Paciente Edit(PacienteDto dto)
        {
            return new Paciente
            {
                IdPaciente = ValidarId.CreateInstance.SetId("Código Paciente", dto.IdPaciente),
                Nome = ValidarString.CreateInstance.SetString(dto.Nome, "Paciente"),
                Cpf = new Cpf(dto.Cpf)
            };
        }

        public int Delete(int idPaciente)
        {
            return ValidarId.CreateInstance.SetId("Código Paciente", idPaciente);
        }
    }
}
