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
    public class GeneralController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SQLDbContext _context;
        public GeneralController(IConfiguration config, SQLDbContext context)
        {
            _config = config;
            _context = context;


        }
        // GET: api/<GeneralController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _context.VatEntites.ToListAsync();
            return Created("", list);
            //type = type == null ? "" : type;
            //if (type.ToUpper() == "ITEIMINFO")
            //{
            //    var list = await _context.Iteminfs.ToListAsync();
            //    return Created("", list);
            //}
            //else
            //{
            //    var list = await _context.VatEntites.ToListAsync();
            //    return Created("", list);
            //}
        }

        // GET api/<GeneralController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GeneralController>
        [HttpPost]
        public void Post([FromBody] VatEntite model)
        {
            var s = _context.VatEntites.First<VatEntite>();
        }

        // PUT api/<GeneralController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GeneralController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
