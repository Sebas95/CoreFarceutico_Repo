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

    /** This class provides a Web Api for The table doctores
    */
    public class DoctoresController : ApiController
    {
      
        /// <summary>
        /// This member is the one who gives the access to the database
        /// </summary>
        private DoctorsAccess databaseAccess = new DoctorsAccess();

        /// <summary>
        /// gets the list of all the doctors 
        /// </summary>
        /// <returns> List<Doctor> </returns>
        public List<Doctor> Get()
        {
            return databaseAccess.getAllDoctors();
        }
        /// <summary>
        /// Insert a new doctor in the database 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns> returns the new doctor</returns>
        public Doctor Post(Doctor doctor)
        {
            return databaseAccess.addDoctor(doctor);
        }
        /// <summary>
        /// Updates a doctor in the table Doctors
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public Doctor Put(int id, [FromBody]Doctor doctor)
        {
            return databaseAccess.updateDoctor(id, doctor);
        }
        /// <summary>
        /// Deletes a doctor identified by its id
        /// </summary>
        /// <param name="id"> the id of the doctor </param>
        public void Delete(int id)
        {
            databaseAccess.deleteDoctor(id);
        }
    }
}
