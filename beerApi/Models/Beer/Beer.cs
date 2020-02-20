using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Models.Beer
{
    public class Beer
    {
        public int IdBeer { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int IdCountry { get; set; }
        public int IdState { get; set; }
    }
}