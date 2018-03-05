(function () {
    'use strict';
    angular.module('app').controller('paciente', function ($scope, $location, agendaService) {
        $scope.pacienteDto = {
            idPaciente: undefined,
            nome: undefined,
            cpf: undefined
        };

        var load = function () {
            clean();

            if (window.sessionStorage.getItem('pacienteDto')) {
                var paciente = JSON.parse(window.sessionStorage.getItem('pacienteDto'));
                $scope.pacienteDto.idPaciente = paciente.IdPaciente;
                $scope.pacienteDto.nome = paciente.Nome;
                $scope.pacienteDto.cpf = paciente.Cpf.Codigo;
                window.sessionStorage.removeItem('pacienteDto');
            }
        };

        var save = function () {
            if ($scope.pacienteDto.idPaciente > 0) {
                agendaService.alterarPaciente($scope.pacienteDto)
               .then(function (paciente) {
                   $scope.pacienteDto = angular.copy(paciente.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });

            } else {
                agendaService.registroPaciente($scope.pacienteDto)
               .then(function (paciente) {
                   $scope.pacienteDto = angular.copy(paciente.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });
            }
            $location.path('/pacienteBusca');
        };

        var cancelar = function () {
            clean();
            $location.path('/pacienteBusca');
        };

        var clean = function () {
            $scope.pacienteDto.idPaciente = undefined;
            $scope.pacienteDto.nome = undefined;
            $scope.pacienteDto.cpf = undefined;
        };

        $scope.salvar = function () {
            save();
        };

        $scope.cancelar = function () {
            cancelar();
        }

        var alert = function (message, type) {
            $("ui-alert").fadeIn(500);
            $scope.message = message;
            $scope.type = type;
            $("ui-alert").delay(3200).fadeOut(1000);
        };

        load();
    });
})();