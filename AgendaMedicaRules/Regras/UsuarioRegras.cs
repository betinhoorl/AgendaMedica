using AgendaMedicaDomain.Dto;
using AgendaMedicaDomain.Entidades;
using AgendaMedicaRules.Validacao;
using System;

namespace AgendaMedicaRules.Regras
{
    public class UsuarioRegras : RouleFactory<UsuarioRegras>
    {
        public UsuarioRegras() {}

        public UsuarioAutenticacaoDto AutenticarUsuario(UsuarioAutenticacaoDto dto)
        {
            return new UsuarioAutenticacaoDto
            {
                UsuarioLogin = ValidarString.CreateInstance.SetString(dto.UsuarioLogin, "Usuário"),
                SenhaCriptografada = ValidarSenha.CreateInstance.SetSenha(dto.Senha),
                TokenAtual = new Guid(GravacaoArquivosRegras.CreateInstance.RecuperarTokenUsuario(dto.UsuarioLogin)),
                NovoToken = TokenRegras.CreateInstance.GerarNovoToken()
            };
        }

        public Usuario CadastroNovoUsuario(UsuarioDto dto)
        {
            return new Usuario
            {
                Login = ValidarString.CreateInstance.SetString(dto.Login, "Usuário"),
                Senha = ValidarSenha.CreateInstance.SetNovaSenha(dto.Senha, dto.ConfirmarSenha),
                Ativo = false     
            };
        }
    }
}
