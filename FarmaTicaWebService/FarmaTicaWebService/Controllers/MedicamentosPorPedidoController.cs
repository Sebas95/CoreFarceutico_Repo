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

        public List<Medicamento_por_pedido> Get()
        {
            return databaseAccess.getMedicamentosPorPedido();
        }
        public List<Medicamento_por_pedido> Get(string id)
        {
            return databaseAccess.getMedicamentosPorPedido(id);
        }
        public Medicamento_por_pedido Post(Medicamento_por_pedido medicamento_por_pedido)
        {
            return databaseAccess.addMedicamento_por_pedido(medicamento_por_pedido);
        }
     
        public void Delete(Medicamento_por_pedido medicamento_por_pedido)
        {
            databaseAccess.Delete_Medicamento_por_pedido(medicamento_por_pedido);
        }
    }
}
