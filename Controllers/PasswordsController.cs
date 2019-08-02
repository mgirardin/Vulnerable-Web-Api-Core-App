using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        // GET api/passwords
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "admin123", "secure-password" };
        }

        // GET api/passwords/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //MD5 Hash
            return "password";
        }

        // POST api/passwords
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/passwords/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/passwords/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
