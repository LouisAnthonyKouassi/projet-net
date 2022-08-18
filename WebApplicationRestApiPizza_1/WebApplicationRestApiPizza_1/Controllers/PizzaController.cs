using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using WebApplicationRestApiPizza_1.Models;

namespace WebApplicationRestApiPizza_1.Controllers
{
    public class PizzaController : ApiController
    {

        Models.PizzaDB pizzasDB = new Models.PizzaDB();

        // GET: api/Pizza
        [HttpGet]
        [Route("api/pizzas")]
        public IEnumerable<Pizza> GetallPizza()
        {
            return   pizzasDB.ListAll() ;
        }

        // GET: api/Pizza
        [HttpGet]
        [Route("api/pizzas/json")]
 
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string GetallPizzajson()
        {
          // return json(pizzasDB.ListAll());
             return new JavaScriptSerializer().Serialize(pizzasDB.ListAll());
        }

        // GET: api/Pizza/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pizza
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pizza/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pizza/5
        public void Delete(int id)
        {
        }
    }
}
