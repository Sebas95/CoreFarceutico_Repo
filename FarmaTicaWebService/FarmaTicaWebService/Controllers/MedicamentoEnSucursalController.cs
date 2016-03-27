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
        public SucursalPorMedicamento Post (string id, [FromBody]SucursalPorMedicamento sucursal_por_medicamento)
        {
            return databaseAccess.addSucursalPorMedicamento(id,sucursal_por_medicamento);

        }
       /* public void deleteRemoveSucursalFromMedicamento(string id, string id2)
        {
            databaseAccess.deleteRemoveSucursalFromMedicamento(id,id2);
        }*/
        
         public void deleteRemoveSucursalFromMedicamento(string codigoMedicamento, string NoSucursal)
        {
            databaseAccess.deleteRemoveSucursalFromMedicamento(codigoMedicamento,NoSucursal);
        }
        

    }
}
