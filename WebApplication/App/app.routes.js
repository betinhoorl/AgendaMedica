/// <reference path="Agenda/Atendimento/agendamento.html" />
(function () {

    'use strict';

    var app = angular.module('app');

    app.config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(false);
        $locationProvider.hashPrefix('');

        $routeProvider

        .when("/home", {
            templateUrl: "index.html",
            controller: "index",
        })
        .when("/login", {
            templateUrl: 'App/ControleAcesso/Autenticacao/login.html',
            controller: 'login'
        })
        .when("/novoUsuario", {
            templateUrl: 'App/ControleAcesso/Usuario/novoUsuario.html',
            controller: 'novoUsuario'
        })
        .when("/balcaoAtendimento", {
            templateUrl: 'App/Agenda/Atendimento/balcaoAtendimento.html',
            controller: 'balcaoAtendimento'
        })
        .when("/medicoBusca", {
            templateUrl: 'App/Agenda/Cadastro/medicoBusca.html',
            controller: 'medicoBusca'
        })
        .when("/medico", {
            templateUrl: 'App/Agenda/Cadastro/medico.html',
            controller: 'medico'
        })
        .when("/pacienteBusca", {
            templateUrl: 'App/Agenda/Cadastro/pacienteBusca.html',
            controller: 'pacienteBusca'
        })
        .when("/paciente", {
            templateUrl: 'App/Agenda/Cadastro/paciente.html',
            controller: 'paciente'
        })
        .when("/agendamento", {
            templateUrl: 'App/Agenda/Atendimento/agendamento.html',
            controller: 'agendamento'
        })

        .otherwise({ redirectTo: '/login' });
    });

})();