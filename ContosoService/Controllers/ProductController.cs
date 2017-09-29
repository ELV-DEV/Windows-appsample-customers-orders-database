﻿using ContosoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoService.Controllers
{
    /// <summary>
    /// Contains methods for interacting with product data.
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all products in the database.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.GetProductsAsync(); 
        }

        /// <summary>
        /// Gets the product with the given id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<Product> Get(Guid id)
        {
            return await _repository.GetProductAsync(id); 
        }


        /// <summary>
        /// Gets all products with a data field matching the start of the given string.
        /// </summary>
        [HttpGet("search")]
        public async Task<IEnumerable<Product>> Search(string value)
        {
            return await _repository.SearchProductsAsync(value); 
        }
    }
}
