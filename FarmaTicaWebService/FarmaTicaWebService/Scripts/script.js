// Code goes here
var app = angular.module('Myapp', ['ngRoute', 'ngResource']);
var URI = 'http://localhost:8080/api/Client';
var typeOfView = '/Items'
var type = "cliente"
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
      .when('/Item/doctores', {
          templateUrl: 'doctoresView.html',
          controller: 'doctorController'
      })
      .when('/Item/doctores/add', {
          templateUrl: 'addDoctor.html',
          controller: 'addDoctorController'
      })
      .when('/Item/doctores/:index', {
          templateUrl: 'addDoctor.html',
          controller: 'editDoctorController'
      })
      .otherwise({
          templateUrl: 'subModuloMantenimiento.html',
          controller: 'menuMantenimientoController'
      })
}]);

app.factory('URIService', function () {
    var svc = {};

    svc.setClients = function () {
        typeOfView = '/Items'
        type = "cliente";
        URI = 'http://localhost:8080/api/Client';
        typeOfView = '/Items'
    }

    svc.setDoctores = function () {
        typeOfView = '/Item/doctores'
        type = "doctor";
        URI = 'http://localhost:8080/api/Doctores';
        typeOfView = '/Item/doctores'
    }

    return svc;

})

app.factory('httpService', function ($resource) {
    alert(URI);
    return $resource(URI, {});
})


app.factory('JsonResource', function ($resource) {
    return $resource('http://localhost:8080/api/Client/:id', {}, {
        query: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        update: { method: 'PUT' },
        delete: { method: 'DELETE' }
    });
});

app.factory('doctorResource', function ($resource) {
    return $resource('http://localhost:8080/api/Doctores/:id', {}, {
        query: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        update: { method: 'PUT' },
        delete: { method: 'DELETE' }
    });
});




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



app.controller('menuMantenimientoController', ["$scope", "$location", "$routeParams", "clientService", "httpService", "URIService",

function ($scope, $location, $routeParams, clientService, httpService, URIService) {
    $scope.doctores = function () {
        URIService.setDoctores();
        $location.path(typeOfView);
    };
    $scope.clientes = function () {
        URIService.setClients();
        $location.path(typeOfView);
    };
    $scope.medicamentos = function () {

    };
    $scope.pedidos = function () {

    };

}]);


app.controller("clientController", ["$scope", "$location", "$routeParams", "clientService", "httpService", "JsonResource", "doctorResource",

function ($scope, $location, $routeParams, clientService, httpService, JsonResource, doctorResource) {


    //$scope.data = [];
    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();    
    $scope.data = JsonResource.query();
    //$scope.data = httpService.query();
    //alert(URI);
    $scope.addClient = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.editClient = function (index) {
        $location.path(typeOfView + "/" + index);
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.data = JsonResource.query();
        //$location.path(typeOfView + "/" +index);
    }

    $scope.back = function () {
        $location.path("regrese");
    }

}]);


app.controller("doctorController", ["$scope", "$location", "$routeParams", "clientService", "httpService", "JsonResource", "doctorResource",

function ($scope, $location, $routeParams, clientService, httpService, JsonResource, doctorResource) {


    //$scope.data = [];
    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();    
    $scope.data = doctorResource.query();
    //$scope.data = httpService.query();
    //alert(URI);
    $scope.addClient = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.editDoctor = function (index) {
        $location.path(typeOfView + "/" + index);
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.data = doctorResource.query();
        //$location.path(typeOfView + "/" +index);
    }

    $scope.back = function () {
        $location.path("regrese");
    }

}]);

app.controller("editDoctorController", ["$scope", "$location", "$routeParams", "clientService", "doctorResource",


function ($scope, $location, $routeParams, clientService, doctorResource) {
    $scope.Item = clientService.getClients()[parseInt($routeParams.index)];    
    doctorResource.query().$promise.then(function (data) {        
        $scope.Item = data[parseInt($routeParams.index)];        
        //$scope.isArray = data instanceof Array;
    });
    /*$scope.save = function () {
        clientService.editClient(parseInt($routeParams.index), {
            name: $scope.Item.name, apellido: $scope.Item.apellido,
            cedula: $scope.Item.cedula, fechaNacimiento: $scope.Item.fechaNacimiento,
            residencia: $scope.Item.residencia
        });
        $location.path("/Items");
    }*/



    $scope.save = function () {
        $scope.newClientUpdated = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            FechaNacimiento: $scope.Item.FechaNacimiento, Residencia: $scope.Item.Residencia
        };
        /*   $scope.newClientUpdated = {
               Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
               Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
               Residencia: $scope.Item.Residencia
           };*/
        doctorResource.update({ id: $scope.Item.NoDoctor }, $scope.newClientUpdated);
        $location.path(typeOfView);
        //Notes.update({ id: $id }, note);
    }

    $scope.cancel = function () {
        $location.path(typeOfView);
    }

    $scope.delete = function () {
        doctorResource.delete({ id: $scope.Item.NoDoctor });
        $location.path(typeOfView);
    }

}]);



app.controller("editController", ["$scope", "$location", "$routeParams", "clientService", "JsonResource",


function ($scope, $location, $routeParams, clientService, JsonResource) {
    $scope.Item = clientService.getClients()[parseInt($routeParams.index)];

    JsonResource.query().$promise.then(function (data) {
        $scope.Item = data[parseInt($routeParams.index)];
        //$scope.isArray = data instanceof Array;
    });
    /*$scope.save = function () {
        clientService.editClient(parseInt($routeParams.index), {
            name: $scope.Item.name, apellido: $scope.Item.apellido,
            cedula: $scope.Item.cedula, fechaNacimiento: $scope.Item.fechaNacimiento,
            residencia: $scope.Item.residencia
        });
        $location.path("/Items");
    }*/



    $scope.save = function () {
        $scope.newClientUpdated = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        };
        /*   $scope.newClientUpdated = {
               Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
               Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
               Residencia: $scope.Item.Residencia
           };*/
        JsonResource.update({ id: $scope.Item.IdCliente }, $scope.newClientUpdated);
        $location.path(typeOfView);
        //Notes.update({ id: $id }, note);
    }

    $scope.cancel = function () {
        $location.path(typeOfView);
    }

    $scope.delete = function () {
        JsonResource.delete({ id: $scope.Item.IdCliente });
        $location.path(typeOfView);
    }

}]);

app.controller("addController", ["$scope", "$http", "$location", "$routeParams", "clientService", "httpService", "JsonResource",


function ($scope, $http, $location, $routeParams, clientService, httpService, JsonResource) {

    $scope.typeOfHuman = "Clientes";
    $scope.save = function () {
        clientService.addClient({
            Nombre: $scope.Item.Nombre, Apellido: $scope.Item.apellido,
            Cedula: $scope.Item.cedula, Prioridad: $scope.prioridad, FechaNacimiento: $scope.Item.fechaNacimiento,
            Residencia: $scope.Item.residencia
        });
        $scope.newClient = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        }
        clientService.getData();
        var postVar = new httpService();
        JsonResource.save($scope.newClient, function () { alert("entro a save"); });
        $scope.DataList = JsonResource.query();
        $scope.dato = vm.mydata;
        $location.path(typeOfView);
    }

    $scope.cancel = function () {
        $location.path(typeOfView);
    }

}]);

app.controller("addDoctorController", ["$scope", "$http", "$location", "$routeParams", "clientService", "httpService", "doctorResource",


function ($scope, $http, $location, $routeParams, clientService, httpService, doctorResource) {

    $scope.typeOfHuman = "Clientes";
    $scope.save = function () {
        clientService.addClient({
            Nombre: $scope.Item.Nombre, Apellido: $scope.Item.apellido,
            Cedula: $scope.Item.cedula, FechaNacimiento: $scope.Item.fechaNacimiento,
            Residencia: $scope.Item.residencia
        });
        $scope.newClient = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        }
        clientService.getData();
        var postVar = new httpService();
        doctorResource.save($scope.newClient, function () { alert("entro a save"); });
        $scope.DataList = doctorResource.query();
        $scope.dato = vm.mydata;
        $location.path(typeOfView);
    }

    $scope.cancel = function () {
        $location.path(typeOfView);
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

