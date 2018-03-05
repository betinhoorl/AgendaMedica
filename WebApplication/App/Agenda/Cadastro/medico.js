(function () {
    'use strict';
    angular.module('app').controller('medico', function ($scope, $location, agendaService) {
        $scope.medicoDto = {
            idMedico: undefined,
            nome: undefined,
            crm: undefined
        };

        var load = function () {
            clean();

            if (window.sessionStorage.getItem('medicoDto')) {
                var medico = JSON.parse(window.sessionStorage.getItem('medicoDto'));
                $scope.medicoDto.idMedico = medico.IdMedico
                $scope.medicoDto.nome = medico.Nome
                $scope.medicoDto.crm = medico.Crm
                window.sessionStorage.removeItem('medicoDto');
            }
        };

        var save = function () {
            if ($scope.medicoDto.idMedico > 0) {
                agendaService.alterarMedico($scope.medicoDto)
               .then(function (medico) {
                   $scope.medicoDto = angular.copy(medico.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });

            } else {
                agendaService.registroMedico($scope.medicoDto)
               .then(function (medico) {
                   $scope.medicoDto = angular.copy(medico.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });
            }
            $location.path('/medicoBusca');
        };

        var cancelar = function () {
            clean();
            $location.path('/medicoBusca');
        };

        var clean = function () {
            $scope.medicoDto.idMedico = undefined;
            $scope.medicoDto.nome = undefined;
            $scope.medicoDto.crm = undefined;
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