// Code goes here

/*var app = angular
        .module("myModule", ['ngResource'])
        .controller("myController", function ($scope,$resource) {
           $scope.list = [];
           //var Resultado = $resource('https://httpbin.org/get',{},{get:{method:'GET'}});
           var Resultado = $resource('https://httpbin.org/get',{}).query();
           $scope.hello = "asdasdf";
           alert(Resultado.data);
           $scope.list = Resultado; 
        });*/


var app = angular
        .module("myModule", ['ngResource','ngRoute'])
        .factory('UserService', function ($resource) {
            return $resource('http://localhost:8080/api/Client', {});
        })
        .controller("myController", function ($scope, $resource, UserService) {
            alert("$scope.users");
            $scope.users = UserService.query();
            $scope.hello = "asdasdf";
            alert($scope.users);
        });
