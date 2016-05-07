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
    public class MedicamentoEnSucursalController : ApiController
    {
        public MedicamentoEnSucursalAccess databaseAccess = new MedicamentoEnSucursalAccess();

        public List<SucursalPorMedicamento> Get(string id)
        {
            return databaseAccess.getSucursalesPorMedicamento(id);
        }
        [Route("api/MedicamentoEnSucursal/{CodigoMedicamento}/{NoSucursal}/{Cantidad}")]
        public void Post(string CodigoMedicamento, string NoSucursal, string Cantidad) 
        {
            databaseAccess.addSucursalPorMedicamento(CodigoMedicamento, NoSucursal, Cantidad);

        }
        /* public void deleteRemoveSucursalFromMedicamento(string id, string id2)
         {
             databaseAccess.deleteRemoveSucursalFromMedicamento(id,id2);
         }*/
        [Route("api/MedicamentoEnSucursal/{codigoMedicamento}/{NoSucursal}")]
        public void deleteRemoveSucursalFromMedicamento(string codigoMedicamento, string NoSucursal)
        {
            databaseAccess.deleteRemoveSucursalFromMedicamento(codigoMedicamento,NoSucursal);
        }
        [HttpGet]
        [Route("api/MedicamentoPorSucursal")]
        public List<MedicamentoPorSucursal> get()
        {
            return databaseAccess.getMedicamentoPorSucursal();
        }
        

    }
}
