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
    public class MedicamentoController : ApiController
    {
        /// <summary>
        /// An object that has access to the Medicmento Table by Sql connection
        /// </summary>
        private MedicamentosAccess databaseAccess = new MedicamentosAccess();


        /// <summary>
        /// Gets all the medicaments of the Table Medicamento
        /// </summary>
        /// <returns> List<Medicamento> </returns>
        public List<Medicamento> Get()
        {
            return databaseAccess.getAllMedicamentos();
        }
        /// <summary>
        /// Gets an specific Medicamento object identified by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Medicamento </returns>
        public Medicamento Get(string id)
        {
            return databaseAccess.getMedicamento(id);
        }
        [Route("api/Medicamento/{Prescripcion}/{NoSucursal}")]
        public List<Medicamento> Get(string Prescripcion, string NoSucursal)
        {
            return databaseAccess.getAllMedicamentosPorSucursal(Prescripcion, NoSucursal);
        }
        [Route("api/Medicamento/Sucursal/{NoSucursal}")]
        public List<Medicamento> GetPorSucursal( string NoSucursal)
        {
            return databaseAccess.getAllMedicamentosPorSucursal( NoSucursal);
        }
        /// <summary>
        /// Returns all the Medicamentos filtered by the attribute Prescripcion
        /// </summary>
        /// <param name="Prescripcion"></param>
        /// <returns>  List<Medicamento>  </returns>
        [Route("api/Medicamento/Prescripcion/{Prescripcion}")]
        public List<Medicamento> GetMedicamentosPrescripcion(string Prescripcion)
        {
            return databaseAccess.getAllMedicamentos(Prescripcion);
        }
        /// <summary>
        /// Posts a new Medicamento object
        /// </summary>
        /// <param name="medicamento"></param>
        /// <returns>The new  Medicamento </returns>
        public Medicamento Post(Medicamento medicamento)
        {
            return databaseAccess.addMedicamento(medicamento);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicamento"></param>
        /// <returns></returns>
        public Medicamento Put(string id, [FromBody] Medicamento medicamento)
        {
            return databaseAccess.updateMedicamento(id,medicamento);
        }
        /// <summary>
        /// Deletes a Medicamento identified by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            databaseAccess.deleteMedicamento(id);
        }
    }
}
