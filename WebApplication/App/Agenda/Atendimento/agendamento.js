(function () {
    'use strict';
    angular.module('app').controller('agendamento', function ($scope, $location, agendaService) {
        $scope.agendamentoDto = {
            idAgendamento: undefined,
            hora: undefined,
            data: undefined,
            idPaciente: undefined,
            idMedico: undefined
        };

        $scope.PacienteDto = [];
        $scope.MedicoDto = [];

        var load = function () {
            //clean();
            carregarPaciente();
            carregarMedico();

            //if (window.sessionStorage.getItem('medicoDto')) {
            //    var medico = JSON.parse(window.sessionStorage.getItem('medicoDto'));
            //    $scope.medicoDto.idMedico = medico.IdMedico
            //    $scope.medicoDto.nome = medico.Nome
            //    $scope.medicoDto.crm = medico.Crm
            //    window.sessionStorage.removeItem('medicoDto');
            //}
        };

        var save = function () {

            var dia = $scope.agendamentoDto.data.getDate();
            if (dia.toString().length == 1)
                dia = "0" + dia;
            var mes = $scope.agendamentoDto.data.getMonth() + 1;
            if (mes.toString().length == 1)
                mes = "0" + mes;
            var ano = $scope.agendamentoDto.data.getFullYear();

            $scope.agendamentoDto.data = dia + "/" + mes + "/" + ano;

            if ($scope.agendamentoDto.idAgendamento > 0) {
                agendaService.alterarMedico($scope.medicoDto)
               .then(function (medico) {
                   $scope.medicoDto = angular.copy(medico.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });

            } else {
                agendaService.registroAgendamento($scope.agendamentoDto)
               .then(function (agendamento) {

                   $scope.agendamentoDto = angular.copy(agendamento.data);
               })
               .catch(function (ex) {
                   var error = ex;
                   $scope.alerts.push({ type: 'danger', msg: ex.data.exceptionMessage });
               });
            }
            $location.path('/balcaoAtendimento');
        };

        var cancelar = function () {
            clean();
            $location.path('/balcaoAtendimento');
        };

        var carregarPaciente = function () {
            agendaService.getAllPacientes()
               .then(function (paciente) {
                   $scope.PacienteDto = angular.copy(paciente.data);
               })
               .catch(function (ex) {
                   $window.alert('Hi!! ' + ex.data.exceptionMessage);
               });
        };


        var carregarMedico = function () {
            agendaService.getAllMedicos()
               .then(function (medico) {
                   $scope.MedicoDto = angular.copy(medico.data);
               })
               .catch(function (ex) {
                   $window.alert('Hi!! ' + ex.data.exceptionMessage);
               });
        };

        //var clean = function () {
        //    $scope.medicoDto.idMedico = undefined;
        //    $scope.medicoDto.nome = undefined;
        //    $scope.medicoDto.crm = undefined;
        //};

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