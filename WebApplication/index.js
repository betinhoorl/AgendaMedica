(function () {
    'use strict';
    angular.module('app').controller('index', function ($scope, $location, $http) {
        $scope.Cadastro = function () {
            $("#menuMedico").addClass("escondeMenu");
            $("#menuPaciente").addClass("escondeMenu");
            $("#menuUsuario").addClass("escondeMenu");
            $("#menuAgendamento").removeClass("escondeMenu");
            $location.path('/pessoaBusca');
        };

        $location.path('/login');
    });
})();