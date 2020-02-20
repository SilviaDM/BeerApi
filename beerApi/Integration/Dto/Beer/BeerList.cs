using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Integration.Dto.Beer
{
    public class BeerList
    {        
        public int IdBeer { get; set; }
        public string Brand { get; set;}        
        public string CountryDescription { get; set; }
        public List<BeerVarietyList> BeerType { get; set; }
}

    public class BeerVarietyList: ErrorResult
    {       
        public int IdBeerVariety { get; set; }
        public string BeerDetailName { get; set; }        
        public string TypeDescription { get; set; }
    }

    public class BeerVarietyDetail : ErrorResult
    {        
        public string BeerDetailName { get; set; }
        public decimal PerAlcohol { get; set; }        
        public string TypeDescription { get; set; }
    }
}