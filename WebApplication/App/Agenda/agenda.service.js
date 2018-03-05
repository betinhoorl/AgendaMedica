(function () {
    "user strict";

    var service = angular.module('app');
    service.factory('agendaService', function ($http) {
        var constantRoute = 'http://localhost:51530/';

        /* Buscar*/
        var _getAllMedicos = function () {
            return $http.get(constantRoute + 'medico/GetAllMedicos')
        };

        /*Inserir*/
        var _registroMedico = function (medico) {
            return $http.post(constantRoute + 'medico/RegistroNovoMedico', medico);
        };

        /*Alterar*/
        var _alterarMedico = function (medico) {
            return $http.put(constantRoute + 'medico/AlterarMedico', medico);
        };


        /* Buscar*/
        var _getAllPacientes = function () {
            return $http.get(constantRoute + 'paciente/GetAllPacientes')
        };

        /*Inserir*/
        var _registroPaciente = function (paciente) {
            return $http.post(constantRoute + 'paciente/RegistroNovoPaciente', paciente);
        };

        /*Alterar*/
        var _alterarPaciente = function (paciente) {
            return $http.put(constantRoute + 'paciente/AlterarPaciente', paciente);
        };


        /* Buscar*/
        var _getAllAgendamentos = function () {
            return $http.get(constantRoute + 'agendamento/GetAllAgendamentos')
        };

        /*Inserir*/
        var _registroAgendamento = function (agendamento) {
            return $http.post(constantRoute + 'agendamento/RegistroNovoAgendamento', agendamento);
        };

        /*Alterar*/
        var _alterarAgendamento = function (agendamento) {
            return $http.put(constantRoute + 'agendamento/AlterarAgendamento', agendamento);
        };

        return {
            getAllMedicos: _getAllMedicos,
            registroMedico: _registroMedico,
            alterarMedico: _alterarMedico,
            getAllPacientes: _getAllPacientes,
            registroPaciente: _registroPaciente,
            alterarPaciente: _alterarPaciente,
            getAllAgendamentos: _getAllAgendamentos,
            registroAgendamento: _registroAgendamento,
            alterarAgendamento: _alterarAgendamento
        }
    });
})();
