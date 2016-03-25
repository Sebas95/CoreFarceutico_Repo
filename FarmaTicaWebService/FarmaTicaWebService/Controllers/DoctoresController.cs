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
    public class DoctoresController : ApiController
    {
        public DoctorsAccess databaseAccess = new DoctorsAccess();

        public List<Doctor> Get()
        {
            return databaseAccess.getAllDoctors();
        }
        public Doctor Post(Doctor doctor)
        {
            return databaseAccess.addDoctor(doctor);
        }
        public Doctor Put(int id, [FromBody]Doctor doctor)
        {
            return databaseAccess.updateDoctor(id, doctor);
        }
        public void Delete(int id)
        {
            databaseAccess.deleteDoctor(id);
        }
    }
}
