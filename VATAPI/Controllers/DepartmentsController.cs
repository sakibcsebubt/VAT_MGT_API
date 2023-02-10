using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.PgModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        public readonly VAT_MGT_DBContext _context;
        public DepartmentsController(VAT_MGT_DBContext context)
        {
            _context = context;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _context.Departments.ToListAsync();

            return Created("",list) ;
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
