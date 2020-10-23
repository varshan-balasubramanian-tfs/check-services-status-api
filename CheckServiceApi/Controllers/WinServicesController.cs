using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckServiceApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckServiceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WinServicesController : ControllerBase
    {
        private IWinServiceClass _IWinServiceClass;

        public WinServicesController(IWinServiceClass InterfaceWinServiceClass)
        {
            _IWinServiceClass = InterfaceWinServiceClass;   
        }
        // GET: api/<WinServicesController>
        [HttpGet]
        public JsonResult Get()
        {   
            return new JsonResult(_IWinServiceClass.GetCamstarServices().ToList());
        }

        // GET api/<WinServicesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WinServicesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WinServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WinServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
