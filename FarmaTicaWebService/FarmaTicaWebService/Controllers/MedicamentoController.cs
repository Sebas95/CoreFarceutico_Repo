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
        public MedicamentosAccess databaseAccess = new MedicamentosAccess();

        /** Retorna toda la lista de medicamentos
        */
        public List<Medicamento> Get()
        {
            return databaseAccess.getAllMedicamentos();
        }
        public Medicamento Get(string id)
        {
            return databaseAccess.getMedicamento(id);
        }
        [Route("api/Medicamento/Prescripcion/{Prescripcion}")]
        public List<Medicamento> GetMedicamentosPrescripcion(string Prescripcion)
        {
            return databaseAccess.getAllMedicamentos(Prescripcion);
        }
        public Medicamento Post(Medicamento medicamento)
        {
            return databaseAccess.addMedicamento(medicamento);
        }
        public Medicamento Put(string id, [FromBody] Medicamento medicamento)
        {
            return databaseAccess.updateMedicamento(id,medicamento);
        }
        public void Delete(string id)
        {
            databaseAccess.deleteMedicamento(id);
        }
    }
}
