using System;

namespace AgendaMedicaDomain.Dto
{
    public class UsuarioAutenticacaoDto
    {
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public byte[] SenhaCriptografada { get; set; }
        public Guid TokenAtual { get; set; }
        public Guid NovoToken { get; set; }
    }
}
