(function () {
    'use strict';
    angular.module('app').controller('balcaoAtendimento', function ($scope, $location, agendaService) {
        $scope.agendamentoDto = {
            idAgendamento: undefined,
            hora: undefined,
            data: undefined,
            idPaciente: undefined,
            idMedico: undefined
        };

        $scope.agendamentos = [];

        var load = function () {
            agendaService.getAllAgendamentos()
                .then(function (agendamento) {
                    $scope.agendamentos = angular.copy(agendamento.data);
                })
                .catch(function (ex) {

                });
        };

        var edit = function (agendamento) {
            window.sessionStorage.setItem('agendamentoDto', JSON.stringify(agendamento));
            $location.path('/agendamento');
        };

        $scope.Editar = function (medico) {
            edit(medico);
        };

        load();

    });
})();