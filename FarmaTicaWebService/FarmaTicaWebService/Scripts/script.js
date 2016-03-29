// Code goes here
var app = angular.module('Myapp', ['ngRoute', 'ngResource']);
var URI = 'http://localhost:8080/api/Client';
var typeOfView = '/Items'
var type = "cliente"
var clientesParaReceta = [];
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/Items', {
        templateUrl: 'clientsView.html',
        controller: 'clientController'
    })
      .when('/Items/add', {
          templateUrl: 'editClient.html',
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
      .when('/Item/recetas/:index', {
          templateUrl: 'editRecetas.html',
          controller: 'editrecetasController'
      })
      .when('/Item/recetas', {
          templateUrl: 'startRecetas.html',
          controller: 'recetasController'
      })
      .when('/Item/pedidos', {
          templateUrl: 'startPedidos.html',
          controller: 'starPedidosController'
      })
      .when('/Item/medica', {
          templateUrl: 'medicamentoView.html',
          controller: 'medicaController'
      })
      .when('/Item/medica/add', {
          templateUrl: 'addMedicamento.html',
          controller: 'addMedicaController'
      })
      .when('/Items/medica/:index', {
          templateUrl: 'addMedicamento.html',
          controller: 'editMedicaController'
      })
      .when('/Item/pedidos/:index', {
          templateUrl: 'Pedido.html',
          controller: 'pedidoController'
      })
      .when('/Item/depend', {
          templateUrl: 'subModuloMantenimiento.html',
          controller: 'menuMantenimientoController'
      })
      .otherwise({
          templateUrl: 'login.html',
          controller: 'loginController'
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
    svc.setRecetas = function () {
        typeOfView = '/Item/recetas'
        type = "receta";
        URI = 'http://localhost:8080/api/Recetas';
        typeOfView = '/Item/recetas'
    }

    svc.setMed = function () {
        typeOfView = '/Item/medica'
        type = "medica";
        URI = 'http://localhost:8080/api/Medicamento';
        typeOfView = '/Item/medica'
    }

    return svc;

})


app.factory('httpService', function ($resource) {
    //alert(URI);
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

app.factory('telefonosResource', function ($resource) {
    return $resource('http://localhost:8080/api/TelefonosClientes/:id', {}, {
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

app.factory('pedidosResource', function ($resource) {
    return $resource('http://localhost:8080/api/Pedido/:id', {}, {
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

app.factory('recetasResource', function ($resource) {
    return $resource('http://localhost:8080/api/Recetas/:id', {}, {
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

app.factory('casasResource', function ($resource) {
    return $resource('http://localhost:8080/api/Recetas/:id', {}, {
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


app.factory('medResource', function ($resource) {
    return $resource('http://localhost:8080/api/Medicamento/:id', {}, {
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


app.factory('sucursalResource', function ($resource) {
    return $resource('http://localhost:8080/api/Sucursal/:id', {}, {
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
                //alert(vm.mydata)
            });
        return vm.mydata;
    }

    svc.getDataList = function () {
        return vm.mydata;
    }

    return svc;
}]);

app.factory('enviarResource', function ($resource) {
    return $resource('http://localhost:8080/api/Medicamento/:id', {}, {
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


app.factory('loginResource', function ($resource) {
    return $resource('http://localhost:8080/api/Medicamento/:id', {}, {
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
        URIService.setMed();
        $location.path(typeOfView);

    };
    $scope.recetas = function () {
        //alert("eentroaqui");
        URIService.setRecetas();
        $location.path(typeOfView);
    };
    $scope.pedido = function () {
        //alert("eentroaqui");
        URIService.setRecetas();
        $location.path("/Item/pedidos/:index");
    };

}]);

app.controller("loginController", ["$scope", "$location", "$routeParams", "pedidosResource",

function ($scope, $location, $routeParams, pedidosResource) {


    $scope.cliente = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.empleado = function (index) {
        $location.path('/Item/depend');
    }

}]);



app.controller("startPedidosController", ["$scope", "$location", "$routeParams", "pedidosResource",

function ($scope, $location, $routeParams, pedidosResource) {


    //$scope.data = [];
    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();    
    $scope.Item = pedidosResource.query();
    //$scope.data = httpService.query();
    //alert(URI);
    $scope.addPedido = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.editPedido = function (index) {
        $location.path(typeOfView + "/" + index);
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.Item = pedidosResource.query();
        //$location.path(typeOfView + "/" +index);
    }

    $scope.back = function () {
        $location.path("regrese");
    }

}]);


app.controller("recetasController", ["$scope", "$location", "$routeParams", "clientService", "httpService", "JsonResource", "doctorResource", "recetasResource",

function ($scope, $location, $routeParams, clientService, httpService, JsonResource, doctorResource, recetasResource) {


    //$scope.data = [];
    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();    
    $scope.data = recetasResource.query();
    //$scope.data = httpService.query();
    //alert(URI);
    $scope.addClient = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.editReceta = function (index) {
        $location.path(typeOfView + "/" + index);
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.data = recetasResource.query();
        //$location.path(typeOfView + "/" +index);
    }

    $scope.back = function () {
        $location.path("regrese");
    }

}]);


app.controller("editRecetasController", ["$scope", "$location", "$routeParams", "clientService", "JsonResource", "recetasResource",


function ($scope, $location, $routeParams, clientService, JsonResource, recetasResource) {
    // $scope.Item = clientService.getClients()[parseInt($routeParams.index)];
    $scope.telefonos = {};
    recetasResource.query().$promise.then(function (data) {
        $scope.Item = data[parseInt($routeParams.index)];

        /*JsonResource.query().$promise.then(function (data) {
            $scope.list = data[parseInt($scope.ItemRecetas.IdCliente)];*/
        //$scope.telefonos = telefonosResource.query({ id: $scope.Item.IdCliente });
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

    $scope.addPhone = function () {
        alert($scope.Item.IdCliente);
        $scope.newPhone = {
            idCliente: $scope.Item.IdCliente, Telefono: $scope.newPhoneC, descripcion: $scope.descrp
        };
        telefonosResource.save($scope.newPhone);
        $location.path(typeOfView);
    }

    $scope.save = function () {
        $scope.newClientUpdated = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        };
        $scope.newTelefonoUpdated = {
            idCliente: $scope.Item.Cedula, Telefono: selectedCar, descripcion: telefono.descripción
        };
        /*   $scope.newClientUpdated = {
               Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
               Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
               Residencia: $scope.Item.Residencia
           };*/
        JsonResource.update({ id: $scope.Item.IdCliente }, $scope.newClientUpdated);
        $location.path(typeOfView);
        telefonosResource.save($scope.newTelefonoUpdated);
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


app.controller("addMedicaController", ["$scope", "$http", "$location", "$routeParams", "clientService", "httpService", "sucursalResource", "medResource",


function ($scope, $http, $location, $routeParams, clientService, httpService, sucursalResource, medResource) {
    $scope.data = sucursalResource.query();
    $scope.typeOfHuman = "Clientes";
    $scope.save = function () {
        /*alert($scope.Item.Nombre);
        alert($scope.Item.codigo);
        alert($scope.Item.Prescripcion);
        alert($scope.Item.CasaFarmaceutica);
        alert($scope.Item.Costo);*/
        $scope.newMed = {
            Nombre: $scope.Item.Nombre, codigo: $scope.Item.codigo, Prescripcion: $scope.Item.Prescripcion,
            CasaFarmaceutica: $scope.Item.CasaFarmaceutica, Costo: $scope.Item.Costo
        };
        alert(angular.toJson($scope.newMed));
        //clientService.getData();
        // var postVar = new httpService();
        medResource.save($scope.newMed, function () { alert("entro a save"); });
        //$scope.DataList = medicaResource.query();
        $scope.dato = vm.mydata;
        $location.path(typeOfView);
    }

    $scope.cancel = function () {
        $location.path(typeOfView);
    }

}]);



app.controller("medicaController", ["$scope", "$location", "$routeParams", "clientService", "httpService", "JsonResource", "medResource",

function ($scope, $location, $routeParams, clientService, httpService, JsonResource, medResource) {


    //$scope.data = [];
    // $scope.ldata  = clientService.getData();
    //alert(clientService.getData());
    //$scope.data = clientService.getClients();        
    $scope.data = medResource.query();
    //$scope.data = httpService.query();
    //alert(URI);
    //alert(typeOfView);
    $scope.addClient = function () {
        $location.path(typeOfView + "/add");
    }

    $scope.editClient = function (index) {
        $location.path('/Items/medica/' + index);
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.data = medResource.query();
        //$location.path(typeOfView + "/" +index);
    }

    $scope.back = function () {
        $location.path("regrese");
    }

}]);


app.controller("editMedicaController", ["$scope", "$location", "$routeParams", "clientService", "doctorResource", "medResource",


function ($scope, $location, $routeParams, clientService, doctorResource, medResource) {
    $scope.Item = clientService.getClients()[parseInt($routeParams.index)];
    medResource.query().$promise.then(function (data) {
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

        alert("entro save");

        $scope.newClientUpdated = {
            Nombre: $scope.Item.Nombre, codigo: $scope.Item.codigo, Prescripcion: $scope.Item.Prescripcion,
            CasaFarmaceutica: $scope.Item.CasaFarmaceutica, Costo: $scope.Item.Costo
        };
        alert(angular.toJson($scope.newClientUpdated));
        medResource.update({ id: $scope.Item.codigo }, $scope.newClientUpdated);
        alert("salió save");
        $location.path(typeOfView);
        //Notes.update({ id: $id }, note);
    }



    $scope.cancel = function () {
        $location.path(typeOfView);
    }

    $scope.delete = function () {
        medResource.delete({ id: $scope.Item.codigo });
        $location.path(typeOfView);
    }

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

app.controller("editDoctorController", ["$scope", "$location", "$routeParams", "clientService", "doctorResource", "telefonosResource",


function ($scope, $location, $routeParams, clientService, doctorResource, telefonosResource) {
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



app.controller("editController", ["$scope", "$location", "$routeParams", "clientService", "JsonResource", "telefonosResource",


function ($scope, $location, $routeParams, clientService, JsonResource, telefonosResource) {
    $scope.Item = clientService.getClients()[parseInt($routeParams.index)];
    $scope.telefonos = {};
    JsonResource.query().$promise.then(function (data) {
        $scope.Item = data[parseInt($routeParams.index)];
        $scope.telefonos = telefonosResource.query({ id: $scope.Item.IdCliente });
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

    $scope.addPhone = function () {
        //alert($scope.Item.IdCliente);
        $scope.newPhone = {
            idCliente: $scope.Item.IdCliente, Telefono: $scope.newPhoneC, descripcion: $scope.descrp
        };
        telefonosResource.save($scope.newPhone);
        $location.path(typeOfView);
    }

    $scope.save = function () {
        $scope.newClientUpdated = {
            Cedula: $scope.Item.Cedula, Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        };
        $scope.newTelefonoUpdated = {
            idCliente: $scope.Item.Cedula, Telefono: selectedCar, descripcion: telefono.descripción
        };
        /*   $scope.newClientUpdated = {
               Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
               Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
               Residencia: $scope.Item.Residencia
           };*/
        JsonResource.update({ id: $scope.Item.IdCliente }, $scope.newClientUpdated);
        $location.path(typeOfView);
        telefonosResource.save($scope.newTelefonoUpdated);
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

app.controller("addController", ["$scope", "$http", "$location", "$routeParams", "clientService", "httpService", "JsonResource", "telefonosResource",


function ($scope, $http, $location, $routeParams, clientService, httpService, JsonResource, telefonosResource) {

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


app.factory('pedidoResource', function ($resource) {
    return $resource('http://localhost:8080/api/VistaPedidos/:id', {}, {
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



app.controller("pedidoController", ["$scope", "$location", "$routeParams", "pedidoResource",
function ($scope, $location, $routeParams, pedidoResource) {
    $scope.data = pedidoResource.query();
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

