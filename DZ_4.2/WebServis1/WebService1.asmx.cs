using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServis1
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

        [WebMethod]
        public float Convert(float val, String con)
        {
            if (con == "bameur")
            {
                return (float)(val * 0.51);
            }
            if (con == "bamchf")
            {
                return (float)(val * 0.53);
            }
            if (con == "eurbam")
            {
                return (float)(val * 1.95);
            }
            if (con == "eurchf")
            {
                return (float)(val * 1.03);
            }
            if (con == "chfeur")
            {
                return (float)(val * 0.97);
            }
            if (con == "chfbam")
            {
                return (float)(val * 1.90);
            }



            return -1;


        }
    }
}
