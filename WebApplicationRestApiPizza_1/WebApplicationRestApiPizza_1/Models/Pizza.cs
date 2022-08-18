using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRestApiPizza_1.Models
{
    public class Pizza
    {
        public Object _id { get; set; }

        public string NroPizz { get; set; }

        public string DesignPizz { get; set; }

        public string TarifPizz { get; set; }
    }
}