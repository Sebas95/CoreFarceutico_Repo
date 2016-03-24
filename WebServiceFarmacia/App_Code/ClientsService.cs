using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Net;




[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ClientsService : System.Web.Services.WebService
{

    public ClientsService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public ClientesAccess clientsAccess = new ClientesAccess();

    [WebMethod]
    public void getClients()
    {
        string json = JsonConvert.SerializeObject(clientsAccess.getClients());
        Context.Response.Write(json);
    }
    [WebMethod]
    public void addClient(Cliente client)
    {
        //INSERT INTO CLIENTE(IdCliente, Cedula, Nombre, Apellido, Prioridad, FechaNacimiento, Residencia)
        //VALUES('id', 'ced', 'nomb', 'apellido', 'A', 'date', 'residencia')
       

    }
   

}
