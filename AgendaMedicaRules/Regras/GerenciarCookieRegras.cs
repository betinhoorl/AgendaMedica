using System;
using System.Web;

namespace AgendaMedicaRules.Regras
{
    public class GerenciarCookieRegras
    {
        public static void SetIdUser(int idUsuario)
        {
            HttpCookie cookieIdUser = new HttpCookie("id_usuario");
            cookieIdUser.Value = idUsuario.ToString();
            HttpContext.Current.Response.AppendCookie(cookieIdUser);
        }

        public static int GetIdUser()
        {
            var retorno = string.Empty;
            if (HttpContext.Current.Request.Cookies["id_usuario"] != null)
            {
                retorno = HttpContext.Current.Request.Cookies["id_usuario"].Value;
            }
            return Convert.ToInt32(retorno);
        }
    }
}
