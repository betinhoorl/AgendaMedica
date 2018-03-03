namespace AgendaMedicaDomain.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public bool Ativo { get; set; }

        public Usuario()  {}
    }
}
