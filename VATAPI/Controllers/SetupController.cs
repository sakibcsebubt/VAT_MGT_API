using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using VATAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VATAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SetupController(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this._config = config;
            this._webHostEnvironment = webHostEnvironment;
        }


        // GET: api/<SetupController>
        [HttpGet]
        public IActionResult Get()
        {
            string query = @" select * from ACINF ";

            try
            {
                DataTable dataTable = new DataTable();
                string sqlDataSource = _config.GetConnectionString("VATPGDBConnection");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        dataTable.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }


                return Created("", dataTable);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET api/<SetupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SetupController>
        [HttpPost]
        public IActionResult Post(ACTINFO model)
        {

            string query = @"
                            insert into acinf(comcod,actcode,actdesc,actelev,acttype,acttdesc,actginf)
                            values(@comcod,@actcode, @actdesc, @actelev, @acttype, @acttdesc, @actginf)
                            ";

            try
            {
                DataTable dataTable = new DataTable();
                string sqlDataSource = _config.GetConnectionString("VATPGDBConnection");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {

                        myCommand.Parameters.AddWithValue("@comcod", model.COMCOD);
                        myCommand.Parameters.AddWithValue("@actcode", model.ACTCODE);
                        myCommand.Parameters.AddWithValue("@actdesc", model.ACTDESC);
                        myCommand.Parameters.AddWithValue("@actelev", model.ACTELEV);
                        myCommand.Parameters.AddWithValue("@acttype", model.ACTTYPE);
                        myCommand.Parameters.AddWithValue("@acttdesc", model.ACTTDESC);
                        myCommand.Parameters.AddWithValue("@actginf", "");

                        myReader = myCommand.ExecuteReader();
                        dataTable.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
                return Created("", "Added Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        // PUT api/<SetupController>/5
        [HttpPut]
        public IActionResult Put(ACTINFO model)
        {

            string query = @"
                            update acinf
                            set actdesc = @actdesc,
                                comcod = @comcod,
                                actelev = @actelev,
                                acttype = @acttype,
                                acttdesc = @acttdesc
                            where actcode = @actcode
                            ";

            try
            {
                DataTable dataTable = new DataTable();
                string sqlDataSource = _config.GetConnectionString("VATPGDBConnection");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@comcod", model.COMCOD);
                        myCommand.Parameters.AddWithValue("@actdesc", model.ACTDESC);
                        myCommand.Parameters.AddWithValue("@actelev", model.ACTELEV);
                        myCommand.Parameters.AddWithValue("@acttype", model.ACTTYPE);
                        myCommand.Parameters.AddWithValue("@acttdesc", model.ACTTDESC);
                        myCommand.Parameters.AddWithValue("@actcode", model.ACTCODE);

                        myReader = myCommand.ExecuteReader();
                        dataTable.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

                return Created("", "Updated Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SetupController>/5
        [HttpDelete("{actcode}")]
        public IActionResult Delete(string actcode)
        {
            string query = @"
                            delete from  acinf
                            where actcode=@actcode
                            ";

            try
            {
                DataTable dataTable = new DataTable();
                string sqlDataSource = _config.GetConnectionString("VATPGDBConnection");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@actcode", actcode);

                        myReader = myCommand.ExecuteReader();
                        dataTable.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }

                return Created("", "Delete Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
