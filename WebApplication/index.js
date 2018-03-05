(function () {
    'use strict';
    angular.module('app').controller('index', function ($scope, $location, $http) {
        $scope.Cadastro = function () {
            $("#menuAtendimento").addClass("escondeMenu");
            $("#menuCadastro").removeClass("escondeMenu");
            $location.path('/pacienteBusca');
        };

        $scope.Atendimento = function () {
            $("#menuCadastro").addClass("escondeMenu");
            $("#menuAtendimento").removeClass("escondeMenu");
            $location.path('/balcaoAtendimento')
        };

        $location.path('/login');
    });
})();