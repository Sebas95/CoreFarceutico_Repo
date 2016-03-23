using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;


namespace WebServiceFarmacia
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class Service : System.Web.Services.WebService
    {
        public DataBaseAccess dbAcces = new DataBaseAccess();
        public Service()
        {
        }
       /* [WebMethod]
        public void GetAllEmployees()
        {
            List<Employee> listEmployees = dbAcces.getEmployees();
            string json = JsonConvert.SerializeObject(listEmployees);
            Context.Response.Write(json);
        }*/

        [WebMethod]
        public void authenticateUser(string userName , string password)
        {
            User user = dbAcces.getUserAuthentication(userName,password);
            string json = JsonConvert.SerializeObject(user);
            Context.Response.Write(json);
        }
        [WebMethod]
        public void getClients()
        {
            string json = JsonConvert.SerializeObject(dbAcces.getClients());
            Context.Response.Write(json);
        }

    }
}