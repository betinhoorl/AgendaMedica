using AgendaMedicaDomain.Dto;
using AgendaMedicaDomain.Entidades;
using AgendaMedicaRules.Validacao;

namespace AgendaMedicaRules.Regras
{
    public class MedicoRegras : RouleFactory<MedicoRegras>
    {
        public MedicoRegras() {}

        public Medico Add(MedicoDto dto)
        {
            return new Medico
            {
                Nome = ValidarString.CreateInstance.SetString(dto.Nome, "Médico"),
                Crm = ValidarString.CreateInstance.SetString(dto.Crm, "Médico")
            };
        }

        public Medico Edit(MedicoDto dto)
        {
            return new Medico
            {
                IdMedico = ValidarId.CreateInstance.SetId("Código Médico", dto.IdMedico),
                Nome = ValidarString.CreateInstance.SetString(dto.Nome, "Adicional"),
                Crm = ValidarString.CreateInstance.SetString(dto.Crm, "Adicional")
            };
        }

        public int Delete(int idMedico)
        {
            return ValidarId.CreateInstance.SetId("Código Médico", idMedico);
        }
    }
}
