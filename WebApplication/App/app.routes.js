/// <reference path="ControleAcesso/Autenticacao/login.html" />
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
        .when("/usuario", {
            templateUrl: 'App/ControleAcesso/Usuario/usuario.html',
            controller: 'usuario'
        })

        // caso não seja nenhum desses, redirecione para a rota '/'
        .otherwise({ redirectTo: '/login' });
    });

})();