
using System.Web.Services;
using Newtonsoft.Json;

/// <summary>
/// Summary description for ClientsService
/// </summary>
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
    public DataBaseAccess dbAcces = new DataBaseAccess();

    [WebMethod]
    public void getClients()
    {
        string json = JsonConvert.SerializeObject(dbAcces.getClients());
        Context.Response.Write(json);
    }

}
