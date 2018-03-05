(function () {
    'use strict';
    angular.module('app').controller('novoUsuario', function ($scope, $location, $window, controleAcessoService) {
        $scope.usuarioDto = {
            login: undefined,
            senha: undefined,
            confirmarSenha: undefined,
        };

        var save = function () {
            controleAcessoService.registroUsuario($scope.usuarioDto)
                .then(function (usuario) {
                    $scope.usuarioRetorno = angular.copy(usuario.data);
                    $scope.alerts.push({ type: 'success', msg: 'Usuario cadastrado com sucesso!' });
                    clean();
                })
                .catch(function (ex) {
                    var error = ex;
                    $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
                });
        };

        var cancelar = function () {
            clean();
            $location.path('/login');
        };

        var clean = function () {
            $scope.usuarioDto.usuarioLogin = undefined;
            $scope.usuarioDto.senha = undefined;
            $scope.usuarioDto.confirmarSenha = undefined;
        };

        $scope.confirmar = function () {
            save();
        }

        $scope.cancelar = function () {
            cancelar();
        }

        $scope.alerts = [];
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };

    });
})();