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
        public MedicamentosPorPedidoAccess databaseAccess = new MedicamentosPorPedidoAccess();

        public List<MedicamentoPorPedido> Get()
        {
            return databaseAccess.getMedicamentosPorPedido();
        }
        [Route("api/MedicamentosPorPedido/{NoFactura}")]
        public List<VistaMedicamentosPorPedido> Get(string NoFactura)
        {
            return databaseAccess.getMedicamentosPorPedido(NoFactura);
        }
        public MedicamentoPorPedido Post(MedicamentoPorPedido medicamento_por_pedido)
        {
            return databaseAccess.addMedicamento_por_pedido(medicamento_por_pedido);
        }

        [Route("api/MedicamentosPorPedido/{NoFactura}/{CodigoMedicamento}")]
        public void Delete(string NoFactura, string CodigoMedicamento)
        {
            databaseAccess.Delete_Medicamento_por_pedido( NoFactura, CodigoMedicamento);
        }
    }
}
