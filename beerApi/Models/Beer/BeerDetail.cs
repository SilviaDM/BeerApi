using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Models.Beer
{
    public class BeerDetail
    {
        public int IdBeerType { get; set; }
        public int IdBeer { get; set; }
        public string Description { get; set; }
        public decimal PerAlcohol { get; set; }
        public int IdType { get; set; }        
    }
}