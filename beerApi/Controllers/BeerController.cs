using beerApi.Integration.Authentication;
using beerApi.Integration.Dto;
using beerApi.Integration.Dto.Beer;
using beerApi.Models.Beer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace beerApi.Controllers
{
    [RoutePrefix("beerApi")]
    [Authorize]
    [IdentityBasicAuthenticationAttribute]
    public class BeerController : ApiController
    {
        [HttpPost]
        [Route("list")]
        public IHttpActionResult BeerList()
        {

            using (var db = new BeerEntities())
            {
                var beerList = db.BeerHeader.ToList();

                var cerveza = new List<BeerList>();

                foreach (var item in beerList)
                {
                    var tempBeer = new BeerList();
                    tempBeer.IdBeer = item.IdBeer;
                    tempBeer.Brand = item.Brand;
                    tempBeer.CountryDescription = db.Catalog.Where(x => x.IdCatalog == item.IdCountry && x.List == "Country")
                                                    .FirstOrDefault().Description;
                    tempBeer.BeerType = new List<BeerVarietyList>();
                    foreach (var beerType in item.BeerVariety)
                    {
                        tempBeer.BeerType.Add(new BeerVarietyList
                        {
                            BeerDetailName = beerType.Description,
                            IdBeerVariety = beerType.IdBeerVariety,
                            TypeDescription = db.Catalog.Where(x => x.IdCatalog == beerType.IdType && x.List == "BeerType")
                                                    .FirstOrDefault().Description
                        });
                    }

                    cerveza.Add(tempBeer);
                }
                return Ok(cerveza);
            }
        }


        [HttpPost]
        [Route("detail")]
        public IHttpActionResult BeerDetail([FromBody] BeerVarietyList request)
        {
            try
            {
                using (var db = new BeerEntities())
                {
                    if (request == null)
                    {
                        return base.BadRequest(Integration.Dto.ResponseMessage.Error);
                    }
                    var beerTypeDetail = new BeerVarietyDetail();

                    if (request.IdBeerVariety > 0)
                    {
                        var beerDetail = db.BeerVariety.Where(x => x.IdBeerVariety == request.IdBeerVariety).ToList();
                        foreach (var item in beerDetail)
                        {
                            beerTypeDetail.TypeDescription = db.Catalog.Where(x => x.IdCatalog == item.IdType && x.List == "BeerType")
                                                    .FirstOrDefault().Description;
                            beerTypeDetail.PerAlcohol = item.PerAcohol;
                            beerTypeDetail.BeerDetailName = item.Description;
                            beerTypeDetail.CodResponse = (int)ResponseCode.Succesful;
                            beerTypeDetail.Message = Integration.Dto.ResponseMessage.Succesful;
                        }

                        return Ok(beerTypeDetail);
                    }

                    return base.BadRequest(Integration.Dto.ResponseMessage.Error);
                }
            }
            catch (Exception ex)
            {
                return base.BadRequest(Integration.Dto.ResponseMessage.Error);
            }
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult BeerRegister([FromBody] BeerRegister request)
        {

            try
            {
                using (var db = new BeerEntities())
                {

                    if (request == null)
                    {
                        return base.BadRequest(Integration.Dto.ResponseMessage.Error);
                    }

                    if (string.IsNullOrEmpty(request.Username))
                    {
                        return base.BadRequest(Integration.Dto.ResponseMessage.UserSpecify);
                    }

                    var user = db.Users.Where(x => x.Username == request.Username).FirstOrDefault();
                    if (user == null)
                    {
                        return base.BadRequest(Integration.Dto.ResponseMessage.UserNotExist);
                    }

                    if (request.IdBeerVariety <= 0)
                    {
                        return base.BadRequest(Integration.Dto.ResponseMessage.BeerType);
                    }
                    var beerInfo = new BeerConsume();

                    beerInfo.DateConsume = DateTime.Now;
                    beerInfo.IdBeerVariety = request.IdBeerVariety;
                    beerInfo.IdUser = user.IdUser;

                    db.BeerConsume.Add(beerInfo);
                    db.SaveChanges();
                }

                return Ok(new { CodResponse = 0,
                                Message = Integration.Dto.ResponseMessage.Thanks });
            }
            catch (Exception ex)
            {
                return base.BadRequest(Integration.Dto.ResponseMessage.Error);
            }
        }

    }
}
