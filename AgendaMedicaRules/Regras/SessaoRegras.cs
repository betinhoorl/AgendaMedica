using AgendaMedicaDomain.Entidades;
using AgendaMedicaRules.Validacao;
using System;

namespace AgendaMedicaRules.Regras
{
    public class SessaoRegras : RouleFactory<SessaoRegras>
    {
        public SessaoRegras() {}

        public Sessao CriarNovaSessao(int idUsuario)
        {
            return new Sessao
            {
                IdUsuario = ValidarId.CreateInstance.SetId("Código Usuário", idUsuario),
                EstaLogado = true,
                DataAbertura = DateTime.Now
            };
        }

        public Sessao EncerrarSessao(int idUsuario)
        {
            return new Sessao
            {
                IdUsuario = ValidarId.CreateInstance.SetId("Código Usuário", idUsuario),
                EstaLogado = false,
                DataAbertura = DateTime.Now
            };
        }
    }
}
