using System.Security.Cryptography;
using System.Text;

namespace AgendaMedicaCommon.Auxiliares
{
    public class Criptografia
    {
        public static byte[] CriptografarSenha(string senha)
        {
            return Criptografar(senha, "jeioors-swewgjgjikwxw-ewonwelsoja-9854");
        }

        public static byte[] Criptografar(string texto, string salt)
        {
            while (salt.Length < 6)
            {
                salt += salt + "Z";
            }
            using (var sha = SHA512.Create())
            {
                salt = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt.Substring(salt.Length - 4))));
                return sha.ComputeHash(Encoding.UTF8.GetBytes(texto + salt));
            }
        }
    }
}
