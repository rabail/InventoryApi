using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var inv = new InputHelper().GetInputAsString();

            var map = new Mapper(inv.Result);
            var mapper = map.GetMapper();
            var outGen = new OutputGenerator(mapper, inv.Result);
            return Ok(JsonConvert.SerializeObject(outGen.GetOutput()));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
