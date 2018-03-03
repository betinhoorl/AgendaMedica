using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace AgendaMedicaRules.Regras
{

    public class GravacaoArquivosRegras : RouleFactory<GravacaoArquivosRegras>
    {
        public GravacaoArquivosRegras() { }

        public void SalvarTokenUsuario(string loginUsuario, Guid numeroToken)
        {
            try
            {
                string pasta = @"C:\\temptoken";

                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }

                if (!string.IsNullOrEmpty(loginUsuario) && numeroToken != null)
                {
                    var caminho = pasta + "\\" + loginUsuario + ".txt";
                    using (StreamWriter stream = new StreamWriter(caminho, false, Encoding.UTF8))
                    {
                        stream.Write(numeroToken);
                        stream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel salvar o arquivo. Erro: " + ex.Message.ToString());
            }
        }

        public string RecuperarTokenUsuario(string loginUsuario)
        {
            try
            {
                string pasta = @"C:\\temptoken";
                string token = string.Empty;

                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }

                if (!string.IsNullOrEmpty(loginUsuario))
                {
                    var caminho = pasta + "\\" + loginUsuario + ".txt";
                    using (StreamReader stream = new StreamReader(caminho, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
                    {
                        token = stream.ReadToEnd();
                    }
                }

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel recuperar o arquivo. Erro: " + ex.Message.ToString());
            }
        }
    }
}
