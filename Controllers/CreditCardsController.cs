using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using APITest.Helper;
namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly APITestContext  _context;  
                
        public CreditCardsController(APITestContext context)         
        {             
            _context = context; 
        }
        [HttpGet("{password}")]
        public ActionResult<List<CreditCardObject>> Get(string password)
        {
            //SHOULD NOT BE AVAILABLE: VERY INSECURE...
            //PASSWORD SECURE123
            Console.Write("PASSWORD IS SECURE123");
            List<CreditCardObject> emptyList = new List<CreditCardObject>();
            if(password=="SECURE123") return _context.CreditCards.ToList();
            return emptyList;
        }

        [HttpGet("{id}/{password}")]
        public ActionResult<List<CreditCardObject>> Get(string id, string password)
        {

            List<CreditCardObject> cards = new List<CreditCardObject>();
            List<CreditCardObject> emptyList = new List<CreditCardObject>();
            Crypto crypto = new Crypto();
            string passwdHash = "";
            //RAW QUERY -> SQL INJECTION 
            using(SqlConnection conn = new SqlConnection()) 
            {
                conn.ConnectionString = "Server=172.19.0.2,1433;User Id=sa;Password=SuperSecure123;Database=APITestDb";
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM CreditCards WHERE Id = " + id + ";", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CreditCardObject tmp_card = new CreditCardObject();
                        tmp_card.CreditCardNumber = reader["CreditCardNumber"] as string;
                        tmp_card.SecurityNumber =  reader["SecurityNumber"] as string;
                        tmp_card.UserId = (long) reader["UserId"];
                        tmp_card.Id = (long) reader["Id"];
                        cards.Add(tmp_card);
                    }
                }
            }
            using(SqlConnection conn = new SqlConnection()) 
            {
                conn.ConnectionString = "Server=172.19.0.2,1433;User Id=sa;Password=SuperSecure123;Database=APITestDb";
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = " + cards[0].UserId + ";", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passwdHash = reader["Password"] as string;
                    }
                }
            }
            Console.Write(password + "\n");
            Console.Write(passwdHash + "\n");
            Console.Write(crypto.MD5(password).ToLower() + "\n");
            if(crypto.MD5(password).ToLower() == passwdHash) return cards;
            else return emptyList;
        }

        // POST api/creditcards
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/creditcards/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/creditcards/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
