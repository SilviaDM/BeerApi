using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Integration.Dto
{
    public class ErrorResult
    {
        public int CodResponse { get; set; }
        public string Message { get; set; }
    }
}