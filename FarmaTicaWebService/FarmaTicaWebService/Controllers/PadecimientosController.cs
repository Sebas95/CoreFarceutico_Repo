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
    public class PadecimientosController : ApiController

    {
        /// <summary>
        ///  Object that has acces to the Padecimiento table
        /// </summary>
        public ClientsAccess DataBaseAccess = new ClientsAccess();

        /// <summary>
        /// Gets Padecimiento objects that belongs to an specific client identified by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> List<Padecimiento> </returns>
        public List<Padecimiento> getPadecimientos(int id)
        {
            return DataBaseAccess.getPadecimientos(id);
        }
        /// <summary>
        /// Add a padecimiento to a specifi client
        /// </summary>
        /// <param name="padecimiento"></param>
        /// <returns> the new Padecimiento posted </returns>
        public Padecimiento Post(Padecimiento padecimiento)
        {
            return DataBaseAccess.addPadecimiento(padecimiento);
        }
    }
}
