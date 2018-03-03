namespace AgendaMedicaDomain.Entidades
{
    public class Usuario
    {
        public const int LoginMaxLength = 15;
        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public bool Ativo { get; set; }

        public Usuario()  {}
    }
}
