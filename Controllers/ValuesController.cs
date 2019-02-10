using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace flights_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class FlightsController : ControllerBase
    {
        // GET api/flights
        [HttpGet]
        public ActionResult<IEnumerable<Flight>> Get()
        {
            return Program.Flights;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(string id)
        {
            return Program.Flights.SingleOrDefault(f => f.FlightNumber == id);
        }

        // POST api/flights
        [HttpPost]
        public void Post(Flight flight)
        {
            var flights = Program.Flights;
            if(!flights.Any(f => f.FlightNumber == flight.FlightNumber)){
                flights.Add(flight);
            };
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public void Put(string id, Flight updateFlight)
        {
            var flight = Program.Flights.SingleOrDefault(f => f.FlightNumber == id);
            if(flight != null){
                flight.FlightNumber = updateFlight.FlightNumber;
                flight.From = updateFlight.From;
                flight.To = updateFlight.To;
            }
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Program.Flights.RemoveAll(f => f.FlightNumber == id);
        }
    }
}
