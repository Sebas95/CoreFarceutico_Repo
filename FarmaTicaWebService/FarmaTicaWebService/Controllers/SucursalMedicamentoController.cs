using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmaTicaWebService.Models;
using FarmaTicaWebService.DataBase;
namespace FarmaTicaWebService.Controllers
{
    public class SucursalMedicamentoController : ApiController
    {
        public MedicamentosAccess databaseAccess = new MedicamentosAccess();

        public List<SucursalPorMedicamento> Get(string id)
        {
            return databaseAccess.getSucursales(id);
        }
   /*     public SucursalPorMedicamento Post (string id, SucursalPorMedicamento sucursal_por_medicamento)
        {
            return databaseAccess.addSucursalPorMedicamento();


        }*/
        //
        public void deleteRemoveSucursalFromMedicamento(string codigoMedicamento, string NoSucursal)
        {
           

        }

    }
}
