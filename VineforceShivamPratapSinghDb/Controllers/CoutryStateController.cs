using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineforceShivamPratapSinghDb.Dto;
using VineforceShivamPratapSinghDb.Services;

namespace VineforceShivamPratapSinghDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoutryStateController : ControllerBase
    {
        private readonly ICountryServices _countryServices;

        public CoutryStateController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }


        /// <summary>
        /// GetCountryList
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCountryList")]
        public List<CountryDto> GetCountryList()
        {
            return _countryServices.GetCountryList().ToList();
        }




        /// <summary>
        /// PostCountryData
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostCountryData")]
        public bool PostCountryData(CountryDto country)
        {
           return _countryServices.PostCountryData(country);
        }

        /// <summary>
        /// DeleteCountryData
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{countryId}")]
        public bool DeleteCountryData(int countryId)
        {
            return _countryServices.DeleteCountryData(countryId);
        }

    }
}
