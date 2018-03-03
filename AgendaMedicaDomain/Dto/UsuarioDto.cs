namespace AgendaMedicaDomain.Dto
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public bool Ativo { get; set; }
    }
}
