using Microsoft.AspNetCore.Mvc;
using pokenae_WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pokenae_WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return id;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody]C_Account_Switch id)
        {
            return id.ID + " posted";
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public string Post()
        //{
        //    return "posted";
        //}

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
