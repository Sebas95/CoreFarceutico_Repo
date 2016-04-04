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
        /// <summary>
        /// Object that has acces to the MEdicmamentoPorReceta table
        /// </summary>
        private MedicamentoPorRecetaAccess databaseAccess = new MedicamentoPorRecetaAccess();

        /// <summary>
        /// Gets all the rows MedicamentoPorReceta
        /// </summary>
        /// <returns>  List<MedicamentoPorReceta> </returns>
        public List<MedicamentoPorReceta> Get()
        {
            return databaseAccess.getMedicamentosPorReceta();
        }
        /// <summary>
        /// Gets all the objects VistaMedicamentoPorReceta filtered by NoFactura
        /// </summary>
        /// <param name="id"></param>
        /// <returns>  List<VistaMedicamentosPorReceta> </returns>
        public List<VistaMedicamentosPorReceta> Get(string id)
        {
            return databaseAccess.getMedicamentosPorReceta(id);
        }
        /// <summary>
        ///  Post a new row in the table MedicamentoPorReceta
        /// </summary>
        /// <param name="medicamento_por_receta"></param>
        /// <returns></returns>
        public MedicamentoPorReceta PostMedicamentoPorReceta (MedicamentoPorReceta medicamento_por_receta)
        {
            return databaseAccess.addMedicamento_por_receta(medicamento_por_receta);
        }
        /// <summary>
        /// Deletes the relation between Receta and MEdicamento in the table MedicamentosPorReceta
        /// </summary>
        /// <param name="codigoMedicamento"></param>
        /// <param name="NoReceta"></param>
        [Route("api/MedicamentosPorReceta/{codigoMedicamento}/{NoReceta}")]
        public void Delete(string codigoMedicamento , string NoReceta)
        {
            databaseAccess.DeleteMedicamento_por_receta(codigoMedicamento, NoReceta);
        }
    }
}

