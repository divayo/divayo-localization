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
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Search()
        {
            throw new NotImplementedException();
        }
    }
}