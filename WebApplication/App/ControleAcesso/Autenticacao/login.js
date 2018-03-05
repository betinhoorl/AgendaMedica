(function () {
    'use strict';
    angular.module('app').controller('login', function ($scope, $location, controleAcessoService) {
        $scope.usuarioDto = {
            login: undefined,
            senha: undefined
        };

        var entrar = function () {
            controleAcessoService.autenticar($scope.usuarioDto)
               .then(function (usuario) {
                   $("#menuPrincipal").removeClass("escondeMenu");
                   $location.path('/balcaoAtendimento');
               })
               .catch(function (ex) {
                   var message = ex.data.exceptionMessage ? ex.data.exceptionMessage : ex.data;
                   alert(message, 'error');
               });
        };

        var load = function () {
            $("#menuPrincipal").addClass("escondeMenu");
            $location.path('/login');
        }

        $scope.entrar = function () {
            entrar();
        };

        $scope.novoUsuario = function () {
            $location.path('/novoUsuario');
        };

        var alert = function (message, type) {
            $("ui-alert").fadeIn(500);
            $scope.message = message;
            $scope.type = type;
            $("ui-alert").delay(3200).fadeOut(1000);
        };

        load();
    });
})();