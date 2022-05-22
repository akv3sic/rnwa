using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServis1
{
    public partial class WebFormKlijentApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConvertClick(object sender, EventArgs e)
        {
            KlijentAplikacija.WebService1SoapClient klijent = new KlijentAplikacija.WebService1SoapClient("WebService1Soap");
            float val = float.Parse(inputField.Text);
            String con = dropdownList.SelectedValue.ToString(); 
            float response= klijent.Convert(val , con);
            ResultLabel.Text = response.ToString();

        }
        protected void inputField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}