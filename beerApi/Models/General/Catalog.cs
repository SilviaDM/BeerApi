using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Models.General
{
    public class Catalog
    {
        public int IdCatalog { get; set; }
        public string List { get; set; }
        public string Description { get; set; }
        public int IdState { get; set; }
    }
}