using AgendaMedicaCommon.Auxiliares;

namespace AgendaMedicaRules.Validacao
{
    public class ValidarSenha : RouleFactory<ValidarSenha>
    {
        public ValidarSenha() { }

        public byte[] SetSenha(string senha)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.StringLength("Senha", senha, 6, 20);
            return Criptografia.CriptografarSenha(senha);
        }

        public byte[] SetNovaSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirma Senha");
            Guard.StringLength("Senha", senha, 6, 20);
            Guard.AreEqual(senha, senhaConfirmacao, "Senhas não conferem");
            return Criptografia.CriptografarSenha(senha);
        }
    }
}
