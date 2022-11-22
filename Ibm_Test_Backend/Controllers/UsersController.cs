using Ibm_Test_Backend.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace Ibm_Test_Backend.Controllers
{
    [RoutePrefix("api/ibmtest")]

    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("users")]
        public Object getClientes()
        {
            var url = "https://jsonplaceholder.typicode.com/users";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";


            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        //En caso de no obtener respuesta devolvemos false
                        if (strReader == null) return new
                        {
                            success = false,
                            message = "Error obteniendo informaciòn desde cliente",
                            result = ""
                        };

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            //Leemos la respuesta y la convertimos en json válido para retornar
                            string responseBody = objReader.ReadToEnd();
                            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);

                            //Retornamos la info de correcta
                            return new
                            {
                                success = true,
                                message = "Información obtenida de forma correcta ",
                                result = users
                            };
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //En caso de error, retornamos false
                return new
                {
                    success = false,
                    message = ex.Message,
                    result = ""
                };
            }
        }
    }
}
