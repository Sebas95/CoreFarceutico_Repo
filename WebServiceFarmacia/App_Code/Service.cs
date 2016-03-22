using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebServiceFarmacia;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public void GetAllEmployees()
    {
        List<Employee> listEmployees = new List<Employee>();

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblEmployees", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employee employee = new Employee();
                employee.id = Convert.ToInt32(rdr["Id"]);
                employee.name = rdr["Name"].ToString();
                employee.gender = rdr["Gender"].ToString();
                employee.salary = Convert.ToInt32(rdr["Salary"]);
                listEmployees.Add(employee);
            }
        }
        string json = JsonConvert.SerializeObject(listEmployees);
        Context.Response.Write(json);
    }

}