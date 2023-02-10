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
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SQLDbContext _context;
        public ItemsController(IConfiguration config, SQLDbContext context)
        {
            _config = config;
            _context = context;
        }
        // GET: api/<Items>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.Iteminfs.ToListAsync();
            return Created("", list);
        }

        // GET api/<Items>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var list = await _context.Iteminfs.ToListAsync();
            return Created("", list);
        }

        // POST api/<Items>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Items>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Items>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
