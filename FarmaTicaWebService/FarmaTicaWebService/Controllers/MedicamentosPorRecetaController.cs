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

        public void Delete(MedicamentoPorReceta medicamento_por_receta)
        {
            databaseAccess.DeleteMedicamento_por_receta(medicamento_por_receta);
        }
    }
}

