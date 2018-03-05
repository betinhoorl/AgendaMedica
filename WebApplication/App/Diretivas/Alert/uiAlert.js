(function () {

    'use strict';

    var app = angular.module('app');
    app.directive('uiAlert', function () {
        return {
            templateUrl: 'App/Diretivas/Alert/uiAlert.html',
            restrict: 'AE',
            scope: {
                message: "@",
                type: "@"
            },
            controller: function ($scope, $element, $attrs) {
                var teste = $scope.type;

                $scope.$watch('type', function (newValue) {

                    if (newValue === 'error') {
                        $scope.title = 'Ops!';
                        $scope.color = '#F2DEDE';
                        $scope.textColor = '#AF4341';
                    }

                    if (newValue === 'success') {
                        $scope.title = 'OK';
                        $scope.color = '#a5d6a7';
                        $scope.textColor = '#1b5e20';
                    }
                });
            },

        };
    });

})();