(function () {
    "user strict";

    var service = angular.module('app');
    service.factory('controleAcessoService', function ($http) {
        var constantRoute = 'http://localhost:51530/';

        /*Autenticar Usuário*/
        var _autenticar = function (usuario) {
            return $http.post(constantRoute + 'usuario/Autenticacao', usuario);
        };

        /*Inserir Novo Usuário*/
        var _registroUsuario = function (usuario) {
            return $http.post(constantRoute + 'usuario/CadastroUsuario', usuario);
        };

        /*Fechar Sessão do Usuário*/
        var _encerrarSessao = function () {
            return $http.post(constantRoute + 'usuario/EncerrarSessao');
        };

        return {
            autenticar: _autenticar,
            registroUsuario: _registroUsuario,
            encerrarSessao: _encerrarSessao
        }

    });
})();
