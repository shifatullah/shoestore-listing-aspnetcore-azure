﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shoestore_listing_aspnetcore.Indexes;
using shoestore_listing_aspnetcore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoestore_listing_aspnetcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;
        private readonly ISearchService _searchService;

        public ListingController(ILogger<ListingController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get(string query)
        {
            var products = await _searchService.SearchAsync(query);
            return products;
        }
    }
}
