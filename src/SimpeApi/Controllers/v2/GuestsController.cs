using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApi.Controllers.v2
{
    [Route("api/v2/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private static List<GuestModelV1> guests = new()
        {
            new GuestModelV1 { Id = 1, FirstName = "Doniyor", LastName = "Niyozov" },
            new GuestModelV1 { Id = 2, FirstName = "Abbos", LastName = "Siddiqov" },
            new GuestModelV1 { Id = 3, FirstName = "Bohir", LastName = "Ahmedov" }
        };

        // GET: api/<GuestsController>
        [HttpGet]
        public IEnumerable<GuestModelV1> Get()
        {
            return guests;
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public GuestModelV1 Get(int id)
        {
            return guests.Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<GuestsController>
        [HttpPost]
        public void Post([FromBody] GuestModelV1 value)
        {
            guests.Add(value);
        }

        // PUT api/<GuestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModelV1 value)
        {
            guests.Remove(guests.Where(g => g.Id == id).FirstOrDefault());
            guests.Add(value);
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            guests.Remove(guests.Where(g => g.Id == id).FirstOrDefault());
        }
    }
}
