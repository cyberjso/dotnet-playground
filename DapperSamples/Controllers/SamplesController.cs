using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DapperSamples.Persistence;
using DapperSamples.Models;

namespace DapperSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        private MySampleDao dao =  new MySampleDao();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<Sample> Get(int id)
        {
            MySampleEntity entity = dao.FindById(id);

            return new Sample {Id = entity.Id, Name =  entity.Name, Description = entity.Description};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
