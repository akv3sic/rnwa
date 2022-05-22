using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebService2
{
    public partial class WebFormKlijentApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Find_Click(object sender, EventArgs e)
        {
            KlijentAplikacija.WebService1SoapClient klijent = new KlijentAplikacija.WebService1SoapClient("WebService1Soap");
            int id = int.Parse(inputField.Text);
            DataTable response = klijent.getEmployeesById(id.ToString());
            ResultLabel.Text ="Ime :" + response.Rows[0]["first_name"].ToString() + "   Prezime:" + response.Rows[0]["last_name"];
        }

        protected void inputField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}