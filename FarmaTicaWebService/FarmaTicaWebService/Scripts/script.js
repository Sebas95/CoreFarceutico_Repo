// Code goes here
var app = angular.module('Myapp', ['ngRoute', 'ngResource']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/Items', {
        templateUrl: 'clientsView.html',
        controller: 'clientController'
    })
      .when('/Items/add', {
          templateUrl: 'addClient.html',
          controller: 'addController'
      })
      .when('/Items/:index', {
          templateUrl: 'addClient.html',
          controller: 'editController'
      })
      .otherwise({
          redirectTo: "/Items"
      })
}]);

app.factory('httpService', function ($resource) {
    return $resource('http://localhost:8080/api/Client', {});
})

app.factory("clientService", ["$rootScope", "$http", function ($rootScope, $http) {
    var svc = {};
    var URI = 'http://localhost:8080/api/Client';
    vm = this;
    vm.mydata = [];

    var data = [
          { name: "Giovanni", apellido: "Villalobos", cedula: "68+1", fechaNacimiento: "66-77-3455", residencia: "en esta" },
          { name: "Marco", apellido: "Biyyalovos", cedula: "69", fechaNacimiento: "12-99-8888", residencia: "en aquella" },
          { name: "Jose", apellido: "Villalibis", cedula: "70-1", fechaNacimiento: "26-123-3123", residencia: "en la que sigue" },
    ];

    svc.getClients = function () {
        return data;
    };

    svc.addClient = function (artist) {
        data.push(artist);
    };


    svc.editClient = function (index, artist) {
        data[index] = artist;
    };


    svc.getData = function () {
        $http.get(URI)
            .then(function (result) {
                vm.mydata = result.data;
                alert(vm.mydata)
            });
        return vm.mydata;
    }

    svc.getDataList = function () {
        return vm.mydata;
    }

    return svc;
}]);


app.controller("clientController", ["$scope", "$location", "$routeParams", "clientService", "httpService",

function ($scope, $location, $routeParams, clientService, httpService) {


    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();
    $scope.data = httpService.query();

    $scope.addClient = function () {
        $location.path("/Items/add");
    }

    $scope.editClient = function (index) {
        $location.path("/Items/" + index);
    }

}]);

app.controller("editController", ["$scope", "$location", "$routeParams", "clientService",


function ($scope, $location, $routeParams, clientService) {
    $scope.Item = clientService.getClients()[parseInt($routeParams.index)];

    $scope.save = function () {
        clientService.editClient(parseInt($routeParams.index), {
            name: $scope.Item.name, apellido: $scope.Item.apellido,
            cedula: $scope.Item.cedula, fechaNacimiento: $scope.Item.fechaNacimiento,
            residencia: $scope.Item.residencia
        });
        $location.path("/Items");
    }

    $scope.cancel = function () {
        $location.path("/Items");
    }

}]);

app.controller("addController", ["$scope", "$http", "$location", "$routeParams", "clientService", "httpService",


function ($scope, $http, $location, $routeParams, clientService, httpService) {


    $scope.save = function () {
        clientService.addClient({
            name: $scope.Item.name, apellido: $scope.Item.apellido,
            cedula: $scope.Item.cedula, fechaNacimiento: $scope.Item.fechaNacimiento,
            residencia: $scope.Item.residencia
        });
        clientService.getData();

        $scope.DataList = httpService.query();
        //$scope.DataList = [{ name: "asdasd", apellido: "asdasdasdf" }];
        //$scope.DataList = vm.mydata;
        $scope.dato = vm.mydata;
        // alert($scope.DataList[0]);
        // $location.path("/Items");
    }

    $scope.cancel = function () {
        $location.path("/Items");
    }

}]);
/*
var URI = 'https://api.github.com/users';
//https://api.github.com/users/rtucker88/repos
//https://api.mongolab.com/api/1/databases/lagrossetete/collections/avengers?apiKey=j0PIJH2HbfakfRo1ELKkX0ShST6_F78A
//http://www.bogotobogo.com/AngularJS/files/httpRequest/planet2.json
app.controller('MyController', function($scope, $http) {
  var vm = this;
  vm.mydata = [];

        $http.get(URI)
            .then(function(result) {
              vm.mydata = result.data;
              alert(result.data)
             });
});*/

