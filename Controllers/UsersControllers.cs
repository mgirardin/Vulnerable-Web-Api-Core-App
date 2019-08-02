using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net.Http;
using Microsoft.AspNetCore.Server
.Kestrel.Core;
using APITest.Helper;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly APITestContext  _context;          
        public UsersController(APITestContext context)         
        {             
            _context = context; 
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "admin", "matheus" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<UserObject> Get(long id)
        {
            //IDOR Vulnerability 
            UserObject item = _context.Users.Find(id); 
            return item;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] UserObject value)
        {
            Crypto crypto = new Crypto();
            using(SqlConnection conn = new SqlConnection()) 
            {
                conn.ConnectionString = "Server=172.19.0.2,1433;User Id=sa;Password=SuperSecure123;Database=APITestDb";
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Name, CPF, Salary, Password) VALUES (" + 
                value.Name + ", " + value.CPF + ", " + value.Salary + ", " + crypto.MD5(value.Password) + ");", conn);
                command.ExecuteNonQuery();
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
