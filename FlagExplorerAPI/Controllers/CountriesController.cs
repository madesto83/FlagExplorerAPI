using FlagExplorerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace FlagExplorerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public CountriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");

            var countries = JsonConvert.DeserializeObject<List<Country>>(response);

            return Ok(countries);
        }

        [HttpGet("GetCountryDetails/{countryname}")]
        public async Task<IActionResult> GetCountryDetails(string countryname)
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/name/" + countryname);

            var country = JsonConvert.DeserializeObject<List<CountryInfo>>(response);

            return Ok(country);
        }
    }
}
