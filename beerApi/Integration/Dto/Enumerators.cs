using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerApi.Integration.Dto
{
    public struct ResponseMessage
    {
        public const string Succesful = "Succesful";
        public const string Error = "Something wrong happened";
        public const string NotExist = "Data not exists";
        public const string UserNotExist = "User doesn't exists";
        public const string BeerType = "Specify beer type";
        public const string UserSpecify = "Specify user";
        public const string Thanks = "Thanks for drink beer!!!";
    }
    public enum ResponseCode
    {
        Succesful = 0,
        Error= 1,
        NotExist=2
    }

    public enum enumGeneralStatus
    {
        Active = 1,
        Inactive = 2        
    }
}