using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DataBaseAccess
{
    public DataBaseAccess()
    {
    }

    public User getUserAuthentication(string userName, string password)    
    {
        User user = new User();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(
                "use SampleDB; Select Salary from tblEmployees where Name ='" + userName + "' and Id = '" + password + "';", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                user.username = userName;
                user.password = password;
                user.type = (Convert.ToInt32(rdr["Salary"]));
            }
        }
        return user;

    }
    public List<Employee> getEmployees()
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
        return listEmployees;
    }


}