// Code goes here
var app = angular.module('Myapp', ['ngRoute', 'ngResource']);
var URI = 'http://localhost:8080/api/Client';
var typeOfView = '/Items'
var type = "cliente"
var clientesParaReceta = [];
var jsonList = {};
var pedidoActual = {};
var clienteActual = 1;
var listaRecets = [];
var docActual = "Doctores"
var medActual = "Medicamentos"
var sucActual = "Sucursales"
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
          controller: 'editRecetasController'
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
      .when('/Item/pedidos', {
          templateUrl: 'Pedido.html',
          controller: 'pedidoController'
      })
      .when('/Item/depend', {
          templateUrl: 'subModuloMantenimiento.html',
          controller: 'menuMantenimientoController'
      })
      .when('/Item/employee', {
          templateUrl: 'empleadoView.html',
          controller: 'empleadoController'
      })
      .when('/Item/DetallePedido/:index', {
          templateUrl: 'DetallePedidoModSucursal.html',
          controller: 'detallePedidoController'
      })
      .when('/Item/RecMod', {
          templateUrl: 'verRecetasModSuc.html',
          controller: 'verRecModController'
      })
      .when('/Item/addPedidosView', {
          templateUrl: 'addPedido.html',
          controller: 'addPedidoController'
      })
      .when('/Item/addReceta', {
          templateUrl: 'addReceta.html',
          controller: 'addPedidoController'
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

app.factory('editRecetasResource', function ($resource) {
    return $resource('http://localhost:8080/api/MedicamentosPorReceta/:cod/:id', {}, {
        query: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        update: { method: 'PUT' },
        delete: {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' }
        }
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
        $location.path('/Item/addPedidosView');
    }

    $scope.empleado = function (index) {
        $location.path('/Item/employee');
    }

}]);

var listaMedicamentosxPedido = [];
var listaMedicamentosxReceta = [];
var listaMedsActuales = [];
var listaMedsActualesPeds = [];
var listaMedsActualesRecs = [];
var newRecetas = [];

app.controller("addPedidoController", ["$scope", "$location", "$routeParams", "doctorResource", "sucursalResource", "medResource", "pedidoResource", "telefonosResource",
    "JsonResource", "detallePedidoResource", "detalleRecetaResource", "recetasResource", "detalleRecetaResource",

function ($scope, $location, $routeParams, doctorResource, sucursalResource, medResource, pedidoResource, telefonosResource, JsonResource, detallePedidoResource
    , detalleRecetaResource, recetasResource, detalleRecetaResource) {

    //Este es el nuevo---------------------
    //Recordar cambiar clienteActual !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1111
    JsonResource.query().$promise.then(function (data) {
        //$scope.Item = data[parseInt($routeParams.index)];
        $scope.telefonos = telefonosResource.query({ id: clienteActual });
        //$scope.isArray = data instanceof Array;
    });
    $scope.numRec = 3;
    $scope.numRec2 = 4;
    $scope.numFac = 2;
    $scope.Estado = "Nuevo";
    $scope.Empresa = "F";
    $scope.docActual = docActual;
    $scope.medActual = medActual;
    $scope.sucActual = sucActual;
    $scope.cantidad = 1;
    $scope.docList = doctorResource.query();
    $scope.recList = sucursalResource.query();
    $scope.medList = medResource.query();
    $scope.medListPed = listaMedsActualesPeds;
    $scope.medListRec = listaMedsActualesRecs;
    $scope.plantillaPedido = { NoFactura: "", CodigoMedicamento: "", Cantidad: "" };

    $scope.addNoSuc = function (numeroS, nombre) {
        $scope.sucActual = nombre;
        $scope.numSuc = numeroS;
    }
    $scope.addMedPed = function (cant, codMed, nomMed, costo) {
        $scope.medActual = nomMed;
        $scope.newMedxPedido = $scope.plantillaPedido;
        $scope.newMedxPedido.codMed = codMed;
        $scope.newMedxPedido.Cantidad = cant;
        listaMedsActualesPeds.push({ Nombre: nomMed, CodigoMedicamento: codMed, Cantidad: cant, Costo: costo });
        listaMedicamentosxPedido.push({ NoFactura: "", CodigoMedicamento: codMed, Cantidad: cant });
        alert(angular.toJson(listaMedicamentosxPedido));
        //Prueba que sirvio-----------------
        /* $scope.newMedxPedido = $scope.plantillaPedido;
         $scope.newMedxPedido.codMed = codMed;
         $scope.listaMedicamentosxPedido.push($scope.newMedxPedido);
         alert(angular.toJson($scope.listaMedicamentosxPedido));
         $scope.listaMedicamentosxPedido[0].NoFactura = 3;
         alert(angular.toJson($scope.listaMedicamentosxPedido));*/
        //$scope.newMedxPedido = { NoFactura:  , CodigoMedicamento: , Cantidad: }
    };

    $scope.addMedRec = function (cant, codMed, nomMed, costo) {
        $scope.medActual = nomMed;
        listaMedsActualesRecs.push({ Nombre: nomMed, Cantidad: cant, Costo: costo });
        listaMedsActuales.push({ NoFactura: "", CodigoMedicamento: codMed, Cantidad: cant });
        alert("Medicamentos de esta receta: ");
        alert(angular.toJson(listaMedsActuales));
        //Prueba que sirvio-----------------
        /* $scope.newMedxPedido = $scope.plantillaPedido;
         $scope.newMedxPedido.codMed = codMed;
         $scope.listaMedicamentosxPedido.push($scope.newMedxPedido);
         alert(angular.toJson($scope.listaMedicamentosxPedido));
         $scope.listaMedicamentosxPedido[0].NoFactura = 3;
         alert(angular.toJson($scope.listaMedicamentosxPedido));*/

        //$scope.newMedxPedido = { NoFactura:  , CodigoMedicamento: , Cantidad: }
    };

    $scope.addReceta = function () {
        listaMedicamentosxReceta.push(listaMedsActuales);
        alert("Medicamentos de recetas: ");
        alert(angular.toJson(listaMedicamentosxReceta));
        listaMedsActuales = [];
        listaRecets.push({ NoFactura: "", IdCliente: clienteActual, NoDoctor: $scope.numeroDoc });
        alert("Recetas totales:  ");
        alert(angular.toJson(listaRecets));
        $location.path('/Item/addPedidosView');
    }

    $scope.goAddReceta = function (index) {
        $location.path('/Item/addReceta');
    }

    $scope.addDoc = function (numeroDoc) {
        $scope.numeroDoc = numeroDoc;
        //$scope.data = httpService.query();
        //$scope.Item = pedidosResource.query();
        //$location.path(typeOfView + "/" +index);
    }
    $scope.refresh = function () {
        //$scope.data = httpService.query();
        //$scope.Item = pedidosResource.query();
        //$location.path(typeOfView + "/" +index);
    }
    $scope.back = function () {
        $location.path("regrese");
    }

    $scope.backPed = function () {
        $location.path('/Item/addPedidosView');
    }

    $scope.borrarMedPed = function (index) {
        listaMedsActualesPeds.splice(index, 1);
        listaMedicamentosxPedido.splice(index, 1);
        $location.path('/Item/addPedidosView');
    }
    $scope.borrarMedRec = function (index) {
        listaMedsActualesRecs.splice(index, 1);
        listaMedsActuales.splice(index, 1);
        $location.path("/Item/addReceta");
    }

    $scope.addPedido = function (fech, phone) {
        pedidoResource.save({
            FechaRecojo: fech, NoSucursal: $scope.numSuc, IdCliente: clienteActual, Estado: $scope.Estado, Empresa: $scope.Empresa,
            TelefonoPreferido: phone
        }).$promise.then(function (data) {
            $scope.numFac = data.NoFactura;
            // alert($scope.numFac);
        }).then(function () {
            //------------------------Guardar  MEDICAMENTOS por PEDIDO---------------------------------------
            var values = listaMedicamentosxPedido;
            angular.forEach(values, function (value, key) {
                value.NoFactura = $scope.numFac;
                //alert(angular.toJson(value));
                detallePedidoResource.save(value);
            });
        })

        //-----------------------Guardar RECETAS-----------------------------------
        .then(function () {
            values = listaRecets;
            //alert(angular.toJson(values));
            angular.forEach(values, function (value, key) {
                value.NoFactura = $scope.numFac;
                //alert(angular.toJson(value));
                recetasResource.save(value).$promise.then(function (data) {
                    alert("key: " + key);
                    alert("value: " + value);
                    listaRecets[key].NoReceta = data.NoReceta;
                    alert("Recetas: ");
                    alert(angular.toJson(listaRecets));

                }).        //-----------------Guardar MEDICAMENTOS por RECETA-------------------------- aqui quede
                    then(function () {
                        alert("medicamentos")
                        alert(angular.toJson(listaMedicamentosxReceta[key]));
                        medsdeRec = listaMedicamentosxReceta[key];
                        angular.forEach(medsdeRec, function (medicamento, key2) {
                            //medicamento.NoReceta = receta.NoReceta;
                            //alert("ingreso en medicamento x receta:");
                            alert("Insertaria: ")
                            alert(angular.toJson({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: listaRecets[key].NoReceta, Cantidad: medicamento.Cantidad }));
                            detalleRecetaResource.save({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: listaRecets[key].NoReceta, Cantidad: medicamento.Cantidad });
                        });
                        /*
                        alert("Recetas resultante:");
                        alert(angular.toJson(listaRecets));
                       // alert("La lista de recetas es: ");
                        //alert(angular.toJson(listaRecets));
                        listRcts = listaRecets;
                        //alert("va por aqui")
                        angular.forEach(listRcts, function (receta, key1) {
                            //alert("ahora va por aqui")
                            medsdeRec = listaMedicamentosxReceta[key1];
                            angular.forEach(medsdeRec, function (medicamento, key2) {
                                medicamento.NoReceta = receta.NoReceta;
                                //alert("ingreso en medicamento x receta:");
                                //alert(angular.toJson({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: receta.NoReceta, Cantidad: medicamento.Cantidad }));
                                detalleRecetaResource.save({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: receta.NoReceta, Cantidad: medicamento.Cantidad });
                            });
                        });*/
                    });

            });
        })
        //-----------------Guardar MEDICAMENTOS por RECETA--------------------------
        //alert("asdasdasda");
        /*
    .then(function () {
        listRcts = listaRecets;
        angular.forEach(listRcts, function (receta, key1) {
            receta.NoReceta = $scope.numRec;
            medsdeRec = listaMedicamentosxReceta[key1];
            angular.forEach(medsdeRec, function (medicamento, key2) {
                medicamento.NoReceta = receta.numRec;
                alert("ingreso: ");
                alert(angular.toJson({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad }));
                detalleRecetaResource.save({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad });
            });
        });
    })
    .then(function () {
        alert('d');
    });*/

        //-----------------Guardar PEDIDO------------------------------------

        //$scope.pedOutPut = pedidoResource.save($scope.pedidoNuevo);

        //----------------Asignar $scope.numFac------------------------------

        //$scope.numFac = $scope.pedOutPut.NoFactura; 
        //alert(angular.toJson($scope.numFac));
        //alert(angular.toJson($scope.listaMedicamentosxPedido));


        //------------------------Guardar  MEDICAMENTOS por PEDIDO---------------------------------------

        /* var values = $scope.listaMedicamentosxPedido;
         angular.forEach(values, function (value, key) {
             value.NoFactura = $scope.numFac;
             alert(angular.toJson(value));
             detallePedidoResource.save(value);            
         });*/

        //-----------------------Guardar RECETAS-----------------------------------
        /*
        values = listaRecets;
        alert(angular.toJson(values));
        angular.forEach(values, function (value, key) {
            value.NoFactura = $scope.numFac;
            alert(angular.toJson(value));
            recetasResource.save(value);
        
        */
        //-----------------Guardar MEDICAMENTOS por RECETA--------------------------

        /* Prueba que sirvió
        listRcts = listaRecets;
        angular.forEach(listRcts, function (receta, key1) {
            receta.NoReceta = $scope.numRec;
            medsdeRec = listaMedicamentosxReceta[key1];
            angular.forEach(medsdeRec, function (medicamento, key2) {
                medicamento.NoReceta = receta.numRec;
                alert("ingreso: ");
                alert(angular.toJson({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad }));
                detalleRecetaResource.save({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad });
            });
            $scope.numRec = 4;
        */
        /*
        listRcts = listaRecets;
        angular.forEach(listRcts, function (receta, key1) {
            receta.NoReceta = $scope.numRec;
            medsdeRec = listaMedicamentosxReceta[key1];
            angular.forEach(medsdeRec, function (medicamento, key2) {
                alert("ingreso: ");
                alert(angular.toJson({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad }));
                detalleRecetaResource.save({ CodigoMedicamento: medicamento.CodigoMedicamento, NoReceta: $scope.numRec, Cantidad: medicamento.Cantidad });
            });
            $scope.numRec = 4;
        });

        */
        //medicamento.NoReceta = listaRecets[key].NoReceta; //la que debería ser una vez que devuelva el ID
        /*value.NoReceta = $scope.numRec;
        alert(angular.toJson(value));
        listaMedicamentosxReceta[key]
        recetasResource.save(value);*/

        /*
        listaMedicamentosxPedido = [];
        listaMedicamentosxReceta = [];
        listaMedsActualesRecs = [];
        listaMedsActualesPeds = [];
        listaMedsActuales = [];
        listaRecets = [];*/
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
        //alert("pasó1");
        jsonList = $scope.data[index];
        //alert("pasó");
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

    $scope.cancel = function () {
        $location.path('/Item/recetas');
    }

}]);


app.controller("editRecetasController", ["$scope", "$location", "$routeParams", "clientService", "medResource", "editRecetasResource",


function ($scope, $location, $routeParams, clientService, medResource, editRecetasResource) {
    // $scope.Item = clientService.getClients()[parseInt($routeParams.index)];
    //alert(angular.toJson(jsonList.NoReceta));
    //quuiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
    //$scope.isArray = data instanceof Array;
    $scope.cantidad = 1;
    $scope.dato = medResource.query();
    $scope.Item = editRecetasResource.query({ id: jsonList.NoReceta });
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
        $scope.newClientUpdated = {
            Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
            Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
            Residencia: $scope.Item.Residencia
        };
    }
    $scope.cancel = function () {
        $location.path(typeOfView);
    }

    $scope.borrar = function (codigo, cantidad) {
        $scope.medABorrar = { CodigoMedicamento: "D", NoReceta: 3, Cantidad: 8 };
        alert($scope.medABorrar);
        //alert(angular.toJson($scope.medABorrar));
        alert(angular.toJson({ cod: codigo, id: jsonList.NoReceta }));
        editRecetasResource.delete({ cod: codigo, id: jsonList.NoReceta });
        alert("ya sirve");
    }

    $scope.addMed = function (cantidad, codigo) {
        alert(cantidad + codigo);
        $scope.newMed = { CodigoMedicamento: codigo, NoReceta: jsonList.NoReceta, Cantidad: cantidad }
        editRecetasResource.save($scope.newMed);
        alert('Se agrego su medicamento');
        $scope.refresh();
        $location.path('/Item/recetas/1');
        //$scope.Item = editRecetasResource.query({ id: jsonList.NoReceta });
    }

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.Item = editRecetasResource.query({ id: jsonList.NoReceta });
        //$location.path(typeOfView + "/" +index);
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
        /*$scope.newMed = {
            Nombre: $scope.Item.Nombre, codigo: $scope.Item.codigo, Prescripcion: $scope.Item.Prescripcion,
            CasaFarmaceutica: $scope.Item.CasaFarmaceutica, Costo: $scope.Item.Costo
        };*/
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
        $location.path('/Items/add');
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
        editController
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
        /*$scope.newTelefonoUpdated = {
            idCliente: $scope.Item.Cedula, Telefono: $scope.selectedCar, descripcion: telefono.descripción
        };*/
        /*   $scope.newClientUpdated = {
               Cedula: "5555555", Nombre: $scope.Item.Nombre, Apellido: $scope.Item.Apellido,
               Prioridad: $scope.Item.Prioridad, FechaNacimiento: $scope.Item.FechaNacimiento,
               Residencia: $scope.Item.Residencia
           };*/
        alert("entro aquia");
        alert(angular.toJson({ id: $scope.Item.IdCliente }));
        alert(angular.toJson($scope.newClientUpdated));


        JsonResource.update({ id: $scope.Item.IdCliente }, $scope.newClientUpdated);
        $location.path(typeOfView);
        //telefonosResource.save($scope.newTelefonoUpdated);
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



app.controller("pedidoController", ["$scope", "$location", "$routeParams", "pedidoResource",
function ($scope, $location, $routeParams, pedidoResource) {
    $scope.data = pedidoResource.query();
    alert(angular.toJson($scope.data));

    $scope.viewPedido = function (index) {
        pedidoActual = $scope.data[index];
        //alert(angular.toJson(pedidoActual));
        alert(angular.toJson($scope.data[index]));
        $location.path("/Item/DetallePedido/" + $routeParams.index);
    }

}]);


app.factory('detallePedidoResource', function ($resource) {
    return $resource('http://localhost:8080/api/MedicamentosPorPedido/:id', {}, {
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





app.factory('detalleRecetaResource', function ($resource) {
    return $resource('http://localhost:8080/api/MedicamentosPorReceta/:id', {}, {
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

app.factory('pedidoRecetaResource', function ($resource) {
    return $resource('http://localhost:8080/api/RecetasPorPedido/:id', {}, {
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



app.controller("detallePedidoController", ["$scope", "$location", "$routeParams", "detallePedidoResource", "pedidoRecetaResource", "pedidoResource", "recetasResource",
function ($scope, $location, $routeParams, detallePedidoResource, pedidoRecetaResource, pedidoResource, recetasResource) {
    $scope.data = recetasResource.query();
    $scope.state = pedidoActual.Estado;
    alert(angular.toJson(pedidoActual.NoFactura));
    $scope.listaRecetas = pedidoRecetaResource.query({ id: pedidoActual.NoFactura });
    alert(angular.toJson($scope.listaRecetas));
    $scope.data = detallePedidoResource.query({ id: pedidoActual.NoFactura });

    $scope.changeState = function (newState) {
        //OJO CON EL PEDIDO ACTUAL PORQUE  CAMBIARIA HAY QUE ASIGNARLO BIEN !!!!!!!!!!!!!!!
        $scope.pedidoUpdated = {
            NoFactura: pedidoActual.NoFactura, FechaRecojo: pedidoActual.FechaRecojo, NoSucursal: pedidoActual.NoSucursal, IdCliente: pedidoActual.IdCliente,
            Estado: newState, Empresa: pedidoActual.Empresa, TelefonoPreferido: pedidoActual.TelefonoPreferido
        }
        alert("Viejo Pedido");
        alert(angular.toJson(pedidoActual));
        //alert(angular.toJson($scope.pedidoUpdated.FechaRecojo));
        $scope.nuevaFactura = pedidoActual.NoFactura;
        alert($scope.pedidoActual);
        pedidoResource.update({ id: pedidoActual.NoFactura }, $scope.pedidoUpdated);
    }
    $scope.verMedRec = function (index) {
        //alert("pasó1");                
        jsonList = $scope.data;
        //alert("pasó");
        $location.path("/Item/RecMod");
    };

}

]);


app.controller("verRecModController", ["$scope", "$location", "$routeParams", "clientService", "editRecetasResource", "editRecetasResource", "recetasResource",


function ($scope, $location, $routeParams, clientService, editRecetasResource, editRecetasResource, recetasResource) {
    // $scope.Item = clientService.getClients()[parseInt($routeParams.index)];
    //alert(angular.toJson(jsonList.NoReceta));
    //quuiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
    //$scope.isArray = data instanceof Array;    
    $scope.Item = jsonList;
    //alert(angular.toJson($scope.Item));

    $scope.refresh = function () {
        //$scope.data = httpService.query();
        $scope.Item = editRecetasResource.query({ id: jsonList.NoReceta });
        //$location.path(typeOfView + "/" +index);
    }
}]);


app.controller("empleadoController", ["$scope", "$location", "$routeParams", "detallePedidoResource", "pedidoRecetaResource", "pedidoResource",
function ($scope, $location, $routeParams, detallePedidoResource, pedidoRecetaResource, pedidoResource) {
    $scope.state = pedidoActual.Estado;
    $scope.listaRecetas = pedidoRecetaResource.query({ id: pedidoActual.NoFactura });
    $scope.data = detallePedidoResource.query({ id: pedidoActual.NoFactura });

    $scope.sucursal = function () {
        $location.path('/Item/pedidos');
    }
    $scope.mantenimiento = function () {
        $location.path('/Item/depend');
    }
}

]);


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
