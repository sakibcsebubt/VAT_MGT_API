using VATAPI.Model.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VATAPI.Model;
using VATAPI.MSModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GoodSetupController : ControllerBase
    {
        private static vmConfigSetup1 vmCfg1 = new vmConfigSetup1();
        private readonly IConfiguration _config;
        private readonly SQLDbContext _context;
        public GoodSetupController(IConfiguration config, SQLDbContext context)
        {
            _config = config;
            _context = context;
            VatServices services = new VatServices(_config);
        }
        // GET: api/<GoodSetupController>
        [HttpGet]
        public IActionResult Get()
        {

            var list = _context.Iteminfs.ToList();

            return Created("", list);
        }

        // GET api/<GoodSetupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GoodSetupController>
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Post(Iteminf inf)
        {
            List<Iteminf> itmInfoList = new List<Iteminf>();

            itmInfoList.Add(new Iteminf()
            {
                ItemName = inf.ItemName,
                Exempted = inf.Exempted,
                UnitId = inf.UnitId,
                Hscode = inf.Hscode,
                Skucode = inf.Skucode,
                Reduced = inf.Reduced,
                Prtype = inf.Prtype,
                Rebatable = inf.Rebatable,
                Expdatereq = inf.Expdatereq,
                Fixedvat = inf.Fixedvat,
                Iaabu = inf.Iaabu,
                Iahcs = inf.Iahcs,
                Iapd = inf.Iapd,
                Itemid = inf.Itemid,
                Mrp = inf.Mrp,
                Vds = inf.Vds,
                Zerorate = inf.Zerorate
            });

            string infList = ListToXml.ToXml<List<Iteminf>>(itmInfoList, "ds");

            var pap1 = vmCfg1.SetParamUpdateItemInf("1001", infList, inf.Itemid.ToString());
            try
            {
                DataSet ds1 = ApiProcessAccess.GetHmsDataSet(pap1);
                var msg = ds1.Tables[0].Rows[0]["Msg"].ToString().Trim();

                if (ds1 != null)
                {
                    return Created("", msg);
                }
                else
                {
                    return BadRequest(msg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

                throw;
            }
        }

        // PUT api/<GoodSetupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoodSetupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
