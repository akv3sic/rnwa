using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySqlConnector;

namespace WebService2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public static DataTable SendQuerry(string querry)
        {
            string connString = "SERVER=localhost" + ";" +
                "DATABASE=employees;" +
                "UID=root;" +
                "PASSWORD=;";

            MySqlConnection cnMySQL = new MySqlConnection(connString);
            MySqlCommand cmdMySQL = cnMySQL.CreateCommand();
            MySqlDataReader reader;

            cmdMySQL.CommandText = querry;
            cnMySQL.Open();
            reader = cmdMySQL.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cnMySQL.Close();

            return dt;

        }



        [WebMethod]
        public DataTable getEmployeesById(String emp_no)
        {
            string querry = "select first_name, last_name, gender, birth_date, hire_date from employees where emp_no =" + emp_no;
            return SendQuerry(querry);
        }
    }
}
