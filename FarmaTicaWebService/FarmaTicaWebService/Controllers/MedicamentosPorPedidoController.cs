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
    public class MedicamentosPorPedidoController : ApiController
    {
        /// <summary>
        /// Object that has acces to the MEdicmamentoPorPedido table
        /// </summary>
        private MedicamentosPorPedidoAccess databaseAccess = new MedicamentosPorPedidoAccess();
        /// <summary>
        /// Gets all the rows MedicamentoPorPedido
        /// </summary>
        /// <returns>  List<MedicamentoPorPedido> </returns>
        public List<MedicamentoPorPedido> Get()
        {
            return databaseAccess.getMedicamentosPorPedido();
        }
        /// <summary>
        /// Gets all the objects VistaMedicamentoPorPedido filtered by NoFactura
        /// </summary>
        /// <param name="NoFactura"></param>
        /// <returns>  List<VistaMedicamentosPorPedido> </returns>
        [Route("api/MedicamentosPorPedido/{NoFactura}")]
        public List<VistaMedicamentosPorPedido> Get(string NoFactura)
        {
            return databaseAccess.getMedicamentosPorPedido(NoFactura);
        }
        /// <summary>
        /// Post a new row in the table MedicamentoPorPedido
        /// </summary>
        /// <param name="medicamento_por_pedido"></param>
        /// <returns> The new  MedicamentoPorPedido  </returns>
        public MedicamentoPorPedido Post(MedicamentoPorPedido medicamento_por_pedido)
        {
            return databaseAccess.addMedicamento_por_pedido(medicamento_por_pedido);
        }
        /// <summary>
        /// Deletes the relation of Pedido and MEdicamento in the table MedicamentosPorPedido
        /// </summary>
        /// <param name="NoFactura"></param>
        /// <param name="CodigoMedicamento"></param>
        [Route("api/MedicamentosPorPedido/{NoFactura}/{CodigoMedicamento}")]
        public void Delete(string NoFactura, string CodigoMedicamento)
        {
            databaseAccess.Delete_Medicamento_por_pedido( NoFactura, CodigoMedicamento);
        }

      
    }
}
