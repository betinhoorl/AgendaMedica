(function () {
    'use strict';
    angular.module('app').controller('medicoBusca', function ($scope, $location, agendaService) {
        $scope.medicoDto = {
            idMedico: undefined,
            nome: undefined,
            crm: undefined
        };

        $scope.medicos = [];

        var load = function () {
            agendaService.getAllMedicos()
                .then(function (medico) {
                    $scope.medicos = angular.copy(medico.data);
                })
                .catch(function (ex) {

                });
        };

        var filter = function (descricao) {


        };

        var edit = function (medico) {
            window.sessionStorage.setItem('medicoDto', JSON.stringify(medico));
            $location.path('/medico');
        };

        $scope.Editar = function (medico) {
            edit(medico);
        };

        load();

    });
})();