(function () {
    'use strict';
    angular.module('app').controller('pacienteBusca', function ($scope, $location, agendaService) {
        $scope.medicoDto = {
            idPaciente: undefined,
            nome: undefined,
            cpf: undefined
        };

        $scope.pacientes = [];

        var load = function () {
            agendaService.getAllPacientes()
                .then(function (paciente) {
                    $scope.pacientes = angular.copy(paciente.data);
                })
                .catch(function (ex) {

                });
        };

        var edit = function (paciente) {
            window.sessionStorage.setItem('pacienteDto', JSON.stringify(paciente));
            $location.path('/paciente');
        };

        $scope.Editar = function (paciente) {
            edit(paciente);
        };

        load();

    });
})();