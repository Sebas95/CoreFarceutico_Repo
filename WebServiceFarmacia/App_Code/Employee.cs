using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
namespace WebServiceFarmacia 
{
    public class Employee
    {
        public int id;
        public int getId() { return id; }
        public void setId(int id2) { id = id2; }
        public string name;
        public string gender;
        public int salary;
    }
}