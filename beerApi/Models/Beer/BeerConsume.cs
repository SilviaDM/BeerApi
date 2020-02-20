using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Models.Beer
{
    public class BeerConsume
    {
        public int IdBeerConsume { get; set; }
        public int IdUser { get; set; }
        public int IdBeerType { get; set; }
        public DateTime DateConsume { get; set; }
    }
}