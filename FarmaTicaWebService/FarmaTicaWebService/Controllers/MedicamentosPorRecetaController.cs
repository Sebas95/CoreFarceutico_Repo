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
    public class MedicamentosPorRecetaController : ApiController
    {
        private MedicamentoPorRecetaAccess databaseAccess = new MedicamentoPorRecetaAccess();

        public List<MedicamentoPorReceta> Get()
        {
            return databaseAccess.getMedicamentosPorReceta();
        }
        public List<VistaMedicamentosPorReceta> Get(string id)
        {
            return databaseAccess.getMedicamentosPorReceta(id);
        }
        public MedicamentoPorReceta PostMedicamentoPorReceta (MedicamentoPorReceta medicamento_por_receta)
        {
            return databaseAccess.addMedicamento_por_receta(medicamento_por_receta);
        }

        [Route("api/MedicamentosPorReceta/{codigoMedicamento}/{NoReceta}")]
        public void Delete(string codigoMedicamento , string NoReceta)
        {
            databaseAccess.DeleteMedicamento_por_receta(codigoMedicamento, NoReceta);
        }
    }
}

