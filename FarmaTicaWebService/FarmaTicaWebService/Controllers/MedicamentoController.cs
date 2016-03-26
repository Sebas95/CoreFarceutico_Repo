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

        public List<Medicamento> Get()
        {
            return databaseAccess.getAllMedicamentos();
        }
        public Medicamento Post(Medicamento medicamento)
        {
            return databaseAccess.addMedicamento(medicamento);
        }
        public Medicamento Put(string id, [FromBody] Medicamento medicamento)
        {
            return databaseAccess.updateMedicamento(id,medicamento);
        }
        public void Delete(int id)
        {
            databaseAccess.deleteMedicamento(id);
        }
    }
}
