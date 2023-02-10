using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.MSModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SQLDbContext _context;
        public SupplierController(IConfiguration config, SQLDbContext context)
        {
            _config = config;
            _context = context;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Sirinfs.ToListAsync();
            return Created("", list);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
