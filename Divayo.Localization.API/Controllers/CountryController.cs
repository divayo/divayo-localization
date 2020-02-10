using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divayo.Localization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divayo.Localization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public CountryController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get()
        {
            var result = await _searchService.GetAllCountriesAsync();

            return Ok(result);
        }
    }
}